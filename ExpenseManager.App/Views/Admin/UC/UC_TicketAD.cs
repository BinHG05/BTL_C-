using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Services;
using ExpenseManager.App.Repositories;
using ExpenseManager.App.Models.EF;

namespace ExpenseManager.App.Views.Admin.UC
{
    public partial class UC_TicketAD : UserControl, ITicketADView
    {
        private TicketADPresenter _presenter;
        private BindingSource _ticketBindingSource;
        private List<Ticket> _allTickets;

        private int currentPage = 1;
        private int totalPages = 1;
        private int itemsPerPage = 25;

        // Implement các event từ ITicketADView
        public event EventHandler LoadTickets;
        public event EventHandler ViewTicket;
        public event EventHandler DeleteTicket;

        public UC_TicketAD()
        {
            InitializeComponent();
            InitializePresenter();
            InitializeComboBox();
        }

        private void InitializePresenter()
        {
            // Khởi tạo dependency injection
            var context = new ExpenseDbContext();
            var repository = new TicketADRepository(context);
            var service = new TicketADServices(repository);

            // Khởi tạo Presenter
            _presenter = new TicketADPresenter(this, service);

            // Trigger event LoadTickets khi UserControl load
            this.Load += (s, e) => LoadTickets?.Invoke(this, EventArgs.Empty);
        }

        private void InitializeComboBox()
        {
            cboItemsPerPage.SelectedIndex = 1; // Chọn "25" mặc định
        }

        #region ITicketADView Implementation

        public void SetTicketListBinding(BindingSource ticketList)
        {
            _ticketBindingSource = ticketList;
            _allTickets = ticketList.DataSource as List<Ticket>;

            if (_allTickets != null)
            {
                currentPage = 1;
                totalPages = (int)Math.Ceiling(_allTickets.Count / (double)itemsPerPage);
                LoadCurrentPage();
                UpdateStatistics();
            }
        }

        public string GetSelectedTicketId()
        {
            if (dgvTickets.CurrentRow == null || dgvTickets.CurrentRow.Index < 0)
                return null;

            var ticketId = dgvTickets.CurrentRow.Cells["colID"].Value?.ToString();
            return ticketId;
        }

        public (DialogResult DialogResult, string Status, string AdminNote) ShowTicketDetailsDialog(Ticket ticket, ExpenseManager.App.Models.Entities.User user)
        {
            string GetTranslatedStatus(string status)
            {
                switch (status)
                {
                    case "Open": return "Mở";
                    case "Pending": return "Đang xử lí";
                    case "Resolved": return "Đã xử lí";
                    default: return status;
                }
            }
            var ticketDetailsForm = new Forms.TicketDetailsAD
            {
                TicketID = $"#{ticket.TicketId}",
                UserName = user?.FullName ?? "N/A",
                Email = user?.Email ?? "N/A",
                Question = ticket.Description ?? "",
                QuestionType = ticket.QuestionType ?? "",
                Status = ticket.Status ?? "Open",
                AdminNote = ticket.AdminNote ?? "",
                CreatedDate = ticket.CreatedAt.ToString("HH:mm dd/MM/yyyy"),
                UpdatedDate = ticket.UpdatedAt?.ToString("HH:mm dd/MM/yyyy") ?? "N/A"
            };

            var dialogResult = ticketDetailsForm.ShowDialog();

            return (dialogResult, ticketDetailsForm.Status, ticketDetailsForm.AdminNote);
        }
        public DialogResult ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(this, message, title, buttons, icon);
        }

        #endregion

        #region Phân trang

        private void LoadCurrentPage()
        {
            if (_allTickets == null || _allTickets.Count == 0)
            {
                dgvTickets.Rows.Clear();
                lblPaginationInfo.Text = "Không có tickets nào";
                return;
            }

            // Tính toán các item cho trang hiện tại
            int startIndex = (currentPage - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, _allTickets.Count);

            var pageTickets = _allTickets.Skip(startIndex).Take(itemsPerPage).ToList();

            // Clear và load lại DataGridView
            dgvTickets.Rows.Clear();
            foreach (var ticket in pageTickets)
            {
                int rowIndex = dgvTickets.Rows.Add();
                DataGridViewRow row = dgvTickets.Rows[rowIndex];

                // Helper function để dịch status
                string translatedStatus;
                switch (ticket.Status) // Sử dụng status từ entity (giả định là Open/Pending/Resolved)
                {
                    case "Open":
                        translatedStatus = "Mở";
                        break;
                    case "Pending":
                        translatedStatus = "Đang xử lí";
                        break;
                    case "Resolved":
                        translatedStatus = "Đã xử lí";
                        break;
                    default:
                        translatedStatus = ticket.Status ?? "Mở";
                        break;
                }

                // Lưu TicketId vào Tag để dễ truy xuất
                row.Tag = ticket.TicketId;

                row.Cells["colID"].Value = $"#{ticket.TicketId}";
                row.Cells["colUser"].Value = ticket.User?.FullName ?? "N/A";
                row.Cells["colEmail"].Value = ticket.User?.Email ?? "N/A";
                row.Cells["colType"].Value = ticket.QuestionType ?? "";
                row.Cells["colStatus"].Value = translatedStatus; // CHUYỂN: Gán giá trị đã dịch
                row.Cells["colCreated"].Value = ticket.CreatedAt.ToString("HH:mm dd/MM/yyyy");
                row.Cells["colNote"].Value = string.IsNullOrEmpty(ticket.AdminNote) ? "" :
                    (ticket.AdminNote.Length > 30 ? ticket.AdminNote.Substring(0, 30) + "..." : ticket.AdminNote);

                // Set màu cho status cell (vẫn dùng status tiếng Anh để xác định màu)
                ApplyStatusColor(row.Cells["colStatus"], ticket.Status);
            }

            UpdatePaginationInfo();
        }

        private void ApplyStatusColor(DataGridViewCell statusCell, string status)
        {
            switch (status)
            {
                case "Open":
                    statusCell.Style.BackColor = System.Drawing.Color.FromArgb(207, 244, 252);
                    statusCell.Style.ForeColor = System.Drawing.Color.FromArgb(1, 87, 155);
                    break;
                case "Pending":
                    statusCell.Style.BackColor = System.Drawing.Color.FromArgb(255, 243, 205);
                    statusCell.Style.ForeColor = System.Drawing.Color.FromArgb(230, 126, 34);
                    break;
                case "Resolved":
                    statusCell.Style.BackColor = System.Drawing.Color.FromArgb(200, 230, 201);
                    statusCell.Style.ForeColor = System.Drawing.Color.FromArgb(27, 94, 32);
                    break;
                default:
                    statusCell.Style.BackColor = System.Drawing.Color.White;
                    statusCell.Style.ForeColor = System.Drawing.Color.Black;
                    break;
            }
        }

        private void UpdatePaginationInfo()
        {
            if (_allTickets == null || _allTickets.Count == 0)
            {
                lblPaginationInfo.Text = "Không có tickets nào";
                lblCurrentPage.Text = "0";
                return;
            }

            int startIndex = (currentPage - 1) * itemsPerPage + 1;
            int endIndex = Math.Min(currentPage * itemsPerPage, _allTickets.Count);

            lblPaginationInfo.Text = $"Hiển thị {startIndex} đến {endIndex} trong tổng số {_allTickets.Count} tickets";
            lblCurrentPage.Text = currentPage.ToString();
        }

        private void UpdateStatistics()
        {
            if (_allTickets == null || _allTickets.Count == 0)
            {
                lblTotalCount.Text = "0";
                lblOpenCount.Text = "0";
                lblPendingCount.Text = "0";
                lblResolvedCount.Text = "0";
                return;
            }

            lblTotalCount.Text = _allTickets.Count.ToString();
            lblOpenCount.Text = _allTickets.Count(t => t.Status == "Open").ToString();
            lblPendingCount.Text = _allTickets.Count(t => t.Status == "Pending").ToString();
            lblResolvedCount.Text = _allTickets.Count(t => t.Status == "Resolved").ToString();
        }

        #endregion

        #region Event Handlers

        private void CboItemsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cboItemsPerPage.Text, out int newItemsPerPage))
            {
                itemsPerPage = newItemsPerPage;
                currentPage = 1;

                if (_allTickets != null)
                {
                    totalPages = (int)Math.Ceiling(_allTickets.Count / (double)itemsPerPage);
                    LoadCurrentPage();
                }
            }
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadCurrentPage();
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadCurrentPage();
            }
        }

        private void DgvTickets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dgvTickets.Columns[e.ColumnIndex].Name;

            // Set current row để GetSelectedTicketId() hoạt động đúng
            dgvTickets.CurrentCell = dgvTickets.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (columnName == "colView")
            {
                // Trigger event ViewTicket
                ViewTicket?.Invoke(this, EventArgs.Empty);
            }
            else if (columnName == "colDelete")
            {
                // Trigger event DeleteTicket
                DeleteTicket?.Invoke(this, EventArgs.Empty);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            // TODO: Implement search functionality
            // Có thể filter _allTickets theo từ khóa tìm kiếm và reload trang
        }

        #endregion
    }
}