using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D; // Thêm cái này để dùng LinearGradientBrush

// THÊM NAMESPACE VÀO ĐÂY (Quan trọng)
namespace ExpenseManager.App.CustomControls
{
    public class CustomProgressBar : Control
    {
        private double _percentage = 0.0; // 0..100
        private int _minimum = 0;
        private int _maximum = 100;
        private bool _showText = true;
        private bool _useGradient = false;

        // Thresholds (0..100)
        public int WarningThreshold { get; set; } = 70;  // cam
        public int DangerThreshold { get; set; } = 90;   // do

        [Browsable(true)]
        [Category("Behavior")]
        public int Minimum
        {
            get => _minimum;
            set { _minimum = value; Invalidate(); }
        }

        [Browsable(true)]
        [Category("Behavior")]
        public int Maximum
        {
            get => _maximum;
            set { _maximum = value; Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public bool ShowText
        {
            get => _showText;
            set { _showText = value; Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public bool UseGradient
        {
            get => _useGradient;
            set { _useGradient = value; Invalidate(); }
        }

        [Browsable(true)]
        [Category("Behavior")]
        public double Percentage
        {
            get => _percentage;
            set
            {
                // clamp to [Minimum..Maximum] interpreted as 0..100
                double p = Math.Max(Minimum, Math.Min(Maximum, value));
                _percentage = p;
                Invalidate();
            }
        }

        // Optional: animate change
        public void SetPercentageAnimated(double newValue, int milliseconds = 300)
        {
            double start = _percentage;
            double end = Math.Max(Minimum, Math.Min(Maximum, newValue));
            if (Math.Abs(end - start) < 0.01) { Percentage = end; return; }

            int stepCount = Math.Max(1, milliseconds / 15);
            int currentStep = 0;
            Timer t = new Timer { Interval = Math.Max(8, milliseconds / stepCount) };
            t.Tick += (s, e) =>
            {
                currentStep++;
                double progress = (double)currentStep / stepCount;
                Percentage = start + (end - start) * progress;
                if (currentStep >= stepCount) { t.Stop(); t.Dispose(); Percentage = end; }
            };
            t.Start();
        }

        public CustomProgressBar()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            Size = new Size(200, 24);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.Clear(BackColor);

            Rectangle rect = ClientRectangle;
            if (rect.Width <= 0 || rect.Height <= 0) return;

            // Draw border (optional)
            using (var borderPen = new Pen(Color.FromArgb(200, 200, 200)))
            {
                g.DrawRectangle(borderPen, rect.Left, rect.Top, rect.Width - 1, rect.Height - 1);
            }

            // Inner rect (padding)
            Rectangle inner = new Rectangle(rect.Left + 2, rect.Top + 2, rect.Width - 4, rect.Height - 4);
            g.FillRectangle(new SolidBrush(Color.FromArgb(250, 250, 250)), inner);

            // Fill width by percentage
            double frac = 0;
            if (Maximum != Minimum) frac = (Percentage - Minimum) / (double)(Maximum - Minimum);
            frac = Math.Max(0.0, Math.Min(1.0, frac));
            int fillWidth = (int)(inner.Width * frac);
            Rectangle fillRect = new Rectangle(inner.Left, inner.Top, Math.Max(0, fillWidth), inner.Height);

            // Choose color by thresholds
            Color fillColor;
            if (Percentage >= DangerThreshold) fillColor = Color.FromArgb(239, 68, 68); // red
            else if (Percentage >= WarningThreshold) fillColor = Color.FromArgb(245, 158, 11); // orange
            else fillColor = Color.FromArgb(34, 197, 94); // green

            if (UseGradient)
            {
                if (fillRect.Width > 0 && fillRect.Height > 0)
                {
                    using (var brush = new LinearGradientBrush(fillRect, ControlPaint.Dark(fillColor), ControlPaint.Light(fillColor), 0f))
                    {
                        g.FillRectangle(brush, fillRect);
                    }
                }
            }
            else
            {
                using (var brush = new SolidBrush(fillColor))
                {
                    g.FillRectangle(brush, fillRect);
                }
            }

            // Optionally draw text
            if (ShowText)
            {
                string text = $"{Percentage:F1}%";
                SizeF textSize = g.MeasureString(text, Font);
                PointF textPos = new PointF(
                    rect.Left + (rect.Width - textSize.Width) / 2f,
                    rect.Top + (rect.Height - textSize.Height) / 2f
                );

                using (var shadowBrush = new SolidBrush(Color.FromArgb(180, Color.Black)))
                {
                    g.DrawString(text, Font, shadowBrush, textPos.X + 1, textPos.Y + 1);
                }
                
                bool textOverFill = textPos.X + textSize.Width <= inner.Left + fillWidth;
                Color textColor = textOverFill ? Color.White : Color.FromArgb(30, 41, 59);
                using (var txtBrush = new SolidBrush(textColor))
                {
                    g.DrawString(text, Font, txtBrush, textPos);
                }
            }
        }
    }
}