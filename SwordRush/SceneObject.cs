using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordRush
{
    internal class SceneObject : GameObject
    {
        private bool wall;
        private int tile;

        // --- Constructor --- //

        public SceneObject(bool wall, int tile, Texture2D texture, Rectangle rectangle) : base(texture, rectangle)
        {
            this.wall = wall;
            this.tile = tile;
        }

        public void Draw(SpriteBatch sb)
        {
            if (tile == 0)
            {
                sb.Draw(texture, Rectangle, Color.White);
            }
            else if (tile == 1)
            {
                sb.Draw(texture, Rectangle, Color.White);
            }
        }

        public void Update(GameTime gt, GameObject collider)
        {

        }
    }
}
