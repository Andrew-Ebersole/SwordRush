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
        private Point position_;
        private Vector2 direction_;
        private float speed_ = 5;
        private int damage_ = 1;

        // --- Constructor --- //
        public Projectile() : base(null, new Rectangle())
        {
            damage_ = 10;
        }

        public override void Draw(SpriteBatch sb)
        {

        }

        public override void Update(GameTime gt)
        {
            direction_.Normalize();
            Rectangle rect = new Rectangle();
            rect.X = rectangle.X + (int)(speed_ * direction_.X);
            rect.Y = rectangle.Y + (int)(speed_ * direction_.Y);
            rect.Size = rectangle.Size;
            rectangle = rect;

            if (Rectangle.Intersects(GameManager.Get.LocalPlayer.Rectangle))
            {
                GameManager.Get.LocalPlayer.Damaged(damage_);
            }
        }
    }
}
