using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsForms.Enum;
using WindowsForms.Static;
using WindowsForms.Servise;
using WindowsForms.Interface;

namespace WindowsForms.Class
{
    class MainCharacter : Entity, IMainGameIndicators
    {
        public int HP { get; set; }

        public MainCharacter(int posY, int posX, int idleFrames, int runFrames, int fallFrames,
            int jumpFrames, int attackFrames, int deathFrames, Image spritesheet,
            Rectangle rectangle, int startPosOfAnimation, int followStepOfanimation, int switchStepOfanimation) 
            : base( posY, posX, idleFrames, runFrames, fallFrames,
            jumpFrames, attackFrames, deathFrames, spritesheet,
             rectangle, startPosOfAnimation,  followStepOfanimation, switchStepOfanimation)
        {
            
        }

        public override void PlayAnimation(Graphics g)
        {
            base.PlayAnimation(g);
        }

        public override void SetAnimationConfiguration(AnimationStyle animation)
        {
            base.SetAnimationConfiguration(animation);
        }
    }
}
