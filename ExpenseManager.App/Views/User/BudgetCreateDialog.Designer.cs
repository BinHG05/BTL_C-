namespace ExpenseManager.App.Views.User
{
    partial class BudgetCreateDialog
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
            addBudgetTitle = new System.Windows.Forms.Label();
            CategoriesPickerTxt = new System.Windows.Forms.Label();
            MoneyTxt = new System.Windows.Forms.Label();
            TimePickerTxt = new System.Windows.Forms.Label();
            fromDateTxt = new System.Windows.Forms.Label();
            toDateTxt = new System.Windows.Forms.Label();
            iconDropDownButton1 = new FontAwesome.Sharp.IconDropDownButton();
            comboBox1 = new System.Windows.Forms.ComboBox();
            textBox1 = new System.Windows.Forms.TextBox();
            weekRadioBtn = new System.Windows.Forms.RadioButton();
            monthRadioBtn = new System.Windows.Forms.RadioButton();
            tMonthRadioBtn = new System.Windows.Forms.RadioButton();
            YearRadioBtn = new System.Windows.Forms.RadioButton();
            fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            addBtn = new FontAwesome.Sharp.IconButton();
            cancelBtn = new FontAwesome.Sharp.IconButton();
            isRecurringChckBox = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // addBudgetTitle
            // 
            addBudgetTitle.AutoSize = true;
            addBudgetTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            addBudgetTitle.Location = new System.Drawing.Point(27, 45);
            addBudgetTitle.Name = "addBudgetTitle";
            addBudgetTitle.Size = new System.Drawing.Size(290, 38);
            addBudgetTitle.TabIndex = 0;
            addBudgetTitle.Text = "Thêm ngân sách mới";
            // 
            // CategoriesPickerTxt
            // 
            CategoriesPickerTxt.AutoSize = true;
            CategoriesPickerTxt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            CategoriesPickerTxt.Location = new System.Drawing.Point(42, 114);
            CategoriesPickerTxt.Name = "CategoriesPickerTxt";
            CategoriesPickerTxt.Size = new System.Drawing.Size(140, 25);
            CategoriesPickerTxt.TabIndex = 1;
            CategoriesPickerTxt.Text = "Chọn categories";
            // 
            // MoneyTxt
            // 
            MoneyTxt.AutoSize = true;
            MoneyTxt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            MoneyTxt.Location = new System.Drawing.Point(42, 226);
            MoneyTxt.Name = "MoneyTxt";
            MoneyTxt.Size = new System.Drawing.Size(67, 25);
            MoneyTxt.TabIndex = 2;
            MoneyTxt.Text = "Số tiền";
            // 
            // TimePickerTxt
            // 
            TimePickerTxt.AutoSize = true;
            TimePickerTxt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            TimePickerTxt.Location = new System.Drawing.Point(42, 329);
            TimePickerTxt.Name = "TimePickerTxt";
            TimePickerTxt.Size = new System.Drawing.Size(194, 25);
            TimePickerTxt.TabIndex = 3;
            TimePickerTxt.Text = "Chọn khoảng thời gian";
            // 
            // fromDateTxt
            // 
            fromDateTxt.AutoSize = true;
            fromDateTxt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            fromDateTxt.Location = new System.Drawing.Point(42, 447);
            fromDateTxt.Name = "fromDateTxt";
            fromDateTxt.Size = new System.Drawing.Size(32, 25);
            fromDateTxt.TabIndex = 4;
            fromDateTxt.Text = "Từ";
            // 
            // toDateTxt
            // 
            toDateTxt.AutoSize = true;
            toDateTxt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            toDateTxt.Location = new System.Drawing.Point(294, 449);
            toDateTxt.Name = "toDateTxt";
            toDateTxt.Size = new System.Drawing.Size(44, 25);
            toDateTxt.TabIndex = 5;
            toDateTxt.Text = "Đến";
            // 
            // iconDropDownButton1
            // 
            iconDropDownButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconDropDownButton1.IconColor = System.Drawing.Color.Black;
            iconDropDownButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconDropDownButton1.Name = "iconDropDownButton1";
            iconDropDownButton1.Size = new System.Drawing.Size(23, 23);
            iconDropDownButton1.Text = "iconDropDownButton1";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(42, 160);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(415, 28);
            comboBox1.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(42, 275);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(415, 27);
            textBox1.TabIndex = 7;
            // 
            // weekRadioBtn
            // 
            weekRadioBtn.AutoSize = true;
            weekRadioBtn.Location = new System.Drawing.Point(42, 394);
            weekRadioBtn.Name = "weekRadioBtn";
            weekRadioBtn.Size = new System.Drawing.Size(74, 24);
            weekRadioBtn.TabIndex = 8;
            weekRadioBtn.TabStop = true;
            weekRadioBtn.Text = "1 Tuần";
            weekRadioBtn.UseVisualStyleBackColor = true;
            // 
            // monthRadioBtn
            // 
            monthRadioBtn.AutoSize = true;
            monthRadioBtn.Location = new System.Drawing.Point(174, 394);
            monthRadioBtn.Name = "monthRadioBtn";
            monthRadioBtn.Size = new System.Drawing.Size(83, 24);
            monthRadioBtn.TabIndex = 9;
            monthRadioBtn.TabStop = true;
            monthRadioBtn.Text = "1 Tháng";
            monthRadioBtn.UseVisualStyleBackColor = true;
            // 
            // tMonthRadioBtn
            // 
            tMonthRadioBtn.AutoSize = true;
            tMonthRadioBtn.Location = new System.Drawing.Point(319, 394);
            tMonthRadioBtn.Name = "tMonthRadioBtn";
            tMonthRadioBtn.Size = new System.Drawing.Size(83, 24);
            tMonthRadioBtn.TabIndex = 10;
            tMonthRadioBtn.TabStop = true;
            tMonthRadioBtn.Text = "3 Tháng";
            tMonthRadioBtn.UseVisualStyleBackColor = true;
            // 
            // YearRadioBtn
            // 
            YearRadioBtn.AutoSize = true;
            YearRadioBtn.Location = new System.Drawing.Point(465, 394);
            YearRadioBtn.Name = "YearRadioBtn";
            YearRadioBtn.Size = new System.Drawing.Size(74, 24);
            YearRadioBtn.TabIndex = 11;
            YearRadioBtn.TabStop = true;
            YearRadioBtn.Text = "1 Năm";
            YearRadioBtn.UseVisualStyleBackColor = true;
            // 
            // fromDateTimePicker
            // 
            fromDateTimePicker.Location = new System.Drawing.Point(80, 447);
            fromDateTimePicker.Name = "fromDateTimePicker";
            fromDateTimePicker.Size = new System.Drawing.Size(208, 27);
            fromDateTimePicker.TabIndex = 12;
            // 
            // toDateTimePicker
            // 
            toDateTimePicker.Location = new System.Drawing.Point(344, 449);
            toDateTimePicker.Name = "toDateTimePicker";
            toDateTimePicker.Size = new System.Drawing.Size(195, 27);
            toDateTimePicker.TabIndex = 13;
            // 
            // addBtn
            // 
            addBtn.BackColor = System.Drawing.SystemColors.Highlight;
            addBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            addBtn.ForeColor = System.Drawing.Color.White;
            addBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            addBtn.IconColor = System.Drawing.Color.White;
            addBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            addBtn.Location = new System.Drawing.Point(250, 536);
            addBtn.Name = "addBtn";
            addBtn.Size = new System.Drawing.Size(124, 42);
            addBtn.TabIndex = 14;
            addBtn.Text = "Thêm";
            addBtn.UseVisualStyleBackColor = false;
            // 
            // cancelBtn
            // 
            cancelBtn.BackColor = System.Drawing.Color.White;
            cancelBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            cancelBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            cancelBtn.IconColor = System.Drawing.Color.Black;
            cancelBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            cancelBtn.Location = new System.Drawing.Point(408, 536);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new System.Drawing.Size(131, 42);
            cancelBtn.TabIndex = 15;
            cancelBtn.Text = "Hủy";
            cancelBtn.UseVisualStyleBackColor = false;
            // 
            // isRecurringChckBox
            // 
            isRecurringChckBox.AutoSize = true;
            isRecurringChckBox.Location = new System.Drawing.Point(42, 495);
            isRecurringChckBox.Name = "isRecurringChckBox";
            isRecurringChckBox.Size = new System.Drawing.Size(154, 24);
            isRecurringChckBox.TabIndex = 33;
            isRecurringChckBox.Text = "Lặp lại theo chu kỳ";
            isRecurringChckBox.UseVisualStyleBackColor = true;
            // 
            // BudgetCreateDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(601, 606);
            Controls.Add(isRecurringChckBox);
            Controls.Add(cancelBtn);
            Controls.Add(addBtn);
            Controls.Add(toDateTimePicker);
            Controls.Add(fromDateTimePicker);
            Controls.Add(YearRadioBtn);
            Controls.Add(tMonthRadioBtn);
            Controls.Add(monthRadioBtn);
            Controls.Add(weekRadioBtn);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(toDateTxt);
            Controls.Add(fromDateTxt);
            Controls.Add(TimePickerTxt);
            Controls.Add(MoneyTxt);
            Controls.Add(CategoriesPickerTxt);
            Controls.Add(addBudgetTitle);
            Name = "BudgetCreateDialog";
            Text = "BudgetCreateDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label addBudgetTitle;
        private System.Windows.Forms.Label CategoriesPickerTxt;
        private System.Windows.Forms.Label MoneyTxt;
        private System.Windows.Forms.Label TimePickerTxt;
        private System.Windows.Forms.Label fromDateTxt;
        private System.Windows.Forms.Label toDateTxt;
        private FontAwesome.Sharp.IconDropDownButton iconDropDownButton1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton weekRadioBtn;
        private System.Windows.Forms.RadioButton monthRadioBtn;
        private System.Windows.Forms.RadioButton tMonthRadioBtn;
        private System.Windows.Forms.RadioButton YearRadioBtn;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private FontAwesome.Sharp.IconButton addBtn;
        private FontAwesome.Sharp.IconButton cancelBtn;
        private System.Windows.Forms.CheckBox isRecurringChckBox;
    }
}