using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ExpenseManager.App.Models.DTOs;
using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Presenters.Admin;
using ExpenseManager.App.Views.Admin.Forms;
using FontAwesome.Sharp;

namespace ExpenseManager.App.Views.Admin.UC
{
    public partial class UC_CategoryAD : UserControl, ICategoryAdminView
    {
        private CategoryAdminPresenter _presenter;
        private string _selectedTab = "Icons";

        public UC_CategoryAD()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        public void InitializePresenter(ExpenseDbContext dbContext)
        {
            _presenter = new CategoryAdminPresenter(this, dbContext);
            _presenter.LoadIcons();
        }

        private void InitializeCustomComponents()
        {
            // Tab button click events
            btnIconsTab.Click += (s, e) => SwitchTab("Icons");
            btnColorsTab.Click += (s, e) => SwitchTab("Colors");

            // Add button click events
            btnAddIcon.Click += BtnAddIcon_Click;
            btnAddColor.Click += BtnAddColor_Click;
        }

        private void SwitchTab(string tab)
        {
            _selectedTab = tab;

            // Reset button styles
            btnIconsTab.BackColor = Color.White;
            btnIconsTab.ForeColor = Color.FromArgb(100, 100, 100);
            btnColorsTab.BackColor = Color.White;
            btnColorsTab.ForeColor = Color.FromArgb(100, 100, 100);

            // Highlight selected tab
            if (tab == "Icons")
            {
                btnIconsTab.BackColor = Color.FromArgb(240, 248, 255);
                btnIconsTab.ForeColor = Color.FromArgb(0, 123, 255);
                pnlIconsList.Visible = true;
                pnlColorsList.Visible = false;
                _presenter?.LoadIcons();
            }
            else
            {
                btnColorsTab.BackColor = Color.FromArgb(240, 248, 255);
                btnColorsTab.ForeColor = Color.FromArgb(0, 123, 255);
                pnlIconsList.Visible = false;
                pnlColorsList.Visible = true;
                _presenter?.LoadColors();
            }
        }

        public void DisplayIcons(System.Collections.Generic.List<IconDTO> icons)
        {
            flpIcons.Controls.Clear();
            lblIconCount.Text = $"{icons.Count} biểu tượng";

            // Add "Thêm Icon" button
            var addPanel = CreateAddPanel("Icons");
            flpIcons.Controls.Add(addPanel);

            // Add icon cards
            foreach (var icon in icons)
            {
                var iconCard = CreateIconCard(icon);
                flpIcons.Controls.Add(iconCard);
            }
        }

        public void DisplayColors(System.Collections.Generic.List<ColorDTO> colors)
        {
            flpColors.Controls.Clear();
            lblColorCount.Text = $"{colors.Count} màu";

            // Add "Thêm Color" button
            var addPanel = CreateAddPanel("Colors");
            flpColors.Controls.Add(addPanel);

            // Add color cards
            foreach (var color in colors)
            {
                var colorCard = CreateColorCard(color);
                flpColors.Controls.Add(colorCard);
            }
        }

        private Panel CreateAddPanel(string type)
        {
            var panel = new Panel
            {
                Size = new Size(130, 140),
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };

            // Dashed border effect
            panel.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.LightGray, 2))
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
                }
            };

            var iconBtn = new IconButton
            {
                IconChar = IconChar.Plus,
                IconColor = Color.Gray,
                IconSize = 40,
                Size = new Size(80, 80),
                Location = new Point(25, 20),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Enabled = false
            };
            iconBtn.FlatAppearance.BorderSize = 0;

            var label = new Label
            {
                Text = type == "Icons" ? "Thêm\nbiểu tượng" : "Thêm\nmàu",
                Location = new Point(0, 100),
                Size = new Size(130, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray
            };

            panel.Controls.Add(iconBtn);
            panel.Controls.Add(label);

            panel.Click += (s, e) =>
            {
                if (type == "Icons") BtnAddIcon_Click(s, e);
                else BtnAddColor_Click(s, e);
            };

            return panel;
        }

        private Panel CreateIconCard(IconDTO icon)
        {
            var panel = new Panel
            {
                Size = new Size(130, 140),
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Tag = icon
            };

            // Parse FontAwesome icon class
            var iconChar = ParseFontAwesomeIcon(icon.IconClass);

            var iconBtn = new IconButton
            {
                IconChar = iconChar,
                IconColor = Color.Black,
                IconSize = 40,
                Size = new Size(80, 80),
                Location = new Point(25, 20),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Enabled = false
            };
            iconBtn.FlatAppearance.BorderSize = 0;

            var label = new Label
            {
                Text = icon.IconName,
                Location = new Point(0, 100),
                Size = new Size(130, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9F)
            };

            var deleteBtn = new IconButton
            {
                IconChar = IconChar.Times,
                IconColor = Color.Red,
                IconSize = 20,
                Size = new Size(25, 25),
                Location = new Point(100, 5),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Tag = icon.IconId
            };
            deleteBtn.FlatAppearance.BorderSize = 0;
            deleteBtn.Click += (s, e) =>
            {
                var result = MessageBox.Show($"Bạn có chắc muốn xóa icon '{icon.IconName}'?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _presenter.DeleteIcon(icon.IconId);
                }
            };

            panel.Controls.Add(iconBtn);
            panel.Controls.Add(label);
            panel.Controls.Add(deleteBtn);

            return panel;
        }

        private Panel CreateColorCard(ColorDTO color)
        {
            var panel = new Panel
            {
                Size = new Size(130, 140),
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Tag = color
            };

            var colorCircle = new Panel
            {
                Size = new Size(60, 60),
                Location = new Point(35, 25),
                BackColor = ColorTranslator.FromHtml(color.HexCode)
            };

            // Draw circle
            colorCircle.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillEllipse(new SolidBrush(colorCircle.BackColor),
                    0, 0, colorCircle.Width - 1, colorCircle.Height - 1);
            };

            var label = new Label
            {
                Text = color.ColorName,
                Location = new Point(0, 100),
                Size = new Size(130, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9F)
            };

            var deleteBtn = new IconButton
            {
                IconChar = IconChar.Times,
                IconColor = Color.Red,
                IconSize = 20,
                Size = new Size(25, 25),
                Location = new Point(100, 5),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Tag = color.ColorId
            };
            deleteBtn.FlatAppearance.BorderSize = 0;
            deleteBtn.Click += (s, e) =>
            {
                var result = MessageBox.Show($"Bạn có chắc muốn xóa màu '{color.ColorName}'?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _presenter.DeleteColor(color.ColorId);
                }
            };

            panel.Controls.Add(colorCircle);
            panel.Controls.Add(label);
            panel.Controls.Add(deleteBtn);

            return panel;
        }

        private IconChar ParseFontAwesomeIcon(string iconClass)
        {
            // Remove "fa-solid " prefix and convert to IconChar
            var iconName = iconClass.Replace("fa-solid ", "").Replace("fa-", "");

            // Map common icons
            switch (iconName)
            {
                case "utensils": return IconChar.Utensils;
                case "bus-simple": return IconChar.Bus;
                case "gas-pump": return IconChar.GasPump;
                case "file-invoice-dollar": return IconChar.FileInvoiceDollar;
                case "house-user": return IconChar.HouseUser;
                case "shirt": return IconChar.Shirt;
                case "cart-shopping": return IconChar.CartShopping;
                case "screwdriver-wrench": return IconChar.Screwdriver;
                case "heart-pulse": return IconChar.HeartPulse;
                case "graduation-cap": return IconChar.GraduationCap;
                case "film": return IconChar.Film;
                case "dumbbell": return IconChar.Dumbbell;
                case "wand-magic-sparkles": return IconChar.WandMagicSparkles;
                case "mug-hot": return IconChar.MugHot;
                case "plane-departure": return IconChar.PlaneDeparture;
                case "palette": return IconChar.Palette;
                case "gift": return IconChar.Gift;
                case "child-reaching": return IconChar.Child;
                case "paw": return IconChar.Paw;
                case "money-bill-wave": return IconChar.MoneyBillWave;
                default: return IconChar.QuestionCircle;
            }
        }

        private void BtnAddIcon_Click(object sender, EventArgs e)
        {
            var addForm = new AddIconForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                var dto = new IconDTO
                {
                    IconName = addForm.IconName,
                    IconClass = addForm.IconClass
                };
                _presenter.AddIcon(dto);
            }
        }

        private void BtnAddColor_Click(object sender, EventArgs e)
        {
            var addForm = new AddColorForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                var dto = new ColorDTO
                {
                    ColorName = addForm.ColorName,
                    HexCode = addForm.HexCode
                };
                _presenter.AddColor(dto);
            }
        }

        public void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}