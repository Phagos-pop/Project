using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using WindowsForms.Interface;
using WindowsForms.Servise;
using WindowsForms.Extension;

namespace WindowsForms
{
    public partial class StartMenu : Form , IMainMenuForm
    {
        public StartMenu()
        {
            InitializeComponent();

            //MainMenuServise.EnableBackgroundMusic();
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

        void SetAllButtonsImage()
        {
            MainMenuServise.SetButtonImage(ExitPicture, "Exit", new RectangleF(43, 20, 0, 0));
            MainMenuServise.SetButtonImage(NewGamePicture, "New Game", new RectangleF(10, 20, 0, 0));
            MainMenuServise.SetButtonImage(LoadGamePicture, "Load Game", new RectangleF(10, 20, 0, 0));
            MainMenuServise.SetButtonImage(OptionPicture, "Option", new RectangleF(30, 20, 0, 0));           
        }

        private void Exit_Mouse_Down(object sender, MouseEventArgs e)
        {
            MainMenuServise.SetButtonImage(ExitPicture, "Exit", new RectangleF(43, 20, 0, 0), 59);
        }

        private void Exit_Mouse_Up(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
             
        private void OptionPicture_MouseDown(object sender, MouseEventArgs e)
        {
            MainMenuServise.SetButtonImage(OptionPicture, "Option", new RectangleF(30, 20, 0, 0), 59);
        }

        private void OptionPicture_MouseUp(object sender, MouseEventArgs e)
        {
            MainMenuServise.SetButtonImage(OptionPicture, "Option", new RectangleF(30, 20, 0, 0));
            OptionForm optionForm = new OptionForm();
            optionForm.Show();
        }

        private void LoadGamePicture_MouseDown(object sender, MouseEventArgs e)
        {
            MainMenuServise.SetButtonImage(LoadGamePicture, "Load Game", new RectangleF(10, 20, 0, 0), 59);
        }

        private void LoadGamePicture_MouseUp(object sender, MouseEventArgs e)
        {
            MainMenuServise.SetButtonImage(LoadGamePicture, "Load Game", new RectangleF(10, 20, 0, 0));
        }

        private void NewGamePicture_MouseDown(object sender, MouseEventArgs e)
        {
            MainMenuServise.SetButtonImage(NewGamePicture, "New Game", new RectangleF(10, 20, 0, 0), 59);
        }

        private void NewGamePicture_MouseUp(object sender, MouseEventArgs e)
        {
            MainMenuServise.SetButtonImage(NewGamePicture, "New Game", new RectangleF(10, 20, 0, 0));
            FirstLevel firstLevel = new FirstLevel();
            firstLevel.Show();
        }
    }
}