namespace ExpenseManager.App.Views.User
{
    partial class BudgetEditDialog
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
            cancelBtn = new FontAwesome.Sharp.IconButton();
            addBtn = new FontAwesome.Sharp.IconButton();
            toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            YearRadioBtn = new System.Windows.Forms.RadioButton();
            tMonthRadioBtn = new System.Windows.Forms.RadioButton();
            monthRadioBtn = new System.Windows.Forms.RadioButton();
            weekRadioBtn = new System.Windows.Forms.RadioButton();
            monetTxtBox = new System.Windows.Forms.TextBox();
            categoryComboBox = new System.Windows.Forms.ComboBox();
            toDateTxt = new System.Windows.Forms.Label();
            fromDateTxt = new System.Windows.Forms.Label();
            TimePickerTxt = new System.Windows.Forms.Label();
            MoneyTxt = new System.Windows.Forms.Label();
            CategoriesPickerTxt = new System.Windows.Forms.Label();
            EditBudgetTitle = new System.Windows.Forms.Label();
            isRecurringChckBox = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // cancelBtn
            // 
            cancelBtn.BackColor = System.Drawing.Color.White;
            cancelBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            cancelBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            cancelBtn.IconColor = System.Drawing.Color.Black;
            cancelBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            cancelBtn.Location = new System.Drawing.Point(426, 521);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new System.Drawing.Size(131, 42);
            cancelBtn.TabIndex = 31;
            cancelBtn.Text = "Hủy";
            cancelBtn.UseVisualStyleBackColor = false;
            // 
            // addBtn
            // 
            addBtn.BackColor = System.Drawing.SystemColors.Highlight;
            addBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            addBtn.ForeColor = System.Drawing.Color.White;
            addBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            addBtn.IconColor = System.Drawing.Color.White;
            addBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            addBtn.Location = new System.Drawing.Point(269, 521);
            addBtn.Name = "addBtn";
            addBtn.Size = new System.Drawing.Size(124, 42);
            addBtn.TabIndex = 30;
            addBtn.Text = "Thêm";
            addBtn.UseVisualStyleBackColor = false;
            // 
            // toDateTimePicker
            // 
            toDateTimePicker.Location = new System.Drawing.Point(362, 426);
            toDateTimePicker.Name = "toDateTimePicker";
            toDateTimePicker.Size = new System.Drawing.Size(195, 27);
            toDateTimePicker.TabIndex = 29;
            // 
            // fromDateTimePicker
            // 
            fromDateTimePicker.Location = new System.Drawing.Point(98, 424);
            fromDateTimePicker.Name = "fromDateTimePicker";
            fromDateTimePicker.Size = new System.Drawing.Size(208, 27);
            fromDateTimePicker.TabIndex = 28;
            // 
            // YearRadioBtn
            // 
            YearRadioBtn.AutoSize = true;
            YearRadioBtn.Location = new System.Drawing.Point(483, 371);
            YearRadioBtn.Name = "YearRadioBtn";
            YearRadioBtn.Size = new System.Drawing.Size(74, 24);
            YearRadioBtn.TabIndex = 27;
            YearRadioBtn.TabStop = true;
            YearRadioBtn.Text = "1 Năm";
            YearRadioBtn.UseVisualStyleBackColor = true;
            // 
            // tMonthRadioBtn
            // 
            tMonthRadioBtn.AutoSize = true;
            tMonthRadioBtn.Location = new System.Drawing.Point(337, 371);
            tMonthRadioBtn.Name = "tMonthRadioBtn";
            tMonthRadioBtn.Size = new System.Drawing.Size(83, 24);
            tMonthRadioBtn.TabIndex = 26;
            tMonthRadioBtn.TabStop = true;
            tMonthRadioBtn.Text = "3 Tháng";
            tMonthRadioBtn.UseVisualStyleBackColor = true;
            // 
            // monthRadioBtn
            // 
            monthRadioBtn.AutoSize = true;
            monthRadioBtn.Location = new System.Drawing.Point(192, 371);
            monthRadioBtn.Name = "monthRadioBtn";
            monthRadioBtn.Size = new System.Drawing.Size(83, 24);
            monthRadioBtn.TabIndex = 25;
            monthRadioBtn.TabStop = true;
            monthRadioBtn.Text = "1 Tháng";
            monthRadioBtn.UseVisualStyleBackColor = true;
            // 
            // weekRadioBtn
            // 
            weekRadioBtn.AutoSize = true;
            weekRadioBtn.Location = new System.Drawing.Point(60, 371);
            weekRadioBtn.Name = "weekRadioBtn";
            weekRadioBtn.Size = new System.Drawing.Size(74, 24);
            weekRadioBtn.TabIndex = 24;
            weekRadioBtn.TabStop = true;
            weekRadioBtn.Text = "1 Tuần";
            weekRadioBtn.UseVisualStyleBackColor = true;
            // 
            // monetTxtBox
            // 
            monetTxtBox.Location = new System.Drawing.Point(60, 252);
            monetTxtBox.Name = "monetTxtBox";
            monetTxtBox.Size = new System.Drawing.Size(415, 27);
            monetTxtBox.TabIndex = 23;
            // 
            // categoryComboBox
            // 
            categoryComboBox.FormattingEnabled = true;
            categoryComboBox.Location = new System.Drawing.Point(60, 137);
            categoryComboBox.Name = "categoryComboBox";
            categoryComboBox.Size = new System.Drawing.Size(415, 28);
            categoryComboBox.TabIndex = 22;
            // 
            // toDateTxt
            // 
            toDateTxt.AutoSize = true;
            toDateTxt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            toDateTxt.Location = new System.Drawing.Point(312, 426);
            toDateTxt.Name = "toDateTxt";
            toDateTxt.Size = new System.Drawing.Size(44, 25);
            toDateTxt.TabIndex = 21;
            toDateTxt.Text = "Đến";
            // 
            // fromDateTxt
            // 
            fromDateTxt.AutoSize = true;
            fromDateTxt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            fromDateTxt.Location = new System.Drawing.Point(60, 424);
            fromDateTxt.Name = "fromDateTxt";
            fromDateTxt.Size = new System.Drawing.Size(32, 25);
            fromDateTxt.TabIndex = 20;
            fromDateTxt.Text = "Từ";
            // 
            // TimePickerTxt
            // 
            TimePickerTxt.AutoSize = true;
            TimePickerTxt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            TimePickerTxt.Location = new System.Drawing.Point(60, 306);
            TimePickerTxt.Name = "TimePickerTxt";
            TimePickerTxt.Size = new System.Drawing.Size(194, 25);
            TimePickerTxt.TabIndex = 19;
            TimePickerTxt.Text = "Chọn khoảng thời gian";
            // 
            // MoneyTxt
            // 
            MoneyTxt.AutoSize = true;
            MoneyTxt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            MoneyTxt.Location = new System.Drawing.Point(60, 203);
            MoneyTxt.Name = "MoneyTxt";
            MoneyTxt.Size = new System.Drawing.Size(67, 25);
            MoneyTxt.TabIndex = 18;
            MoneyTxt.Text = "Số tiền";
            // 
            // CategoriesPickerTxt
            // 
            CategoriesPickerTxt.AutoSize = true;
            CategoriesPickerTxt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            CategoriesPickerTxt.Location = new System.Drawing.Point(60, 91);
            CategoriesPickerTxt.Name = "CategoriesPickerTxt";
            CategoriesPickerTxt.Size = new System.Drawing.Size(140, 25);
            CategoriesPickerTxt.TabIndex = 17;
            CategoriesPickerTxt.Text = "Chọn categories";
            // 
            // EditBudgetTitle
            // 
            EditBudgetTitle.AutoSize = true;
            EditBudgetTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            EditBudgetTitle.Location = new System.Drawing.Point(45, 22);
            EditBudgetTitle.Name = "EditBudgetTitle";
            EditBudgetTitle.Size = new System.Drawing.Size(206, 38);
            EditBudgetTitle.TabIndex = 16;
            EditBudgetTitle.Text = "Sửa ngân sách";
            // 
            // isRecurringChckBox
            // 
            isRecurringChckBox.AutoSize = true;
            isRecurringChckBox.Location = new System.Drawing.Point(60, 467);
            isRecurringChckBox.Name = "isRecurringChckBox";
            isRecurringChckBox.Size = new System.Drawing.Size(154, 24);
            isRecurringChckBox.TabIndex = 32;
            isRecurringChckBox.Text = "Lặp lại theo chu kỳ";
            isRecurringChckBox.UseVisualStyleBackColor = true;
            // 
            // BudgetEditDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(603, 588);
            Controls.Add(isRecurringChckBox);
            Controls.Add(cancelBtn);
            Controls.Add(addBtn);
            Controls.Add(toDateTimePicker);
            Controls.Add(fromDateTimePicker);
            Controls.Add(YearRadioBtn);
            Controls.Add(tMonthRadioBtn);
            Controls.Add(monthRadioBtn);
            Controls.Add(weekRadioBtn);
            Controls.Add(monetTxtBox);
            Controls.Add(categoryComboBox);
            Controls.Add(toDateTxt);
            Controls.Add(fromDateTxt);
            Controls.Add(TimePickerTxt);
            Controls.Add(MoneyTxt);
            Controls.Add(CategoriesPickerTxt);
            Controls.Add(EditBudgetTitle);
            Name = "BudgetEditDialog";
            Text = "EditBudgetDialog";
            ResumeLayout(false);
            PerformLayout();
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