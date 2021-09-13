using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.Interface;
using WindowsForms.Servise;
using WindowsForms.Extension;

namespace WindowsForms
{
    public partial class OptionForm : Form , IMainMenuForm
    {
        public OptionForm()
        {
            InitializeComponent();

            EnableAnimatedBackground();
            this.EnableFullScreen();
            SetAllButtonsImage();
        }

        public void EnableAnimatedBackground()
        {
            BackgroundImage = Image.FromFile("E:\\Winform\\WindowsForms\\Assets\\Background\\StartMenu.gif");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            ImageAnimator.Animate(BackgroundImage, OnFrameChanged);
        }

        public void OnFrameChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => OnFrameChanged(sender, e)));
                return;
            }
            ImageAnimator.UpdateFrames();
            Invalidate(false);
        }

        private void SetAllButtonsImage()
        {
            MainMenuServise.SetButtonImage(BackPicture, "Back", new RectangleF(43, 20, 0, 0));
        }

        private void BackPicture_MouseDown(object sender, MouseEventArgs e)
        {
            MainMenuServise.SetButtonImage(BackPicture, "Back", new RectangleF(43, 20, 0, 0), 59);
        }

        private void BackPicture_MouseUp(object sender, MouseEventArgs e)
        {
            this.Hide();
        }
    }
}
