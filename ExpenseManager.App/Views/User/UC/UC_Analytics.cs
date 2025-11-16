using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D; // Thêm thư viện này để vẽ

namespace ExpenseManager.App.Views.Admin.UC
{
    public partial class UC_Analytics : UserControl
    {
        // Biến trạng thái
        private Panel underline;
        private bool isIncomeView = false; // Mặc định là xem Expenses

        // Màu sắc
        private Color tabActiveColor = Color.FromArgb(59, 130, 246);
        private Color tabInactiveColor = Color.FromArgb(100, 116, 139);
        private Color totalExpenseColor = Color.FromArgb(220, 38, 38);
        private Color totalExpenseBgColor = Color.FromArgb(254, 226, 226);
        private Color totalIncomeColor = Color.FromArgb(22, 163, 74);
        private Color totalIncomeBgColor = Color.FromArgb(220, 252, 231);

        public UC_Analytics()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.UC_Analytics_Load);

            // Giúp việc vẽ (Paint) mượt mà hơn
            this.DoubleBuffered = true;

            // Kết nối sự kiện Paint của Panel với hàm vẽ biểu đồ
            this.pnlDonutChart.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDonutChart_Paint);

            // *** THÊM SỰ KIỆN CLICK CHO 2 NÚT TAB ***
            this.btnExpenses.Click += new System.EventHandler(this.btnExpenses_Click);
            this.btnIncome.Click += new System.EventHandler(this.btnIncome_Click);
        }

        private void UC_Analytics_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định cho các bộ lọc
            cmbWallets.Text = "Tất cả ví";
            dtpMonth.Value = new DateTime(2025, 11, 1);
            dtpMonth.Format = DateTimePickerFormat.Custom;
            dtpMonth.CustomFormat = "MMMM yyyy";

            // Tạo gạch chân (underline)
            underline = new Panel();
            underline.BackColor = tabActiveColor;
            underline.Size = new Size(btnExpenses.Width, 3);
            pnlTabsAndFilters.Controls.Add(underline);

            // Mặc định hiển thị tab Expenses
            ShowExpensesData();
        }

        // --- XỬ LÝ CHUYỂN TAB ---

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            isIncomeView = false; // Chuyển sang view Chi tiêu

            // Cập nhật UI
            btnExpenses.ForeColor = tabActiveColor;
            btnIncome.ForeColor = tabInactiveColor;
            underline.Location = new Point(btnExpenses.Left, btnExpenses.Bottom - 3);

            // Tải dữ liệu
            ShowExpensesData();
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            isIncomeView = true; // Chuyển sang view Thu nhập

            // Cập nhật UI
            btnIncome.ForeColor = tabActiveColor;
            btnExpenses.ForeColor = tabInactiveColor;
            underline.Location = new Point(btnIncome.Left, btnIncome.Bottom - 3);

            // Tải dữ liệu
            ShowIncomeData();
        }

        // --- TẢI DỮ LIỆU (DATA LOADING) ---

        private void ShowExpensesData()
        {
            lblExpensesBreakdown.Text = "Expenses Breakdown";
            lblTotalExpenses.Text = "Tổng: 39,326,000đ";
            lblTotalExpenses.BackColor = totalExpenseBgColor;
            lblTotalExpenses.ForeColor = totalExpenseColor;
            lblPageName.Text = "Expense"; // Cập nhật breadcrumb

            LoadExpensesTransactionHistory();
            LoadExpensesChartLegend();
            pnlDonutChart.Refresh(); // Yêu cầu vẽ lại biểu đồ
        }

        private void ShowIncomeData()
        {
            lblExpensesBreakdown.Text = "Income Breakdown";
            lblTotalExpenses.Text = "Tổng: 110,000,000đ";
            lblTotalExpenses.BackColor = totalIncomeBgColor;
            lblTotalExpenses.ForeColor = totalIncomeColor;
            lblPageName.Text = "Income"; // Cập nhật breadcrumb

            LoadIncomeTransactionHistory();
            LoadIncomeChartLegend();
            pnlDonutChart.Refresh(); // Yêu cầu vẽ lại biểu đồ
        }

        // --- HÀM VẼ BIỂU ĐỒ (Cập nhật) ---
        private void pnlDonutChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(5, 5, pnlDonutChart.Width - 10, pnlDonutChart.Height - 10);
            float holeRadiusRatio = 0.6f;

            float[] values;
            Color[] colors;

            if (isIncomeView)
            {
                // Dữ liệu Thu nhập (Vàng, Đỏ)
                values = new float[] { 54.5f, 45.5f };
                colors = new Color[] { Color.FromArgb(234, 179, 8), Color.FromArgb(239, 68, 68) };
            }
            else
            {
                // Dữ liệu Chi tiêu (Cam, Hồng, Lục...) - Dữ liệu giả
                values = new float[] { 77.6f, 12.0f, 10.4f };
                colors = new Color[] { Color.FromArgb(249, 115, 22), Color.FromArgb(236, 72, 153), Color.FromArgb(34, 197, 94) };
            }

            // 1. Vẽ các miếng Pie
            float currentAngle = -90; // Bắt đầu từ đỉnh
            for (int i = 0; i < values.Length; i++)
            {
                float sweepAngle = 360f * (values[i] / 100f);
                using (SolidBrush brush = new SolidBrush(colors[i]))
                {
                    g.FillPie(brush, rect, currentAngle, sweepAngle);
                }
                currentAngle += sweepAngle;
            }

            // 2. Vẽ "lỗ" ở giữa
            RectangleF holeRect = new RectangleF(
                rect.Left + (rect.Width * (1 - holeRadiusRatio) / 2),
                rect.Top + (rect.Height * (1 - holeRadiusRatio) / 2),
                rect.Width * holeRadiusRatio,
                rect.Height * holeRadiusRatio
            );
            using (SolidBrush brushWhite = new SolidBrush(pnlChart.BackColor))
            {
                g.FillEllipse(brushWhite, holeRect);
            }
        }

        // --- HÀM TẢI CHÚ THÍCH (LEGEND) ---
        private void LoadIncomeChartLegend()
        {
            flpLegend.Controls.Clear();
            CreateLegendItem(Color.FromArgb(234, 179, 8), "Lương", "60,000,000đ", "54.5%");
            CreateLegendItem(Color.FromArgb(239, 68, 68), "May mắn", "50,000,000đ", "45.5%");
        }

        private void LoadExpensesChartLegend()
        {
            flpLegend.Controls.Clear();
            // Dữ liệu giả cho Expenses
            CreateLegendItem(Color.FromArgb(249, 115, 22), "Mua sắm", "10,000,000đ", "77.6%");
            CreateLegendItem(Color.FromArgb(236, 72, 153), "Cà phê", "115,000đ", "12.0%");
            CreateLegendItem(Color.FromArgb(34, 197, 94), "Đổ xăng", "20,000đ", "10.4%");
        }

        // Hàm trợ giúp tạo chú thích
        private void CreateLegendItem(Color color, string name, string amount, string percent)
        {
            Panel pnlItem = new Panel { Size = new Size(flpLegend.Width - 25, 40), Margin = new Padding(0, 5, 0, 5) };
            Label lblColorBox = new Label { BackColor = color, Size = new Size(18, 18), Location = new Point(5, 11) };
            Label lblName = new Label { Text = name, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.FromArgb(30, 41, 59), Location = new Point(35, 10), AutoSize = true };
            Label lblAmount = new Label { Text = amount, Font = new Font("Segoe UI", 10F), ForeColor = Color.FromArgb(100, 116, 139), Location = new Point(200, 10), AutoSize = true };
            Label lblPercent = new Label { Text = percent, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.FromArgb(30, 41, 59), Location = new Point(350, 10), AutoSize = true };

            pnlItem.Controls.Add(lblColorBox);
            pnlItem.Controls.Add(lblName);
            pnlItem.Controls.Add(lblAmount);
            pnlItem.Controls.Add(lblPercent);
            flpLegend.Controls.Add(pnlItem);
        }

        // --- HÀM TẢI BẢNG DỮ LIỆU ---
        private void LoadExpensesTransactionHistory()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Category"); dt.Columns.Add("Date"); dt.Columns.Add("Description"); dt.Columns.Add("Amount", typeof(decimal));
            dt.Rows.Add("Đổ xăng", "15/11/2025", "Xăng xe", -20000);
            dt.Rows.Add("Ăn sáng", "15/11/2025", "Bánh mì chả ngon tí nào", -15000);
            dt.Rows.Add("Ăn sáng", "15/11/2025", "Bánh mì chả ngon tí nào", -15000);
            dt.Rows.Add("Mua sắm", "14/11/2025", "Giày mạ vàng 9999", -10000000);
            dt.Rows.Add("Cà phê", "14/11/2025", "Sinh tố bơ Kataii", -55000);
            dt.Rows.Add("Cà phê", "12/11/2025", "Cafe so ta bug", -60000);
            SetupDataGridView(dt);
        }

        private void LoadIncomeTransactionHistory()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Category"); dt.Columns.Add("Date"); dt.Columns.Add("Description"); dt.Columns.Add("Amount", typeof(decimal));
            dt.Rows.Add("May mắn", "9/11/2025", "Trúng số 50 triệu", 50000000);
            dt.Rows.Add("Lương", "5/11/2025", "Lương tháng 11", 30000000);
            dt.Rows.Add("Lương", "5/11/2025", "Lương tháng 11", 30000000);
            SetupDataGridView(dt);
        }

        private void SetupDataGridView(DataTable dt)
        {
            dgvTransactions.DataSource = dt;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(100, 116, 139);
            dgvTransactions.EnableHeadersVisualStyles = false;
            dgvTransactions.BorderStyle = BorderStyle.None;
            dgvTransactions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTransactions.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvTransactions.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvTransactions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(238, 242, 247);
            dgvTransactions.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dgvTransactions.RowTemplate.Height = 40;
            dgvTransactions.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

            dgvTransactions.Columns["Amount"].DefaultCellStyle.Format = "N0";
            dgvTransactions.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTransactions.Columns["Amount"].DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvTransactions.Columns["Category"].FillWeight = 20;
            dgvTransactions.Columns["Date"].FillWeight = 20;
            dgvTransactions.Columns["Description"].FillWeight = 40;
            dgvTransactions.Columns["Amount"].FillWeight = 20;

            dgvTransactions.CellFormatting -= DgvTransactions_CellFormatting;
            dgvTransactions.CellFormatting += DgvTransactions_CellFormatting;
        }

        private void DgvTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTransactions.Columns[e.ColumnIndex].Name == "Amount")
            {
                if (e.Value != null && e.Value is decimal)
                {
                    decimal amount = (decimal)e.Value;

                    if (amount < 0)
                    {
                        e.CellStyle.ForeColor = totalExpenseColor; // Đỏ
                    }
                    else
                    {
                        e.CellStyle.ForeColor = totalIncomeColor; // Xanh lá
                        e.Value = "+" + String.Format("{0:N0}", amount); // Thêm dấu + và format
                    }
                }
            }
        }
    }
}