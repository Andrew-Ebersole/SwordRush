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
        private List<SceneObject> walls;



        // --- Constructor --- //

        public GameManager(ContentManager content, Point windowSize, Texture2D whiteRectangle)
        {
            this.spriteSheet = spriteSheet;
            gameActive = false;
            enemies = new List<Enemy>();
            player = new Player(null, new Rectangle(500, 500, 16, 32));
            enemies.Add(new ShortRangeEnemy(null, new Rectangle(10, 10, 16, 16), player));
            dungeontilesTexture2D = content.Load<Texture2D>("DungeonTiles");
            walls = new List<SceneObject>();

            //temporary test walls
            
            walls.Add(new SceneObject(true, whiteRectangle, new Rectangle(1000, 500, 20, 20)));


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

                    //update enemy collision
                    Collision(enemy, walls);
                }

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

                sb.Draw(dungeontilesTexture2D, player.Rectangle, new Rectangle(128, 64, 16, 32), Color.White);
                sb.Draw(dungeontilesTexture2D, enemies[0].Rectangle, new Rectangle(368, 80, 16, 16), Color.White);

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
            List<Rectangle> intersectionsList = new List<Rectangle>();
            List<Rectangle> wallRects = new List<Rectangle>();

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
            entity.X = entityRect.X;
            entity.Y = entityRect.Y;

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
