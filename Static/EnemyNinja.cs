using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms.Static
{
    public static class EnemyNinja
    {
        public static int idleFrames = 4;
        public static int runFrames = 3;
        public static int attackFrames = 4;
        public static int deathFrames = 4;
        public static int jumpFrames = 5;
        public static int fallFrames = 2;

        public static int sizeX = 20;
        public static int sizeY = 32;
        public static int startPosAnimation = 16;
        public static int followStepOfanimation = 48;
        public static int switchStepOfanimation = 32;

        public static Rectangle Rectangle = new Rectangle(new Point(startPosAnimation, startPosAnimation), new Size(sizeX, sizeY));

        public static int startPosXTop = 350;
        public static int startPosYTop = 350;
        public static int startPosXLeft = 600;
        public static int startPosYLeft = 350;
        public static int startPosXRight = 300;
        public static int startPosYRight = 500;
        public static int startPosXBottom = 1000;
        public static int startPosYBottom = 780;
    }
}
