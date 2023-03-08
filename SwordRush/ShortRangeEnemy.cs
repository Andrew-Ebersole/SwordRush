﻿using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SwordRush
{
    internal class ShortRangeEnemy:Enemy
    {

        // --- Constructor --- //
        public ShortRangeEnemy(Texture2D texture, Rectangle rectangle, Player player) : base(texture, rectangle, player)
        {

        }

        public void initStat(int level)
        {

        }

        public void AI()
        {
            Vector2 distance = position - player.Position;
            if (distance.Length() < 100 && distance.Length()>1)
            {
                Vector2 direction = Vector2.Normalize(distance);

                position -= direction * 1;
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
