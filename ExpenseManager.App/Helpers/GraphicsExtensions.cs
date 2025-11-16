using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ExpenseManager.App.Helpers
{
    public static class GraphicsExtensions
    {
        public static void FillRoundedRectangle(this Graphics g, Brush brush, Rectangle bounds, int radius)
        {
            //using (var path = new GraphicsPath())
            //{
            //    path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            //    path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
            //    path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
            //    path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
            //    path.CloseFigure();
            //    g.FillPath(brush, path);
            //}
        }
    }
}
