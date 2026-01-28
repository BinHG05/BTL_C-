using ExpenseManager.App.Models.Entities;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FontAwesome.Sharp; 

namespace ExpenseManager.App.Views.User.UC
{
    public partial class UC_CategoryItem : UserControl
    {
        private Category _category;

        public event EventHandler EditClicked;
        public event EventHandler DeleteClicked;

        public UC_CategoryItem()
        {
            InitializeComponent();
        }

        public UC_CategoryItem(Category category)
        {
            InitializeComponent();
            _category = category;

            // Bind data
            lblCategoryName.Text = category.CategoryName;

            try
            {
                // 1. Chuyển đổi tên class (VD: "fa-solid fa-utensils")
                IconChar icon = ConvertIconClassToIconChar(category.Icon.IconClass);

                // 2. Gán icon và màu
                iconPictureBox.IconChar = icon;
                iconPictureBox.IconColor = System.Drawing.ColorTranslator.FromHtml(category.Color.HexCode);
            }
            catch (Exception ex)
            {
                // Nếu không tìm thấy icon, hiển thị icon mặc định
                iconPictureBox.IconChar = IconChar.QuestionCircle;
                iconPictureBox.IconColor = System.Drawing.Color.Gray;
                Console.WriteLine($"Lỗi convert icon: {category.Icon.IconClass} - {ex.Message}");
            }

            // Wire up events
            btnEdit.Click += (s, e) => EditClicked?.Invoke(this, EventArgs.Empty);
            btnDelete.Click += (s, e) => DeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        private IconChar ConvertIconClassToIconChar(string iconClass)
        {
            string name = iconClass.Split(' ').Last(); 
            name = name.Replace("fa-", ""); 

            string[] parts = name.Split('-');
            StringBuilder pascalCaseName = new StringBuilder();
            foreach (string part in parts)
            {
                pascalCaseName.Append(char.ToUpper(part[0]) + part.Substring(1));
            }

            if (Enum.TryParse<IconChar>(pascalCaseName.ToString(), out IconChar result))
            {
                return result;
            }

            return IconChar.QuestionCircle;
        }

        public int CategoryId => _category.CategoryId;
        public Category GetCategory() => _category;
    }
}