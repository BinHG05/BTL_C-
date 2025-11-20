using ExpenseManager.App.Models.DTOs;
using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Repositories;
using ExpenseManager.App.Services;
using ExpenseManager.App.Utilities; 
using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.Admin.UC
{
    public partial class UC_UserAD : UserControl, IUserManagementView
    {
        private UserManagementPresenter _presenter;
        private int _currentPage = 1;
        private int _totalPages = 1;

        public UC_UserAD()
        {
            InitializeComponent();
            lblDateTime.Text = "📅 " + DateTime.Now.ToString("dddd, dd MMMM, yyyy", new CultureInfo("vi-VN"));
            InitializeDataGridView();
            InitializeDefaults();
            FixLayoutUI();

          
            dgvUsers.CellPainting += DgvUsers_CellPainting;
            dgvUsers.CellClick += DgvUsers_CellClick;

           
            cardTotal.Paint += CardPanel_Paint;
            cardActive.Paint += CardPanel_Paint;
            cardBlocked.Paint += CardPanel_Paint;
            cardAdmins.Paint += CardPanel_Paint;

            
            iconTotal.Paint += (s, e) => DrawIconFromBitmap(s, e, IconChar.Users, Color.FromArgb(229, 243, 255), Color.FromArgb(0, 123, 255));
            iconActive.Paint += (s, e) => DrawIconFromBitmap(s, e, IconChar.CheckCircle, Color.FromArgb(220, 252, 231), Color.FromArgb(22, 163, 74));
            iconBlocked.Paint += (s, e) => DrawIconFromBitmap(s, e, IconChar.TimesCircle, Color.FromArgb(254, 226, 226), Color.FromArgb(220, 38, 38));
            iconAdmins.Paint += (s, e) => DrawIconFromBitmap(s, e, IconChar.UserShield, Color.FromArgb(224, 242, 254), Color.FromArgb(14, 165, 233));
        }

   
        private void DrawIconFromBitmap(object sender, PaintEventArgs e, IconChar icon, Color circleBgColor, Color iconColor)
        {
            Panel pnl = sender as Panel;
            if (pnl == null) return;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 1. Vẽ nền tròn
            int circleSize = Math.Min(pnl.Width, pnl.Height) - 2;
            Rectangle circleRect = new Rectangle((pnl.Width - circleSize) / 2, (pnl.Height - circleSize) / 2, circleSize, circleSize);
            using (var brush = new SolidBrush(circleBgColor))
            {
                e.Graphics.FillEllipse(brush, circleRect);
            }

            // 2. Vẽ Icon

            int iconSize = (int)(circleSize * 0.55f);

            using (var iconPic = new IconPictureBox())
            {
                iconPic.IconChar = icon;
                iconPic.IconSize = iconSize;
                iconPic.IconColor = iconColor;
             
                iconPic.BackColor = circleBgColor;
                iconPic.Size = new Size(iconSize, iconSize);
                iconPic.SizeMode = PictureBoxSizeMode.CenterImage;

                var bmp = new Bitmap(iconSize, iconSize);
                iconPic.DrawToBitmap(bmp, new Rectangle(0, 0, iconSize, iconSize));

                // Vẽ Bitmap lên Panel
                int x = (pnl.Width - iconSize) / 2;
                int y = (pnl.Height - iconSize) / 2;
                e.Graphics.DrawImage(bmp, x, y);

                bmp.Dispose();
            }
        }

       

        private void FixLayoutUI()
        {
            int paddingLeft = 25;
            int iconY = 20;
            foreach (var pnl in new[] { iconTotal, iconActive, iconBlocked, iconAdmins })
            {
                pnl.Location = new Point(paddingLeft, iconY);
                pnl.BackColor = Color.Transparent;
                pnl.Size = new Size(60, 60);
            }
            int valueX = 100; int valueY = 25;
            foreach (var lbl in new[] { lblTotalValue, lblActiveValue, lblBlockedValue, lblAdminsValue })
            {
                lbl.Location = new Point(valueX, valueY);
                lbl.BringToFront();
            }
            int labelX = paddingLeft; int labelY = 90;
            foreach (var lbl in new[] { lblTotalLabel, lblActiveLabel, lblBlockedLabel, lblAdminsLabel })
            {
                lbl.Location = new Point(labelX, labelY);
            }
        }

        public void InitializePresenter(ExpenseDbContext dbContext)
        {
            var repository = new UserRepositoryAD(dbContext);
            var service = new UserServiceAD(repository);
            _presenter = new UserManagementPresenter(this, service);
            _ = _presenter.InitializeAsync();
        }

        private void InitializeDefaults() { cmbRole.SelectedIndex = 0; cmbStatus.SelectedIndex = 0; }

        private void InitializeDataGridView()
        {
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.AllowUserToResizeRows = false;
            dgvUsers.MultiSelect = false;

            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(120, 120, 120);
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvUsers.ColumnHeadersDefaultCellStyle.Padding = new Padding(15, 10, 0, 10);
            dgvUsers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUsers.ColumnHeadersHeight = 50;

            dgvUsers.RowsDefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvUsers.RowsDefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            dgvUsers.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 247, 250);
            dgvUsers.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(50, 50, 50);
            dgvUsers.RowsDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsers.GridColor = Color.FromArgb(240, 240, 240);
            dgvUsers.RowTemplate.Height = 70;

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNo", HeaderText = "#", Width = 50, ReadOnly = true });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colUser", HeaderText = "USER", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 150, ReadOnly = true });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEmail", HeaderText = "EMAIL", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 120, ReadOnly = true });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRole", HeaderText = "ROLE", Width = 120, ReadOnly = true });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCreatedDate", HeaderText = "CREATED DATE", Width = 130, ReadOnly = true });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colLastLogin", HeaderText = "LAST LOGIN", Width = 150, ReadOnly = true });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "STATUS", Width = 120, ReadOnly = true });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colActions", HeaderText = "", Width = 60, ReadOnly = true });
        }

        private void DgvUsers_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            if (e.ColumnIndex == dgvUsers.Columns["colUser"].Index)
            {
                var value = e.Value?.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    var parts = value.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    var fullName = parts.Length > 0 ? parts[0] : "";
                    var userId = parts.Length > 1 ? parts[1] : "";

                    var avatarSize = 40;
                    var avatarY = e.CellBounds.Y + (e.CellBounds.Height - avatarSize) / 2;
                    var avatarRect = new Rectangle(e.CellBounds.X + 10, avatarY, avatarSize, avatarSize);

                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    using (var brush = new SolidBrush(GetAvatarColor(fullName)))
                        e.Graphics.FillEllipse(brush, avatarRect);

                    using (var font = new Font("Segoe UI", 12F, FontStyle.Bold))
                    using (var brush = new SolidBrush(Color.White))
                    {
                        var firstChar = !string.IsNullOrEmpty(fullName) ? fullName.Substring(0, 1).ToUpper() : "?";
                        var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        e.Graphics.DrawString(firstChar, font, brush, avatarRect, sf);
                    }

                    // Vẽ Text (Tính tọa độ trực tiếp)
                    var textX = avatarRect.Right + 12;
                    var nameY = e.CellBounds.Y + 12;
                    using (var fontName = new Font("Segoe UI", 10F, FontStyle.Bold))
                    using (var brushName = new SolidBrush(Color.FromArgb(40, 40, 40)))
                        e.Graphics.DrawString(fullName, fontName, brushName, textX, nameY);

                    var idY = nameY + 20;
                    using (var fontId = new Font("Segoe UI", 9F, FontStyle.Regular))
                    using (var brushId = new SolidBrush(Color.Gray))
                        e.Graphics.DrawString(userId, fontId, brushId, textX, idY);
                }
                e.Handled = true;
            }
            else if (e.ColumnIndex == dgvUsers.Columns["colRole"].Index)
            {
                var role = e.Value?.ToString();
                if (!string.IsNullOrEmpty(role))
                {
                    bool isAdmin = role.Trim() == "Admin";
                    var bgColor = isAdmin ? Color.FromArgb(225, 240, 255) : Color.FromArgb(242, 244, 247);
                    var fgColor = isAdmin ? Color.FromArgb(0, 123, 255) : Color.FromArgb(100, 116, 139);
                    var textSize = e.Graphics.MeasureString(role, new Font("Segoe UI", 9F, FontStyle.Bold));
                    var rect = new Rectangle(e.CellBounds.X + 5, e.CellBounds.Y + (e.CellBounds.Height - 26) / 2, (int)textSize.Width + 20, 26);

                    using (var brush = new SolidBrush(bgColor)) e.Graphics.FillRoundedRectangle(brush, rect, 4);
                    using (var font = new Font("Segoe UI", 9F, FontStyle.Bold))
                    using (var brush = new SolidBrush(fgColor))
                    {
                        var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        e.Graphics.DrawString(role, font, brush, rect, sf);
                    }
                }
                e.Handled = true;
            }
            else if (e.ColumnIndex == dgvUsers.Columns["colStatus"].Index)
            {
                var status = e.Value?.ToString();
                if (!string.IsNullOrEmpty(status))
                {
                    bool isActive = status.Trim() == "Active";
                    var bgColor = isActive ? Color.FromArgb(220, 252, 231) : Color.FromArgb(254, 226, 226);
                    var fgColor = isActive ? Color.FromArgb(22, 163, 74) : Color.FromArgb(220, 38, 38);
                    var text = isActive ? "Active" : "Blocked";
                    var rect = new Rectangle(e.CellBounds.X + 5, e.CellBounds.Y + (e.CellBounds.Height - 26) / 2, 80, 26);

                    using (var brush = new SolidBrush(bgColor)) e.Graphics.FillRoundedRectangle(brush, rect, 4);
                    using (var font = new Font("Segoe UI", 9F, FontStyle.Bold))
                    using (var brush = new SolidBrush(fgColor))
                    {
                        var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        e.Graphics.DrawString(text, font, brush, rect, sf);
                    }
                }
                e.Handled = true;
            }
            else if (e.ColumnIndex == dgvUsers.Columns["colActions"].Index)
            {
                var rect = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
                using (var font = new Font("Segoe UI", 14F, FontStyle.Bold))
                using (var brush = new SolidBrush(Color.FromArgb(150, 150, 150)))
                {
                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    e.Graphics.DrawString("⋮", font, brush, rect, sf);
                }
                e.Handled = true;
            }
        }

        private void CardPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl == null) return;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(this.BackColor);
            Rectangle rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
            using (var path = ExpenseManager.App.Utilities.GraphicsExtensions.GetRoundedRect(rect, 15))
            using (var brush = new SolidBrush(Color.White))
            {
                e.Graphics.FillPath(brush, path);
                using (var pen = new Pen(Color.FromArgb(230, 230, 230), 1)) e.Graphics.DrawPath(pen, path);
            }
        }

        private Color GetAvatarColor(string name)
        {
            if (string.IsNullOrEmpty(name)) return Color.Gray;
            Color[] colors = { Color.FromArgb(52, 152, 219), Color.FromArgb(46, 204, 113), Color.FromArgb(155, 89, 182), Color.FromArgb(241, 196, 15), Color.FromArgb(230, 126, 34), Color.FromArgb(231, 76, 60), Color.FromArgb(26, 188, 156) };
            return colors[Math.Abs(name.GetHashCode()) % colors.Length];
        }

        public void DisplayUsers(PagedResult<UserDTO> result) { if (InvokeRequired) { Invoke(new Action(() => DisplayUsers(result))); return; } dgvUsers.Rows.Clear(); int rowNumber = result.StartIndex; foreach (var user in result.Items) { int rowIndex = dgvUsers.Rows.Add(rowNumber++, $"{user.FullName}\nID: {user.DisplayId}", user.Email, user.Role, user.CreatedAt.ToString("dd/MM/yyyy"), user.LastLoginText, user.StatusText, ""); dgvUsers.Rows[rowIndex].Tag = user.UserId; } lblPaginationInfo.Text = $"Page {result.PageNumber} of {result.TotalPages}"; }
        public void DisplayStatistics(UserStatisticsDTO stats) { if (InvokeRequired) { Invoke(new Action(() => DisplayStatistics(stats))); return; } lblTotalValue.Text = stats.TotalUsers.ToString(); lblActiveValue.Text = stats.ActiveUsers.ToString(); lblBlockedValue.Text = stats.BlockedUsers.ToString(); lblAdminsValue.Text = stats.Administrators.ToString(); }
        public void ShowMessage(string message, string title, bool isError = false) { MessageBox.Show(message, title, MessageBoxButtons.OK, isError ? MessageBoxIcon.Error : MessageBoxIcon.Information); }
        public void ShowLoading(bool isLoading) { if (InvokeRequired) { Invoke(new Action(() => ShowLoading(isLoading))); return; } loadingPanel.Visible = isLoading; if (isLoading) loadingPanel.BringToFront(); }
        public void UpdatePaginationInfo(string info) { if (InvokeRequired) { Invoke(new Action(() => UpdatePaginationInfo(info))); return; } if (info.StartsWith("Showing")) lblShowingInfo.Text = info; else if (info.StartsWith("Page")) { lblPaginationInfo.Text = info; var parts = info.Split(' '); if (parts.Length >= 4) { if (int.TryParse(parts[1], out int current)) _currentPage = current; if (int.TryParse(parts[3], out int total)) _totalPages = total; } } }
        public void EnablePagination(bool hasPrevious, bool hasNext) { }
        private void BtnSearch_Click(object sender, EventArgs e) => _ = _presenter?.SearchAsync(txtSearch.Text);
        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e) { if (e.KeyChar == (char)Keys.Enter) { e.Handled = true; BtnSearch_Click(sender, e); } }
        private void CmbRole_SelectedIndexChanged(object sender, EventArgs e) { if (_presenter != null) _ = _presenter.FilterByRoleAsync(cmbRole.SelectedItem.ToString()); }
        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e) { if (_presenter != null) _ = _presenter.FilterByStatusAsync(cmbStatus.SelectedItem.ToString()); }
        private void BtnRefresh_Click(object sender, EventArgs e) { txtSearch.Clear(); cmbRole.SelectedIndex = 0; cmbStatus.SelectedIndex = 0; _ = _presenter?.RefreshAsync(); }
        private void LblPaginationInfo_Click(object sender, EventArgs e) { /* Logic phân trang */ }
        private void DgvUsers_CellClick(object sender, DataGridViewCellEventArgs e) { if (e.RowIndex < 0) return; if (e.ColumnIndex == dgvUsers.Columns["colActions"].Index) { var userId = dgvUsers.Rows[e.RowIndex].Tag?.ToString(); var userName = dgvUsers.Rows[e.RowIndex].Cells["colUser"].Value?.ToString()?.Split('\n')[0]; if (!string.IsNullOrEmpty(userId)) ShowActionsMenu(userId, userName, e.RowIndex); } }

        // Menu Actions
        private void ShowActionsMenu(string userId, string userName, int rowIndex)
        {
            var menu = new ContextMenuStrip { Font = new Font("Segoe UI", 10F) };
            var toggleItem = new ToolStripMenuItem { Text = "Toggle Status", Image = GetMenuIconBitmap(IconChar.PowerOff, 16, Color.FromArgb(52, 152, 219)) };
            toggleItem.Click += (s, e) => ToggleUserStatus(userId, userName);
            var deleteItem = new ToolStripMenuItem { Text = "Delete User", Image = GetMenuIconBitmap(IconChar.Trash, 16, Color.FromArgb(231, 76, 60)) };
            deleteItem.Click += (s, e) => DeleteUser(userId, userName);
            menu.Items.AddRange(new ToolStripItem[] { toggleItem, deleteItem });
            var cellRect = dgvUsers.GetCellDisplayRectangle(dgvUsers.Columns["colActions"].Index, rowIndex, true);
            var menuLocation = dgvUsers.PointToScreen(new Point(cellRect.Right - 150, cellRect.Bottom));
            menu.Show(menuLocation);
        }

        private void ToggleUserStatus(string userId, string userName) { if (MessageBox.Show($"Toggle status of '{userName}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) _ = _presenter?.ToggleUserStatusAsync(userId, userName); }
        private void DeleteUser(string userId, string userName) { if (MessageBox.Show($"Delete '{userName}'? Cannot undo!", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) _ = _presenter?.DeleteUserAsync(userId, userName); }

      
        private Bitmap GetMenuIconBitmap(IconChar icon, int size, Color color)
        {
            using (var iconPic = new IconPictureBox())
            {
                iconPic.IconChar = icon;
                iconPic.IconSize = size;
                iconPic.IconColor = color;
                iconPic.BackColor = Color.Transparent;
                iconPic.Size = new Size(size, size);
                iconPic.SizeMode = PictureBoxSizeMode.CenterImage;
                var bmp = new Bitmap(size, size);
                iconPic.DrawToBitmap(bmp, new Rectangle(0, 0, size, size));
                return bmp;
            }
        }
    }
}