using System;
using System.Threading.Tasks;
using ExpenseManager.App.Services;
using ExpenseManager.App.Session;
using ExpenseManager.App.Views.User.UC;

namespace ExpenseManager.App.Presenters
{
    public class SearchPresenter
    {
        private readonly ISearchView _view;
        private readonly ISearchServices _service;
        private readonly object _searchLock = new object();
        private bool _isSearching = false;
        private bool _categoriesLoaded = false;

        public SearchPresenter(ISearchView view, ISearchServices service)
        {
            _view = view;
            _service = service;
        }

        public async void LoadInitialData()
        {
            await Task.Delay(100); // Small delay to ensure UI is ready
            await SearchTransactionsAsync();
        }

        public async void LoadCategories()
        {
            // Skip if already loaded
            if (_categoriesLoaded)
                return;

            try
            {
                var userId = CurrentUserSession.CurrentUser?.UserId;
                if (string.IsNullOrEmpty(userId))
                {
                    _view.ShowMessage("Vui lòng đăng nhập để sử dụng chức năng này", "Thông báo", true);
                    return;
                }

                var categories = await _service.GetUserCategoriesAsync(userId);
                _view.LoadCategories(categories);
                _categoriesLoaded = true;
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi khi tải danh mục: {ex.Message}", "Lỗi", true);
            }
        }

        public async void SearchTransactions()
        {
            // Prevent concurrent searches
            lock (_searchLock)
            {
                if (_isSearching)
                    return;
                _isSearching = true;
            }

            try
            {
                await SearchTransactionsAsync();
            }
            finally
            {
                lock (_searchLock)
                {
                    _isSearching = false;
                }
            }
        }

        private async Task SearchTransactionsAsync()
        {
            try
            {
                var userId = CurrentUserSession.CurrentUser?.UserId;
                if (string.IsNullOrEmpty(userId))
                {
                    _view.ShowMessage("Vui lòng đăng nhập để sử dụng chức năng này", "Thông báo", true);
                    return;
                }

                var transactions = await _service.SearchTransactionsAsync(
                    userId,
                    _view.Keyword ?? string.Empty,
                    _view.SelectedType ?? "Tất cả",
                    _view.SelectedCategoryId,
                    _view.FromDate,
                    _view.ToDate
                );

                _view.Transactions = transactions;
                _view.ResultCount = $"Tìm thấy {transactions.Count} giao dịch";
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", true);
            }
        }

        public void ResetFilters()
        {
            // Use the new method that doesn't reload categories
            _view.ResetFiltersUI();

            // Search with default filters
            LoadInitialData();
        }
    }
}