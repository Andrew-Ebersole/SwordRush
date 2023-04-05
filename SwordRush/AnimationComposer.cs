using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SwordRush
{
    internal class AnimationComposer
    {
        AnimationSequence movementSequence_ = null;
        AnimationSequence slotSequence_ = null;

        public AnimationSequence GetCurrentSequence()
        {
            if(slotSequence_ == null)
            {
                return movementSequence_;
            } else
            {
                if(slotSequence_.End)
                {
                    return movementSequence_;
                } else
                {
                    return slotSequence_;
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if(slotSequence_ != null)
            {
                if (slotSequence_.End)
                {
                    movementSequence_.Update(gameTime);
                }
                else
                {
                    slotSequence_.Update(gameTime);
                }
                
            } else
            {
                movementSequence_.Update(gameTime);
            }
        }

        public void PlayActionAnimation()
        {

        }

        public void PlayMovementAnimation(AnimationSequence movementAnimation)
        {
            movementSequence_ = movementAnimation;
        }
    }
}
