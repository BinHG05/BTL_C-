using System.Drawing;
using System.Windows.Forms;

namespace ExpenseManager.App.Views
{
    partial class AddGoalForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblLabelGoalName;
        private TextBox txtGoalName;
        private Label lblLabelTargetAmount;
        private NumericUpDown numTargetAmount;
        private Label lblLabelCompletionDate;
        private DateTimePicker dtpCompletionDate;
        private Button btnSave;
        private Button btnCancel;

        // *** KHAI BÁO NÚT MỚI (Cho chức năng Xóa) ***
        private Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            lblLabelGoalName = new Label();
            txtGoalName = new TextBox();
            lblLabelTargetAmount = new Label();
            numTargetAmount = new NumericUpDown();
            lblLabelCompletionDate = new Label();
            dtpCompletionDate = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();

            // *** KHỞI TẠO NÚT MỚI (Cho chức năng Xóa) ***
            btnDelete = new Button();

            ((System.ComponentModel.ISupportInitialize)(numTargetAmount)).BeginInit();
            SuspendLayout();

            // === Form ===
            BackColor = Color.White;
            ClientSize = new Size(500, 500);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add New Goal";

            int x = 40;
            int inputWidth = 420;

            // === Title ===
            lblTitle.Text = "Create New Goal";
            lblTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(x, 30);
            Controls.Add(lblTitle);

            // --- Goal Name ---
            lblLabelGoalName.Text = "Goal Name";
            lblLabelGoalName.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblLabelGoalName.ForeColor = Color.Black;
            lblLabelGoalName.AutoSize = true;
            lblLabelGoalName.Location = new Point(x, 110);
            Controls.Add(lblLabelGoalName);

            txtGoalName.PlaceholderText = "e.g., New MacBook Pro";
            txtGoalName.Font = new Font("Segoe UI", 11F);
            txtGoalName.Location = new Point(x, 140);
            txtGoalName.Width = inputWidth;
            txtGoalName.Height = 45;
            Controls.Add(txtGoalName);

            // --- Target Amount ---
            lblLabelTargetAmount.Text = "Target Amount ($)";
            lblLabelTargetAmount.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblLabelTargetAmount.ForeColor = Color.Black;
            lblLabelTargetAmount.AutoSize = true;
            lblLabelTargetAmount.Location = new Point(x, 210);
            Controls.Add(lblLabelTargetAmount);

            numTargetAmount.Font = new Font("Segoe UI", 11F);
            numTargetAmount.Location = new Point(x, 240);
            numTargetAmount.Width = inputWidth;
            numTargetAmount.Height = 45;
            numTargetAmount.DecimalPlaces = 2;
            numTargetAmount.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numTargetAmount.ThousandsSeparator = true;
            Controls.Add(numTargetAmount);

            // --- Completion Date ---
            lblLabelCompletionDate.Text = "Target Completion Date";
            lblLabelCompletionDate.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblLabelCompletionDate.ForeColor = Color.Black;
            lblLabelCompletionDate.AutoSize = true;
            lblLabelCompletionDate.Location = new Point(x, 310);
            Controls.Add(lblLabelCompletionDate);

            dtpCompletionDate.Font = new Font("Segoe UI", 11F);
            dtpCompletionDate.Location = new Point(x, 340);
            dtpCompletionDate.Width = inputWidth;
            dtpCompletionDate.Height = 45;
            dtpCompletionDate.Format = DateTimePickerFormat.Short;
            Controls.Add(dtpCompletionDate);

            // --- *** CẤU HÌNH NÚT MỚI (Xóa) *** ---
            btnDelete.Text = "Xóa"; // (Việt hóa sau)
            btnDelete.BackColor = Color.WhiteSmoke;
            btnDelete.ForeColor = Color.Red; // Màu đỏ
            btnDelete.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 1;
            btnDelete.FlatAppearance.BorderColor = Color.Red;
            btnDelete.Location = new Point(x, 410); // Y: 410, X: 40
            btnDelete.Size = new Size(120, 45);
            btnDelete.Visible = false; // QUAN TRỌNG: Ẩn nút này
            Controls.Add(btnDelete); // Thêm vào Form

            // === Button Cancel ===
            btnCancel.Text = "Cancel";
            btnCancel.BackColor = Color.WhiteSmoke;
            btnCancel.ForeColor = Color.Black;
            btnCancel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 1;
            btnCancel.FlatAppearance.BorderColor = Color.LightGray;
            btnCancel.Location = new Point(200, 410); // Y: 410
            btnCancel.Size = new Size(120, 45);
            Controls.Add(btnCancel);

            // === Button Save ===
            btnSave.Text = "Save Goal";
            btnSave.BackColor = Color.FromArgb(120, 99, 255);
            btnSave.ForeColor = Color.White;
            btnSave.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Location = new Point(330, 410); // Y: 410
            btnSave.Size = new Size(130, 45);
            Controls.Add(btnSave);

            ((System.ComponentModel.ISupportInitialize)(numTargetAmount)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}