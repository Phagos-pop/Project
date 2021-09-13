using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms.Servise
{
    class MainMenuServise
    {
        public static WMPLib.WindowsMediaPlayer MainMenuMusic;
        static PrivateFontCollection CustomFont;

        public static void SetButtonImage(PictureBox button, string text, RectangleF rectangle, int y = 10)
        {
            if (CustomFont == null)
            {
                CustomFont = new PrivateFontCollection();
                CustomFont.AddFontFile("C:\\Users\\Phagos\\AppData\\Local\\Microsoft\\Windows\\Fonts\\_bitmap_font____romulus_by_pix3m-d6aokem.ttf");
            }
            Image image = new Bitmap("E:\\Winform\\WindowsForms\\Assets\\UI\\ButtonImage.png");
            Image NewButtonImage = new Bitmap(140, 60);
            Graphics g = Graphics.FromImage(NewButtonImage);
            g.DrawImage(image, new Rectangle(0, 0, 140, 60), 15, y, 130, 40, GraphicsUnit.Pixel);

            Graphics part = Graphics.FromImage(NewButtonImage);
            part.DrawString(text, new Font(CustomFont.Families[0], 20),
            new SolidBrush(Color.DarkRed), rectangle);

            button.BackgroundImage = NewButtonImage;
            button.BackgroundImageLayout = ImageLayout.Stretch;
            button.BackColor = Color.Transparent;
        }

        public static void EnableBackgroundMusic()
        {
            MainMenuMusic = new WMPLib.WindowsMediaPlayer{ URL = @"E:\\Winform\\WindowsForms\\Music\\StartMenu.mp3" };
            MainMenuMusic.settings.volume = 100;
            MainMenuMusic.controls.play();
        }

        public static void TurnOffBackgroundMusic()
        {
            MainMenuMusic.controls.stop();
            MainMenuMusic.close();
        }
    }
}
