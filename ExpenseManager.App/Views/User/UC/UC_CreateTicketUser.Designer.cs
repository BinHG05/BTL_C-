using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace ExpenseManager.App.Views.User.UC
{
    partial class UC_CreateTicketUser
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            mainPanel = new Panel();
            contentPanel = new Panel();
            buttonPanel = new Panel();
            btnCancel = new IconButton();
            btnCreate = new IconButton();
            txtDescription = new TextBox();
            lblDescription = new Label();
            cmbType = new ComboBox();
            lblType = new Label();
            headerPanel = new Panel();
            lblTitle = new Label();
            mainPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            buttonPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(245, 245, 245);
            mainPanel.Controls.Add(contentPanel);
            mainPanel.Controls.Add(headerPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(34, 40, 34, 40);
            mainPanel.Size = new Size(1143, 800);
            mainPanel.TabIndex = 0;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.White;
            contentPanel.Controls.Add(buttonPanel);
            contentPanel.Controls.Add(txtDescription);
            contentPanel.Controls.Add(lblDescription);
            contentPanel.Controls.Add(cmbType);
            contentPanel.Controls.Add(lblType);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(34, 133);
            contentPanel.Margin = new Padding(3, 4, 3, 4);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(34, 40, 34, 40);
            contentPanel.Size = new Size(1075, 627);
            contentPanel.TabIndex = 1;
            // 
            // buttonPanel
            // 
            buttonPanel.Controls.Add(btnCancel);
            buttonPanel.Controls.Add(btnCreate);
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Location = new Point(34, 520);
            buttonPanel.Margin = new Padding(3, 4, 3, 4);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(1007, 67);
            buttonPanel.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(220, 53, 69);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.IconChar = IconChar.Close;
            btnCancel.IconColor = Color.White;
            btnCancel.IconFont = IconFont.Auto;
            btnCancel.IconSize = 20;
            btnCancel.Location = new Point(217, 7);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(171, 53);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(101, 109, 255);
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCreate.ForeColor = Color.White;
            btnCreate.IconChar = IconChar.Check;
            btnCreate.IconColor = Color.White;
            btnCreate.IconFont = IconFont.Auto;
            btnCreate.IconSize = 20;
            btnCreate.Location = new Point(23, 7);
            btnCreate.Margin = new Padding(3, 4, 3, 4);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(171, 53);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "Create";
            btnCreate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += BtnCreate_Click;
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescription.Location = new Point(32, 230);
            txtDescription.Margin = new Padding(3, 4, 3, 4);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Nhập mô tả chi tiết vấn đề của bạn...";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(1006, 253);
            txtDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescription.ForeColor = Color.Black;
            lblDescription.Location = new Point(34, 166);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(175, 38);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Description:";
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.Font = new Font("Segoe UI", 10F);
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(34, 94);
            cmbType.Margin = new Padding(3, 4, 3, 4);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(395, 31);
            cmbType.TabIndex = 1;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblType.ForeColor = Color.Black;
            lblType.Location = new Point(34, 33);
            lblType.Name = "lblType";
            lblType.Size = new Size(87, 38);
            lblType.TabIndex = 0;
            lblType.Text = "Type:";
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.Transparent;
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(34, 40);
            headerPanel.Margin = new Padding(3, 4, 3, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1075, 93);
            headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(0, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(327, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Create Support Ticket";
            // 
            // UC_CreateTicketUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_CreateTicketUser";
            Size = new Size(1143, 800);
            mainPanel.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            buttonPanel.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Panel buttonPanel;
        private FontAwesome.Sharp.IconButton btnCreate;
        private FontAwesome.Sharp.IconButton btnCancel;
    }
}