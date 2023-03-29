using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SwordRush
{
    internal class ShortRangeEnemy : Enemy
    {
        Player player;
        private double damageFrame;
        private Texture2D dungeontilesTexture2D;
        private AnimationComposer animationComposer_ = new AnimationComposer();

        // --- Constructor --- //
        public ShortRangeEnemy(Texture2D texture, Rectangle rectangle, Player player,int level) : base(texture, rectangle, player)
        {
            this.player = player;
            dungeontilesTexture2D = texture;

            List<Texture2D> frames = new List<Texture2D>();

            frames.Add(GameManager.Get.ContentManager.Load<Texture2D>("skelet_idle_anim_f0"));
            frames.Add(GameManager.Get.ContentManager.Load<Texture2D>("skelet_idle_anim_f1"));
            frames.Add(GameManager.Get.ContentManager.Load<Texture2D>("skelet_idle_anim_f2"));
            frames.Add(GameManager.Get.ContentManager.Load<Texture2D>("skelet_idle_anim_f3"));

            animationComposer_.PlaySequence(new AnimationSequence(frames, 0.2, true));
            this.level = level;
            initStat(level);
        }
        
        public void initStat(int level)
        {
            health = level;
            atk = level;
        }

        /// <summary>
        /// Push the enemy away from the player when it was damaged
        /// </summary>
        public override void Damaged()
        {
            if (enemyState != EnemyStateMachine.Damaged)
            {
                Vector2 distance = position - player.Position;
                Vector2 direction = Vector2.Normalize(distance);
                health -= player.Atk;
                Position += direction * 100;
                enemyState = EnemyStateMachine.Damaged;
            }

        }

        /// <summary>
        /// Move the enemy towards to player
        /// </summary>
        public void AI(GameTime gameTime)
        {
            damageFrame += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (damageFrame >= 1000)
            {
                Vector2 distance = position - player.Position;
                if (distance.Length() < 300 && distance.Length() > 1)
                {
                    Vector2 direction = Vector2.Normalize(distance);

                    Position -= direction * 2;
                    enemyState = EnemyStateMachine.Move;
                }
                else
                {
                    enemyState = EnemyStateMachine.Idle;
                }
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(animationComposer_.GetCurrentSequence().GetCurrentFrame(), Rectangle, Color.White);
            //sb.Draw(dungeontilesTexture2D, Rectangle, new Rectangle(368, 80, 16, 16), Color.White);
        }

        public override void Update(GameTime gt)
        {
            AI(gt);
            animationComposer_.Update(gt);
        }
    }
}
