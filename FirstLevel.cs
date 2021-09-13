using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.Interface;
using WindowsForms.Servise;
using WindowsForms.Extension;
using WindowsForms.Class;
using WindowsForms.Static;
using System.Threading;
using WindowsForms.Enum;
using System.IO;

namespace WindowsForms
{
    public partial class FirstLevel : Form
    {
        Enemy enemyNinjaTop;
        Enemy enemyNinjaBottom;
        MainCharacter player;
        Point[] allTopPlatformHitbox;
        Point[] allSidePlatformHitbox;

        public FirstLevel()
        {
            InitializeComponent();

            SetTimer();
            Start();            

            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnUpPress);
            this.EnableFullScreen();
            
        }

        public void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    player.DirX += -3;
                    player.IsMoving = true;
                    player.Flip = -1;
                    if(player.IsOnAir == false)
                    {
                        player.SetAnimationConfiguration(AnimationStyle.FlipRun);
                    }
                    else
                    {
                        player.SetAnimationConfiguration(AnimationStyle.FlipFall);
                    }
                    break;
                case Keys.D:
                    player.DirX += 3;
                    player.IsMoving = true;
                    player.Flip = 1;
                    if (player.IsOnAir == false)
                    {
                        player.SetAnimationConfiguration(AnimationStyle.Run);
                    }
                    else
                    {
                        player.SetAnimationConfiguration(AnimationStyle.Fall);
                    }
                    break;
                case Keys.Space:
                    if (player.IsOnAir == false)
                    {
                        if (e.KeyCode == Keys.A)
                        {
                            player.DirX += -4;
                            player.SetAnimationConfiguration(AnimationStyle.FlipJump);
                            player.Flip = -1;
                        }
                        if (e.KeyCode == Keys.D)
                        {
                            player.DirX += 4;
                            player.SetAnimationConfiguration(AnimationStyle.Jump);
                            player.Flip = 1;
                        }
                        player.DirY += -2;
                        player.IsMoving = true;
                        player.IsJumping = true;
                        if (player.Flip == -1)
                            player.SetAnimationConfiguration(AnimationStyle.FlipJump);
                        else 
                            player.SetAnimationConfiguration(AnimationStyle.Jump);
                    }                    
                    break;
            }
        }

        public void OnUpPress(object sender, KeyEventArgs e)
        {
            player.DirX = 0;
            player.DirY = 0;
            player.IsMoving = false;
            player.SetStartPosOfAnimation();
            if (player.IsOnAir)
            {
                if (player.Flip == -1)
                    player.SetAnimationConfiguration(AnimationStyle.FlipFall);
                else player.SetAnimationConfiguration(AnimationStyle.Fall);
            }
            else
            {
                if (player.Flip == -1)
                    player.SetAnimationConfiguration(AnimationStyle.FlipIdle);
                else player.SetAnimationConfiguration(AnimationStyle.Idle);
            }            
        }

        public void SetTimer()
        {
            MainTimer.Interval = 2;
            MainTimer.Tick += new EventHandler(Update);
        }

        public void Update(object sender, EventArgs e)
        {
            Parallel.Invoke(
                () => {
                    player.InteractingWithMap(allTopPlatformHitbox, allSidePlatformHitbox);                 
                },
                () =>
                {
                    enemyNinjaTop.InteractingWithMap(allTopPlatformHitbox, allSidePlatformHitbox);
                },
                () =>
                {
                    enemyNinjaTop.InteractingWithPlayer(player);
                    enemyNinjaBottom.InteractingWithPlayer(player);
                },
                () =>
                {
                    enemyNinjaBottom.InteractingWithMap(allTopPlatformHitbox, allSidePlatformHitbox);
                }
                );
            Invalidate();            
        }

        public void Start()
        {            
            allTopPlatformHitbox = CreateTopPlatformHitbox();
            allSidePlatformHitbox = CreateSidePlatformHitbox();

            player = new MainCharacter
                (Hero.startPosY, Hero.startPosX, Hero.idleFrames,
                Hero.runFrames, Hero.fallFrames, Hero.attackFrames, Hero.jumpFrames, Hero.deathFrames,
                new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Assets\\Character\\Hero3.png")),
                Hero.Rectangle, Hero.startPosAnimation, Hero.followStepOfAnimation, Hero.switchStepOfAnimation);
            enemyNinjaTop = new Enemy
                 (EnemyNinja.startPosYTop, EnemyNinja.startPosXTop, EnemyNinja.idleFrames,
                EnemyNinja.runFrames, EnemyNinja.fallFrames, EnemyNinja.attackFrames, EnemyNinja.jumpFrames, EnemyNinja.deathFrames,
                new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Assets\\Character\\Enemy.png")),
                EnemyNinja.Rectangle, EnemyNinja.startPosAnimation, EnemyNinja.followStepOfanimation, EnemyNinja.switchStepOfanimation);
            enemyNinjaBottom = new Enemy
                 (EnemyNinja.startPosYBottom, EnemyNinja.startPosXBottom, EnemyNinja.idleFrames,
                EnemyNinja.runFrames, EnemyNinja.fallFrames, EnemyNinja.attackFrames, EnemyNinja.jumpFrames, EnemyNinja.deathFrames,
                new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Assets\\Character\\Enemy.png")),
                EnemyNinja.Rectangle, EnemyNinja.startPosAnimation, EnemyNinja.followStepOfanimation, EnemyNinja.switchStepOfanimation);
            MainTimer.Start();


            if (player.Flip == -1)
                player.SetAnimationConfiguration(AnimationStyle.FlipFall);
            else player.SetAnimationConfiguration(AnimationStyle.Fall);
        }

        public Point[] CreateTopPlatformHitbox()
        {
            int valueOfPoints = 0;
            int currentNumberOfPoint = 0;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform")
                    valueOfPoints += x.Bounds.Width;
            }
            Point[] arrayOfPoints = new Point[valueOfPoints];
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform")
                {                   
                    for (int j = 0; j < x.Bounds.Width; j++)
                    {
                        arrayOfPoints[currentNumberOfPoint] = new Point(x.Bounds.X + j, x.Bounds.Y);
                        currentNumberOfPoint++;
                    }
                }
            }            
            return arrayOfPoints;
        }

        public Point[] CreateSidePlatformHitbox()
        {
            int valueOfPoints = 0;
            int currentNumberOfPoint = 0;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform")
                    valueOfPoints += (int)((x.Bounds.Height * 2) - 4);
            }
            Point[] arrayOfPoints = new Point[valueOfPoints];
            foreach (Control x in this.Controls)
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

        private void FirstLevel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FirstLevel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            player.PlayAnimation(g);
            enemyNinjaTop.PlayAnimation(g);
            enemyNinjaBottom.PlayAnimation(g);
        }
    }
}
