using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseManager.App.Presenters
{
    // ==================== INTERFACE VIEW ====================
    public interface IBudgetView
    {
        // Properties
        string CurrentUserId { get; set; }

        // Events
        event EventHandler ViewLoaded;
        event EventHandler<int> BudgetSelected;
        event EventHandler AddBudgetClicked;
        event EventHandler EditBudgetClicked;
        event EventHandler DeleteBudgetClicked;
        event EventHandler<DateRangeEventArgs> ChartDateRangeChanged;
        event EventHandler<string> ChartTypeChanged;

        // Methods to update UI
        void DisplayBudgetList(IEnumerable<BudgetSummaryDto> budgets);
        void DisplayBudgetDetail(BudgetDetailDto detail);
        void DisplayExpenseChart(IEnumerable<ExpenseBreakdownDto> breakdown);
        void ShowMessage(string message, string title, MessageBoxIcon icon);
        void ShowLoading(bool isLoading);
        void ClearBudgetDetail();

        // UI Controls access
        FlowLayoutPanel BudgetListPanel { get; }
        Panel MainContentPanel { get; }
    }

    // ==================== PRESENTER ====================
    public class BudgetPresenter
    {
        private readonly IBudgetView _view;
        private readonly IBudgetService _budgetService;
        private readonly ICategoryService _categoryService;
        private readonly IIconService _iconService;

        private int _selectedBudgetId;
        private List<BudgetSummaryDto> _currentBudgets;

        public BudgetPresenter(
            IBudgetView view,
            IBudgetService budgetService,
            ICategoryService categoryService,
            IIconService iconService)
        {
            _view = view;
            _budgetService = budgetService;
            _categoryService = categoryService;
            _iconService = iconService;

            // Subscribe to view events
            _view.ViewLoaded += OnViewLoaded;
            _view.BudgetSelected += OnBudgetSelected;
            _view.AddBudgetClicked += OnAddBudgetClicked;
            _view.EditBudgetClicked += OnEditBudgetClicked;
            _view.DeleteBudgetClicked += OnDeleteBudgetClicked;
            _view.ChartDateRangeChanged += OnChartDateRangeChanged;
            _view.ChartTypeChanged += OnChartTypeChanged;
        }

        // ==================== EVENT HANDLERS ====================

        private async void OnViewLoaded(object sender, EventArgs e)
        {
            await LoadBudgetsAsync();
        }

        private async void OnBudgetSelected(object sender, int budgetId)
        {
            _selectedBudgetId = budgetId;
            await LoadBudgetDetailAsync(budgetId);
        }

        private async void OnAddBudgetClicked(object sender, EventArgs e)
        {
            // Mở form tạo mới budget
            var categories = await _categoryService.GetUserCategoriesAsync(_view.CurrentUserId, "Expense");
            var createForm = new BudgetCreateDialog(categories);

            if (createForm.ShowDialog() == DialogResult.OK)
            {
                await CreateBudgetAsync(createForm.BudgetData);
            }
        }

        private async void OnEditBudgetClicked(object sender, EventArgs e)
        {
            if (_selectedBudgetId <= 0)
            {
                _view.ShowMessage("Vui lòng chọn ngân sách cần chỉnh sửa", "Thông báo", MessageBoxIcon.Warning);
                return;
            }

            var budget = await _budgetService.GetBudgetDetailAsync(_selectedBudgetId, _view.CurrentUserId);

            if (budget == null)
            {
                _view.ShowMessage("Không tìm thấy ngân sách", "Lỗi", MessageBoxIcon.Error);
                return;
            }

            var categories = await _categoryService.GetUserCategoriesAsync(_view.CurrentUserId, "Expense");
            var editForm = new BudgetEditDialog(categories, budget);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                await UpdateBudgetAsync(_selectedBudgetId, editForm.BudgetData);
            }
        }

        private async void OnDeleteBudgetClicked(object sender, EventArgs e)
        {
            if (_selectedBudgetId <= 0)
            {
                _view.ShowMessage("Vui lòng chọn ngân sách cần xóa", "Thông báo", MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa ngân sách này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                await DeleteBudgetAsync(_selectedBudgetId);
            }
        }

        private async void OnChartDateRangeChanged(object sender, DateRangeEventArgs e)
        {
            if (_selectedBudgetId > 0)
            {
                await LoadExpenseChartAsync(_selectedBudgetId, e.StartDate, e.EndDate);
            }
        }

        private async void OnChartTypeChanged(object sender, string chartType)
        {
            if (_selectedBudgetId > 0)
            {
                await LoadBudgetDetailAsync(_selectedBudgetId);
            }
        }

        // ==================== BUSINESS LOGIC ====================

        public async Task LoadBudgetsAsync()
        {
            try
            {
                _view.ShowLoading(true);

                var budgets = await _budgetService.GetUserBudgetSummariesAsync(_view.CurrentUserId);
                _currentBudgets = budgets.ToList();

                _view.DisplayBudgetList(_currentBudgets);

                // Nếu có budget, tự động chọn cái đầu tiên
                if (_currentBudgets.Any())
                {
                    var firstBudget = _currentBudgets.First();
                    _selectedBudgetId = firstBudget.BudgetId;
                    await LoadBudgetDetailAsync(firstBudget.BudgetId);
                }
                else
                {
                    _view.ClearBudgetDetail();
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi khi tải danh sách ngân sách: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
            finally
            {
                _view.ShowLoading(false);
            }
        }

        public async Task LoadBudgetDetailAsync(int budgetId)
        {
            try
            {
                _view.ShowLoading(true);

                var detail = await _budgetService.GetBudgetDetailAsync(budgetId, _view.CurrentUserId);

                if (detail != null)
                {
                    _view.DisplayBudgetDetail(detail);

                    // Load expense chart
                    var breakdown = await _budgetService.GetExpenseBreakdownAsync(
                        budgetId, _view.CurrentUserId);
                    _view.DisplayExpenseChart(breakdown);
                }
                else
                {
                    _view.ShowMessage("Không tìm thấy thông tin ngân sách", "Lỗi", MessageBoxIcon.Error);
                    _view.ClearBudgetDetail();
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi khi tải chi tiết ngân sách: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
            finally
            {
                _view.ShowLoading(false);
            }
        }

        private async Task LoadExpenseChartAsync(int budgetId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var breakdown = await _budgetService.GetExpenseBreakdownAsync(budgetId, _view.CurrentUserId);

                // Filter by date range
                var filteredBreakdown = breakdown
                    .Where(b => b.Date >= startDate && b.Date <= endDate)
                    .ToList();

                _view.DisplayExpenseChart(filteredBreakdown);
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi khi tải biểu đồ: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
        }

        public async Task CreateBudgetAsync(BudgetCreateDto createDto)
        {
            try
            {
                _view.ShowLoading(true);

                // Validate
                if (createDto.BudgetAmount <= 0)
                {
                    _view.ShowMessage("Số tiền ngân sách phải lớn hơn 0", "Thông báo", MessageBoxIcon.Warning);
                    return;
                }

                if (createDto.EndDate <= createDto.StartDate)
                {
                    _view.ShowMessage("Ngày kết thúc phải sau ngày bắt đầu", "Thông báo", MessageBoxIcon.Warning);
                    return;
                }

                var budget = await _budgetService.CreateBudgetAsync(createDto, _view.CurrentUserId);

                _view.ShowMessage("Tạo ngân sách thành công!", "Thành công", MessageBoxIcon.Information);

                // Reload list
                await LoadBudgetsAsync();

                // Select the new budget
                _selectedBudgetId = budget.BudgetId;
                await LoadBudgetDetailAsync(budget.BudgetId);
            }
            catch (InvalidOperationException ex)
            {
                _view.ShowMessage(ex.Message, "Thông báo", MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi khi tạo ngân sách: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
            finally
            {
                _view.ShowLoading(false);
            }
        }

        public async Task UpdateBudgetAsync(int budgetId, BudgetUpdateDto updateDto)
        {
            try
            {
                _view.ShowLoading(true);

                // Validate
                if (updateDto.BudgetAmount <= 0)
                {
                    _view.ShowMessage("Số tiền ngân sách phải lớn hơn 0", "Thông báo", MessageBoxIcon.Warning);
                    return;
                }

                if (updateDto.EndDate <= updateDto.StartDate)
                {
                    _view.ShowMessage("Ngày kết thúc phải sau ngày bắt đầu", "Thông báo", MessageBoxIcon.Warning);
                    return;
                }

                var success = await _budgetService.UpdateBudgetAsync(budgetId, updateDto, _view.CurrentUserId);

                if (success)
                {
                    _view.ShowMessage("Cập nhật ngân sách thành công!", "Thành công", MessageBoxIcon.Information);

                    // Reload list and detail
                    await LoadBudgetsAsync();
                    await LoadBudgetDetailAsync(budgetId);
                }
                else
                {
                    _view.ShowMessage("Không thể cập nhật ngân sách", "Lỗi", MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi khi cập nhật ngân sách: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
            finally
            {
                _view.ShowLoading(false);
            }
        }

        public async Task DeleteBudgetAsync(int budgetId)
        {
            try
            {
                _view.ShowLoading(true);

                var success = await _budgetService.DeleteBudgetAsync(budgetId, _view.CurrentUserId);

                if (success)
                {
                    _view.ShowMessage("Xóa ngân sách thành công!", "Thành công", MessageBoxIcon.Information);

                    // Clear selection and reload
                    _selectedBudgetId = 0;
                    _view.ClearBudgetDetail();
                    await LoadBudgetsAsync();
                }
                else
                {
                    _view.ShowMessage("Không thể xóa ngân sách", "Lỗi", MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi khi xóa ngân sách: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
            finally
            {
                _view.ShowLoading(false);
            }
        }

        public async Task RefreshAsync()
        {
            await LoadBudgetsAsync();
        }
    }

    // ==================== HELPER CLASSES ====================

    public class DateRangeEventArgs : EventArgs
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    // Interface cho Icon Service
    public interface IIconService
    {
        string GetIconEmoji(int iconId);
        Image GetIconImage(int iconId);
    }

    // Interface cho Category Service
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetUserCategoriesAsync(string userId, string type = null);
        Task<Category> GetByIdAsync(int categoryId);
    }
}