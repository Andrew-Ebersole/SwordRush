using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace SwordRush
{
    internal class GameObject
    {
        private Texture2D texture;
        protected Rectangle rectangle;
        private SoundEffect sound;
        protected Vector2 position;
        protected Point size;

        public void Draw(SpriteBatch sb)
        {

        }

        public void Update(GameTime gt)
        {

        }
    }
}
