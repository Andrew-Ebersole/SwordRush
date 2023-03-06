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

        // --- Constructor --- //

        public SceneObject(Texture2D texture, Vector2 position, Point size) : base(texture, position, size)
        {

        }

        public void Draw(SpriteBatch sb)
        {

        }

        public void Update(GameTime gt, GameObject collider)
        {

        }
    }
}
