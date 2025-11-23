using System.Drawing;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.Admin.Forms
{
    partial class AddColorForm
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
            this.lblTitle = new Label();
            this.lblColorName = new Label();
            this.txtColorName = new TextBox();
            this.lblHexCode = new Label();
            this.txtHexCode = new TextBox();
            this.lblPreview = new Label();
            this.colorPreview = new Panel();
            this.btnChooseColor = new Button();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(150, 25);
            this.lblTitle.Text = "Thêm màu mới";

            // lblColorName
            this.lblColorName.AutoSize = true;
            this.lblColorName.Font = new Font("Segoe UI", 10F);
            this.lblColorName.Location = new Point(20, 70);
            this.lblColorName.Name = "lblColorName";
            this.lblColorName.Size = new Size(100, 19);
            this.lblColorName.Text = "Tên màu:";

            // txtColorName
            this.txtColorName.Font = new Font("Segoe UI", 10F);
            this.txtColorName.Location = new Point(20, 95);
            this.txtColorName.Name = "txtColorName";
            this.txtColorName.Size = new Size(360, 25);
            this.txtColorName.PlaceholderText = "VD: Đỏ, Xanh dương,...";

            // lblHexCode
            this.lblHexCode.AutoSize = true;
            this.lblHexCode.Font = new Font("Segoe UI", 10F);
            this.lblHexCode.Location = new Point(20, 135);
            this.lblHexCode.Name = "lblHexCode";
            this.lblHexCode.Size = new Size(100, 19);
            this.lblHexCode.Text = "Mã Hex:";

            // txtHexCode
            this.txtHexCode.Font = new Font("Segoe UI", 10F);
            this.txtHexCode.Location = new Point(20, 160);
            this.txtHexCode.Name = "txtHexCode";
            this.txtHexCode.Size = new Size(250, 25);
            this.txtHexCode.PlaceholderText = "VD: #ef4444";
            this.txtHexCode.TextChanged += TxtHexCode_TextChanged;

            // btnChooseColor
            this.btnChooseColor.BackColor = Color.FromArgb(108, 117, 125);
            this.btnChooseColor.FlatStyle = FlatStyle.Flat;
            this.btnChooseColor.Font = new Font("Segoe UI", 9F);
            this.btnChooseColor.ForeColor = Color.White;
            this.btnChooseColor.Location = new Point(280, 160);
            this.btnChooseColor.Name = "btnChooseColor";
            this.btnChooseColor.Size = new Size(100, 25);
            this.btnChooseColor.Text = "Chọn màu";
            this.btnChooseColor.UseVisualStyleBackColor = false;
            this.btnChooseColor.Click += BtnChooseColor_Click;

            // lblPreview
            this.lblPreview.AutoSize = true;
            this.lblPreview.Font = new Font("Segoe UI", 10F);
            this.lblPreview.Location = new Point(20, 200);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new Size(100, 19);
            this.lblPreview.Text = "Xem trước:";

            // colorPreview
            this.colorPreview.BackColor = Color.White;
            this.colorPreview.BorderStyle = BorderStyle.FixedSingle;
            this.colorPreview.Location = new Point(20, 225);
            this.colorPreview.Name = "colorPreview";
            this.colorPreview.Size = new Size(60, 60);

            // btnSave
            this.btnSave.BackColor = Color.FromArgb(0, 123, 255);
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(200, 310);
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
            this.btnCancel.Location = new Point(290, 310);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(90, 35);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            // AddColorForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, 370);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.colorPreview);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.btnChooseColor);
            this.Controls.Add(this.txtHexCode);
            this.Controls.Add(this.lblHexCode);
            this.Controls.Add(this.txtColorName);
            this.Controls.Add(this.lblColorName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddColorForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Thêm Màu";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblColorName;
        private TextBox txtColorName;
        private Label lblHexCode;
        private TextBox txtHexCode;
        private Label lblPreview;
        private Panel colorPreview;
        private Button btnChooseColor;
        private Button btnSave;
        private Button btnCancel;
    }
}