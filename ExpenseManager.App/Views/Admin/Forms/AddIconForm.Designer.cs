using System.Drawing;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.Admin.Forms
{
    partial class AddIconForm
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
            this.lblTitle = new Label();
            this.lblIconName = new Label();
            this.txtIconName = new TextBox();
            this.lblIconClass = new Label();
            this.txtIconClass = new TextBox();
            this.lblExample = new Label();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(150, 25);
            this.lblTitle.Text = "Thêm biểu tượng mới";

            // lblIconName
            this.lblIconName.AutoSize = true;
            this.lblIconName.Font = new Font("Segoe UI", 10F);
            this.lblIconName.Location = new Point(20, 70);
            this.lblIconName.Name = "lblIconName";
            this.lblIconName.Size = new Size(100, 19);
            this.lblIconName.Text = "Tên biểu tượng:";

            // txtIconName
            this.txtIconName.Font = new Font("Segoe UI", 10F);
            this.txtIconName.Location = new Point(20, 95);
            this.txtIconName.Name = "txtIconName";
            this.txtIconName.Size = new Size(360, 25);
            this.txtIconName.PlaceholderText = "VD: Ăn uống";

            // lblIconClass
            this.lblIconClass.AutoSize = true;
            this.lblIconClass.Font = new Font("Segoe UI", 10F);
            this.lblIconClass.Location = new Point(20, 135);
            this.lblIconClass.Name = "lblIconClass";
            this.lblIconClass.Size = new Size(150, 19);
            this.lblIconClass.Text = "FontAwesome Class:";

            // txtIconClass
            this.txtIconClass.Font = new Font("Segoe UI", 10F);
            this.txtIconClass.Location = new Point(20, 160);
            this.txtIconClass.Name = "txtIconClass";
            this.txtIconClass.Size = new Size(360, 25);
            this.txtIconClass.PlaceholderText = "VD: fa-solid fa-utensils";

            // lblExample
            this.lblExample.Font = new Font("Segoe UI", 8.5F);
            this.lblExample.ForeColor = Color.Gray;
            this.lblExample.Location = new Point(20, 190);
            this.lblExample.Name = "lblExample";
            this.lblExample.Size = new Size(360, 40);
            this.lblExample.Text = "Tìm biểu tượng tại: https://fontawesome.com/icons\nFormat: fa-solid fa-[icon-name]";

            // btnSave
            this.btnSave.BackColor = Color.FromArgb(0, 123, 255);
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(200, 240);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(90, 35);
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += BtnSave_Click;

            // btnCancel
            this.btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(290, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(90, 35);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            // AddIconForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, 300);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblExample);
            this.Controls.Add(this.txtIconClass);
            this.Controls.Add(this.lblIconClass);
            this.Controls.Add(this.txtIconName);
            this.Controls.Add(this.lblIconName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddIconForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Thêm biểu tượng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblIconName;
        private TextBox txtIconName;
        private Label lblIconClass;
        private TextBox txtIconClass;
        private Label lblExample;
        private Button btnSave;
        private Button btnCancel;
    }
}