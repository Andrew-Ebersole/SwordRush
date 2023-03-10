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
        private Rectangle window;



        // --- Constructor --- //

        public GameManager(ContentManager content, Point windowSize)
        {
            this.spriteSheet = spriteSheet;
            gameActive = false;
            enemies = new List<Enemy>();
            player = new Player(null, new Rectangle(10, 10, 16, 32));
            enemies.Add(new ShortRangeEnemy(null, new Rectangle(10, 10, 16, 16), player));
            dungeontilesTexture2D = content.Load<Texture2D>("DungeonTiles");
            this.window = new Rectangle(0, 0,
                windowSize.X, windowSize.Y);
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

                sb.Draw(dungeontilesTexture2D, player.Rectangle, new Rectangle(128, 64, 16, 32), Color.White);
                sb.Draw(dungeontilesTexture2D, enemies[0].Rectangle, new Rectangle(368, 80, 16, 16), Color.White);
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
    }
}
