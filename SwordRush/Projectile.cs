using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SwordRush
{
    internal class Projectile : GameObject
    {
        private Vector2 direction;
        private int damage;

        // --- Constructor --- //
        public Projectile(Texture2D texture, Rectangle rectangle) : base(texture, rectangle)
        {

        }

        public override void Draw(SpriteBatch sb)
        {

        }
        
        public override void Update(GameTime gt)  
        {
            if (Rectangle.Intersects(GameManager.Get.LocalPlayer.Rectangle))
            {
                GameManager.Get.LocalPlayer.Damaged(damage);
            }
        }
    }
}
