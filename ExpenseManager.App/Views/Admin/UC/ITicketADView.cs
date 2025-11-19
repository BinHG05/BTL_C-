using System;
using System.Windows.Forms;
using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Views.Admin.UC
{
    public interface ITicketADView
    {
        // Event để Presenter lắng nghe
        event EventHandler LoadTickets;
        event EventHandler ViewTicket;
        event EventHandler DeleteTicket;

        // Phương thức để gán dữ liệu vào DataGridView
        void SetTicketListBinding(BindingSource ticketList);

        // Phương thức lấy TicketId được chọn
        string GetSelectedTicketId();

        // Phương thức mở form TicketDetailsAD và trả về kết quả
        (DialogResult DialogResult, string Status, string AdminNote) ShowTicketDetailsDialog(Ticket ticket, ExpenseManager.App.Models.Entities.User user);

        // Phương thức hiển thị thông báo
        DialogResult ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon);
    }
}