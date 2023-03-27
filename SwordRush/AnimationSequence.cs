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
    internal class AnimationSequence
    {
        List<Texture2D> frameTextures_;
        double frameSeconds_;
        int frameIndex_ = 0;
        double curFrameSeconds_ = 0;
        bool loop_ = false;
        bool end_ = false;

        public bool Loop
        {
            get { return loop_; }
        }

        public bool End
        {
            get { return end_; }
        }

        public AnimationSequence(List<Texture2D> frameTextures, double frameSeconds, bool loop)
        {
            this.frameTextures_ = frameTextures;
            this.frameSeconds_ = frameSeconds;
            this.loop_ = loop;
        }

        public void Update(GameTime gt)
        {
            curFrameSeconds_ += gt.ElapsedGameTime.TotalSeconds;
            if(curFrameSeconds_ >= frameSeconds_)
            {
                curFrameSeconds_ = 0;
                if (frameIndex_ < frameTextures_.Count - 1)
                {
                    frameIndex_++;
                } else
                {
                    end_ = true;
                }
            }

            System.Diagnostics.Debug.WriteLine(frameIndex_);
        }

        public void Reset()
        {
            frameIndex_ = 0;
            curFrameSeconds_ = 0;
            end_ = false;
        }

        public Texture2D GetCurrentFrame()
        {
            return frameTextures_[frameIndex_];
        }

        public bool ShouldEnd()
        {
            return end_;
        }
    }
}
