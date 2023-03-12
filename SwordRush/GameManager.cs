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
        private List<SceneObject> walls;
        
        private static GameManager instance = null;
        public static GameManager Get
        {
            get
            {
                // Does it exist yet? No? Make it!
                if (instance == null)
                {
                    // Call the default constructor.
                    instance = new GameManager();
                }

                // Either way, return the (newly made or already made) instance
                return instance;
            }

            // NEVER a set for the instance
        }

        // --- Constructor --- //

        public void Initialize(ContentManager content, Point windowSize, Texture2D whiteRectangle)
        {
            this.spriteSheet = spriteSheet;
            gameActive = false;
            dungeontilesTexture2D = content.Load<Texture2D>("DungeonTiles");
            walls = new List<SceneObject>();
            enemies = new List<Enemy>();
            player = new Player(dungeontilesTexture2D, new Rectangle(500, 500, 32, 64));
            enemies.Add(new ShortRangeEnemy(null, new Rectangle(10, 10, 32, 32), player));
            //temporary test walls

            walls.Add(new SceneObject(true, whiteRectangle, new Rectangle(500, 500, 80, 80)));


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

                    //update enemy collision
                    Collision(enemy, walls);
                }

                // End game if player health runs out
                if (player.Health <= 0)
                {
                    gameOver();
                }

                //update player collision
                Collision(player, walls);
                
            }
        }

        public void Draw(SpriteBatch sb)
        {
            if (gameActive)
            {
                sb.Draw(dungeontilesTexture2D, new Vector2(0, 0), new Rectangle(0, 64, 16, 32), Color.White);

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

                //draw walls
                foreach (SceneObject obj in walls)
                {
                    obj.Draw(sb);
                }
            }
        }
        public void GenerateRoom()
        {

        }

        public void Collision(GameObject entity, List<SceneObject> walls)
        {
            //temporary variables for calculations
            Rectangle entityRect = entity.Rectangle;

            // For taller entities we only want to check collision with their feet
            if (entity.Rectangle.Width < entity.Rectangle.Height)
            {
                entityRect = new Rectangle(entityRect.X, entityRect.Y + entityRect.Height / 2, entityRect.Width, entityRect.Height / 2);
            }
            List<Rectangle> intersectionsList = new List<Rectangle>();
            List<Rectangle> wallRects = new List<Rectangle>();
            intersectionsList.Clear();
            wallRects.Clear();
            
            foreach (SceneObject obj in walls)
            {
                wallRects.Add(obj.Rectangle);
            }

            //get list of intersections
            for (int i = 0; i < walls.Count; i++)
            {
                if (entityRect.Intersects(wallRects[i]))
                {
                    intersectionsList.Add(wallRects[i]);
                }
            }

            //collision

            //loop through intersects
            for (int i = 0; i < intersectionsList.Count; i++)
            {
                Rectangle intersect = Rectangle.Intersect(entityRect, intersectionsList[i]);

                //horizontal collision
                if (intersect.Width < intersect.Height)
                {
                    if (entityRect.X < intersect.X)
                    {
                        entityRect.X -= intersect.Width;
                    }
                    else
                    {
                        entityRect.X += intersect.Width;
                    }
                }
                //vertical collision
                else
                {
                    if (entityRect.Y < intersect.Y)
                    {
                        entityRect.Y -= intersect.Height;
                    }
                    else
                    {
                        entityRect.Y += intersect.Height;
                    }
                    
                }
            }

            //update player position
            entity.X = entityRect.X+entityRect.Width / 2;
            entity.Y = entityRect.Y+entityRect.Height / 2;

            // For player sprite to collide with wall properly and not have space above head
            if (entity.Rectangle.Width < entity.Rectangle.Height)
            {
                entity.Y = entityRect.Y;
            }

        }


        public void StartGame()
        {
            gameActive = true;
            player.NewRound();
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
