using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Repositories;
using ExpenseManager.App.Repositories.Interfaces;
using ExpenseManager.App.Services;
using ExpenseManager.App.Services.Interfaces;
using ExpenseManager.App.Session; // Dùng cho UserId
using ExpenseManager.App.Views.User.UC;
using FontAwesome.Sharp;
//using FontAwesome.Sharp.Fonts; // <<< THÊM DÒNG NÀY
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing; // Giữ nguyên
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Dùng cho Chart
using System.Windows.Media;


// ===== THÊM ALIAS NÀY =====
using DbColor = ExpenseManager.App.Models.Entities.Color;

namespace ExpenseManager.App.Views.Admin.UC // Đảm bảo namespace này đúng
{
    public partial class UC_Wallet : UserControl, IWalletView
    {
        private WalletPresenter _presenter;
        private int _currentPage = 1;
        private int _totalPages = 1;
        private int? _selectedWalletId = null;
        private int _totalRecords = 0;
        private int _pageSize = 10;

        public UC_Wallet()
        {
            InitializeComponent();
            InitializePresenter();
            SetupDataGridView();
            SetupChart();

            // Gán sự kiện
            this.btnAddWallet.Click += (s, e) => AddNewWallet?.Invoke(this, EventArgs.Empty);
            this.btnEdit.Click += (s, e) => EditWallet?.Invoke(this, EventArgs.Empty);
            this.btnDelete.Click += (s, e) => DeleteWallet?.Invoke(this, EventArgs.Empty);
            this.btnNextPage.Click += (s, e) => NextPage?.Invoke(this, EventArgs.Empty);
            this.btnPrevPage.Click += (s, e) => PreviousPage?.Invoke(this, EventArgs.Empty);
        }

        private void InitializePresenter()
        {
            var dbContext = new ExpenseDbContext();
            IWalletRepository repository = new WalletRepository(dbContext);
            IWalletService service = new WalletService(repository);
            _presenter = new WalletPresenter(this, service);
        }

        private void UC_Wallet_Load(object sender, EventArgs e)
        {
            // Kích hoạt Presenter tải dữ liệu
            LoadView?.Invoke(this, EventArgs.Empty);
        }

        // ===========================================
        // === Triển khai IWalletView
        // ===========================================

        public string UserId => CurrentUserSession.CurrentUser?.UserId;
        public int? SelectedWalletId
        {
            get => _selectedWalletId;
            set => _selectedWalletId = value;
        }
        public int CurrentPage
        {
            get => _currentPage;
            set => _currentPage = value;
        }

        public event EventHandler LoadView;
        public event EventHandler SelectWallet;
        public event EventHandler AddNewWallet;
        public event EventHandler EditWallet;
        public event EventHandler DeleteWallet;
        public event EventHandler NextPage;
        public event EventHandler PreviousPage;

        public void DisplayWallets(List<Wallet> wallets)
        {
            flpWallets.Controls.Clear();

            // ===== SỬA LOGIC MẶC ĐỊNH =====
            // Nếu chưa có ví nào được chọn (lần đầu load), chọn ví đầu tiên
            if (_selectedWalletId == null && wallets.Any())
            {
                _selectedWalletId = wallets.First().WalletId;
            }
            // ===== KẾT THÚC SỬA =====

            foreach (var wallet in wallets)
            {
                var item = new UC_WalletItem(wallet);
                item.Click += OnWalletItem_Click;
                flpWallets.Controls.Add(item);

                // Cập nhật trạng thái selected
                if (wallet.WalletId == _selectedWalletId)
                {
                    item.SetSelected(true);
                }
            }
        }

        private void OnWalletItem_Click(object sender, EventArgs e)
        {
            var selectedItem = (UC_WalletItem)sender;
            _selectedWalletId = selectedItem.WalletId;

            // Cập nhật lại UI (highlight)
            foreach (UC_WalletItem item in flpWallets.Controls)
            {
                item.SetSelected(item.WalletId == _selectedWalletId);
            }

            // Báo cho Presenter
            SelectWallet?.Invoke(this, EventArgs.Empty);
        }

        public void DisplayWalletDetails(Wallet wallet, decimal monthlyExpenses)
        {
            lblBIDVTitle.Text = wallet.WalletName;
            lblTotalBalanceAmount.Text = wallet.Balance.ToString("N0", new CultureInfo("vi-VN")) + "đ";
            lblMonthlyExpensesAmount.Text = monthlyExpenses.ToString("N0", new CultureInfo("vi-VN")) + "đ";
        }

        public void DisplayTransactions(List<Transaction> transactions, int totalRecords, int pageSize)
        {
            _totalRecords = totalRecords;
            _pageSize = pageSize;
            _totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Cập nhật DataGridView
            dgvTransactions.Rows.Clear();

            // ===== SỬA LỖI HIỂN THỊ "CHƯA CÓ GIAO DỊCH" =====
            if (totalRecords == 0)
            {
                lblNoTransactions.Visible = true;
                dgvTransactions.Visible = false;
                lblPageInfo.Visible = false;
                btnNextPage.Visible = false;
                btnPrevPage.Visible = false;
            }
            else
            {
                lblNoTransactions.Visible = false;
                dgvTransactions.Visible = true;
                lblPageInfo.Visible = true;
                btnNextPage.Visible = true;
                btnPrevPage.Visible = true;

                foreach (var tran in transactions)
                {
                    string categoryDisplay = (tran.Category?.Icon != null)
                        ? $"{tran.Category.Icon.IconName}"
                        : tran.Category?.CategoryName ?? "N/A";

                    string amountString = (tran.Type == "Expense" ? "-" : "+") + tran.Amount.ToString("N0", new CultureInfo("vi-VN")) + "đ";
                    System.Drawing.Color amountColor = (tran.Type == "Expense") ? System.Drawing.Color.FromArgb(239, 68, 68) : System.Drawing.Color.FromArgb(34, 197, 94);

                    int rowIndex = dgvTransactions.Rows.Add(
                        categoryDisplay,
                        tran.TransactionDate.ToString("dd/MM/yyyy"),
                        tran.Description,
                        amountString
                    );

                    dgvTransactions.Rows[rowIndex].Cells["Amount"].Style.ForeColor = amountColor;
                    dgvTransactions.Rows[rowIndex].Cells["Amount"].Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    dgvTransactions.Rows[rowIndex].Cells["Category"].Tag = tran.Category;
                }
            }
            // ===== KẾT THÚC SỬA =====

            // Cập nhật thông tin phân trang
            lblPageInfo.Text = $"Page {_currentPage} of {_totalPages}";
            btnPrevPage.Enabled = _currentPage > 1;
            btnNextPage.Enabled = _currentPage < _totalPages;
        }

        public void DisplayCategoryChart(List<CategoryExpense> categoryExpenses)
        {
            pieChart.Series.Clear();
            pieChart.Legends.Clear();
            pieChart.Titles.Clear(); // Xóa title cũ

            if (!categoryExpenses.Any())
            {
                // Hiển thị thông báo không có dữ liệu
                pieChart.Titles.Add("Không có dữ liệu chi tiêu tháng này.");
                pieChart.Titles[0].Font = new Font("Segoe UI", 12F);
                pieChart.Titles[0].ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
                return;
            }

            var series = new Series("Expenses")
            {
                ChartType = SeriesChartType.Pie
            };

            Legend legend = new Legend("MainLegend")
            {
                Docking = Docking.Right,
                Alignment = StringAlignment.Center,
                Font = new Font("Segoe UI", 10F)
            };
            pieChart.Legends.Add(legend);

            foreach (var expense in categoryExpenses)
            {
                DataPoint point = new DataPoint();
                point.SetValueY(Convert.ToDouble(expense.Amount));
                series.Points.Add(point);

                point.Color = System.Drawing.ColorTranslator.FromHtml(expense.ColorHex);
                point.LegendText = $"{expense.CategoryName} ({expense.Amount:N0}đ)";
                point.Label = $"{Math.Round((double)(expense.Amount / categoryExpenses.Sum(c => c.Amount)) * 100)}%";
                point.LabelForeColor = System.Drawing.Color.White;
                point.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }

            series["PieLabelStyle"] = "Outside";
            series["PieLineColor"] = "Black";

            pieChart.Series.Add(series);
        }

        public void ShowEmptyState(bool show)
        {
            pnlEmptyState.Visible = show;
            pnlEmptyState.BringToFront();

            // Ẩn các panel nội dung
            pnlBIDVHeader.Visible = !show;
            pnlTotalBalance.Visible = !show;
            pnlMonthlyExpenses.Visible = !show;
            pnlCategoryChart.Visible = !show;
            pnlTransactionHistory.Visible = !show;
        }

        public void ShowMessage(string message, string title, bool isError = false)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK,
                isError ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
        }

        // ===========================================
        // === Cài đặt giao diện
        // ===========================================

        private void SetupDataGridView()
        {
            dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1E293B");
            dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvTransactions.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dgvTransactions.EnableHeadersVisualStyles = false;

            dgvTransactions.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvTransactions.DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1E293B");
            dgvTransactions.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvTransactions.DefaultCellStyle.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#F1F5F9");
            dgvTransactions.DefaultCellStyle.SelectionForeColor = System.Drawing.ColorTranslator.FromHtml("#1E293B");
            dgvTransactions.DefaultCellStyle.Padding = new Padding(5);

            dgvTransactions.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FAFAFA");

            dgvTransactions.Columns.Clear();
            dgvTransactions.Columns.Add("Category", "Category");
            dgvTransactions.Columns.Add("Date", "Date");
            dgvTransactions.Columns.Add("Description", "Description");
            dgvTransactions.Columns.Add("Amount", "Amount");

            dgvTransactions.Columns["Category"].Width = 200;
            dgvTransactions.Columns["Date"].Width = 150;
            dgvTransactions.Columns["Description"].Width = 530;
            dgvTransactions.Columns["Amount"].Width = 180;
            dgvTransactions.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTransactions.CellPainting += DgvTransactions_CellPainting;
        }

        private void DgvTransactions_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvTransactions.Columns["Category"].Index)
                return;

            e.PaintBackground(e.CellBounds, true);

            if (dgvTransactions.Rows[e.RowIndex].Cells["Category"].Tag is Category category && category.Icon != null)
            {
                IconChar iconChar = ConvertIconClassToIconChar(category.Icon.IconClass);
                System.Drawing.Color iconColor;

                // Kiểm tra null cho Color
                if (category.Color != null && !string.IsNullOrWhiteSpace(category.Color.HexCode))
                {
                    try { iconColor = System.Drawing.ColorTranslator.FromHtml(category.Color.HexCode); }
                    catch { iconColor = System.Drawing.Color.FromArgb(30, 41, 59); } // Màu mặc định
                }
                else
                {
                    iconColor = System.Drawing.Color.FromArgb(30, 41, 59); // Màu mặc định
                }


                // Vẽ icon
                try
                {
                    using (var iconFont = new Font("Font Awesome 6 Free Solid", 14F, FontStyle.Regular, GraphicsUnit.Point))
                    {
                        string iconGlyph = char.ToString((char)iconChar);
                        RectangleF iconBounds = new RectangleF(e.CellBounds.Left + 10, e.CellBounds.Top, 30, e.CellBounds.Height);
                        TextRenderer.DrawText(e.Graphics, iconGlyph, iconFont, Point.Round(iconBounds.Location), iconColor);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Font error: {ex.Message}");
                }

                // Vẽ text
                Rectangle textBounds = new Rectangle(e.CellBounds.Left + 45, e.CellBounds.Top, e.CellBounds.Width - 50, e.CellBounds.Height);
                TextRenderer.DrawText(e.Graphics, category.CategoryName, e.CellStyle.Font, textBounds, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter);
            }
            else
            {
                e.PaintContent(e.CellBounds);
            }
            e.Handled = true;
        }

        private IconChar ConvertIconClassToIconChar(string iconClass)
        {
            if (string.IsNullOrWhiteSpace(iconClass))
                return IconChar.CircleQuestion;

            string name = iconClass.Split(' ').Last();
            name = name.Replace("fa-", "");

            string[] parts = name.Split('-');
            StringBuilder pascalCaseName = new StringBuilder();
            foreach (string part in parts)
            {
                pascalCaseName.Append(char.ToUpper(part[0]) + part.Substring(1));
            }

            if (Enum.TryParse<IconChar>(pascalCaseName.ToString(), true, out IconChar result))
            {
                return result;
            }

            return IconChar.CircleQuestion;
        }

        private void SetupChart()
        {
            pieChart.Legends[0].Docking = Docking.Right;
            pieChart.Legends[0].Alignment = StringAlignment.Center;
            pieChart.Legends[0].Font = new Font("Segoe UI", 10F);

            pieChart.ChartAreas[0].Area3DStyle.Enable3D = false;
        }
    }
}