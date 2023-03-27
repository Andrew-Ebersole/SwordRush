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
        List<AnimationSequence> sequences_ = new List<AnimationSequence>();

        public AnimationSequence GetCurrentSequence()
        {
            return sequences_.Last();
        }

        public void Update(GameTime gameTime)
        {
            for(int i = 0; i < sequences_.Count; i++)
            {
                AnimationSequence sequence = sequences_[i];
                sequence.Update(gameTime);
                if(sequence.End)
                {
                    if(sequence.Loop)
                    {
                        sequence.Reset();
                    } else
                    {
                        if(sequences_.Count > 1)
                        {
                            sequences_.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
        }

        public void PlaySequence(AnimationSequence animationSequence)
        {
            sequences_.Add(animationSequence);
        }
    }
}
