using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpenseManager.App.Services;
using ExpenseManager.App.Views.Admin.UC;

namespace ExpenseManager.App.Presenters
{
    public class TicketADPresenter
    {
        private readonly ITicketADView _view;
        private readonly ITicketADServices _service;

        public TicketADPresenter(ITicketADView view, ITicketADServices service)
        {
            _view = view;
            _service = service;

            // Đăng ký lắng nghe các event từ View
            _view.LoadTickets += OnLoadTickets;
            _view.ViewTicket += OnViewTicket;
            _view.DeleteTicket += OnDeleteTicket;
        }

        private async void OnLoadTickets(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách ticket từ Service
                var tickets = await _service.GetAllTicketsAsync();

                // Tạo BindingSource và gán cho View
                var bindingSource = new BindingSource { DataSource = tickets };
                _view.SetTicketListBinding(bindingSource);
            }
            catch (Exception ex)
            {
                _view.ShowMessage(
                    $"Lỗi khi tải danh sách yêu cầu: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async void OnDeleteTicket(object sender, EventArgs e)
        {
            try
            {
                // Lấy TicketId được chọn
                string ticketIdStr = _view.GetSelectedTicketId();

                if (string.IsNullOrEmpty(ticketIdStr))
                {
                    _view.ShowMessage(
                        "Vui lòng chọn một yêu cầu để xóa!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Hiển thị xác nhận
                var confirmResult = _view.ShowMessage(
                    $"Bạn có chắc chắn muốn xóa ticket {ticketIdStr}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmResult.ToString() == "No")
                    return;

                // Chuyển đổi ticketId sang int
                int ticketId = int.Parse(ticketIdStr.Replace("#", ""));

                // Gọi Service để xóa
                await _service.DeleteTicketAsync(ticketId);

                // Hiển thị thông báo thành công
                _view.ShowMessage(
                    "Đã xóa ticket thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Làm mới danh sách
                OnLoadTickets(sender, e);
            }
            catch (Exception ex)
            {
                _view.ShowMessage(
                    $"Lỗi khi xóa ticket: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async void OnViewTicket(object sender, EventArgs e)
        {
            try
            {
                // Lấy TicketId được chọn
                string ticketIdStr = _view.GetSelectedTicketId();

                if (string.IsNullOrEmpty(ticketIdStr))
                {
                    _view.ShowMessage(
                        "Vui lòng chọn một ticket để xem!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Chuyển đổi ticketId sang int
                int ticketId = int.Parse(ticketIdStr.Replace("#", ""));

                // Lấy chi tiết ticket từ Service (bao gồm User)
                var ticket = await _service.GetTicketDetailsAsync(ticketId);

                if (ticket == null)
                {
                    _view.ShowMessage(
                        "Không tìm thấy ticket!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                // Mở form TicketDetailsAD và nhận kết quả
                var result = _view.ShowTicketDetailsDialog(ticket, ticket.User);

                // Kiểm tra nếu người dùng nhấn OK 
                if (result.DialogResult == DialogResult.OK)
                {
                    // Cập nhật ticket với thông tin mới
                    await _service.UpdateTicketDetailsAsync(
                        ticketId,
                        result.Status,
                        result.AdminNote
                    );

                    // Hiển thị thông báo thành công
                    _view.ShowMessage(
                        "Đã lưu thay đổi thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Làm mới danh sách
                    OnLoadTickets(sender, e);
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage(
                    $"Lỗi khi xem/cập nhật ticket: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}