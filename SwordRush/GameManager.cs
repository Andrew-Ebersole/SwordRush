using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using Color = Microsoft.Xna.Framework.Color;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace SwordRush
{
    internal class GameManager
    {
        // --- Fields --- //

        private enum GameFSM
        {
            Playing,
            Paused,
            LevelUp,
            Menu
        }
        private GameFSM gameFSM;
        private ContentManager contentManager_;
        private FileManager fileManager_;
        
        //game event
        private Rectangle window;
        public event GameOver gameOver;
        private KeyboardState currentKeyState;
        private KeyboardState previousKeyState;

        //objects
        private Player player;
        private List<Enemy> enemies;

        //textures
        private Texture2D spriteSheet;
        private Texture2D dungeontilesTexture2D;
        private Texture2D healthBarTexture;
        private Texture2D xpBarTexture;
        private Texture2D emptyBarTexture;
        private Texture2D whiteRectangle;

        // fonts
        private SpriteFont BellMT24;
        private SpriteFont BellMT72;

        //tiling
        private List<SceneObject> walls;
        private int[,] grid;
        private List<List<AStarNode>> graph;

        private static GameManager instance = null;
        

        // Graphics Device
        private GraphicsDevice graphicsDevice;

        // Mouse States
        MouseState currentMS;
        MouseState previousMS;

        // --- Properties --- //

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

        public ContentManager ContentManager { get { return contentManager_; } }

        public int[,] Grid { get { return grid; } }
        public List<List<AStarNode>> Graph { get { return graph; } }

        // --- Constructor --- //

        public void Initialize(ContentManager content, Point windowSize, Texture2D whiteRectangle, GraphicsDevice graphicsDevice)
        {
            contentManager_ = content;
            fileManager_ = new FileManager();
            //sprites & game states
            this.spriteSheet = spriteSheet;
            gameFSM = GameFSM.Menu;
            dungeontilesTexture2D = content.Load<Texture2D>("DungeonTiles");
            this.whiteRectangle = whiteRectangle;
            
            //objects
            enemies = new List<Enemy>();
            player = new Player(dungeontilesTexture2D, new Rectangle(0,0, 32, 64), graphicsDevice);


            //tiling
            grid = new int[20, 12];
            graph = new List<List<AStarNode>>();
            walls = new List<SceneObject>();
            //test wall
            walls.Add(new SceneObject(true, whiteRectangle, new Rectangle(500, 500, 64, 64)));

            //window
            this.window = new Rectangle(0, 0,
                windowSize.X, windowSize.Y);

            // health and xp bars
            emptyBarTexture = content.Load<Texture2D>("empty_bar");
            healthBarTexture = content.Load<Texture2D>("health_bar");
            xpBarTexture = content.Load<Texture2D>("energy_bar");

            // Font
            BellMT24 = content.Load<SpriteFont>("Bell_MT-24");
            BellMT72 = content.Load<SpriteFont>("Bell_MT-72");

            // graphicsDevice
            this.graphicsDevice = graphicsDevice;

            // Mouse States
            currentMS = Mouse.GetState(); 
            previousMS = Mouse.GetState();
        }

        public Player LocalPlayer
        {
            get { return player; }
        }

        // --- Methods --- //

        public void Update(GameTime gt)
        {
            currentMS = Mouse.GetState();

            switch (gameFSM)
            {
                case GameFSM.Playing: // Playing Game

                    player.Update(gt);

                    //update all the enemies
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        enemies[i].Update(gt);

                        //update enemy collision
                        WallCollision(enemies[i], walls);

                        if (player.PlayerState == PlayerStateMachine.Attack &&
                            SwordCollision(enemies[i].Rectangle, 0, player.Sword.Rectangle, player.SwordRotateAngle()))
                        {
                            enemies[i].Damaged();
                            Rectangle r0 = player.Sword.Rectangle;
                        }

                        if (enemies[i].Rectangle.Intersects(player.Rectangle) && enemies[i].Health > 0
                            && enemies[i].EnemyState == EnemyStateMachine.Move)
                        {
                            enemies[i].AttackCooldown();
                            player.Damaged(enemies[i].Atk);
                        }

                        if (enemies[i].Health <= 0)
                        {
                            player.GainExp(enemies[i].Level);
                            enemies.RemoveAt(i);
                        }
                    }

                    // End game if player health runs out
                    if (player.Health <= 0)
                    {
                        gameFSM = GameFSM.Menu;
                        gameOver(player.RoomsCleared);
                    }

                    //update player collision
                    WallCollision(player, walls);


                    //get keyboard state
                    currentKeyState = Keyboard.GetState();

                    //go to next level shortcut
                    if (currentKeyState.IsKeyDown(Keys.Enter) && previousKeyState.IsKeyUp(Keys.Enter))
                    {
                        enemies.Clear();
                    }

                    previousKeyState = currentKeyState;

                    //check if enemies are all dead
                    if (enemies.Count == 0 && UI.Get.GameFSM == SwordRush.GameFSM.Game)
                    {
                        player.RoomsCleared += 1;
                        StartGame();
                        player.NewRoom();
                    }

                    // Pause game on right click
                    if (currentMS.RightButton == ButtonState.Pressed
                        && previousMS.RightButton == ButtonState.Released)
                    {
                        gameFSM = GameFSM.Paused;
                    }

                    // Go To Level Up Screen
                    if (player.Exp >= player.LevelUpExp)
                    {
                        gameFSM |= GameFSM.LevelUp;
                    }
                    break;

                case GameFSM.Paused:

                    // End game on right click
                    if (currentMS.RightButton == ButtonState.Pressed
                        && previousMS.RightButton == ButtonState.Released)
                    {
                        player.Die();
                        gameOver(player.RoomsCleared);
                        gameFSM = GameFSM.Menu;
                    }
                    // Unpause when left click
                    if (currentMS.LeftButton == ButtonState.Pressed
                        && previousMS.LeftButton == ButtonState.Released)
                    {
                        gameFSM = GameFSM.Playing;
                    }

                    break;

                case GameFSM.LevelUp:

                    // Temporary level up system
                    if (Keyboard.GetState().IsKeyDown(Keys.D1))
                    {
                        // Heal to max health
                        player.LevelUp(LevelUpAbility.Heal);
                        gameFSM = GameFSM.Playing;
                    }
                    else if (Keyboard.GetState().IsKeyDown(Keys.D2))
                    {
                        // Increase max health
                        player.LevelUp(LevelUpAbility.MaxHealth);
                        gameFSM = GameFSM.Playing;
                    }
                    else if (Keyboard.GetState().IsKeyDown(Keys.D3))
                    {
                        // Increase attack speed
                        player.LevelUp(LevelUpAbility.AttackSpeed);
                        gameFSM = GameFSM.Playing;
                    }
                    else if (Keyboard.GetState().IsKeyDown(Keys.D4))
                    {
                        // Increase attack damage
                        player.LevelUp(LevelUpAbility.AttackDamage);
                        gameFSM = GameFSM.Playing;
                    }
                    else if (Keyboard.GetState().IsKeyDown(Keys.D5))
                    {
                        // Increase movement range
                        player.LevelUp(LevelUpAbility.Range);
                        gameFSM = GameFSM.Playing;
                    }
                    break;
            }

            previousMS = Mouse.GetState();

            UpdateGrid();
            UpdateGraph();
        }

        public void Draw(SpriteBatch sb)
        {
            switch (gameFSM)
            {
                case GameFSM.Playing:
                    sb.Draw(dungeontilesTexture2D, new Vector2(0, 0), new Rectangle(0, 64, 16, 32), Color.White);

                    //draw walls
                    foreach (SceneObject obj in walls)
                    {
                        obj.Draw(sb);
                    }

                    player.Draw(sb);
                    foreach (Enemy enemy in enemies)
                    {
                        enemy.Draw(sb);
                    }

                    // Display health and xp bars
                    drawBar(healthBarTexture,
                        player.Health,
                        player.MaxHealth,
                        new Rectangle((int)(window.Width * 0.12f), (int)(window.Height * 0.92f),
                        (int)(window.Width * 0.3f), (int)(window.Height * 0.079)),
                        sb);

                    drawBar(xpBarTexture,
                        player.Exp,
                        player.LevelUpExp,
                        new Rectangle((int)(window.Width * 0.62f), (int)(window.Height * 0.92f),
                        (int)(window.Width * 0.3f), (int)(window.Height * 0.079f)),
                        sb);


                    // Draw Room Number top right
                    sb.DrawString(BellMT24,
                        $"Rooms Cleared: {player.RoomsCleared}",
                        new Vector2(10, 10),
                        Color.Black);

                    break;

                case GameFSM.Paused:

                    sb.DrawString(BellMT72,
                        $"Paused",
                        new Vector2(window.Width *0.38f, window.Height * 0.36f),
                        Color.White);

                    sb.DrawString(BellMT24,
                        $"Right Click to Quit\n" +
                        $"Left Click to Resume",
                        new Vector2(window.Width * 0.38f, window.Height * 0.56f),
                        Color.White);
                    break;

                case GameFSM.LevelUp:
                    sb.DrawString(BellMT72,
                        $"Level up!",
                        new Vector2(window.Width * 0.38f, window.Height * 0.36f),
                        Color.White);

                    sb.DrawString(BellMT24,
                        $"[Temporary System]" +
                        $"\n1: Health" +
                        $"\n2: Max Health" +
                        $"\n3: Attack Speed" +
                        $"\n4: Attack Damage" +
                        $"\n5: Attack Range",
                        new Vector2(window.Width* 0.38f, window.Height * 0.56f),
                        Color.White);

                    sb.DrawString(BellMT24,
                        $"" +
                        $"\n:Current:{player.Health}" +
                        $"\n:Current:{player.MaxHealth}" +
                        $"\n:Current:{player.AtkSpd}" +
                        $"\n:Current:{player.Atk}" +
                        $"\n:Current:{player.Range}",
                        new Vector2(window.Width * 0.58f, window.Height * 0.56f),
                        Color.White);
                    break;
            }
            if (gameFSM == GameFSM.Playing)
            {
                
            }
        }

        public void UpdateGraph()
        {
            graph.Clear();
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                List<AStarNode> temp = new List<AStarNode>();
                for (int j = 0; j < grid.GetLength(0); j++)
                {
                    bool walkable = true;
                    if (grid[j, i] == 1)
                    {
                        walkable = true;
                    }
                    temp.Add(new AStarNode(new Vector2(j*64,i*64),walkable,1));
                }
                graph.Add(temp);
            }
        }

        /// <summary>
        /// creates wall objects based on where 1 values in the grid are
        /// </summary>
        public void GenerateRoom()
        {
            walls.Clear();
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                for (int j = 0; j < grid.GetLength(0); j++)
                {
                    if (grid[j,i] == 1)
                    {
                        walls.Add(new SceneObject(true, whiteRectangle, new Rectangle(j*64, i*64, 64, 64)));
                    }
                    else if (grid[j,i] == 2)
                    {
                        enemies.Add(new ShortRangeEnemy(dungeontilesTexture2D, new Rectangle(j*64 +32, i*64 +32, 32, 32), player, (player.RoomsCleared / 2) + 1, graphicsDevice));
                    }
                    else if (grid[j,i] == 3)
                    {
                        player.X = (j * 64 + 32);
                        player.Y = (i * 64 + 32);
                    }
                }
            }
        }

        /// <summary>
        /// updates the position of the player and enemies on the grid
        /// </summary>
        public void UpdateGrid()
        {
            //clear old positions of enemies and players
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                for (int j = 0; j < grid.GetLength(0); j++)
                {
                    if (grid[j,i] == 3 || grid[j,i] == 2)
                    {
                        grid[j,i] = 0;
                    }
                }
            }

            //add enemy positions
            foreach (ShortRangeEnemy SRenemy in enemies)
            {
                if (SRenemy.Position.X > 0 && SRenemy.Position.Y > 0
                && SRenemy.Position.X < window.Width && SRenemy.Position.Y < window.Height)
                {
                    grid[Convert.ToInt32(SRenemy.Position.X) / 64, Convert.ToInt32(SRenemy.Position.Y) / 64] = 2;
                }
            }

            //add player position
            if (player.Position.X > 0 && player.Position.Y > 0
                && player.Position.X < window.Width && player.Position.Y < window.Height)
            {
                grid[Convert.ToInt32(player.Position.X) / 64, Convert.ToInt32(player.Position.Y) / 64] = 3;
            }
        }

        public void WallCollision(GameObject entity, List<SceneObject> walls)
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

        /// <summary>
        /// check collision of the sword and other objects
        /// </summary>
        /// <param name="other">rectangle of other</param>
        /// <param name="rotationR0">rotation angle of other</param>
        /// <param name="sword">rectangle of the sword</param>
        /// <param name="rotationR1">rotation angle of the sword</param>
        /// <returns>if collision had happen</returns>
        public static bool SwordCollision(Rectangle other, float rotationR0, Rectangle sword, float rotationR1)
        {
            Vector2 rotOriginR0 = new Vector2(other.X + other.Width * .5f, other.Y + other.Height * .5f);
            Vector2 rotOriginR1 = new Vector2(sword.X + 16, sword.Y + 16);

            // get rotated points of rectangle 1
            Vector2 A0 = new Vector2(other.Left, other.Top);
            Vector2 B0 = new Vector2(other.Right, other.Top);
            Vector2 C0 = new Vector2(other.Right, other.Bottom);
            Vector2 D0 = new Vector2(other.Left, other.Bottom);
            // optimally you store the shapes points in clockwise (cw) or ccw order.
            // we could also do this with just two rotations saving a lot of this extra work
            A0 = RotatePoint(A0, rotOriginR0, rotationR0);
            B0 = RotatePoint(B0, rotOriginR0, rotationR0);
            C0 = RotatePoint(C0, rotOriginR0, rotationR0);
            D0 = RotatePoint(D0, rotOriginR0, rotationR0);

            // get rotated points of rectangle 2
            Vector2 A1 = new Vector2(sword.Left, sword.Top);
            Vector2 B1 = new Vector2(sword.Right, sword.Top);
            Vector2 C1 = new Vector2(sword.Right, sword.Bottom);
            Vector2 D1 = new Vector2(sword.Left, sword.Bottom);
            A1 = RotatePoint(A1, rotOriginR1, rotationR1);
            B1 = RotatePoint(B1, rotOriginR1, rotationR1);
            C1 = RotatePoint(C1, rotOriginR1, rotationR1);
            D1 = RotatePoint(D1, rotOriginR1, rotationR1);

            // you can return true with just one match but this is left to demonstrate.
            bool match = false;

            // first rectangle
            if (IsPointWithinRectangle(A0, B0, C0, D0, A1)) { match = true; }
            if (IsPointWithinRectangle(A0, B0, C0, D0, B1)) { match = true; }
            if (IsPointWithinRectangle(A0, B0, C0, D0, C1)) { match = true; }
            if (IsPointWithinRectangle(A0, B0, C0, D0, D1)) { match = true; }
            // second rectangle
            if (IsPointWithinRectangle(A1, B1, C1, D1, A0)) { match = true; }
            if (IsPointWithinRectangle(A1, B1, C1, D1, B0)) { match = true; }
            if (IsPointWithinRectangle(A1, B1, C1, D1, C0)) { match = true; }
            if (IsPointWithinRectangle(A1, B1, C1, D1, D0)) { match = true; }

            return match;
        }

        /// <summary>
        /// check if the collision point in in the rectangle
        /// </summary>
        /// <param name="A">point A</param>
        /// <param name="B">point B</param>
        /// <param name="C">point C</param>
        /// <param name="D">point D</param>
        /// <param name="collision_point">the collision point</param>
        /// <returns>if the point is in the rectangle</returns>
        public static bool IsPointWithinRectangle(Vector2 A, Vector2 B, Vector2 C, Vector2 D, Vector2 collision_point)
        {
            int numberofplanescrossed = 0;
            if (HasPointCrossedPlane(A, B, collision_point)) { numberofplanescrossed++; } else { numberofplanescrossed--; }
            if (HasPointCrossedPlane(B, C, collision_point)) { numberofplanescrossed++; } else { numberofplanescrossed--; }
            if (HasPointCrossedPlane(C, D, collision_point)) { numberofplanescrossed++; } else { numberofplanescrossed--; }
            if (HasPointCrossedPlane(D, A, collision_point)) { numberofplanescrossed++; } else { numberofplanescrossed--; }

            return numberofplanescrossed >= 4;
        }

        /// <summary>
        /// calculate if the point has cross the plane
        /// </summary>
        /// <param name="start">start point</param>
        /// <param name="end">end point</param>
        /// <param name="collision_point">the point to be check</param>
        /// <returns>if the point had crossed plane</returns>
        public static bool HasPointCrossedPlane(Vector2 start, Vector2 end, Vector2 collision_point)
        {
            Vector2 B = (end - start);
            Vector2 A = (collision_point - start);
            // We only need the signed result
            // cross right and dot 
            float sign = A.X * -B.Y + A.Y * B.X;
            return sign > 0.0f;
        }

        /// <summary>
        /// rotate the point
        /// </summary>
        /// <param name="p">the point</param>
        /// <param name="o">the origin</param>
        /// <param name="q">the rotating angle</param>
        /// <returns>the new point</returns>
        public static Vector2 RotatePoint(Vector2 p, Vector2 o, double q)
        {
            //x' = x*cos s - y*sin s , y' = x*sin s + y*cos s 
            double x = p.X - o.X; // transform locally to the orgin
            double y = p.Y - o.Y;
            double rx = x * Math.Cos(q) - y * Math.Sin(q);
            double ry = x * Math.Sin(q) + y * Math.Cos(q);
            p.X = (float)rx + o.X; // translate back to non local
            p.Y = (float)ry + o.Y;
            return p;
        }

        public void StartGame()
        {
            gameFSM = GameFSM.Playing;
            

            //load grid
            grid = fileManager_.LoadGrid($"Content/Level{player.RoomsCleared%3}.txt");
            
            enemies.Clear();
            //generates curent room based on grid
            GenerateRoom();
            // TODO: Reset game code goes here
        }

        public void QuitGame()
        {
            player.Die();
            gameFSM = GameFSM.Menu;
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

            int barPercent = value * 120 / maxValue;

            sb.Draw(texture,
                new Rectangle(size.X,size.Y,(size.Width * barPercent) / 120,size.Height),
                new Rectangle(0,0,(texture.Width* barPercent) / 120,(int)(texture.Height*0.25f)),
                Color.White);

            sb.DrawString(
                BellMT24,
                $"{value}",
                new Vector2(size.X+ window.Width * 0.015f, size.Y + window.Height * 0.015f),
                Color.White);
        }
    }
}
