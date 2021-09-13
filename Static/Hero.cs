using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms.Static
{
    public static class Hero
    {
        public static int idleFrames = 4;
        public static int runFrames = 6;
        public static int attackFrames = 7;
        public static int deathFrames = 4;
        public static int jumpFrames = 6;
        public static int fallFrames = 2;

        public static int sizeX = 20;
        public static int sizeY = 32;
        public static int startPosAnimation = 16;
        public static int followStepOfAnimation = 48;
        public static int switchStepOfAnimation = 32;

        public static Rectangle Rectangle = new Rectangle(new Point(startPosAnimation, startPosAnimation), new Size(Hero.sizeX, Hero.sizeY));

        public static int startPosX = 338;
        public static int startPosY = 780;
    }
}
