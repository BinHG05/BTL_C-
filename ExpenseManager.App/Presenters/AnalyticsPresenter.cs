using ExpenseManager.App.Services.Interfaces;
using ExpenseManager.App.Views.User.UC;
using ExpenseManager.App.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using ExpenseManager.App.Models.DTOs;

namespace ExpenseManager.App.Presenters
{
    public class AnalyticsPresenter
    {
        private readonly IAnalyticsView _view;
        private readonly IAnalyticsService _analyticsService;
        private readonly IWalletService _walletService;

        private int _currentIncomePage = 1;
        private int _currentExpensePage = 1;
        private const int PAGE_SIZE = 7;

        public AnalyticsPresenter(
            IAnalyticsView view,
            IAnalyticsService analyticsService,
            IWalletService walletService)
        {
            _view = view;
            _analyticsService = analyticsService;
            _walletService = walletService;

            // Đăng ký sự kiện
            _view.LoadWalletList += OnLoadWalletList;
            _view.ApplyFilter += OnApplyFilter;
            _view.ResetFilter += OnResetFilter;
            _view.PageChanged += OnPageChanged;

            // Set tháng mặc định
            _view.SelectedMonth = DateTime.Now.ToString("yyyy-MM");
        }

        private async void OnLoadWalletList(object? sender, EventArgs e)
        {
            try
            {
                var wallets = await _walletService.GetWalletsByUserIdAsync(_view.UserId);
                var walletDtos = wallets.Select(w => new WalletDto
                {
                    WalletID = w.WalletId,
                    WalletName = w.WalletName,
                    Balance = w.Balance
                }).ToList();

                _view.SetWalletList(walletDtos);
            }
            catch (Exception ex)
            {
                _view.ShowError("Lỗi tải danh sách ví: " + ex.Message);
            }
        }

        private async void OnApplyFilter(object? sender, EventArgs e)
        {
            // Reset về trang 1 khi apply filter
            _currentExpensePage = 1;
            _currentIncomePage = 1;
            await LoadData(1);
        }

        private async void OnResetFilter(object? sender, EventArgs e)
        {
            // Reset về tháng hiện tại
            _view.SelectedMonth = DateTime.Now.ToString("yyyy-MM");
            _currentExpensePage = 1;
            _currentIncomePage = 1;
            await LoadData(1);
        }

        private async void OnPageChanged(object? sender, int newPage)
        {
            if (_view.ActiveTab == "Income")
            {
                _currentIncomePage = newPage;
            }
            else // "Expense"
            {
                _currentExpensePage = newPage;
            }
            await LoadData(newPage);
        }

        private async Task LoadData(int page)
        {
            try
            {
                _view.ShowLoading(true);

                var userId = ExpenseManager.App.Session.CurrentUserSession.CurrentUser?.UserId;
                var walletId = _view.SelectedWalletId;
                var month = _view.SelectedMonth;

                if (string.IsNullOrEmpty(userId))
                {
                    _view.ShowError("Không tìm thấy thông tin người dùng");
                    return;
                }

                if (_view.ActiveTab == "Income")
                {
                    var result = await _analyticsService.GetIncomeAnalyticsAsync(
                        userId, walletId, month, _currentIncomePage, PAGE_SIZE);

                    // Materialize tất cả collections ngay
                    var breakdown = result.Breakdown.ToList();
                    var history = result.History.ToList();
                    var trendData = result.TrendData.ToList();

                    _view.DisplayIncomeBreakdown(breakdown);
                    _view.DisplayIncomeHistory(history);
                    _view.DisplayTotalIncome(result.Total);
                    _view.DisplayIncomeTrend(trendData);
                    _view.DisplayPagingInfo(result.Paging);
                }
                else
                {
                    var result = await _analyticsService.GetExpenseAnalyticsAsync(
                        userId, walletId, month, _currentExpensePage, PAGE_SIZE);

                    // Materialize tất cả collections ngay
                    var breakdown = result.Breakdown.ToList();
                    var history = result.History.ToList();
                    var trendData = result.TrendData.ToList();

                    _view.DisplayExpenseBreakdown(breakdown);
                    _view.DisplayExpenseHistory(history);
                    _view.DisplayTotalExpense(result.Total);
                    _view.DisplayExpenseTrend(trendData);
                    _view.DisplayPagingInfo(result.Paging);
                }
            }
            catch (Exception ex)
            {
                _view.ShowError("Lỗi tải dữ liệu phân tích: " + ex.Message);
            }
            finally
            {
                _view.ShowLoading(false);
            }
        }
    }
}