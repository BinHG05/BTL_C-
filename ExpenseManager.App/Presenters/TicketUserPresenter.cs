using System;
using System.Threading.Tasks;
using ExpenseManager.App.Services;
using ExpenseManager.App.Views.User.UC;

namespace ExpenseManager.App.Presenters
{
    internal class TicketUserPresenter
    {
        private readonly ITicketUserView _view;
        private readonly ITicketUserServices _service;

        public TicketUserPresenter(ITicketUserView view, ITicketUserServices service)
        {
            _view = view;
            _service = service;

            // Subscribe to events
            _view.LoadTickets += OnLoadTickets;
        }

        private async void OnLoadTickets(object sender, EventArgs e)
        {
            await LoadTicketsAsync();
        }

        private async Task LoadTicketsAsync()
        {
            try
            {
                _view.SetLoading(true);

                var tickets = await _service.GetUserTicketsAsync(_view.UserId);
                _view.DisplayTickets(tickets);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Không thể tải danh sách yêu cầu: {ex.Message}");
            }
            finally
            {
                _view.SetLoading(false);
            }
        }
    }
}