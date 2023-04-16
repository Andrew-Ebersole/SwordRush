using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordRush
{
    internal class LongRangeEnemy : Enemy
    {
        private double _currentShootCd;

        public List<Projectile> Projectiles { get; }

        // --- Constructor --- //
        public LongRangeEnemy(Texture2D texture, Rectangle rectangle, Player player, GraphicsDevice graphicsDevice) :
            base(texture, rectangle, player, graphicsDevice)
        {
            Projectiles = new List<Projectile>();
        }

        public override void Draw(SpriteBatch sb)
        {
            foreach (var projectile in Projectiles)
            {
                projectile.Draw(sb);
            }
        }

        public override void Update(GameTime gt)
        {
            foreach (var projectile in Projectiles)
            {
                projectile.Update(gt);
            }

            if (_currentShootCd <= 0)
            {
                _currentShootCd = 3;

                Vector2 fireDirection = Position - GameManager.Get.LocalPlayer.Position;
                fireDirection.Normalize();

                Projectiles.Add(new Projectile(rectangle.Center, fireDirection, this));
            }
            else
            {
                _currentShootCd -= gt.ElapsedGameTime.TotalSeconds;
            }
        }
    }
}