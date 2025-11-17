using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Services.Interfaces;
using ExpenseManager.App.Views; // Cho WalletForm
using ExpenseManager.App.Views.User.UC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseManager.App.Presenters
{
    public class WalletPresenter : IDisposable
    {
        private readonly IWalletView _view;
        private readonly IWalletService _service;
        private List<Wallet> _userWallets;
        private const int PageSize = 10; // 10 giao dịch mỗi trang

        public WalletPresenter(IWalletView view, IWalletService service)
        {
            _view = view;
            _service = service;

            _view.LoadView += OnLoadView;
            _view.SelectWallet += OnSelectWallet;
            _view.AddNewWallet += OnAddNewWallet;
            _view.EditWallet += OnEditWallet;
            _view.DeleteWallet += OnDeleteWallet;
            _view.NextPage += OnNextPage;
            _view.PreviousPage += OnPreviousPage;
        }

        private async void OnLoadView(object sender, EventArgs e)
        {
            await LoadAllWalletsAsync();
        }

        private async Task LoadAllWalletsAsync()
        {
            try
            {
                _userWallets = await _service.GetWalletsByUserIdAsync(_view.UserId);
                _view.DisplayWallets(_userWallets);

                if (_userWallets.Any())
                {
                    _view.ShowEmptyState(false);
                    // Chọn ví đầu tiên làm mặc định
                    _view.SelectedWalletId = _userWallets.First().WalletId;
                    _view.CurrentPage = 1;
                    await LoadWalletDetailsAsync(_userWallets.First().WalletId, 1);
                }
                else
                {
                    _view.ShowEmptyState(true); // Hiển thị "Chưa có ví"
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi tải danh sách ví: {ex.Message}", "Lỗi", true);
            }
        }

        private async void OnSelectWallet(object sender, EventArgs e)
        {
            if (_view.SelectedWalletId.HasValue)
            {
                _view.CurrentPage = 1;
                await LoadWalletDetailsAsync(_view.SelectedWalletId.Value, 1);
            }
        }

        private async Task LoadWalletDetailsAsync(int walletId, int page)
        {
            try
            {
                var wallet = _userWallets.FirstOrDefault(w => w.WalletId == walletId);
                if (wallet == null) return;

                // 1. Lấy chi phí tháng
                var today = DateTime.Now;
                var monthlyExpenses = await _service.GetMonthlyExpensesAsync(walletId, today.Month, today.Year);
                _view.DisplayWalletDetails(wallet, monthlyExpenses);

                // 2. Lấy biểu đồ
                var chartData = await _service.GetMonthlyExpenseByCategoryAsync(walletId, today.Month, today.Year);
                _view.DisplayCategoryChart(chartData);

                // 3. Lấy giao dịch
                var transactionData = await _service.GetTransactionsByWalletIdAsync(walletId, page, PageSize);
                _view.DisplayTransactions(transactionData.Items, transactionData.TotalRecords, PageSize);
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi tải chi tiết ví: {ex.Message}", "Lỗi", true);
            }
        }

        private async void OnAddNewWallet(object sender, EventArgs e)
        {
            using (var form = new WalletForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var newWallet = new Wallet
                        {
                            UserId = _view.UserId,
                            WalletName = form.WalletName,
                            InitialBalance = form.InitialBalance,
                            WalletType = form.WalletType
                        };
                        await _service.CreateWalletAsync(newWallet);
                        _view.ShowMessage("Tạo ví mới thành công!", "Thành công");
                        await LoadAllWalletsAsync(); // Tải lại toàn bộ
                    }
                    catch (Exception ex)
                    {
                        _view.ShowMessage($"Lỗi: {ex.Message}", "Lỗi tạo ví", true);
                    }
                }
            }
        }

        private async void OnEditWallet(object sender, EventArgs e)
        {
            if (!_view.SelectedWalletId.HasValue) return;

            var walletToEdit = _userWallets.FirstOrDefault(w => w.WalletId == _view.SelectedWalletId.Value);
            if (walletToEdit == null) return;

            using (var form = new WalletForm(walletToEdit))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        walletToEdit.WalletName = form.WalletName; // Chỉ cập nhật tên
                        await _service.UpdateWalletAsync(walletToEdit);
                        _view.ShowMessage("Cập nhật ví thành công!", "Thành công");

                        // Tải lại
                        await LoadAllWalletsAsync();
                        await LoadWalletDetailsAsync(walletToEdit.WalletId, _view.CurrentPage);
                    }
                    catch (Exception ex)
                    {
                        _view.ShowMessage($"Lỗi: {ex.Message}", "Lỗi cập nhật ví", true);
                    }
                }
            }
        }

        private async void OnDeleteWallet(object sender, EventArgs e)
        {
            if (!_view.SelectedWalletId.HasValue) return;

            var result = MessageBox.Show("Bạn có chắc muốn xóa ví này? Hành động này không thể hoàn tác nếu ví không có giao dịch.",
                                         "Xác nhận xóa",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await _service.DeleteWalletAsync(_view.SelectedWalletId.Value);
                    _view.ShowMessage("Xóa ví thành công!", "Thành công");
                    await LoadAllWalletsAsync(); // Tải lại từ đầu
                }
                catch (InvalidOperationException opEx)
                {
                    // Lỗi nghiệp vụ (ví còn tiền, ví có giao dịch)
                    _view.ShowMessage(opEx.Message, "Không thể xóa", true);
                }
                catch (Exception ex)
                {
                    _view.ShowMessage($"Lỗi: {ex.Message}", "Lỗi xóa ví", true);
                }
            }
        }

        private async void OnNextPage(object sender, EventArgs e)
        {
            if (!_view.SelectedWalletId.HasValue) return;
            _view.CurrentPage++;
            await LoadWalletDetailsAsync(_view.SelectedWalletId.Value, _view.CurrentPage);
        }

        private async void OnPreviousPage(object sender, EventArgs e)
        {
            if (!_view.SelectedWalletId.HasValue) return;
            if (_view.CurrentPage > 1)
            {
                _view.CurrentPage--;
                await LoadWalletDetailsAsync(_view.SelectedWalletId.Value, _view.CurrentPage);
            }
        }

        public void Dispose()
        {
            _view.LoadView -= OnLoadView;
            _view.SelectWallet -= OnSelectWallet;
            _view.AddNewWallet -= OnAddNewWallet;
            _view.EditWallet -= OnEditWallet;
            _view.DeleteWallet -= OnDeleteWallet;
            _view.NextPage -= OnNextPage;
            _view.PreviousPage -= OnPreviousPage;
        }
    }
}