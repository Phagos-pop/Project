using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms.Extension
{
    public static class FormsExtansions
    {
        public static void EnableFullScreen(this Form form)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        public static Point[] Enafd(this Form form)
        {
            int valueOfPoints = 0;
            int currentNumberOfPoint = 0;

            foreach (Control x in form.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform")
                    valueOfPoints += (int)((x.Bounds.Height * 2) - 4);
            }
            Point[] arrayOfPoints = new Point[valueOfPoints];
            foreach (Control x in form.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform")
                {
                    for (int i = 0; i < x.Bounds.Height - 2; i++)
                    {
                        arrayOfPoints[currentNumberOfPoint] = new Point(x.Bounds.X, x.Bounds.Y + i + (x.Bounds.Height / 4));
                        currentNumberOfPoint++;
                    }
                    for (int i = 0; i < x.Bounds.Height - 2; i++)
                    {
                        arrayOfPoints[currentNumberOfPoint] = new Point(x.Bounds.X + x.Bounds.Width, x.Bounds.Y + i + (x.Bounds.Height / 4));
                        currentNumberOfPoint++;
                    }
                }
            }
            return arrayOfPoints;
        }
    }
}
