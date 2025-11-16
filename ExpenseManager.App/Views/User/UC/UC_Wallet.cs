using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.Admin.UC
{
    public partial class UC_Wallet : UserControl
    {
        public UC_Wallet()
        {
            InitializeComponent();
            SetupDataGridView();
        }

        private void UC_Wallet_Load(object sender, EventArgs e)
        {
            LoadTransactionData();
        }

        private void SetupDataGridView()
        {
            // Style cho DataGridView
            dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#1E293B");
            dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvTransactions.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            dgvTransactions.EnableHeadersVisualStyles = false;

            dgvTransactions.DefaultCellStyle.BackColor = Color.White;
            dgvTransactions.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#1E293B");
            dgvTransactions.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvTransactions.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F1F5F9");
            dgvTransactions.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#1E293B");
            dgvTransactions.DefaultCellStyle.Padding = new Padding(5);

            dgvTransactions.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FAFAFA");
        }

        private void LoadTransactionData()
        {
            // Tạo DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Amount", typeof(string));

            // Thêm dữ liệu mẫu
            dt.Rows.Add("⛽ Đổ xăng", "15/11/2025", "Xăng xe", "-20,000đ");
            dt.Rows.Add("🍽️ Ăn sáng", "15/11/2025", "Bánh mì chả ngon tí nào", "-15,000đ");
            dt.Rows.Add("🍽️ Ăn sáng", "15/11/2025", "Bánh mì chả ngon tí nào", "-15,000đ");
            dt.Rows.Add("👕 Mua sắm", "14/11/2025", "Giày mạ vàng 9999", "-10,000,000đ");
            dt.Rows.Add("☕ Cà phê", "14/11/2025", "Sinh tổ bo Katali", "-55,000đ");
            dt.Rows.Add("☕ Cà phê", "12/11/2025", "Cafe sờ ta bug", "-60,000đ");

            dgvTransactions.DataSource = dt;

            // Tùy chỉnh cột
            if (dgvTransactions.Columns.Count > 0)
            {
                dgvTransactions.Columns["Category"].HeaderText = "Category";
                dgvTransactions.Columns["Category"].Width = 200;

                dgvTransactions.Columns["Date"].HeaderText = "Date";
                dgvTransactions.Columns["Date"].Width = 150;

                dgvTransactions.Columns["Description"].HeaderText = "Description";
                dgvTransactions.Columns["Description"].Width = 380;

                dgvTransactions.Columns["Amount"].HeaderText = "Amount";
                dgvTransactions.Columns["Amount"].Width = 180;
                dgvTransactions.Columns["Amount"].DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#EF4444");
                dgvTransactions.Columns["Amount"].DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                dgvTransactions.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
    }
}