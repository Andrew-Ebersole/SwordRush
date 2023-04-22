using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordRush
{
    internal class LongRangeEnemy : Enemy
    {
        private double _currentShootCd;
        private int maxHP;
        private Vector2 direction;
        private readonly Animation<Texture2D> _animation = new(0.2f);
        public List<Projectile> Projectiles { get; }

        public double damageFrame;

        // --- Constructor --- //
        public LongRangeEnemy(Texture2D texture, Rectangle rectangle1, Player player, int level,
            GraphicsDevice graphicsDevice) :
            base(texture, rectangle1, player, graphicsDevice)
        {
            initStat(level);
            Projectiles = new List<Projectile>();

            _animation.AddFrame(GameManager.Get.ContentManager.Load<Texture2D>("necromancer_idle_anim_f0"));
            _animation.AddFrame(GameManager.Get.ContentManager.Load<Texture2D>("necromancer_idle_anim_f1"));
            _animation.AddFrame(GameManager.Get.ContentManager.Load<Texture2D>("necromancer_idle_anim_f2"));
            _animation.AddFrame(GameManager.Get.ContentManager.Load<Texture2D>("necromancer_idle_anim_f3"));
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(_animation.Frame, rectangle, Color.White);
            foreach (Projectile projectile in Projectiles)
            {
                projectile.Draw(sb);
            }
        }

        public override void Update(GameTime gt)
        {
            damageFrame += gt.ElapsedGameTime.TotalMilliseconds;
            _animation.Update(gt);
            if (_animation.Done)
            {
                _animation.Reset();
            }

            for (int i = 0; i < Projectiles.Count; i++)
            {
                Projectiles[i].Update(gt);

                if (Projectiles[i].Rectangle.Intersects(player.Rectangle))
                {
                    GameManager.Get.LocalPlayer.Damaged(atk);
                    Projectiles.RemoveAt(i);
                    i--;
                }
            }

            if (_currentShootCd <= 0)
            {
                _currentShootCd = 0.4;

                Vector2 fireDirection = player.Position - Position;
                fireDirection.Normalize();

                Projectiles.Add(new Projectile(rectangle.Center, fireDirection, this, atk));
            }
            else
            {
                _currentShootCd -= gt.ElapsedGameTime.TotalSeconds;
            }

            Debug.WriteLine(damageFrame);
            if (damageFrame < 200)
            {
                Position += direction * 20;
            }
            else
            {
                direction = new Vector2(0, 0);
                enemyState = EnemyStateMachine.Idle;
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
                _currentShootCd = 3;
                health -= (int)player.Atk;
                Vector2 distance = position - player.Position;
                direction = Vector2.Normalize(distance);
                SoundManager.Get.EnemyDamagedEffect.Play();
                enemyState = EnemyStateMachine.Damaged;
                damageFrame = 0;
            }
        }
    }
}