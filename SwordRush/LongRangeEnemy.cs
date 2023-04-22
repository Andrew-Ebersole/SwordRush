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
        private int maxHP;
        private Vector2 direction;
        public List<Projectile> Projectiles { get; }

        public double damageFrame;

        // --- Constructor --- //
        public LongRangeEnemy(Texture2D texture, Rectangle rectangle1, Player player, int level,
            GraphicsDevice graphicsDevice) :
            base(texture, rectangle1, player, graphicsDevice)
        {
            initStat(level);
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
            damageFrame += gt.ElapsedGameTime.TotalMilliseconds;
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

                Projectiles.Add(new Projectile(rectangle.Center, fireDirection, this, atk));
            }
            else
            {
                _currentShootCd -= gt.ElapsedGameTime.TotalSeconds;
            }

            if (damageFrame < 200)
            {
                Position += direction * 20;
            }
            else
            {
                direction = new Vector2(0, 0);
            }
        }

        public void initStat(int level)
        {
            health = (int)(2f * level);
            atk = (level / 2) + 1;
            maxHP = health;
        }

        /// <summary>
        /// Push the enemy away from the player when it was damaged
        /// </summary>
        public override void Damaged()
        {
            if (enemyState != EnemyStateMachine.Damaged)
            {
                health -= (int)player.Atk;
                Vector2 distance = position - player.Position;
                direction = Vector2.Normalize(distance);
                AttackCooldown();
                SoundManager.Get.EnemyDamagedEffect.Play();
            }
        }
    }
}