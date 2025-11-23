namespace ExpenseManager.App.Views.User
{
    partial class BudgetCreateDialog
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
            addBudgetTitle = new System.Windows.Forms.Label();
            CategoriesPickerTxt = new System.Windows.Forms.Label();
            MoneyTxt = new System.Windows.Forms.Label();
            TimePickerTxt = new System.Windows.Forms.Label();
            fromDateTxt = new System.Windows.Forms.Label();
            toDateTxt = new System.Windows.Forms.Label();
            comboBox1 = new System.Windows.Forms.ComboBox();
            textBox1 = new System.Windows.Forms.TextBox();
            weekRadioBtn = new System.Windows.Forms.RadioButton();
            monthRadioBtn = new System.Windows.Forms.RadioButton();
            tMonthRadioBtn = new System.Windows.Forms.RadioButton();
            YearRadioBtn = new System.Windows.Forms.RadioButton();
            fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            addBtn = new System.Windows.Forms.Button();
            cancelBtn = new System.Windows.Forms.Button();
            isRecurringChckBox = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // addBudgetTitle
            // 
            addBudgetTitle.AutoSize = true;
            addBudgetTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            addBudgetTitle.Location = new System.Drawing.Point(27, 25);
            addBudgetTitle.Name = "addBudgetTitle";
            addBudgetTitle.Size = new System.Drawing.Size(290, 38);
            addBudgetTitle.TabIndex = 0;
            addBudgetTitle.Text = "Thêm ngân sách mới";
            // 
            // CategoriesPickerTxt
            // 
            CategoriesPickerTxt.AutoSize = true;
            CategoriesPickerTxt.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            CategoriesPickerTxt.Location = new System.Drawing.Point(42, 90);
            CategoriesPickerTxt.Name = "CategoriesPickerTxt";
            CategoriesPickerTxt.Size = new System.Drawing.Size(140, 25);
            CategoriesPickerTxt.TabIndex = 1;
            CategoriesPickerTxt.Text = "Chọn categories";
            // 
            // MoneyTxt
            // 
            MoneyTxt.AutoSize = true;
            MoneyTxt.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            MoneyTxt.Location = new System.Drawing.Point(42, 330);
            MoneyTxt.Name = "MoneyTxt";
            MoneyTxt.Size = new System.Drawing.Size(67, 25);
            MoneyTxt.TabIndex = 2;
            MoneyTxt.Text = "Số tiền";
            // 
            // TimePickerTxt
            // 
            TimePickerTxt.AutoSize = true;
            TimePickerTxt.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            TimePickerTxt.Location = new System.Drawing.Point(42, 420);
            TimePickerTxt.Name = "TimePickerTxt";
            TimePickerTxt.Size = new System.Drawing.Size(194, 25);
            TimePickerTxt.TabIndex = 3;
            TimePickerTxt.Text = "Chọn khoảng thời gian";
            // 
            // fromDateTxt
            // 
            fromDateTxt.AutoSize = true;
            fromDateTxt.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            fromDateTxt.Location = new System.Drawing.Point(42, 540);
            fromDateTxt.Name = "fromDateTxt";
            fromDateTxt.Size = new System.Drawing.Size(32, 25);
            fromDateTxt.TabIndex = 4;
            fromDateTxt.Text = "Từ";
            // 
            // toDateTxt
            // 
            toDateTxt.AutoSize = true;
            toDateTxt.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            toDateTxt.Location = new System.Drawing.Point(360, 540);
            toDateTxt.Name = "toDateTxt";
            toDateTxt.Size = new System.Drawing.Size(44, 25);
            toDateTxt.TabIndex = 5;
            toDateTxt.Text = "Đến";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(42, 130);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(590, 28);
            comboBox1.TabIndex = 6;
            comboBox1.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            textBox1.Location = new System.Drawing.Point(42, 365);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(590, 32);
            textBox1.TabIndex = 7;
            // 
            // weekRadioBtn
            // 
            weekRadioBtn.AutoSize = true;
            weekRadioBtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            weekRadioBtn.Location = new System.Drawing.Point(42, 460);
            weekRadioBtn.Name = "weekRadioBtn";
            weekRadioBtn.Size = new System.Drawing.Size(80, 27);
            weekRadioBtn.TabIndex = 8;
            weekRadioBtn.Text = "1 Tuần";
            weekRadioBtn.UseVisualStyleBackColor = true;
            // 
            // monthRadioBtn
            // 
            monthRadioBtn.AutoSize = true;
            monthRadioBtn.Checked = true;
            monthRadioBtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            monthRadioBtn.Location = new System.Drawing.Point(180, 460);
            monthRadioBtn.Name = "monthRadioBtn";
            monthRadioBtn.Size = new System.Drawing.Size(89, 27);
            monthRadioBtn.TabIndex = 9;
            monthRadioBtn.TabStop = true;
            monthRadioBtn.Text = "1 Tháng";
            monthRadioBtn.UseVisualStyleBackColor = true;
            // 
            // tMonthRadioBtn
            // 
            tMonthRadioBtn.AutoSize = true;
            tMonthRadioBtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            tMonthRadioBtn.Location = new System.Drawing.Point(330, 460);
            tMonthRadioBtn.Name = "tMonthRadioBtn";
            tMonthRadioBtn.Size = new System.Drawing.Size(89, 27);
            tMonthRadioBtn.TabIndex = 10;
            tMonthRadioBtn.Text = "3 Tháng";
            tMonthRadioBtn.UseVisualStyleBackColor = true;
            // 
            // YearRadioBtn
            // 
            YearRadioBtn.AutoSize = true;
            YearRadioBtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            YearRadioBtn.Location = new System.Drawing.Point(480, 460);
            YearRadioBtn.Name = "YearRadioBtn";
            YearRadioBtn.Size = new System.Drawing.Size(80, 27);
            YearRadioBtn.TabIndex = 11;
            YearRadioBtn.Text = "1 Năm";
            YearRadioBtn.UseVisualStyleBackColor = true;
            // 
            // fromDateTimePicker
            // 
            fromDateTimePicker.Font = new System.Drawing.Font("Segoe UI", 10F);
            fromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            fromDateTimePicker.Location = new System.Drawing.Point(80, 538);
            fromDateTimePicker.Name = "fromDateTimePicker";
            fromDateTimePicker.Size = new System.Drawing.Size(250, 30);
            fromDateTimePicker.TabIndex = 12;
            // 
            // toDateTimePicker
            // 
            toDateTimePicker.Font = new System.Drawing.Font("Segoe UI", 10F);
            toDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            toDateTimePicker.Location = new System.Drawing.Point(410, 538);
            toDateTimePicker.Name = "toDateTimePicker";
            toDateTimePicker.Size = new System.Drawing.Size(222, 30);
            toDateTimePicker.TabIndex = 13;
            // 
            // addBtn
            // 
            addBtn.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            addBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            addBtn.FlatAppearance.BorderSize = 0;
            addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            addBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            addBtn.ForeColor = System.Drawing.Color.White;
            addBtn.Location = new System.Drawing.Point(360, 630);
            addBtn.Name = "addBtn";
            addBtn.Size = new System.Drawing.Size(130, 45);
            addBtn.TabIndex = 14;
            addBtn.Text = "Thêm";
            addBtn.UseVisualStyleBackColor = false;
            // 
            // cancelBtn
            // 
            cancelBtn.BackColor = System.Drawing.Color.White;
            cancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            cancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cancelBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            cancelBtn.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            cancelBtn.Location = new System.Drawing.Point(502, 630);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new System.Drawing.Size(130, 45);
            cancelBtn.TabIndex = 15;
            cancelBtn.Text = "Hủy";
            cancelBtn.UseVisualStyleBackColor = false;
            // 
            // isRecurringChckBox
            // 
            isRecurringChckBox.AutoSize = true;
            isRecurringChckBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            isRecurringChckBox.Location = new System.Drawing.Point(42, 585);
            isRecurringChckBox.Name = "isRecurringChckBox";
            isRecurringChckBox.Size = new System.Drawing.Size(175, 27);
            isRecurringChckBox.TabIndex = 33;
            isRecurringChckBox.Text = "Lặp lại theo chu kỳ";
            isRecurringChckBox.UseVisualStyleBackColor = true;
            // 
            // BudgetCreateDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(680, 700);
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
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BudgetCreateDialog";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Thêm ngân sách mới";
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton weekRadioBtn;
        private System.Windows.Forms.RadioButton monthRadioBtn;
        private System.Windows.Forms.RadioButton tMonthRadioBtn;
        private System.Windows.Forms.RadioButton YearRadioBtn;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.CheckBox isRecurringChckBox;
    }
}