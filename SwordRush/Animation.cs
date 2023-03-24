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
    internal class Animation
    {
        List<Texture2D> frameTextures_;
        double frameSeconds_;
        int frameIndex_ = 0;
        double curFrameSeconds_ = 0;

        public Animation(List<Texture2D> frameTextures, double frameSeconds)
        {
            this.frameTextures_ = frameTextures;
            this.frameSeconds_ = frameSeconds;
        }

        public void Update(GameTime gt)
        {
            curFrameSeconds_ += gt.ElapsedGameTime.TotalSeconds;
            if(curFrameSeconds_ >= frameSeconds_)
            {
                NextFrame();
            }
        }

        public void NextFrame()
        {
            if(frameIndex_ == frameTextures_.Count - 1)
            {
                frameIndex_ = 0;
            }
            else
            {
                frameIndex_++;
            }
            curFrameSeconds_ = 0;
        }

        public Texture2D GetCurrentFrame()
        {
            return frameTextures_[frameIndex_];
        }
    }
}
