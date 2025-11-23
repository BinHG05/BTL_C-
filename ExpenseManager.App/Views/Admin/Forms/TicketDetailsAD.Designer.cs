using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace ExpenseManager.App.Views.Admin.Forms
{
    partial class TicketDetailsAD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            headerPanel = new Panel();
            btnCloseX = new IconButton();
            lblTitle = new Label();
            mainPanel = new Panel();
            footerPanel = new Panel();
            btnClose = new Button();
            btnSave = new Button();
            contentPanel = new Panel();
            lblUpdatedValue = new Label();
            lblUpdated = new Label();
            lblCreatedValue = new Label();
            lblCreated = new Label();
            txtAdminNote = new TextBox();
            lblAdminNote = new Label();
            panel2 = new Panel();
            lblStatusValue = new Label();
            cboStatus = new ComboBox();
            lblStatus = new Label();
            lblQuestionTypeValue = new Label();
            lblQuestionType = new Label();
            panel1 = new Panel();
            lblQuestionValue = new Label();
            lblQuestion = new Label();
            lblEmailValue = new Label();
            lblEmail = new Label();
            lblUserNameValue = new Label();
            lblUserName = new Label();
            headerPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            footerPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.White;
            headerPanel.Controls.Add(btnCloseX);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(3, 4, 3, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(766, 80);
            headerPanel.TabIndex = 0;
            headerPanel.MouseDown += HeaderPanel_MouseDown;
            headerPanel.MouseMove += HeaderPanel_MouseMove;
            headerPanel.MouseUp += HeaderPanel_MouseUp;
            // 
            // btnCloseX
            // 
            btnCloseX.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCloseX.BackColor = Color.Transparent;
            btnCloseX.FlatAppearance.BorderSize = 0;
            btnCloseX.FlatStyle = FlatStyle.Flat;
            btnCloseX.IconChar = IconChar.Close;
            btnCloseX.IconColor = Color.Gray;
            btnCloseX.IconFont = IconFont.Auto;
            btnCloseX.IconSize = 24;
            btnCloseX.Location = new Point(720, 20);
            btnCloseX.Margin = new Padding(3, 4, 3, 4);
            btnCloseX.Name = "btnCloseX";
            btnCloseX.Size = new Size(34, 40);
            btnCloseX.TabIndex = 1;
            btnCloseX.UseVisualStyleBackColor = false;
            btnCloseX.Click += BtnCloseX_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(34, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(235, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Chi tiết yêu cầu";
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.White;
            mainPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(footerPanel);
            mainPanel.Controls.Add(contentPanel);
            mainPanel.Controls.Add(headerPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(768, 860);
            mainPanel.TabIndex = 1;
            // 
            // footerPanel
            // 
            footerPanel.BackColor = Color.FromArgb(248, 249, 250);
            footerPanel.Controls.Add(btnClose);
            footerPanel.Controls.Add(btnSave);
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Location = new Point(0, 771);
            footerPanel.Margin = new Padding(3, 4, 3, 4);
            footerPanel.Name = "footerPanel";
            footerPanel.Padding = new Padding(34, 20, 34, 20);
            footerPanel.Size = new Size(766, 87);
            footerPanel.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(108, 117, 125);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(629, 20);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(103, 47);
            btnClose.TabIndex = 1;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(25, 135, 84);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(503, 20);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(103, 47);
            btnSave.TabIndex = 0;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.White;
            contentPanel.Controls.Add(lblUpdatedValue);
            contentPanel.Controls.Add(lblUpdated);
            contentPanel.Controls.Add(lblCreatedValue);
            contentPanel.Controls.Add(lblCreated);
            contentPanel.Controls.Add(txtAdminNote);
            contentPanel.Controls.Add(lblAdminNote);
            contentPanel.Controls.Add(panel2);
            contentPanel.Controls.Add(panel1);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 80);
            contentPanel.Margin = new Padding(3, 4, 3, 4);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(34, 27, 34, 27);
            contentPanel.Size = new Size(766, 778);
            contentPanel.TabIndex = 1;
            // 
            // lblUpdatedValue
            // 
            lblUpdatedValue.AutoSize = true;
            lblUpdatedValue.Font = new Font("Segoe UI", 9.5F);
            lblUpdatedValue.ForeColor = Color.Gray;
            lblUpdatedValue.Location = new Point(455, 707);
            lblUpdatedValue.Name = "lblUpdatedValue";
            lblUpdatedValue.Size = new Size(38, 21);
            lblUpdatedValue.TabIndex = 15;
            lblUpdatedValue.Text = "N/A";
            // 
            // lblUpdated
            // 
            lblUpdated.AutoSize = true;
            lblUpdated.Font = new Font("Segoe UI", 9.5F);
            lblUpdated.ForeColor = Color.Gray;
            lblUpdated.Location = new Point(369, 707);
            lblUpdated.Name = "lblUpdated";
            lblUpdated.Size = new Size(72, 21);
            lblUpdated.TabIndex = 14;
            lblUpdated.Text = "Updated:";
            // 
            // lblCreatedValue
            // 
            lblCreatedValue.AutoSize = true;
            lblCreatedValue.Font = new Font("Segoe UI", 9.5F);
            lblCreatedValue.ForeColor = Color.Gray;
            lblCreatedValue.Location = new Point(126, 707);
            lblCreatedValue.Name = "lblCreatedValue";
            lblCreatedValue.Size = new Size(158, 21);
            lblCreatedValue.TabIndex = 13;
            lblCreatedValue.Text = "23:14:29 16/11/2025";
            // 
            // lblCreated
            // 
            lblCreated.AutoSize = true;
            lblCreated.Font = new Font("Segoe UI", 9.5F);
            lblCreated.ForeColor = Color.Gray;
            lblCreated.Location = new Point(40, 707);
            lblCreated.Name = "lblCreated";
            lblCreated.Size = new Size(67, 21);
            lblCreated.TabIndex = 12;
            lblCreated.Text = "Created:";
            // 
            // txtAdminNote
            // 
            txtAdminNote.BorderStyle = BorderStyle.FixedSingle;
            txtAdminNote.Font = new Font("Segoe UI", 10F);
            txtAdminNote.Location = new Point(40, 493);
            txtAdminNote.Margin = new Padding(3, 4, 3, 4);
            txtAdminNote.Multiline = true;
            txtAdminNote.Name = "txtAdminNote";
            txtAdminNote.ScrollBars = ScrollBars.Vertical;
            txtAdminNote.Size = new Size(685, 159);
            txtAdminNote.TabIndex = 11;
            // 
            // lblAdminNote
            // 
            lblAdminNote.AutoSize = true;
            lblAdminNote.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAdminNote.ForeColor = Color.FromArgb(13, 110, 253);
            lblAdminNote.Location = new Point(40, 447);
            lblAdminNote.Name = "lblAdminNote";
            lblAdminNote.Size = new Size(222, 25);
            lblAdminNote.TabIndex = 10;
            lblAdminNote.Text = "Ghi chú từ quản trị viên";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblStatusValue);
            panel2.Controls.Add(cboStatus);
            panel2.Controls.Add(lblStatus);
            panel2.Controls.Add(lblQuestionTypeValue);
            panel2.Controls.Add(lblQuestionType);
            panel2.Location = new Point(40, 307);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(686, 107);
            panel2.TabIndex = 9;
            // 
            // lblStatusValue
            // 
            lblStatusValue.BackColor = Color.FromArgb(207, 244, 252);
            lblStatusValue.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStatusValue.ForeColor = Color.FromArgb(1, 87, 155);
            lblStatusValue.Location = new Point(369, 53);
            lblStatusValue.Name = "lblStatusValue";
            lblStatusValue.Size = new Size(114, 33);
            lblStatusValue.TabIndex = 8;
            lblStatusValue.Text = "Open";
            lblStatusValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Font = new Font("Segoe UI", 10F);
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Mở",
            "Đang xử lí",
            "Đã xử lí" });
            cboStatus.Location = new Point(369, 9);
            cboStatus.Margin = new Padding(3, 4, 3, 4);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(285, 31);
            cboStatus.TabIndex = 7;
            cboStatus.SelectedIndexChanged += CboStatus_SelectedIndexChanged;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(13, 110, 253);
            lblStatus.Location = new Point(369, -27);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(67, 25);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Status";
            // 
            // lblQuestionTypeValue
            // 
            lblQuestionTypeValue.AutoSize = true;
            lblQuestionTypeValue.BorderStyle = BorderStyle.FixedSingle;
            lblQuestionTypeValue.Font = new Font("Segoe UI", 10F);
            lblQuestionTypeValue.ForeColor = Color.FromArgb(73, 80, 87);
            lblQuestionTypeValue.Location = new Point(6, 40);
            lblQuestionTypeValue.Name = "lblQuestionTypeValue";
            lblQuestionTypeValue.Size = new Size(135, 25);
            lblQuestionTypeValue.TabIndex = 5;
            lblQuestionTypeValue.Text = "Feature Request";
            // 
            // lblQuestionType
            // 
            lblQuestionType.AutoSize = true;
            lblQuestionType.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblQuestionType.ForeColor = Color.FromArgb(13, 110, 253);
            lblQuestionType.Location = new Point(6, 7);
            lblQuestionType.Name = "lblQuestionType";
            lblQuestionType.Size = new Size(118, 25);
            lblQuestionType.TabIndex = 4;
            lblQuestionType.Text = "Loại câu hỏi";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblQuestionValue);
            panel1.Controls.Add(lblQuestion);
            panel1.Controls.Add(lblEmailValue);
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(lblUserNameValue);
            panel1.Controls.Add(lblUserName);
            panel1.Location = new Point(40, 27);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(686, 240);
            panel1.TabIndex = 0;
            // 
            // lblQuestionValue
            // 
            lblQuestionValue.BorderStyle = BorderStyle.FixedSingle;
            lblQuestionValue.Font = new Font("Segoe UI", 10F);
            lblQuestionValue.ForeColor = Color.FromArgb(73, 80, 87);
            lblQuestionValue.Location = new Point(6, 147);
            lblQuestionValue.Name = "lblQuestionValue";
            lblQuestionValue.Size = new Size(669, 80);
            lblQuestionValue.TabIndex = 5;
            lblQuestionValue.Text = "test 5";
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblQuestion.ForeColor = Color.FromArgb(13, 110, 253);
            lblQuestion.Location = new Point(6, 113);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(64, 25);
            lblQuestion.TabIndex = 4;
            lblQuestion.Text = "Mô tả";
            // 
            // lblEmailValue
            // 
            lblEmailValue.AutoSize = true;
            lblEmailValue.BorderStyle = BorderStyle.FixedSingle;
            lblEmailValue.Font = new Font("Segoe UI", 10F);
            lblEmailValue.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmailValue.Location = new Point(369, 40);
            lblEmailValue.Name = "lblEmailValue";
            lblEmailValue.Size = new Size(228, 25);
            lblEmailValue.TabIndex = 3;
            lblEmailValue.Text = "auduongtan321@gmail.com";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(13, 110, 253);
            lblEmail.Location = new Point(369, 7);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(59, 25);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            // 
            // lblUserNameValue
            // 
            lblUserNameValue.AutoSize = true;
            lblUserNameValue.BorderStyle = BorderStyle.FixedSingle;
            lblUserNameValue.Font = new Font("Segoe UI", 10F);
            lblUserNameValue.ForeColor = Color.FromArgb(73, 80, 87);
            lblUserNameValue.Location = new Point(6, 40);
            lblUserNameValue.Name = "lblUserNameValue";
            lblUserNameValue.Size = new Size(123, 25);
            lblUserNameValue.TabIndex = 1;
            lblUserNameValue.Text = "Âu Dương Tấn";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblUserName.ForeColor = Color.FromArgb(13, 110, 253);
            lblUserName.Location = new Point(6, 7);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(155, 25);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "Tên người dùng";
            // 
            // TicketDetailsAD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(768, 860);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "TicketDetailsAD";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ticket Details";
            Load += TicketDetailsAD_Load;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            mainPanel.ResumeLayout(false);
            footerPanel.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private FontAwesome.Sharp.IconButton btnCloseX;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserNameValue;
        private System.Windows.Forms.Label lblEmailValue;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblQuestionValue;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblQuestionTypeValue;
        private System.Windows.Forms.Label lblQuestionType;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblAdminNote;
        private System.Windows.Forms.TextBox txtAdminNote;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.Label lblCreatedValue;
        private System.Windows.Forms.Label lblUpdated;
        private System.Windows.Forms.Label lblUpdatedValue;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}