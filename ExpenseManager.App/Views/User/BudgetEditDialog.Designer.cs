namespace ExpenseManager.App.Views.User
{
    partial class BudgetEditDialog
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
            this.cancelBtn = new FontAwesome.Sharp.IconButton();
            this.addBtn = new FontAwesome.Sharp.IconButton();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.YearRadioBtn = new System.Windows.Forms.RadioButton();
            this.tMonthRadioBtn = new System.Windows.Forms.RadioButton();
            this.monthRadioBtn = new System.Windows.Forms.RadioButton();
            this.weekRadioBtn = new System.Windows.Forms.RadioButton();
            this.monetTxtBox = new System.Windows.Forms.TextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.toDateTxt = new System.Windows.Forms.Label();
            this.fromDateTxt = new System.Windows.Forms.Label();
            this.TimePickerTxt = new System.Windows.Forms.Label();
            this.MoneyTxt = new System.Windows.Forms.Label();
            this.CategoriesPickerTxt = new System.Windows.Forms.Label();
            this.EditBudgetTitle = new System.Windows.Forms.Label();
            this.isRecurringChckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.White;
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.cancelBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.cancelBtn.IconColor = System.Drawing.Color.Black;
            this.cancelBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.cancelBtn.Location = new System.Drawing.Point(426, 521);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(131, 42);
            this.cancelBtn.TabIndex = 31;
            this.cancelBtn.Text = "Hủy";
            this.cancelBtn.UseVisualStyleBackColor = false;
            // 
            // addBtn (Nút Lưu)
            // 
            this.addBtn.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.addBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.addBtn.ForeColor = System.Drawing.Color.White;
            this.addBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.addBtn.IconColor = System.Drawing.Color.White;
            this.addBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.addBtn.Location = new System.Drawing.Point(250, 521);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(160, 42);
            this.addBtn.TabIndex = 30;
            this.addBtn.Text = "Lưu Ngân Sách";
            this.addBtn.UseVisualStyleBackColor = false;
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDateTimePicker.Location = new System.Drawing.Point(362, 426);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(195, 30);
            this.toDateTimePicker.TabIndex = 29;
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.fromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDateTimePicker.Location = new System.Drawing.Point(98, 424);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(208, 30);
            this.fromDateTimePicker.TabIndex = 28;
            // 
            // YearRadioBtn
            // 
            this.YearRadioBtn.AutoSize = true;
            this.YearRadioBtn.Location = new System.Drawing.Point(483, 371);
            this.YearRadioBtn.Name = "YearRadioBtn";
            this.YearRadioBtn.Size = new System.Drawing.Size(74, 24);
            this.YearRadioBtn.TabIndex = 27;
            this.YearRadioBtn.Text = "1 Năm";
            this.YearRadioBtn.UseVisualStyleBackColor = true;
            // 
            // tMonthRadioBtn
            // 
            this.tMonthRadioBtn.AutoSize = true;
            this.tMonthRadioBtn.Location = new System.Drawing.Point(337, 371);
            this.tMonthRadioBtn.Name = "tMonthRadioBtn";
            this.tMonthRadioBtn.Size = new System.Drawing.Size(83, 24);
            this.tMonthRadioBtn.TabIndex = 26;
            this.tMonthRadioBtn.Text = "3 Tháng";
            this.tMonthRadioBtn.UseVisualStyleBackColor = true;
            // 
            // monthRadioBtn
            // 
            this.monthRadioBtn.AutoSize = true;
            this.monthRadioBtn.Location = new System.Drawing.Point(192, 371);
            this.monthRadioBtn.Name = "monthRadioBtn";
            this.monthRadioBtn.Size = new System.Drawing.Size(83, 24);
            this.monthRadioBtn.TabIndex = 25;
            this.monthRadioBtn.Text = "1 Tháng";
            this.monthRadioBtn.UseVisualStyleBackColor = true;
            // 
            // weekRadioBtn
            // 
            this.weekRadioBtn.AutoSize = true;
            this.weekRadioBtn.Location = new System.Drawing.Point(60, 371);
            this.weekRadioBtn.Name = "weekRadioBtn";
            this.weekRadioBtn.Size = new System.Drawing.Size(74, 24);
            this.weekRadioBtn.TabIndex = 24;
            this.weekRadioBtn.Text = "1 Tuần";
            this.weekRadioBtn.UseVisualStyleBackColor = true;
            // 
            // monetTxtBox
            // 
            this.monetTxtBox.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.monetTxtBox.Location = new System.Drawing.Point(60, 252);
            this.monetTxtBox.Name = "monetTxtBox";
            this.monetTxtBox.Size = new System.Drawing.Size(415, 32);
            this.monetTxtBox.TabIndex = 23;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.Location = new System.Drawing.Point(60, 137);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(415, 28);
            this.categoryComboBox.TabIndex = 22;
            this.categoryComboBox.Visible = false; // Ẩn để dùng Grid
            // 
            // toDateTxt
            // 
            this.toDateTxt.AutoSize = true;
            this.toDateTxt.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.toDateTxt.Location = new System.Drawing.Point(312, 426);
            this.toDateTxt.Name = "toDateTxt";
            this.toDateTxt.Size = new System.Drawing.Size(44, 25);
            this.toDateTxt.TabIndex = 21;
            this.toDateTxt.Text = "Đến";
            // 
            // fromDateTxt
            // 
            this.fromDateTxt.AutoSize = true;
            this.fromDateTxt.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.fromDateTxt.Location = new System.Drawing.Point(60, 424);
            this.fromDateTxt.Name = "fromDateTxt";
            this.fromDateTxt.Size = new System.Drawing.Size(32, 25);
            this.fromDateTxt.TabIndex = 20;
            this.fromDateTxt.Text = "Từ";
            // 
            // TimePickerTxt
            // 
            this.TimePickerTxt.AutoSize = true;
            this.TimePickerTxt.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.TimePickerTxt.Location = new System.Drawing.Point(60, 306);
            this.TimePickerTxt.Name = "TimePickerTxt";
            this.TimePickerTxt.Size = new System.Drawing.Size(194, 25);
            this.TimePickerTxt.TabIndex = 19;
            this.TimePickerTxt.Text = "Chọn khoảng thời gian";
            // 
            // MoneyTxt
            // 
            this.MoneyTxt.AutoSize = true;
            this.MoneyTxt.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.MoneyTxt.Location = new System.Drawing.Point(60, 203);
            this.MoneyTxt.Name = "MoneyTxt";
            this.MoneyTxt.Size = new System.Drawing.Size(67, 25);
            this.MoneyTxt.TabIndex = 18;
            this.MoneyTxt.Text = "Số tiền";
            // 
            // CategoriesPickerTxt
            // 
            this.CategoriesPickerTxt.AutoSize = true;
            this.CategoriesPickerTxt.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.CategoriesPickerTxt.Location = new System.Drawing.Point(60, 91);
            this.CategoriesPickerTxt.Name = "CategoriesPickerTxt";
            this.CategoriesPickerTxt.Size = new System.Drawing.Size(140, 25);
            this.CategoriesPickerTxt.TabIndex = 17;
            this.CategoriesPickerTxt.Text = "Categories";
            // 
            // EditBudgetTitle
            // 
            this.EditBudgetTitle.AutoSize = true;
            this.EditBudgetTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.EditBudgetTitle.Location = new System.Drawing.Point(45, 22);
            this.EditBudgetTitle.Name = "EditBudgetTitle";
            this.EditBudgetTitle.Size = new System.Drawing.Size(320, 38);
            this.EditBudgetTitle.TabIndex = 16;
            this.EditBudgetTitle.Text = "Chỉnh Sửa Ngân Sách";
            // 
            // isRecurringChckBox
            // 
            this.isRecurringChckBox.AutoSize = true;
            this.isRecurringChckBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.isRecurringChckBox.Location = new System.Drawing.Point(60, 467);
            this.isRecurringChckBox.Name = "isRecurringChckBox";
            this.isRecurringChckBox.Size = new System.Drawing.Size(175, 27);
            this.isRecurringChckBox.TabIndex = 32;
            this.isRecurringChckBox.Text = "Lặp lại theo chu kỳ";
            this.isRecurringChckBox.UseVisualStyleBackColor = true;
            // 
            // BudgetEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(603, 588);
            this.Controls.Add(this.isRecurringChckBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.toDateTimePicker);
            this.Controls.Add(this.fromDateTimePicker);
            this.Controls.Add(this.YearRadioBtn);
            this.Controls.Add(this.tMonthRadioBtn);
            this.Controls.Add(this.monthRadioBtn);
            this.Controls.Add(this.weekRadioBtn);
            this.Controls.Add(this.monetTxtBox);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.toDateTxt);
            this.Controls.Add(this.fromDateTxt);
            this.Controls.Add(this.TimePickerTxt);
            this.Controls.Add(this.MoneyTxt);
            this.Controls.Add(this.CategoriesPickerTxt);
            this.Controls.Add(this.EditBudgetTitle);
            this.Name = "BudgetEditDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chỉnh sửa ngân sách";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton cancelBtn;
        private FontAwesome.Sharp.IconButton addBtn;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.RadioButton YearRadioBtn;
        private System.Windows.Forms.RadioButton tMonthRadioBtn;
        private System.Windows.Forms.RadioButton monthRadioBtn;
        private System.Windows.Forms.RadioButton weekRadioBtn;
        private System.Windows.Forms.TextBox monetTxtBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label toDateTxt;
        private System.Windows.Forms.Label fromDateTxt;
        private System.Windows.Forms.Label TimePickerTxt;
        private System.Windows.Forms.Label MoneyTxt;
        private System.Windows.Forms.Label CategoriesPickerTxt;
        private System.Windows.Forms.Label EditBudgetTitle;
        private System.Windows.Forms.CheckBox isRecurringChckBox;
    }
}