﻿using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SwordRush
{
    internal class ShortRangeEnemy:Enemy
    {
        Player player;

        // --- Constructor --- //
        public ShortRangeEnemy(Texture2D texture, Rectangle rectangle, Player player) : base(texture, rectangle, player)
        {
            this.player = player;
        }

        public void initStat(int level)
        {

        }

        public void Damaged()
        {
            Vector2 distance = position - player.Position;
            Vector2 direction = Vector2.Normalize(distance);

            Position += direction * 2;
        }

        public void AI()
        {
            Vector2 distance = position - player.Position;
            if (distance.Length() < 300 && distance.Length()>1)
            {
                Vector2 direction = Vector2.Normalize(distance);

                Position -= direction * 2;
            }
        }

        public void Draw(SpriteBatch sb)
        {

        }

        public override void Update(GameTime gt)
        {
            AI();
        }
    }
}
