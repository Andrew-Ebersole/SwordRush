using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace SwordRush
{
    internal class GameManager
    {
        // --- Fields --- //

        private Texture2D spriteSheet;
        private bool gameActive;
        private Player player;
        private List<Enemy> enemies;
        public event ToggleGameState gameOver;
        private Texture2D dungeontilesTexture2D;
        private Texture2D healthBarTexture;
        private Texture2D xpBarTexture;
        private Texture2D emptyBarTexture;
        private Rectangle window;
        private SpriteFont BellMT24;



        // --- Constructor --- //

        public GameManager(ContentManager content, Point windowSize)
        {
            this.spriteSheet = spriteSheet;
            gameActive = false;
            enemies = new List<Enemy>();
            
            dungeontilesTexture2D = content.Load<Texture2D>("DungeonTiles");
            player = new Player(dungeontilesTexture2D, new Rectangle(10, 10, 16, 32));
            enemies.Add(new ShortRangeEnemy(null, new Rectangle(10, 10, 16, 16), player));
            this.window = new Rectangle(0, 0,
                windowSize.X, windowSize.Y);

            // health and xp bars
            emptyBarTexture = content.Load<Texture2D>("empty_bar");
            healthBarTexture = content.Load<Texture2D>("health_bar");
            xpBarTexture = content.Load<Texture2D>("energy_bar");

            // Font
            BellMT24 = content.Load<SpriteFont>("Bell_MT-24");
        }



        // --- Methods --- //

        public void Update(GameTime gt)
        {
            if (gameActive)
            {
                player.playerControl();
                foreach (Enemy enemy in enemies)
                {
                    enemy.Update(gt);
                }

                // End game if player health runs out
                if (player.Health <= 0)
                {
                    gameOver();
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            if (gameActive)
            {
                sb.Draw(dungeontilesTexture2D, new Vector2(0, 0), new Rectangle(0, 64, 16, 32), Color.White);

                //sb.Draw(dungeontilesTexture2D, player.Rectangle, new Rectangle(128, 64, 16, 32), Color.White);
                player.Draw(sb);
                sb.Draw(dungeontilesTexture2D, enemies[0].Rectangle, new Rectangle(368, 80, 16, 16), Color.White);

                // Display health and xp bars
                drawBar(healthBarTexture,
                    player.Health,
                    player.MaxHealth,
                    new Rectangle((int)(window.Width * 0.1f), (int)(window.Height * 0.9f),
                    (int)(window.Width * 0.3f), (int)(window.Height * 0.09f)), 
                    sb);

                drawBar(xpBarTexture,
                    player.Exp,
                    player.LevelUpExp,
                    new Rectangle((int)(window.Width * 0.6f), (int)(window.Height * 0.9f),
                    (int)(window.Width * 0.3f), (int)(window.Height * 0.09f)),
                    sb);
            }
        }
        public void GenerateRoom()
        {
        }

        public void StartGame()
        {
            gameActive = true;
            // TODO: Reset game code goes here
        }

        public void QuitGame()
        {
            gameActive = false;
        }

        public void drawBar(Texture2D texture, int value, int maxValue, Rectangle size, SpriteBatch sb)
        {
            sb.Draw(emptyBarTexture,
                size,
                new Rectangle(0,0,emptyBarTexture.Width,(int)(emptyBarTexture.Height*0.25f)),
                Color.White);

            sb.Draw(texture,
                new Rectangle((int)(size.X - window.Width * 0.06f), size.Y, size.Width / 6, size.Height),
                new Rectangle(0, (int)(texture.Height * 0.55f), texture.Width / 3, texture.Height / 2),
                Color.White);

            int barPercent = value * 6 / maxValue;

            sb.Draw(texture,
                new Rectangle(size.X,size.Y,(size.Width * barPercent) / 6,size.Height),
                new Rectangle(0,0,(texture.Width* barPercent) / 6,(int)(texture.Height*0.25f)),
                Color.White);

            sb.DrawString(
                BellMT24,
                $"{value}",
                new Vector2(size.X+ window.Width * 0.015f, size.Y + window.Height * 0.015f),
                Color.White);
        }
    }
}
