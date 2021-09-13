using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsForms.Enum;
using WindowsForms.Interface;

namespace WindowsForms.Class
{
    class Enemy : Entity, IMainGameIndicators
    {
        Point[] agrHitbox;

        public int HP { get; set; }

        public Enemy(int posY, int posX, int idleFrames, int runFrames, int fallFrames,
            int jumpFrames, int attackFrames, int deathFrames, Image spritesheet,
            Rectangle rectangle, int startPosOfAnimation, int followStepOfanimation, int switchStepOfanimation)
            : base(posY, posX, idleFrames, runFrames, fallFrames,
            jumpFrames, attackFrames, deathFrames, spritesheet,
             rectangle, startPosOfAnimation, followStepOfanimation, switchStepOfanimation)
        {

        }

        public void InteractingWithPlayer(Entity player)
        {
            CreateAgrHitbox();
            if (ContactWithAgrHitbox(player.hitBox) == 1)
            {
                DirX += 3;
                SetAnimationConfiguration(AnimationStyle.Run);
                IsMoving = true;
            }
            if (ContactWithAgrHitbox(player.hitBox) == -1)
            {
                DirX += -3;
                SetAnimationConfiguration(AnimationStyle.FlipRun);
                IsMoving = true;
            }
            if (ContactWithAgrHitbox(player.hitBox) == 0)
            {
                DirX = 0;
                IsMoving = false;
            }
            if (ContactWithHitbox(player.hitBox))
            {
                DirX = 0;
                IsMoving = false;
            }
        }

        public void CreateAgrHitbox()
        {
            Point[] points = new Point[100];
            int numberOfPoints = 0;
            for (int j = 0; j < 50; j++)
            {
                points[numberOfPoints] = new Point(PosX + j + rectangle.Width, PosY + (rectangle.Height/2));
                numberOfPoints++;
            }
            for (int j = 0; j < 50; j++)
            {
                points[numberOfPoints] = new Point(PosX - j, PosY + (rectangle.Height / 2));
                numberOfPoints++;
            }
            agrHitbox = points;
        }

        public int ContactWithAgrHitbox(Point[] otherHitbox)
        {
            for (int i = 0; i < agrHitbox.Length; i++)
            {
                for (int j = 0; j < otherHitbox.Length; j++)
                {
                    if (agrHitbox[i] == otherHitbox[j])
                    {
                        if (otherHitbox[j].X > PosX)
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
            }
            return 0;
        }

        public override void Move()
        {
            if (DirY < -25)
            {
                DirY = -25;
            }
            if (DirY > 3)
            {
                DirY = 3;
            }
            if (DirX > 2)
            {
                DirX = 2;
            }
            if (DirX < -2)
            {
                DirX = -2;
            }
            PosX += DirX;
            PosY += DirY;
        }

        public override void PlayAnimation(Graphics g)
        {
            rectangle.Y = startPosOfAnimation + curreentAnimation * switchStepOfAnimation;
            if (frameStep < currentLimit - 1)
            {
                if (currentFrame < currentLimit - 1)
                {
                    currentFrame++;
                }
                if (currentFrame == currentLimit - 1)
                {
                    rectangle.X += followStepOfAnimation;
                    currentFrame = -3;
                    if (currentLimit == runFrames)
                    {
                        currentFrame = -2;
                    }
                    frameStep++;
                }
            }
            if (frameStep == currentLimit - 1)
            {
                rectangle.X = startPosOfAnimation;
                frameStep = 0;
            }
            g.DrawImage(spriteSheet, PosX, PosY, rectangle, GraphicsUnit.Pixel);
        }

        public override void SetAnimationConfiguration(AnimationStyle animation)
        {
            base.SetAnimationConfiguration(animation);
        }
    }
}
