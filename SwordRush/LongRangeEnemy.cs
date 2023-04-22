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
        private AnimationComposer animationComposer_ = new AnimationComposer();

        public List<Projectile> Projectiles { get; }

        // --- Constructor --- //
        public LongRangeEnemy(Texture2D texture, Rectangle rectangle1, Player player, GraphicsDevice graphicsDevice) :
            base(texture, rectangle1, player, graphicsDevice)
        {
            Projectiles = new List<Projectile>();

            List<Texture2D> frames = new List<Texture2D>();

            frames.Add(GameManager.Get.ContentManager.Load<Texture2D>("necromancer_idle_anim_f0"));
            frames.Add(GameManager.Get.ContentManager.Load<Texture2D>("necromancer_idle_anim_f1"));
            frames.Add(GameManager.Get.ContentManager.Load<Texture2D>("necromancer_idle_anim_f2"));
            frames.Add(GameManager.Get.ContentManager.Load<Texture2D>("necromancer_idle_anim_f3"));

            animationComposer_.PlayMovementAnimation(new AnimationSequence(frames, 0.2, true));
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(animationComposer_.GetCurrentSequence().GetCurrentFrame(), rectangle, Color.White);
            foreach (Projectile projectile in Projectiles)
            {
                projectile.Draw(sb);
            }
        }

        public override void Update(GameTime gt)
        {
            System.Diagnostics.Debug.WriteLine(rectangle.Location);

            animationComposer_.Update(gt);

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