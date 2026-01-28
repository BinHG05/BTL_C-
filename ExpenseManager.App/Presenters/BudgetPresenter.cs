using ExpenseManager.App.Models.DTOs;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories.Interfaces;
using ExpenseManager.App.Services;
using ExpenseManager.App.Services.Interfaces;
using ExpenseManager.App.Views.User;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        void SetChartDateRange(DateTime startDate, DateTime endDate);
    }

    public class BudgetPresenter : IDisposable
    {
        private readonly IBudgetView _view;
        private readonly IServiceProvider _serviceProvider;

        private int _selectedBudgetId;
        private List<BudgetSummaryDto> _currentBudgets;
        private bool _disposed = false;
        private string _currentGrouping = "Day"; // Default grouping

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

        public void Dispose()
        {
            if (!_disposed)
            {
                _view.ViewLoaded -= OnViewLoaded;
                _view.BudgetSelected -= OnBudgetSelected;
                _view.DeleteBudgetClicked -= OnDeleteBudgetClicked;
                _view.EditBudgetClicked -= OnEditBudgetClicked;
                _view.ChartDateRangeChanged -= OnChartDateRangeChanged;
                _view.ChartTypeChanged -= OnChartTypeChanged;

                _currentBudgets?.Clear();
                _currentBudgets = null;
                _selectedBudgetId = 0;

                _disposed = true;
            }
        }

        private bool CanUpdateView()
        {
            if (_disposed) return false;

            if (_view is UserControl uc && (uc.IsDisposed || uc.Disposing))
                return false;

            return true;
        }

        private async void OnViewLoaded(object sender, EventArgs e)
        {
            if (!CanUpdateView()) return;
            await LoadBudgetsAsync();
        }

        private async void OnBudgetSelected(object sender, int budgetId)
        {
            if (!CanUpdateView()) return;
            _selectedBudgetId = budgetId;
            await LoadBudgetDetailAsync(budgetId);
        }

        private async void OnDeleteBudgetClicked(object sender, EventArgs e)
        {
            if (!CanUpdateView()) return;
            if (_selectedBudgetId <= 0) return;
            await DeleteBudgetAsync(_selectedBudgetId);
        }

        private async void OnEditBudgetClicked(object sender, EventArgs e)
        {
            if (!CanUpdateView()) return;

            if (_selectedBudgetId <= 0)
            {
                _view.ShowMessage("Vui lòng chọn ngân sách cần sửa!", "Thông báo", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _view.ShowLoading(true);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var budgetService = scope.ServiceProvider.GetRequiredService<IBudgetService>();
                    var categoryService = scope.ServiceProvider.GetRequiredService<ICategoryService>();

                    var currentBudget = await budgetService.GetBudgetDetailAsync(_selectedBudgetId, _view.CurrentUserId);

                    if (!CanUpdateView()) return;

                    if (currentBudget == null)
                    {
                        _view.ShowMessage("Không tìm thấy thông tin ngân sách!", "Lỗi", MessageBoxIcon.Error);
                        return;
                    }

                    var allCategories = await categoryService.GetCategoriesByUserIdAsync(_view.CurrentUserId);
                    var summaries = await budgetService.GetUserBudgetSummariesAsync(_view.CurrentUserId);

                    if (!CanUpdateView()) return;

                    var usedCategoryIds = summaries
                        .Where(b => b.BudgetId != _selectedBudgetId)
                        .Select(b => b.CategoryId)
                        .ToHashSet();

                    var availableCategories = allCategories
                        .Where(c => c.Type == "Expense" && !usedCategoryIds.Contains(c.CategoryId))
                        .ToList();

                    using (var dialog = new BudgetEditDialog(currentBudget, availableCategories))
                    {
                        _view.ShowLoading(false);

                        if (dialog.ShowDialog() == DialogResult.OK && dialog.UpdatedBudgetDto != null)
                        {
                            if (!CanUpdateView()) return;

                            _view.ShowLoading(true);
                            bool success = await budgetService.UpdateBudgetAsync(_selectedBudgetId, dialog.UpdatedBudgetDto, _view.CurrentUserId);

                            if (!CanUpdateView()) return;

                            if (success)
                            {
                                _view.ShowMessage("Cập nhật thành công!", "Thông báo", MessageBoxIcon.Information);
                                await LoadBudgetsAsync();
                            }
                            else
                            {
                                _view.ShowMessage("Cập nhật thất bại!", "Lỗi", MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (CanUpdateView())
                    _view.ShowMessage($"Lỗi: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
            finally
            {
                if (CanUpdateView())
                    _view.ShowLoading(false);
            }
        }

        private async void OnChartDateRangeChanged(object sender, BudgetViewDateRangeEventArgs e)
        {
            if (!CanUpdateView()) return;
            if (_selectedBudgetId > 0)
            {
                await LoadExpenseChartAsync(_selectedBudgetId, e.StartDate, e.EndDate, _currentGrouping);
            }
        }

        private async void OnChartTypeChanged(object sender, string chartType)
        {
            if (!CanUpdateView()) return;

            // Map view display names to grouping keys
            _currentGrouping = chartType switch
            {
                "Theo Tuần" => "Week",
                "Theo Tháng" => "Month",
                _ => "Day"
            };

            // Re-fetch data with current date range and new grouping
            // Actually, we should just let the view trigger range change if it wants to,
            // but for immediate feedback, we call LoadExpenseChartAsync.
            if (_selectedBudgetId > 0)
            {
                // We need the current dates from the view if possible, or just re-fetch
                // Based on UC_Budget, CmbChartType_SelectedIndexChanged triggers ChartDateRangeChanged
                // so we might not need to do anything here if the view triggers the event.
                // However, let's be explicit if needed.
            }
        }

        public async Task LoadBudgetsAsync()
        {
            try
            {
                if (!CanUpdateView()) return;

                using (var scope = _serviceProvider.CreateScope())
                {
                    var budgetService = scope.ServiceProvider.GetRequiredService<IBudgetService>();
                    var budgets = await budgetService.GetUserBudgetSummariesAsync(_view.CurrentUserId);

                    if (!CanUpdateView()) return;

                    _currentBudgets = budgets?.ToList() ?? new List<BudgetSummaryDto>();
                    _view.DisplayBudgetList(_currentBudgets);

                    if (_currentBudgets.Any())
                    {
                        if (_selectedBudgetId > 0 && _currentBudgets.Any(b => b.BudgetId == _selectedBudgetId))
                        {
                            await LoadBudgetDetailAsync(_selectedBudgetId);
                        }
                        else
                        {
                            _selectedBudgetId = _currentBudgets.First().BudgetId;
                            await LoadBudgetDetailAsync(_selectedBudgetId);
                        }
                    }
                    else
                    {
                        _view.ClearBudgetDetail();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"LoadBudgetsAsync Error: {ex.Message}");
            }
        }

        public async Task LoadBudgetDetailAsync(int budgetId)
        {
            try
            {
                if (!CanUpdateView()) return;

                using (var scope = _serviceProvider.CreateScope())
                {
                    var budgetService = scope.ServiceProvider.GetRequiredService<IBudgetService>();
                    var detail = await budgetService.GetBudgetDetailAsync(budgetId, _view.CurrentUserId);

                    if (!CanUpdateView()) return;

                    if (detail != null)
                    {
                        _view.DisplayBudgetDetail(detail);

                        _view.SetChartDateRange(detail.StartDate, detail.EndDate);

                        var breakdown = await budgetService.GetExpenseBreakdownAsync(
                            budgetId, _view.CurrentUserId, detail.StartDate, detail.EndDate, _currentGrouping);

                        if (!CanUpdateView()) return;

                        _view.DisplayExpenseChart(breakdown ?? Enumerable.Empty<ExpenseBreakdownDto>());
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"LoadBudgetDetailAsync Error: {ex.Message}");
            }
        }

        private async Task LoadExpenseChartAsync(int budgetId, DateTime start, DateTime end, string grouping = "Day")
        {
            try
            {
                if (!CanUpdateView()) return;

                using (var scope = _serviceProvider.CreateScope())
                {
                    var budgetService = scope.ServiceProvider.GetRequiredService<IBudgetService>();

                    var breakdown = await budgetService.GetExpenseBreakdownAsync(
                        budgetId, _view.CurrentUserId, start, end, grouping);

                    if (!CanUpdateView()) return;

                    _view.DisplayExpenseChart(breakdown ?? Enumerable.Empty<ExpenseBreakdownDto>());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"LoadExpenseChartAsync Error: {ex.Message}");
            }
        }

        public async Task<List<Category>> GetCategoriesForNewBudgetAsync()
        {
            try
            {
                if (!CanUpdateView()) return new List<Category>();

                using (var scope = _serviceProvider.CreateScope())
                {
                    var categoryService = scope.ServiceProvider.GetRequiredService<ICategoryService>();
                    var allCategories = await categoryService.GetCategoriesByUserIdAsync(_view.CurrentUserId);

                    if (allCategories == null) return new List<Category>();

                    var existingBudgetCategoryIds = GetExistingBudgetCategoryIds();

                    var validCategories = allCategories
                        .Where(c => c.Type == "Expense" && !existingBudgetCategoryIds.Contains(c.CategoryId))
                        .ToList();

                    return validCategories;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"GetCategoriesForNewBudgetAsync Error: {ex.Message}");
                return new List<Category>();
            }
        }

        public HashSet<int> GetExistingBudgetCategoryIds()
        {
            if (_currentBudgets == null || !_currentBudgets.Any())
                return new HashSet<int>();
            return new HashSet<int>(_currentBudgets.Select(b => b.CategoryId));
        }

        public async Task CreateBudgetAsync(BudgetCreateDto createDto)
        {
            try
            {
                if (!CanUpdateView()) return;

                _view.ShowLoading(true);
                using (var scope = _serviceProvider.CreateScope())
                {
                    var budgetService = scope.ServiceProvider.GetRequiredService<IBudgetService>();
                    await budgetService.CreateBudgetAsync(createDto, _view.CurrentUserId);
                }

                if (!CanUpdateView()) return;

                _view.ShowMessage("Tạo ngân sách thành công!", "Thành công", MessageBoxIcon.Information);
                await LoadBudgetsAsync();
            }
            catch (Exception ex)
            {
                if (CanUpdateView())
                    _view.ShowMessage(ex.Message, "Lỗi", MessageBoxIcon.Error);
            }
            finally
            {
                if (CanUpdateView())
                    _view.ShowLoading(false);
            }
        }

        public async Task DeleteBudgetAsync(int budgetId)
        {
            try
            {
                if (!CanUpdateView()) return;

                _view.ShowLoading(true);
                using (var scope = _serviceProvider.CreateScope())
                {
                    var budgetService = scope.ServiceProvider.GetRequiredService<IBudgetService>();
                    await budgetService.DeleteBudgetAsync(budgetId, _view.CurrentUserId);
                }

                if (!CanUpdateView()) return;

                _view.ShowMessage("Xóa thành công!", "Thông báo", MessageBoxIcon.Information);
                _selectedBudgetId = 0;
                await LoadBudgetsAsync();
            }
            catch (Exception ex)
            {
                if (CanUpdateView())
                    _view.ShowMessage(ex.Message, "Lỗi", MessageBoxIcon.Error);
            }
            finally
            {
                if (CanUpdateView())
                    _view.ShowLoading(false);
            }
        }

        public string GetIconEmoji(int iconId)
        {
            return "💰";
        }
    }
}