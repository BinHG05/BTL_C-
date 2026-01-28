using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.Admin.Forms
{
    public partial class TicketDetailsAD : Form
    {
        public string TicketID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Question { get; set; }
        public string QuestionType { get; set; }
        public string Status { get; set; }
        public string AdminNote { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }

        public TicketDetailsAD()
        {
            InitializeComponent();
            InitializeForm();
        }
        private readonly Dictionary<string, string> StatusMap = new Dictionary<string, string>
        {
            {"Mở", "Open"},
            {"Đang xử lí", "Pending"},
            {"Đã xử lí", "Resolved"}
        };
        private string GetLogicStatus(string displayStatus)
        {
            return StatusMap.ContainsKey(displayStatus) ? StatusMap[displayStatus] : displayStatus;
        }
        private string GetDisplayStatus(string logicStatus)
        {
            return StatusMap.FirstOrDefault(x => x.Value == logicStatus).Key ?? logicStatus;
        }
        private void InitializeForm()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.None;

            this.BackColor = Color.White;
        }

        private void TicketDetailsAD_Load(object sender, EventArgs e)
        {
            lblUserNameValue.Text = UserName ?? "N/A";
            lblEmailValue.Text = Email ?? "N/A";
            lblQuestionValue.Text = Question ?? "N/A";
            lblQuestionTypeValue.Text = QuestionType ?? "N/A";


            cboStatus.Text = GetDisplayStatus(Status ?? "Open"); 
            UpdateStatusColor();

            txtAdminNote.Text = AdminNote ?? "";

            lblCreatedValue.Text = CreatedDate ?? "N/A";
            lblUpdatedValue.Text = UpdatedDate ?? "N/A";
        }

        private void UpdateStatusColor()
        {
            string logicStatus = GetLogicStatus(cboStatus.Text);

            switch (logicStatus) 
            {
                case "Open":
                    lblStatusValue.ForeColor = Color.FromArgb(1, 87, 155);
                    lblStatusValue.BackColor = Color.FromArgb(207, 244, 252);
                    break;
                case "Pending":
                    lblStatusValue.ForeColor = Color.FromArgb(230, 126, 34);
                    lblStatusValue.BackColor = Color.FromArgb(255, 243, 205);
                    break;
                case "Resolved":
                    lblStatusValue.ForeColor = Color.FromArgb(27, 94, 32);
                    lblStatusValue.BackColor = Color.FromArgb(200, 230, 201);
                    break;
                default:
                    lblStatusValue.ForeColor = Color.Black;
                    lblStatusValue.BackColor = Color.White;
                    break;
            }
            lblStatusValue.Text = cboStatus.Text;
        }

        private void CboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStatusColor();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Status = GetLogicStatus(cboStatus.Text);
            AdminNote = txtAdminNote.Text;
            UpdatedDate = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            lblUpdatedValue.Text = UpdatedDate;

            this.DialogResult = DialogResult.OK; 
            this.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnCloseX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void HeaderPanel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void HeaderPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void HeaderPanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}