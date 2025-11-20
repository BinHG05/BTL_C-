using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpenseManager.App.Services.Interfaces;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Services;
using DbColor = ExpenseManager.App.Models.Entities.Color;
using DbIcon = ExpenseManager.App.Models.Entities.Icon;
using WinColor = System.Drawing.Color;
using System.Diagnostics;

namespace ExpenseManager.App.Presenters
{
    public class BudgetViewDateRangeEventArgs : EventArgs
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public interface IBudgetView
    {
        string CurrentUserId { get; set; }
        event EventHandler ViewLoaded;
        event EventHandler<int> BudgetSelected;
        event EventHandler AddBudgetClicked;
        event EventHandler EditBudgetClicked;
        event EventHandler DeleteBudgetClicked;
        event EventHandler<BudgetViewDateRangeEventArgs> ChartDateRangeChanged;
        event EventHandler<string> ChartTypeChanged;

        void DisplayBudgetList(IEnumerable<BudgetSummaryDto> budgets);
        void DisplayBudgetDetail(BudgetDetailDto detail);
        void DisplayExpenseChart(IEnumerable<ExpenseBreakdownDto> breakdown);
        void ShowMessage(string message, string title, MessageBoxIcon icon);
        void ShowLoading(bool isLoading);
        void ClearBudgetDetail();
    }

    public class BudgetPresenter
    {
        private readonly IBudgetView _view;
        private readonly IBudgetService _budgetService;
        private readonly ICategoryService _categoryService;

        private int _selectedBudgetId;
        private List<BudgetSummaryDto> _currentBudgets;
        private List<Category> _allCategories;
        private List<DbIcon> _allIcons;
        private List<DbColor> _allColors;

        public BudgetPresenter(
            IBudgetView view,
            IBudgetService budgetService,
            ICategoryService categoryService)
        {
            _view = view;
            _budgetService = budgetService;
            _categoryService = categoryService;

            _view.ViewLoaded += OnViewLoaded;
            _view.BudgetSelected += OnBudgetSelected;
            _view.DeleteBudgetClicked += OnDeleteBudgetClicked;
            _view.ChartDateRangeChanged += OnChartDateRangeChanged;
            _view.ChartTypeChanged += OnChartTypeChanged;
        }

        private async void OnViewLoaded(object sender, EventArgs e)
        {
            Debug.WriteLine("[BudgetPresenter] OnViewLoaded: Bắt đầu tải dữ liệu ban đầu.");
            await LoadInitialDataAsync();
        }

        private async void OnBudgetSelected(object sender, int budgetId)
        {
            Debug.WriteLine($"[BudgetPresenter] OnBudgetSelected: Người dùng chọn ngân sách ID: {budgetId}");
            _selectedBudgetId = budgetId;
            await LoadBudgetDetailAsync(budgetId);
        }

        private async void OnDeleteBudgetClicked(object sender, EventArgs e)
        {
            if (_selectedBudgetId <= 0)
            {
                Debug.WriteLine("[BudgetPresenter] OnDeleteBudgetClicked: Không có ngân sách nào được chọn để xóa.");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ngân sách này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Debug.WriteLine($"[BudgetPresenter] OnDeleteBudgetClicked: Bắt đầu xóa ngân sách ID: {_selectedBudgetId}");
                await DeleteBudgetAsync(_selectedBudgetId);
            }
        }

        private async void OnChartDateRangeChanged(object sender, BudgetViewDateRangeEventArgs e)
        {
            if (_selectedBudgetId > 0)
            {
                Debug.WriteLine($"[BudgetPresenter] OnChartDateRangeChanged: Tải biểu đồ cho ngân sách ID: {_selectedBudgetId}, từ {e.StartDate} đến {e.EndDate}");
                await LoadExpenseChartAsync(_selectedBudgetId, e.StartDate, e.EndDate);
            }
        }

        private async void OnChartTypeChanged(object sender, string chartType)
        {
            if (_selectedBudgetId > 0)
            {
                Debug.WriteLine($"[BudgetPresenter] OnChartTypeChanged: Tải lại chi tiết cho ngân sách ID: {_selectedBudgetId}");
                await LoadBudgetDetailAsync(_selectedBudgetId);
            }
        }

        private async Task LoadInitialDataAsync()
        {
            try
            {
                _view.ShowLoading(true);
                Debug.WriteLine("[BudgetPresenter] LoadInitialDataAsync: Bắt đầu tải dữ liệu ban đầu...");

                var categoriesTask = _categoryService.GetCategoriesByUserIdAsync(_view.CurrentUserId);
                var iconsTask = _categoryService.GetAllIconsAsync();
                var colorsTask = _categoryService.GetAllColorsAsync();

                await Task.WhenAll(categoriesTask, iconsTask, colorsTask);

                _allCategories = categoriesTask.Result;
                _allIcons = iconsTask.Result;
                _allColors = colorsTask.Result;

                Debug.WriteLine($"[BudgetPresenter] LoadInitialDataAsync: Tải xong Categories: {_allCategories.Count}, Icons: {_allIcons.Count}, Colors: {_allColors.Count}");

                await LoadBudgetsAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[BudgetPresenter] LoadInitialDataAsync: Lỗi: {ex.Message}");
                _view.ShowMessage(ex.Message, "Lỗi", MessageBoxIcon.Error);
            }
            finally { _view.ShowLoading(false); }
        }

        public async Task LoadBudgetsAsync()
        {
            try
            {
                Debug.WriteLine("[BudgetPresenter] LoadBudgetsAsync: Bắt đầu tải danh sách ngân sách.");

                var budgets = await _budgetService.GetUserBudgetSummariesAsync(_view.CurrentUserId);

                Debug.WriteLine($"[BudgetPresenter] LoadBudgetsAsync: Dữ liệu nhận từ service: {budgets?.Count()}");

                _currentBudgets = budgets.ToList();

                Debug.WriteLine($"[BudgetPresenter] LoadBudgetsAsync: Dữ liệu đã được gán vào _currentBudgets. Số lượng: {_currentBudgets.Count}");

                _view.DisplayBudgetList(_currentBudgets);

                if (_currentBudgets.Any())
                {
                    Debug.WriteLine($"[BudgetPresenter] LoadBudgetsAsync: Chọn ngân sách đầu tiên: {_currentBudgets.First().BudgetId}");
                    _selectedBudgetId = _currentBudgets.First().BudgetId;
                    await LoadBudgetDetailAsync(_selectedBudgetId);
                }
                else
                {
                    Debug.WriteLine("[BudgetPresenter] LoadBudgetsAsync: Không có ngân sách nào, làm sạch detail.");
                    _view.ClearBudgetDetail();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[BudgetPresenter] LoadBudgetsAsync: Lỗi: {ex.Message}");
                _view.ShowMessage(ex.Message, "Lỗi", MessageBoxIcon.Error);
            }
        }

        public async Task LoadBudgetDetailAsync(int budgetId)
        {
            Debug.WriteLine($"[BudgetPresenter] LoadBudgetDetailAsync: Bắt đầu tải chi tiết ngân sách ID: {budgetId}");

            var detail = await _budgetService.GetBudgetDetailAsync(budgetId, _view.CurrentUserId);

            if (detail != null)
            {
                Debug.WriteLine($"[BudgetPresenter] LoadBudgetDetailAsync: Nhận được chi tiết. Hiển thị lên giao diện.");
                _view.DisplayBudgetDetail(detail);

                var breakdown = await _budgetService.GetExpenseBreakdownAsync(budgetId, _view.CurrentUserId);
                Debug.WriteLine($"[BudgetPresenter] LoadBudgetDetailAsync: Nhận được phân tích chi tiêu: {breakdown?.Count()} điểm dữ liệu.");
                _view.DisplayExpenseChart(breakdown);
            }
            else
            {
                Debug.WriteLine("[BudgetPresenter] LoadBudgetDetailAsync: Không tìm thấy chi tiết ngân sách.");
                _view.ClearBudgetDetail();
            }
        }

        private async Task LoadExpenseChartAsync(int budgetId, DateTime startDate, DateTime endDate)
        {
            Debug.WriteLine($"[BudgetPresenter] LoadExpenseChartAsync: Tải biểu đồ cho ngân sách ID: {budgetId}, từ {startDate} đến {endDate}");

            var breakdown = await _budgetService.GetExpenseBreakdownAsync(budgetId, _view.CurrentUserId);
            var filtered = breakdown.Where(b => b.Date >= startDate && b.Date <= endDate);
            Debug.WriteLine($"[BudgetPresenter] LoadExpenseChartAsync: Số điểm dữ liệu sau lọc: {filtered.Count()}");

            _view.DisplayExpenseChart(filtered);
        }

        public async Task<List<Category>> GetCategoriesForNewBudgetAsync()
        {
            if (_allCategories == null)
                _allCategories = await _categoryService.GetCategoriesByUserIdAsync(_view.CurrentUserId);

            return _allCategories
                .Where(c => c.Type.Equals("Expense", StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public async Task CreateBudgetAsync(BudgetCreateDto createDto)
        {
            try
            {
                _view.ShowLoading(true);
                Debug.WriteLine("[BudgetPresenter] CreateBudgetAsync: Bắt đầu tạo ngân sách mới.");
                // 1. Load danh mục trước
                _allCategories = await _categoryService.GetCategoriesByUserIdAsync(_view.CurrentUserId);
                // 2. Sau đó load Icon
                _allIcons = await _categoryService.GetAllIconsAsync();
                // 3. Cuối cùng load Color
                _allColors = await _categoryService.GetAllColorsAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[BudgetPresenter] CreateBudgetAsync: Lỗi: {ex.Message}");
                _view.ShowMessage(ex.Message, "Lỗi", MessageBoxIcon.Error);
            }
            finally { _view.ShowLoading(false); }
        }

        public async Task DeleteBudgetAsync(int budgetId)
        {
            try
            {
                Debug.WriteLine($"[BudgetPresenter] DeleteBudgetAsync: Gọi service để xóa ngân sách ID: {budgetId}");
                if (await _budgetService.DeleteBudgetAsync(budgetId, _view.CurrentUserId))
                {
                    Debug.WriteLine($"[BudgetPresenter] DeleteBudgetAsync: Xóa thành công. Tải lại danh sách.");
                    _view.ShowMessage("Xóa thành công!", "Thông báo", MessageBoxIcon.Information);
                    _selectedBudgetId = 0;
                    await LoadBudgetsAsync();
                }
                else
                {
                    Debug.WriteLine($"[BudgetPresenter] DeleteBudgetAsync: Xóa thất bại từ service.");
                    _view.ShowMessage("Không thể xóa ngân sách.", "Lỗi", MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[BudgetPresenter] DeleteBudgetAsync: Lỗi: {ex.Message}");
                _view.ShowMessage(ex.Message, "Lỗi", MessageBoxIcon.Error);
            }
        }

        public WinColor GetColor(int colorId)
        {
            DbColor dbColor = _allColors?.FirstOrDefault(c => c.ColorId == colorId);

            if (dbColor != null && !string.IsNullOrEmpty(dbColor.HexCode))
            {
                try
                {
                    return System.Drawing.ColorTranslator.FromHtml(dbColor.HexCode);
                }
                catch { return WinColor.Gray; }
            }
            return WinColor.Gray;
        }

        public string GetIconEmoji(int iconId)
        {
            var icon = _allIcons?.FirstOrDefault(i => i.IconId == iconId);
            return icon?.IconName ?? "💰";
        }
    }
}