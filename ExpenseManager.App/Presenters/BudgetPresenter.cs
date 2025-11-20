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
using Microsoft.Extensions.DependencyInjection;

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
        private readonly IServiceProvider _serviceProvider;

        private int _selectedBudgetId;
        private List<BudgetSummaryDto> _currentBudgets;
        private List<Category> _allCategories;
        private List<DbIcon> _allIcons;
        private List<DbColor> _allColors;

        public BudgetPresenter(IBudgetView view, IServiceProvider serviceProvider)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            _view.ViewLoaded += OnViewLoaded;
            _view.BudgetSelected += OnBudgetSelected;
            _view.DeleteBudgetClicked += OnDeleteBudgetClicked;
            _view.EditBudgetClicked += OnEditBudgetClicked;
            _view.ChartDateRangeChanged += OnChartDateRangeChanged;
            _view.ChartTypeChanged += OnChartTypeChanged;
        }

        private async void OnViewLoaded(object sender, EventArgs e)
        {
            Debug.WriteLine("[BudgetPresenter] OnViewLoaded");
            await LoadInitialDataAsync();
        }

        private async void OnBudgetSelected(object sender, int budgetId)
        {
            Debug.WriteLine($"[BudgetPresenter] OnBudgetSelected: {budgetId}");
            _selectedBudgetId = budgetId;
            await LoadBudgetDetailAsync(budgetId);
        }

        private async void OnDeleteBudgetClicked(object sender, EventArgs e)
        {
            if (_selectedBudgetId <= 0)
            {
                _view.ShowMessage("Vui lòng chọn ngân sách để xóa!", "Thông báo", MessageBoxIcon.Warning);
                return;
            }

            await DeleteBudgetAsync(_selectedBudgetId);
        }

        private async void OnEditBudgetClicked(object sender, EventArgs e)
        {
            if (_selectedBudgetId <= 0)
            {
                _view.ShowMessage("Vui lòng chọn ngân sách để sửa!", "Thông báo", MessageBoxIcon.Warning);
                return;
            }

            Debug.WriteLine($"[BudgetPresenter] OnEditBudgetClicked: {_selectedBudgetId}");
            // TODO: Implement edit logic
            _view.ShowMessage("Chức năng chỉnh sửa đang phát triển!", "Thông báo", MessageBoxIcon.Information);
        }

        private async void OnChartDateRangeChanged(object sender, BudgetViewDateRangeEventArgs e)
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

        private async Task LoadInitialDataAsync()
        {
            try
            {
                _view.ShowLoading(true);
                Debug.WriteLine("=== LoadInitialDataAsync START ===");

                using (var scope1 = _serviceProvider.CreateScope())
                {
                    var categoryService = scope1.ServiceProvider.GetRequiredService<ICategoryService>();
                    _allCategories = await categoryService.GetCategoriesByUserIdAsync(_view.CurrentUserId);
                    Debug.WriteLine($"✅ Categories: {_allCategories?.Count ?? 0}");
                }

                using (var scope2 = _serviceProvider.CreateScope())
                {
                    var categoryService = scope2.ServiceProvider.GetRequiredService<ICategoryService>();
                    _allIcons = await categoryService.GetAllIconsAsync();
                    Debug.WriteLine($"✅ Icons: {_allIcons?.Count ?? 0}");
                }

                using (var scope3 = _serviceProvider.CreateScope())
                {
                    var categoryService = scope3.ServiceProvider.GetRequiredService<ICategoryService>();
                    _allColors = await categoryService.GetAllColorsAsync();
                    Debug.WriteLine($"✅ Colors: {_allColors?.Count ?? 0}");
                }

                await LoadBudgetsAsync();
                Debug.WriteLine("=== LoadInitialDataAsync COMPLETE ===");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ LoadInitialDataAsync Error: {ex.Message}\n{ex.StackTrace}");
                _view.ShowMessage($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
            finally
            {
                _view.ShowLoading(false);
            }
        }

        public async Task LoadBudgetsAsync()
        {
            try
            {
                Debug.WriteLine("[LoadBudgetsAsync] START");

                using (var scope = _serviceProvider.CreateScope())
                {
                    var budgetService = scope.ServiceProvider.GetRequiredService<IBudgetService>();
                    var budgets = await budgetService.GetUserBudgetSummariesAsync(_view.CurrentUserId);

                    _currentBudgets = budgets?.ToList() ?? new List<BudgetSummaryDto>();
                    Debug.WriteLine($"✅ Loaded {_currentBudgets.Count} budgets");

                    _view.DisplayBudgetList(_currentBudgets);

                    if (_currentBudgets.Any())
                    {
                        _selectedBudgetId = _currentBudgets.First().BudgetId;
                        await LoadBudgetDetailAsync(_selectedBudgetId);
                    }
                    else
                    {
                        _view.ClearBudgetDetail();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ LoadBudgetsAsync Error: {ex.Message}");
                _view.ShowMessage($"Lỗi tải danh sách: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
        }

        public async Task LoadBudgetDetailAsync(int budgetId)
        {
            try
            {
                Debug.WriteLine($"[LoadBudgetDetailAsync] Loading ID: {budgetId}");

                using (var scope = _serviceProvider.CreateScope())
                {
                    var budgetService = scope.ServiceProvider.GetRequiredService<IBudgetService>();

                    var detail = await budgetService.GetBudgetDetailAsync(budgetId, _view.CurrentUserId);

                    if (detail != null)
                    {
                        _view.DisplayBudgetDetail(detail);

                        var breakdown = await budgetService.GetExpenseBreakdownAsync(budgetId, _view.CurrentUserId);
                        _view.DisplayExpenseChart(breakdown ?? Enumerable.Empty<ExpenseBreakdownDto>());
                    }
                    else
                    {
                        _view.ClearBudgetDetail();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ LoadBudgetDetailAsync Error: {ex.Message}");
                _view.ShowMessage($"Lỗi tải chi tiết: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
        }

        private async Task LoadExpenseChartAsync(int budgetId, DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var budgetService = scope.ServiceProvider.GetRequiredService<IBudgetService>();
                    var breakdown = await budgetService.GetExpenseBreakdownAsync(budgetId, _view.CurrentUserId);
                    var filtered = breakdown?.Where(b => b.Date >= startDate && b.Date <= endDate)
                                   ?? Enumerable.Empty<ExpenseBreakdownDto>();
                    _view.DisplayExpenseChart(filtered);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ LoadExpenseChartAsync Error: {ex.Message}");
            }
        }

        public async Task<List<Category>> GetCategoriesForNewBudgetAsync()
        {
            try
            {
                if (_allCategories == null || !_allCategories.Any())
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var categoryService = scope.ServiceProvider.GetRequiredService<ICategoryService>();
                        _allCategories = await categoryService.GetCategoriesByUserIdAsync(_view.CurrentUserId);
                    }
                }

                return _allCategories
                    .Where(c => c.Type.Equals("Expense", StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ GetCategoriesForNewBudgetAsync Error: {ex.Message}");
                throw;
            }
        }

        public async Task CreateBudgetAsync(BudgetCreateDto createDto)
        {
            try
            {
                _view.ShowLoading(true);
                Debug.WriteLine($"[CreateBudgetAsync] Creating budget for CategoryId: {createDto.CategoryId}");

                using (var scope = _serviceProvider.CreateScope())
                {
                    var budgetService = scope.ServiceProvider.GetRequiredService<IBudgetService>();
                    await budgetService.CreateBudgetAsync(createDto, _view.CurrentUserId);
                }

                _view.ShowMessage("Tạo ngân sách thành công!", "Thành công", MessageBoxIcon.Information);
                await LoadBudgetsAsync();
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine($"⚠️ CreateBudgetAsync Validation: {ex.Message}");
                _view.ShowMessage(ex.Message, "Cảnh báo", MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ CreateBudgetAsync Error: {ex.Message}\n{ex.StackTrace}");
                _view.ShowMessage($"Lỗi tạo ngân sách: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
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
                Debug.WriteLine($"[DeleteBudgetAsync] Deleting ID: {budgetId}");

                using (var scope = _serviceProvider.CreateScope())
                {
                    var budgetService = scope.ServiceProvider.GetRequiredService<IBudgetService>();

                    if (await budgetService.DeleteBudgetAsync(budgetId, _view.CurrentUserId))
                    {
                        _view.ShowMessage("Xóa ngân sách thành công!", "Thành công", MessageBoxIcon.Information);
                        _selectedBudgetId = 0;
                        await LoadBudgetsAsync();
                    }
                    else
                    {
                        _view.ShowMessage("Không thể xóa ngân sách!", "Lỗi", MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ DeleteBudgetAsync Error: {ex.Message}");
                _view.ShowMessage($"Lỗi xóa: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
            finally
            {
                _view.ShowLoading(false);
            }
        }

        public WinColor GetColor(int colorId)
        {
            try
            {
                var dbColor = _allColors?.FirstOrDefault(c => c.ColorId == colorId);
                if (dbColor != null && !string.IsNullOrEmpty(dbColor.HexCode))
                {
                    return System.Drawing.ColorTranslator.FromHtml(dbColor.HexCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ GetColor Error: {ex.Message}");
            }
            return WinColor.Gray;
        }

        public string GetIconEmoji(int iconId)
        {
            try
            {
                var icon = _allIcons?.FirstOrDefault(i => i.IconId == iconId);
                return icon?.IconName ?? "💰";
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ GetIconEmoji Error: {ex.Message}");
                return "💰";
            }
        }
    }
}