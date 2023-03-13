using System.Diagnostics;
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

        // --- Constructor --- //
        /*
        public ShortRangeEnemy(Texture2D texture, Vector2 position, Point size) : base(texture, position, size)
        {

        }
        */
        public void initStat(int level)
        {

        }

        /// <summary>
        /// Push the enemy away from the player when it was damaged
        /// </summary>
        public void Damaged()
        {
            Vector2 distance = position - player.Position;
            Vector2 direction = Vector2.Normalize(distance);

            Position += direction * 10;
        }

        /// <summary>
        /// Move the enemy towards to player
        /// </summary>
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
