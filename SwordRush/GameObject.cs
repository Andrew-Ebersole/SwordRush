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
        protected Texture2D texture;
        protected Rectangle rectangle;
        protected SoundEffect sound;
        protected Vector2 position;
        protected Point size;

        public GameObject (Texture2D texture, Vector2 position, Point size)
        {
            this.texture = texture;
            this.rectangle = new Rectangle(new Point((int)position.X,(int)position.Y), size);
            this.position = position;
            this.size = size;
        }

        public virtual void Update(GameTime gt)
        {

        }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(
                texture,
                rectangle,
                Microsoft.Xna.Framework.Color.White);
        }

    }
}
