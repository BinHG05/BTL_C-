using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace ExpenseManager.App.Views.User.Forms
{
    partial class AddTransactionForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            btnClose = new IconButton();
            titleLabel = new Label();
            contentPanel = new Panel();
            btnSubmit = new Button();
            txtDescription = new TextBox();
            lblDescription = new Label();
            dtpTransaction = new DateTimePicker();
            lblDate = new Label();
            cmbWallet = new ComboBox();
            lblWallet = new Label();
            categoryFlowPanel = new FlowLayoutPanel();
            lblCategory = new Label();
            amountPanel = new Panel();
            lblCurrency = new Label();
            txtAmount = new TextBox();
            lblAmount = new Label();
            typePanel = new Panel();
            btnIncome = new Button();
            btnExpense = new Button();
            headerPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            amountPanel.SuspendLayout();
            typePanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(101, 109, 255);
            headerPanel.Controls.Add(btnClose);
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(3, 4, 3, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(23, 20, 23, 20);
            headerPanel.Size = new Size(743, 80);
            headerPanel.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.IconChar = IconChar.Close;
            btnClose.IconColor = Color.White;
            btnClose.IconFont = IconFont.Auto;
            btnClose.IconSize = 24;
            btnClose.Location = new Point(674, 20);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(46, 40);
            btnClose.TabIndex = 1;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Dock = DockStyle.Left;
            titleLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(23, 20);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(189, 32);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Thêm giao dịch";
            // 
            // contentPanel
            // 
            contentPanel.AutoScroll = true;
            contentPanel.BackColor = Color.White;
            contentPanel.Controls.Add(btnSubmit);
            contentPanel.Controls.Add(txtDescription);
            contentPanel.Controls.Add(lblDescription);
            contentPanel.Controls.Add(dtpTransaction);
            contentPanel.Controls.Add(lblDate);
            contentPanel.Controls.Add(cmbWallet);
            contentPanel.Controls.Add(lblWallet);
            contentPanel.Controls.Add(categoryFlowPanel);
            contentPanel.Controls.Add(lblCategory);
            contentPanel.Controls.Add(amountPanel);
            contentPanel.Controls.Add(lblAmount);
            contentPanel.Controls.Add(typePanel);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 80);
            contentPanel.Margin = new Padding(3, 4, 3, 4);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(34, 27, 34, 27);
            contentPanel.Size = new Size(743, 920);
            contentPanel.TabIndex = 1;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(101, 109, 255);
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(34, 873);
            btnSubmit.Margin = new Padding(3, 4, 3, 4);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(674, 67);
            btnSubmit.TabIndex = 11;
            btnSubmit.Text = "✅  Thêm giao dịch";
            btnSubmit.UseVisualStyleBackColor = false;
            //btnSubmit.Click += BtnSubmit_Click;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(34, 767);
            txtDescription.Margin = new Padding(3, 4, 3, 4);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Thêm ghi chú...";
            txtDescription.Size = new Size(674, 79);
            txtDescription.TabIndex = 10;
            // 
            // lblDescription
            // 
            lblDescription.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDescription.ForeColor = Color.FromArgb(50, 50, 50);
            lblDescription.Location = new Point(34, 727);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(674, 33);
            lblDescription.TabIndex = 9;
            lblDescription.Text = "Ghi chú (tùy chọn)";
            // 
            // dtpTransaction
            // 
            dtpTransaction.CustomFormat = "dd-MM-yyyy HH:mm";
            dtpTransaction.Font = new Font("Segoe UI", 11F);
            dtpTransaction.Format = DateTimePickerFormat.Custom;
            dtpTransaction.Location = new Point(34, 664);
            dtpTransaction.Margin = new Padding(3, 4, 3, 4);
            dtpTransaction.Name = "dtpTransaction";
            dtpTransaction.Size = new Size(674, 32);
            dtpTransaction.TabIndex = 8;
            // 
            // lblDate
            // 
            lblDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDate.ForeColor = Color.FromArgb(50, 50, 50);
            lblDate.Location = new Point(34, 624);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(674, 33);
            lblDate.TabIndex = 7;
            lblDate.Text = "Ngày giao dịch";
            // 
            // cmbWallet
            // 
            this.cmbWallet.BackColor = System.Drawing.Color.WhiteSmoke; // ✅ Mới thêm: Màu nền xám nhạt để dễ nhìn
            this.cmbWallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWallet.FlatStyle = System.Windows.Forms.FlatStyle.Standard; // ✅ Mới sửa: Đổi sang Standard để hiện viền 3D
            this.cmbWallet.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbWallet.FormattingEnabled = true;
            this.cmbWallet.Location = new System.Drawing.Point(34, 560);
            this.cmbWallet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbWallet.Name = "cmbWallet";
            this.cmbWallet.Size = new System.Drawing.Size(674, 33);
            this.cmbWallet.TabIndex = 6;
            //cmbWallet.DropDownStyle = ComboBoxStyle.DropDownList;
            //cmbWallet.FlatStyle = FlatStyle.Flat;
            //cmbWallet.Font = new Font("Segoe UI", 11F);
            //cmbWallet.FormattingEnabled = true;
            //cmbWallet.Location = new Point(34, 560);
            //cmbWallet.Margin = new Padding(3, 4, 3, 4);
            //cmbWallet.Name = "cmbWallet";
            //cmbWallet.Size = new Size(674, 33);
            //cmbWallet.TabIndex = 6;
            // 
            // lblWallet
            // 
            lblWallet.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblWallet.ForeColor = Color.FromArgb(50, 50, 50);
            lblWallet.Location = new Point(34, 520);
            lblWallet.Name = "lblWallet";
            lblWallet.Size = new Size(674, 33);
            lblWallet.TabIndex = 5;
            lblWallet.Text = "Từ ví";
            // 
            // categoryFlowPanel
            // 
            categoryFlowPanel.BackColor = Color.White;
            categoryFlowPanel.Location = new Point(34, 293);
            categoryFlowPanel.Margin = new Padding(3, 4, 3, 4);
            categoryFlowPanel.Name = "categoryFlowPanel";
            categoryFlowPanel.Size = new Size(674, 200);
            categoryFlowPanel.TabIndex = 4;
            // 
            // lblCategory
            // 
            lblCategory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCategory.ForeColor = Color.FromArgb(50, 50, 50);
            lblCategory.Location = new Point(34, 253);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(674, 33);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Danh mục";
            // 
            // amountPanel
            // 
            amountPanel.BackColor = Color.FromArgb(245, 245, 245);
            amountPanel.Controls.Add(lblCurrency);
            amountPanel.Controls.Add(txtAmount);
            amountPanel.Location = new Point(34, 160);
            amountPanel.Margin = new Padding(3, 4, 3, 4);
            amountPanel.Name = "amountPanel";
            amountPanel.Padding = new Padding(17, 13, 17, 13);
            amountPanel.Size = new Size(674, 67);
            amountPanel.TabIndex = 2;
            // 
            // lblCurrency
            // 
            lblCurrency.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCurrency.ForeColor = Color.Gray;
            lblCurrency.Location = new Point(589, 17);
            lblCurrency.Name = "lblCurrency";
            lblCurrency.Size = new Size(69, 40);
            lblCurrency.TabIndex = 1;
            lblCurrency.Text = "VND";
            lblCurrency.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtAmount
            // 
            txtAmount.BackColor = Color.FromArgb(245, 245, 245);
            txtAmount.BorderStyle = BorderStyle.None;
            txtAmount.Font = new Font("Segoe UI", 12F);
            txtAmount.Location = new Point(17, 17);
            txtAmount.Margin = new Padding(3, 4, 3, 4);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(560, 27);
            txtAmount.TabIndex = 0;
            txtAmount.Text = "0";
            // 
            // lblAmount
            // 
            lblAmount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAmount.ForeColor = Color.FromArgb(50, 50, 50);
            lblAmount.Location = new Point(34, 120);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(674, 33);
            lblAmount.TabIndex = 1;
            lblAmount.Text = "Số tiền";
            // 
            // typePanel
            // 
            typePanel.Controls.Add(btnIncome);
            typePanel.Controls.Add(btnExpense);
            typePanel.Location = new Point(34, 27);
            typePanel.Margin = new Padding(3, 4, 3, 4);
            typePanel.Name = "typePanel";
            typePanel.Size = new Size(674, 67);
            typePanel.TabIndex = 0;
            // 
            // btnIncome
            // 
            btnIncome.BackColor = Color.White;
            btnIncome.Cursor = Cursors.Hand;
            btnIncome.FlatAppearance.BorderColor = Color.LightGray;
            btnIncome.FlatStyle = FlatStyle.Flat;
            btnIncome.Font = new Font("Segoe UI", 11F);
            btnIncome.ForeColor = Color.Gray;
            btnIncome.Location = new Point(343, 0);
            btnIncome.Margin = new Padding(3, 4, 3, 4);
            btnIncome.Name = "btnIncome";
            btnIncome.Size = new Size(331, 67);
            btnIncome.TabIndex = 1;
            btnIncome.Text = "💰  Thu nhập";
            btnIncome.UseVisualStyleBackColor = false;
            btnIncome.Click += BtnIncome_Click;
            // 
            // btnExpense
            // 
            btnExpense.BackColor = Color.FromArgb(101, 109, 255);
            btnExpense.Cursor = Cursors.Hand;
            btnExpense.FlatAppearance.BorderSize = 0;
            btnExpense.FlatStyle = FlatStyle.Flat;
            btnExpense.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExpense.ForeColor = Color.White;
            btnExpense.Location = new Point(0, 0);
            btnExpense.Margin = new Padding(3, 4, 3, 4);
            btnExpense.Name = "btnExpense";
            btnExpense.Size = new Size(331, 67);
            btnExpense.TabIndex = 0;
            btnExpense.Text = "💸  Chi tiêu";
            btnExpense.UseVisualStyleBackColor = false;
            btnExpense.Click += BtnExpense_Click;
            // 
            // AddTransactionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(743, 1000);
            Controls.Add(contentPanel);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddTransactionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm giao dịch";
            //Load += AddTransactionForm_Load;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            amountPanel.ResumeLayout(false);
            amountPanel.PerformLayout();
            typePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private FontAwesome.Sharp.IconButton btnClose;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel typePanel;
        private System.Windows.Forms.Button btnExpense;
        private System.Windows.Forms.Button btnIncome;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Panel amountPanel;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.FlowLayoutPanel categoryFlowPanel;
        private System.Windows.Forms.Label lblWallet;
        private System.Windows.Forms.ComboBox cmbWallet;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpTransaction;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSubmit;
    }
}