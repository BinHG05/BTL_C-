using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.Admin.UC
{
    public partial class UC_Dashboard : UserControl
    {
        public UC_Dashboard()
        {
            InitializeComponent();
            InitializeCustomComponents();
            LoadExpensesData();
        }

        private void InitializeCustomComponents()
        {
            // Apply rounded corners to stat cards
            ApplyRoundedCorners(pnlTotalBalance, 12);
            ApplyRoundedCorners(pnlPeriodChange, 12);
            ApplyRoundedCorners(pnlPeriodExpenses, 12);
            ApplyRoundedCorners(pnlPeriodIncome, 12);
            ApplyRoundedCorners(pnlBalanceTrends, 12);
            ApplyRoundedCorners(pnlExpensesBreakdown, 12);

            // Draw a simple area chart
            DrawBalanceChart();
        }

        private void ApplyRoundedCorners(Panel panel, int radius)
        {
            panel.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
                GraphicsPath path = GetRoundedRectangle(rect, radius);

                panel.Region = new Region(path);

                using (Pen pen = new Pen(Color.FromArgb(229, 231, 235), 1))
                {
                    g.DrawPath(pen, path);
                }
            };
        }

        private GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        private void DrawBalanceChart()
        {
            pnlBalanceChart.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Sample data points
                int[] dataPoints = { 50, 60, 55, 70, 85, 100, 110, 95, 120, 150, 130, 155 };

                int width = pnlBalanceChart.Width;
                int height = pnlBalanceChart.Height;
                int margin = 20;

                // Calculate points
                List<PointF> points = new List<PointF>();
                float xStep = (float)(width - margin * 2) / (dataPoints.Length - 1);
                float maxValue = 200f;

                for (int i = 0; i < dataPoints.Length; i++)
                {
                    float x = margin + i * xStep;
                    float y = height - margin - (dataPoints[i] / maxValue) * (height - margin * 2);
                    points.Add(new PointF(x, y));
                }

                // Create gradient area
                GraphicsPath areaPath = new GraphicsPath();
                areaPath.AddLine(margin, height - margin, points[0].X, points[0].Y);

                for (int i = 0; i < points.Count - 1; i++)
                {
                    areaPath.AddLine(points[i], points[i + 1]);
                }

                areaPath.AddLine(points[points.Count - 1].X, points[points.Count - 1].Y,
                                width - margin, height - margin);
                areaPath.AddLine(width - margin, height - margin, margin, height - margin);

                // Draw gradient fill
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(0, height),
                    Color.FromArgb(120, 99, 122, 255),
                    Color.FromArgb(20, 99, 122, 255)))
                {
                    g.FillPath(brush, areaPath);
                }

                // Draw line
                using (Pen pen = new Pen(Color.FromArgb(99, 102, 241), 3))
                {
                    for (int i = 0; i < points.Count - 1; i++)
                    {
                        g.DrawLine(pen, points[i], points[i + 1]);
                    }
                }
            };
        }

        private void LoadExpensesData()
        {
            // Sample expense data
            var expenses = new List<ExpenseCategory>
            {
                new ExpenseCategory { Name = "Food", Amount = 1200, Color = Color.FromArgb(251, 146, 60), Percentage = 38 },
                new ExpenseCategory { Name = "Transport", Amount = 1200, Color = Color.FromArgb(251, 191, 36), Percentage = 38 },
                new ExpenseCategory { Name = "Healthcare", Amount = 1200, Color = Color.FromArgb(253, 224, 71), Percentage = 38 },
                new ExpenseCategory { Name = "Education", Amount = 1200, Color = Color.FromArgb(132, 204, 22), Percentage = 38 },
                new ExpenseCategory { Name = "Clothes", Amount = 1200, Color = Color.FromArgb(34, 197, 94), Percentage = 38 },
                new ExpenseCategory { Name = "Pets", Amount = 1200, Color = Color.FromArgb(6, 182, 212), Percentage = 38 }
            };

            // Create progress bar at top
            Panel progressBar = CreateProgressBar(expenses);
            progressBar.Location = new Point(0, 0);
            progressBar.Width = pnlExpensesList.Width - 5;
            progressBar.Height = 8;
            pnlExpensesList.Controls.Add(progressBar);

            // Add expense items
            int yPos = 30;
            foreach (var expense in expenses)
            {
                Panel expenseItem = CreateExpenseItem(expense);
                expenseItem.Location = new Point(0, yPos);
                expenseItem.Width = pnlExpensesList.Width - 20;
                pnlExpensesList.Controls.Add(expenseItem);
                yPos += 60;
            }
        }

        private Panel CreateProgressBar(List<ExpenseCategory> expenses)
        {
            Panel progressBar = new Panel
            {
                Height = 8
            };

            progressBar.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                float xPos = 0;
                float totalWidth = progressBar.Width;

                foreach (var expense in expenses)
                {
                    float segmentWidth = (expense.Percentage / 100f) * totalWidth;

                    using (SolidBrush brush = new SolidBrush(expense.Color))
                    {
                        g.FillRectangle(brush, xPos, 0, segmentWidth, progressBar.Height);
                    }

                    xPos += segmentWidth;
                }
            };

            return progressBar;
        }

        private Panel CreateExpenseItem(ExpenseCategory expense)
        {
            Panel item = new Panel
            {
                Height = 50,
                BackColor = Color.Transparent
            };

            // Color indicator
            Panel colorBox = new Panel
            {
                Size = new Size(12, 12),
                BackColor = expense.Color,
                Location = new Point(0, 15)
            };
            colorBox.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(0, 0, colorBox.Width - 1, colorBox.Height - 1);
                    colorBox.Region = new Region(path);
                }
            };

            // Category name
            Label lblName = new Label
            {
                Text = expense.Name,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(31, 41, 55),
                AutoSize = true,
                Location = new Point(25, 15)
            };

            // Amount
            Label lblAmount = new Label
            {
                Text = $"${expense.Amount}",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55),
                AutoSize = true,
                Location = new Point(300, 15)
            };

            // Percentage
            Label lblPercentage = new Label
            {
                Text = $"{expense.Percentage}%",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(107, 114, 128),
                AutoSize = true,
                Location = new Point(400, 15)
            };

            item.Controls.Add(colorBox);
            item.Controls.Add(lblName);
            item.Controls.Add(lblAmount);
            item.Controls.Add(lblPercentage);

            return item;
        }

        private class ExpenseCategory
        {
            public string Name { get; set; }
            public decimal Amount { get; set; }
            public Color Color { get; set; }
            public int Percentage { get; set; }
        }
    }
}