using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Services.Interfaces;
using ExpenseManager.App.Views.User.UC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.App.Presenters
{
    public class AddTransactionPresenter
    {
        private readonly IAddTransactionView _view;
        private readonly ITransactionService _transactionService;
        private readonly ICategoryService _categoryService;
        private readonly IWalletService _walletService;

        // Cache categories để đỡ phải gọi DB nhiều lần khi switch tab
        private List<Category> _allCategories;

        public AddTransactionPresenter(
            IAddTransactionView view,
            ITransactionService transactionService,
            ICategoryService categoryService,
            IWalletService walletService)
        {
            _view = view;
            _transactionService = transactionService;
            _categoryService = categoryService;
            _walletService = walletService;

            // Đăng ký sự kiện
            _view.LoadView += OnLoadView;
            _view.SaveTransaction += OnSaveTransaction;
            _view.TypeChanged += OnTypeChanged;
        }

        private async void OnLoadView(object sender, EventArgs e)
        {
            try
            {
                // 1. Load Wallets
                var wallets = await _walletService.GetWalletsByUserIdAsync(_view.UserId);
                _view.LoadWallets(wallets);

                // 2. Load Categories
                _allCategories = await _categoryService.GetCategoriesByUserIdAsync(_view.UserId);
                FilterCategories(); // Hiển thị category theo Type mặc định (Expense)
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", true);
            }
        }

        private void OnTypeChanged(object sender, EventArgs e)
        {
            FilterCategories();
        }

        private void FilterCategories()
        {
            if (_allCategories == null) return;

            var filtered = _allCategories
                .Where(c => c.Type == _view.TransactionType)
                .ToList();

            _view.LoadCategories(filtered);
        }

        private async void OnSaveTransaction(object sender, EventArgs e)
        {
            try
            {
                // Validate từ View (Presenter cũng có thể validate thêm)
                if (_view.SelectedWalletId == null || _view.SelectedCategoryId == null)
                {
                    _view.ShowMessage("Vui lòng chọn Ví và Danh mục", "Thiếu thông tin", true);
                    return;
                }

                var transaction = new Transaction
                {
                    UserId = _view.UserId,
                    WalletId = _view.SelectedWalletId.Value,
                    CategoryId = _view.SelectedCategoryId.Value,
                    Type = _view.TransactionType,
                    Amount = _view.Amount,
                    TransactionDate = _view.TransactionDate,
                    Description = _view.Description
                };

                await _transactionService.AddTransactionAsync(transaction);

                _view.ShowMessage("Thêm giao dịch thành công!", "Thành công");
                _view.CloseForm(); // Đóng form sau khi lưu xong
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi: {ex.Message}", "Lỗi lưu giao dịch", true);
            }
        }
    }
}