using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Repositories;
using ExpenseManager.App.Repositories.Interfaces;
using ExpenseManager.App.Services;
using ExpenseManager.App.Services.Interfaces;
using ExpenseManager.App.Session;
using ExpenseManager.App.Views.User.UC;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Color = System.Drawing.Color;

namespace ExpenseManager.App.Views.Admin.UC
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
            this.BackColor = Color.FromArgb(238, 242, 247);
            InitializePresenter();
            SetupDataGridView();
            SetupChart();

            // Sự kiện cho nút Add Wallet
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
            LoadView?.Invoke(this, EventArgs.Empty);
        }

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

            if (_selectedWalletId == null && wallets.Any())
            {
                _selectedWalletId = wallets.First().WalletId;
            }

            foreach (var wallet in wallets)
            {
                var item = new UC_WalletItem(wallet);
                item.Click += OnWalletItem_Click;
                flpWallets.Controls.Add(item);

                if (wallet.WalletId == _selectedWalletId)
                {
                    item.SetSelected(true);
                }
            }

            flpWallets.Controls.Add(this.btnAddWallet);
        }

        private void OnWalletItem_Click(object sender, EventArgs e)
        {
            var selectedItem = (UC_WalletItem)sender;
            _selectedWalletId = selectedItem.WalletId;

            foreach (Control control in flpWallets.Controls)
            {
                if (control is UC_WalletItem item) 
                {
                    item.SetSelected(item.WalletId == _selectedWalletId);
                }
            }
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

            dgvTransactions.Rows.Clear();

            if (totalRecords == 0)
            {
                ShowEmptyState(false);
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
                    Bitmap iconBitmap = null;
                    if (tran.Category?.Icon != null)
                    {
                        IconChar iconChar = ConvertIconClassToIconChar(tran.Category.Icon.IconClass);
                        Color iconColor = Color.Gray;
                        if (tran.Category.Color != null && !string.IsNullOrEmpty(tran.Category.Color.HexCode))
                        {
                            try
                            {
                                string hex = tran.Category.Color.HexCode.Trim();
                                if (!hex.StartsWith("#")) hex = "#" + hex;
                                iconColor = ColorTranslator.FromHtml(hex);
                            }
                            catch { }
                        }
                        iconBitmap = iconChar.ToBitmap(iconColor, 32);
                    }

                    string categoryName = tran.Category?.CategoryName ?? "Unknown";
                    string amountString = (tran.Type == "Expense" ? "-" : "+") + tran.Amount.ToString("N0", new CultureInfo("vi-VN")) + "đ";

                    Color amountColor = (tran.Type == "Expense") ? Color.FromArgb(239, 68, 68) : Color.FromArgb(34, 197, 94);

                    int rowIndex = dgvTransactions.Rows.Add(
                        iconBitmap,
                        categoryName,
                        tran.TransactionDate.ToString("dd/MM/yyyy"),
                        tran.Description,
                        amountString
                    );

                    var cell = dgvTransactions.Rows[rowIndex].Cells["Amount"];
                    cell.Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    cell.Style.ForeColor = amountColor;
                    cell.Style.SelectionForeColor = amountColor;
                }
            }

            lblPageInfo.Text = $"Page {_currentPage} of {_totalPages}";
            btnPrevPage.Enabled = _currentPage > 1;
            btnNextPage.Enabled = _currentPage < _totalPages;
            dgvTransactions.ClearSelection();
        }

        public void DisplayCategoryChart(List<CategoryExpense> categoryExpenses)
        {
            pieChart.Series.Clear();
            pieChart.Legends.Clear();
            pieChart.Titles.Clear();

            if (!categoryExpenses.Any())
            {
                pieChart.Titles.Add("Không có dữ liệu chi tiêu tháng này.");
                pieChart.Titles[0].Font = new Font("Segoe UI", 12F);
                pieChart.Titles[0].ForeColor = Color.FromArgb(100, 116, 139);
                return;
            }
            var series = new Series("Expenses") { ChartType = SeriesChartType.Pie };
            Legend legend = new Legend("MainLegend") { Docking = Docking.Right, Alignment = StringAlignment.Center, Font = new Font("Segoe UI", 10F) };
            pieChart.Legends.Add(legend);

            foreach (var expense in categoryExpenses)
            {
                DataPoint point = new DataPoint();
                point.SetValueY(Convert.ToDouble(expense.Amount));
                series.Points.Add(point);
                point.Color = ColorTranslator.FromHtml(expense.ColorHex);
                point.LegendText = $"{expense.CategoryName} ({expense.Amount:N0}đ)";
                point.Label = $"{Math.Round((double)(expense.Amount / categoryExpenses.Sum(c => c.Amount)) * 100)}%";
                point.LabelForeColor = Color.White;
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
            pnlBIDVHeader.Visible = !show;
            pnlTotalBalance.Visible = !show;
            pnlMonthlyExpenses.Visible = !show;
            pnlCategoryChart.Visible = !show;
            pnlTransactionHistory.Visible = !show;
        }

        public void ShowMessage(string message, string title, bool isError = false)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, isError ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
        }

        private void SetupDataGridView()
        {
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
            dgvTransactions.RowTemplate.Height = 50;
            dgvTransactions.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FAFAFA");
            dgvTransactions.BorderStyle = BorderStyle.None;
            dgvTransactions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTransactions.GridColor = Color.FromArgb(240, 240, 240);
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvTransactions.Columns.Clear();
            DataGridViewImageColumn iconCol = new DataGridViewImageColumn();
            iconCol.Name = "Icon"; iconCol.HeaderText = ""; iconCol.Width = 50; iconCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvTransactions.Columns.Add(iconCol);
            dgvTransactions.Columns.Add("CategoryName", "Danh mục"); dgvTransactions.Columns["CategoryName"].Width = 180;
            dgvTransactions.Columns.Add("Date", "Ngày"); dgvTransactions.Columns["Date"].Width = 120;
            dgvTransactions.Columns.Add("Description", "Mô tả"); dgvTransactions.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTransactions.Columns.Add("Amount", "Số tiền"); dgvTransactions.Columns["Amount"].Width = 150;
            dgvTransactions.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private IconChar ConvertIconClassToIconChar(string iconClass)
        {
            if (string.IsNullOrWhiteSpace(iconClass)) return IconChar.QuestionCircle;
            try
            {
                var parts = iconClass.Split(' ');
                var iconName = parts.Length > 0 ? parts[parts.Length - 1] : iconClass;
                if (iconName.StartsWith("fa-")) iconName = iconName.Substring(3);
                var words = iconName.Split('-');
                for (int i = 0; i < words.Length; i++) { if (words[i].Length > 0) words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1); }
                var enumString = string.Join("", words);
                if (Enum.TryParse(enumString, true, out IconChar result)) return result;
            }
            catch { }
            return IconChar.QuestionCircle;
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