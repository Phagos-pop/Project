using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsForms.Enum;
using WindowsForms.Static;

namespace WindowsForms.Class
{
    abstract class Entity : IDisposable
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public int DirX { get; set; }
        public int DirY { get; set; }

        public bool IsMoving { get; set; }
        public bool IsOnAir { get; set; }
        public bool IsJumping { get; set; }
        public int Flip { get; set; }

        public int curreentAnimation;
        public int currentFrame;
        public int currentLimit;
        public int idleFrames;
        public int runFrames;
        public int fallFrames;
        public int jumpFrames;
        public int attackFrames;
        public int deathFrames;
        public Rectangle rectangle;
        public int frameStep;
        public int startPosOfAnimation;
        public int followStepOfAnimation;
        public int switchStepOfAnimation;
        public Point[] hitBox;
        public int timerToFall;
        public Image spriteSheet;

        public Entity(int posY, int posX, int idleFrames, int runFrames, int fallFrames,
            int jumpFrames, int attackFrames, int deathFrames, Image spritesheet,
            Rectangle rectangle, int startPosOfAnimation , int followStepOfanimation, int switchStepOfanimation)
        {
            this.PosX = posX;
            this.PosY = posY;
            this.idleFrames = idleFrames;
            this.runFrames = runFrames;
            this.fallFrames = fallFrames;
            this.attackFrames = attackFrames;
            this.jumpFrames = jumpFrames;
            this.deathFrames = deathFrames;
            this.spriteSheet = spritesheet;
            this.rectangle = rectangle;
            this.startPosOfAnimation = startPosOfAnimation;
            this.followStepOfAnimation = followStepOfanimation;
            this.switchStepOfAnimation = switchStepOfanimation;
            curreentAnimation = 0;
            currentFrame = 0;
            frameStep = 0;
            currentLimit = idleFrames;
            Flip = 1;
            CreateHitBox();
            timerToFall = 0;
        }

        public void CreateHitBox()
        {
            Point[] points = new Point[rectangle.Width * 2 + rectangle.Height * 2];
            int numberOfPoints = 0;
            for (int j = 0; j < rectangle.Width; j++)
            {
                points[numberOfPoints] = new Point(PosX + j, PosY);
                numberOfPoints++;
            }
            for (int j = 0; j < rectangle.Width; j++)
            {
                points[numberOfPoints] = new Point(PosX + j, PosY + rectangle.Height);
                numberOfPoints++;
            }
            for (int o = 0; o < rectangle.Height; o++)
            {
                points[numberOfPoints] = new Point(PosX, PosY + o);
                numberOfPoints++;
            }
            for (int o = 0; o < rectangle.Height; o++)
            {
                points[numberOfPoints] = new Point(PosX + rectangle.Width, PosY + o);
                numberOfPoints++;
            }
            hitBox = points;
        }

        public bool ContactWithHitbox(Point[] otherHitbox)
        {
            for (int i = 0; i < hitBox.Length; i++)
            {
                for (int j = 0; j < otherHitbox.Length; j++)
                {
                    if (new Point(DirX + hitBox[i].X, hitBox[i].Y + DirY) == otherHitbox[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Fly()
        {
            if (IsJumping)
            {
                timerToFall = 12;
                IsJumping = false;
            }
            if (timerToFall > 4)
            {
                timerToFall -= 1; 
                DirY += -1;
                PosY += DirY;
                return;
            }
            if (timerToFall > 0)
            {
                timerToFall -= 1;
            }
            if (timerToFall == 0 && IsOnAir)
            {
                DirY = 4;
                PosY += DirY;
            }            
        }


        public virtual void Move()
        {
            if (DirY < -25)
            {
                DirY = -25;
            }
            if (DirY > 3)
            {
                DirY = 3;
            }
            if (DirX > 3)
            {
                DirX = 3;
            }
            if (DirX < -3)
            {
                DirX = -3;
            }
            PosX += DirX;
            PosY += DirY;
        }

        public virtual void PlayAnimation(Graphics g)
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
                    currentFrame = -1;
                    if (currentLimit == runFrames)
                    {
                        currentFrame = 2;
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

        public virtual void SetAnimationConfiguration(AnimationStyle animation)
        {
            curreentAnimation = (int)animation;

            switch (curreentAnimation)
            {
                case 0:
                    if (currentLimit != idleFrames)
                    {
                        currentLimit = idleFrames;
                    }                    
                    break;
                case 1:
                    if (currentLimit != idleFrames)
                    {
                        currentLimit = idleFrames;
                    }
                    break;
                case 2:
                    if (currentLimit != runFrames)
                    {
                        currentLimit = runFrames;
                    }
                    break;
                case 3:
                    if (currentLimit != runFrames)
                    {
                        currentLimit = runFrames;
                    }
                    break;
                case 4:
                    if (currentLimit != fallFrames)
                    {
                        currentLimit = fallFrames;
                        frameStep = 0;
                        currentFrame = 0;
                    }
                    break;
                case 5:
                    if (currentLimit != fallFrames)
                    {
                        currentLimit = fallFrames;
                        frameStep = 0;
                        currentFrame = 0;
                    }
                    break;
                case 6:
                    if (currentLimit != jumpFrames)
                    {
                        currentLimit = jumpFrames;
                    }
                    break;
                case 7:
                    if (currentLimit != jumpFrames)
                    {
                        currentLimit = jumpFrames;
                    }
                    break;
                case 13:
                    currentLimit = idleFrames;
                    break;
                case 14:
                    currentLimit = runFrames;
                    break;
            }
        }

        public void SetStartPosOfAnimation()
        {
            rectangle.X = startPosOfAnimation;
            frameStep = 0;
            currentFrame = 0;
        }

        public void InteractingWithMap(Point[] allTopPlatformHitbox, Point[] allSidePlatformHitbox)
        {
            CreateHitBox();
            if (ContactWithHitbox(allTopPlatformHitbox))
            {
                IsOnAir = false;
                if (!IsJumping)
                {
                    DirY = 0;
                }
                if (!IsMoving)
                {
                    if (Flip == -1)
                        SetAnimationConfiguration(AnimationStyle.FlipIdle);
                    else SetAnimationConfiguration(AnimationStyle.Idle);
                }
            }
            else
            {
                IsOnAir = true;
            }
            if (IsOnAir)
            {
                Fly();
            }
            if (ContactWithHitbox(allSidePlatformHitbox))
            {
                if (!IsJumping)
                {
                    DirX = 0;
                }
                IsMoving = false;
            }
            if (IsMoving)
            {
                Move();
            }
        }

        public void Dispose()
        {
            spriteSheet = null;
        }
    }
}
