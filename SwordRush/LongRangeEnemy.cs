using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordRush
{
    internal class LongRangeEnemy:Enemy
    {
        private List<Projectile> projectiles;

        // --- Constructor --- //
        public LongRangeEnemy(Texture2D texture, Rectangle rectangle,Player player, GraphicsDevice graphicsDevice) : base(texture, rectangle, player, graphicsDevice)
        {

        }

        public void initStat(int level)
        {

        }

        public void shoot()
        {

        }

        public void AI()
        {

        }

        public override void Draw(SpriteBatch sb)
        {
            for(int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(sb);
            }
        }

        public override void Update(GameTime gt)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update(gt);
            }
        }
    }
}
