using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.Admin.Forms
{
    public partial class AddColorForm : Form
    {
        public string ColorName { get; private set; }
        public string HexCode { get; private set; }

        // XÓA KHAI BÁO CONTROLS Ở ĐÂY - Chuyển sang Designer.cs
        // private Label lblTitle;
        // private Label lblColorName;
        // ...

        public AddColorForm()
        {
            InitializeComponent();  // GỌI method từ Designer.cs
        }

        // XÓA METHOD InitializeComponent() Ở ĐÂY
        // Nó phải nằm trong Designer.cs

        private void BtnChooseColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    Color selectedColor = colorDialog.Color;
                    txtHexCode.Text = $"#{selectedColor.R:X2}{selectedColor.G:X2}{selectedColor.B:X2}";
                    UpdateColorPreview(selectedColor);
                }
            }
        }

        private void TxtHexCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtHexCode.Text))
                {
                    Color color = ColorTranslator.FromHtml(txtHexCode.Text);
                    UpdateColorPreview(color);
                }
            }
            catch
            {
                colorPreview.BackColor = Color.White;
            }
        }

        private void UpdateColorPreview(Color color)
        {
            colorPreview.BackColor = color;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtColorName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên màu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtColorName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHexCode.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hex!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHexCode.Focus();
                return;
            }

            try
            {
                ColorTranslator.FromHtml(txtHexCode.Text);
            }
            catch
            {
                MessageBox.Show("Mã hex không hợp lệ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHexCode.Focus();
                return;
            }

            ColorName = txtColorName.Text.Trim();
            HexCode = txtHexCode.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }
    }
}