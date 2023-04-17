using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Color = Microsoft.Xna.Framework.Color;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using System.Linq;
using System.Transactions;

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
        private Texture2D abilityIcons;
        private Texture2D singleColor;

        // fonts
        private SpriteFont BellMT24;
        private SpriteFont BellMT48;
        private SpriteFont BellMT72;
        //tiling
        private List<SceneObject> walls;
        private int[,] grid;
        private SceneObject[,] floorTiles;
        private List<SceneObject> wallTiles;
        private List<List<AStarNode>> graph;

        private static GameManager instance = null;

        // Level up buttons
        private List<ImageButton> levelUpButtons;

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
            floorTiles = new SceneObject[40, 24];
            wallTiles = new List<SceneObject>();
            for (int i = 0; i < floorTiles.GetLength(1); i++)
            {
                for (int j = 0; j < floorTiles.GetLength(0); j++)
                {
                    floorTiles[j,i] = new SceneObject(false, 20, dungeontilesTexture2D, new Rectangle(j * 32, i * 32, 32, 32));
                }
            }

            //window
            this.window = new Rectangle(0, 0,
                windowSize.X, windowSize.Y);

            // health and xp bars
            emptyBarTexture = content.Load<Texture2D>("empty_bar");
            healthBarTexture = content.Load<Texture2D>("health_bar");
            xpBarTexture = content.Load<Texture2D>("energy_bar");

            // Single color texture
            singleColor = new Texture2D(graphicsDevice, 1, 1);
            singleColor.SetData(new Color[] { Color.White });

            // Font
            BellMT24 = content.Load<SpriteFont>("Bell_MT-24");
            BellMT48 = content.Load<SpriteFont>("Bell_MT-48");
            BellMT72 = content.Load<SpriteFont>("Bell_MT-72");

            // graphicsDevice
            this.graphicsDevice = graphicsDevice;

            // Mouse States
            currentMS = Mouse.GetState(); 
            previousMS = Mouse.GetState();

            // level up buttons
            levelUpButtons = new List<ImageButton>();
            abilityIcons = content.Load<Texture2D>("AbilityIcons");
            InitializeLevelUpButtons();

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
                            SoundManager.Get.EnemyAttackEffect.Play();
                            enemies[i].AttackCooldown();
                            player.Damaged(enemies[i].Atk);
                        }

                        if (enemies[i].Health <= 0)
                        {
                            player.GainExp(enemies[i].Level);
                            SoundManager.Get.EnemyDeathEffect.Play();
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
                        SoundManager.Get.LevelCleardEffect.Play();
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
                        RandomizeLevelUpAbilities();
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

                    // Update buttons to check if clicked
                    foreach (ImageButton b in levelUpButtons)
                    {
                        b.Update(gt);
                    }

                    // Increase Stat when pressed
                    if (levelUpButtons[0].LeftClicked)
                    {
                        // Heal to max health
                        player.LevelUp(LevelUpAbility.Heal);
                        gameFSM = GameFSM.Playing;
                    }
                    else if (levelUpButtons[1].LeftClicked)
                    {
                        // Increase max health
                        player.LevelUp(LevelUpAbility.MaxHealth);
                        gameFSM = GameFSM.Playing;
                    }
                    else if (levelUpButtons[2].LeftClicked)
                    {
                        // Increase attack speed
                        player.LevelUp(LevelUpAbility.AttackSpeed);
                        gameFSM = GameFSM.Playing;
                    }
                    else if (levelUpButtons[3].LeftClicked)
                    {
                        // Increase attack damage
                        player.LevelUp(LevelUpAbility.AttackDamage);
                        gameFSM = GameFSM.Playing;
                    }
                    else if (levelUpButtons[4].LeftClicked)
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
            // Testing image buttons
            

            switch (gameFSM)
            {
                case GameFSM.Playing:

                    DrawGame(sb);

                    break;

                case GameFSM.Paused: // --- Paused --------------------------------------------//

                    // elements of the game a drawn but not updated
                    DrawGame(sb);

                    // Add a transparent black rectangle over the game
                    // to darken screen and make text stand out
                    sb.Draw(singleColor,
                        window,
                        Color.Black * 0.4f);

                    // Text for the pause menu
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

                    // elements of the game a drawn but not updated
                    DrawGame(sb);

                    // Add a transparent black rectangle over the game
                    // to darken screen and make text stand out
                    sb.Draw(singleColor,
                        window,
                        Color.Black * 0.4f);

                    // Draw Text
                    sb.DrawString(BellMT72,
                        $"LEVEL UP",
                        new Vector2(window.Width * 0.3f, window.Height * 0.16f),
                        Color.LightGreen);

                    // Draw all buttons
                    foreach (ImageButton i in levelUpButtons)
                    {
                        i.Draw(sb);
                    }

                    break;
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
                        walkable = false;
                    }
                    temp.Add(new AStarNode(new Vector2(j*64,i*64),walkable,1));
                }
                graph.Add(temp);
            }
        }

        /// <summary>
        /// Draws all elements of the game
        /// Player,Enemies,Tiles,Health and XP bar
        /// </summary>
        /// <param name="sb"></param>
        private void DrawGame(SpriteBatch sb)
        {
            foreach (SceneObject tile in floorTiles)
            {
                tile.Draw(sb);
            }

            //draw walls
            foreach (SceneObject obj in walls)
            {
                obj.Draw(sb);
            }

            //draw tiles
            foreach (SceneObject tile in wallTiles)
            {
                tile.Draw(sb);
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
                Color.LightGray);
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
                        walls.Add(new SceneObject(true,0, whiteRectangle, new Rectangle(j*64, i*64, 64, 64)));
                    }
                    else if (grid[j,i] == 2)
                    {
                        enemies.Add(new ShortRangeEnemy(dungeontilesTexture2D, new Rectangle(j*64, i*64, 32, 32), player, (player.RoomsCleared / 2) + 1, graphicsDevice));
                    }
                    else if (grid[j,i] == 3)
                    {
                        player.X = (j * 64 + 32);
                        player.Y = (i * 64 + 32);
                    }
                    else if (grid[j, i] == 5)
                    {
                        enemies.Add(new LongRangeEnemy(dungeontilesTexture2D, new Rectangle(j * 64, i * 64, 32, 32), player, graphicsDevice));
                    }
                }
            }

            wallTiles.Clear();
            int[,] tileGrid;

            //if game just start generate the intro room, else randomly pick room
            if (player.RoomsCleared == 0)
            {
                tileGrid = fileManager_.LoadWallTiles($"Content/Level{0}.txt");
            }
            else
            {
                //the second parameter is the number of total room
                tileGrid = fileManager_.LoadWallTiles($"Content/Level{new Random().Next(1,6)}.txt");
            }


            for (int i = 0; i < tileGrid.GetLength(1); i++)
            {
                for (int j = 0; j < tileGrid.GetLength(0); j++)
                {
                    switch (tileGrid[j,i])
                    {
                        case 1:
                            wallTiles.Add(new SceneObject(false, 1, dungeontilesTexture2D, new Rectangle(j * 64, i * 64, 32, 32)));
                            wallTiles.Add(new SceneObject(false, 1, dungeontilesTexture2D, new Rectangle(j * 64 + 32, i * 64, 32, 32)));
                            wallTiles.Add(new SceneObject(false, 4, dungeontilesTexture2D, new Rectangle(j * 64, i * 64 + 32, 32, 32)));
                            wallTiles.Add(new SceneObject(false, 4, dungeontilesTexture2D, new Rectangle(j * 64 + 32, i * 64 + 32, 32, 32)));
                            break;
                        case 2:
                            wallTiles.Add(new SceneObject(false, 2, dungeontilesTexture2D, new Rectangle(j * 64, i * 64, 32, 32)));
                            wallTiles.Add(new SceneObject(false, 8, dungeontilesTexture2D, new Rectangle(j * 64, i * 64 + 32, 32, 32)));
                            break;
                        case 3:
                            wallTiles.Add(new SceneObject(false, 3, dungeontilesTexture2D, new Rectangle(j * 64, i * 64, 32, 32)));
                            break;
                        case 4:
                            wallTiles.Add(new SceneObject(false, 4, dungeontilesTexture2D, new Rectangle(j * 64, i * 64, 32, 32)));
                            wallTiles.Add(new SceneObject(false, 4, dungeontilesTexture2D, new Rectangle(j * 64 + 32, i * 64, 32, 32)));
                            break;
                        case 5:
                            wallTiles.Add(new SceneObject(false, 5, dungeontilesTexture2D, new Rectangle(j * 64 + 32, i * 64, 32, 32)));
                            wallTiles.Add(new SceneObject(false, 7, dungeontilesTexture2D, new Rectangle(j * 64 + 32, i * 64 +32, 32, 32)));
                            break;
                        case 6:
                            wallTiles.Add(new SceneObject(false, 6, dungeontilesTexture2D, new Rectangle(j * 64 + 32, i * 64, 32, 32)));
                            break;
                        case 7:
                            wallTiles.Add(new SceneObject(false, 7, dungeontilesTexture2D, new Rectangle(j * 64 + 32, i * 64, 32, 32)));
                            wallTiles.Add(new SceneObject(false, 7, dungeontilesTexture2D, new Rectangle(j * 64 + 32, i * 64 + 32, 32, 32)));
                            break;
                        case 8:
                            wallTiles.Add(new SceneObject(false, 8, dungeontilesTexture2D, new Rectangle(j * 64 , i * 64, 32, 32)));
                            wallTiles.Add(new SceneObject(false, 8, dungeontilesTexture2D, new Rectangle(j * 64 , i * 64 + 32, 32, 32)));
                            break;
                        case 9:
                            wallTiles.Add(new SceneObject(false, 8, dungeontilesTexture2D, new Rectangle(j * 64, i * 64, 32, 32)));
                            wallTiles.Add(new SceneObject(false, 9, dungeontilesTexture2D, new Rectangle(j * 64, i * 64 + 32, 32, 32)));
                            wallTiles.Add(new SceneObject(false, 1, dungeontilesTexture2D, new Rectangle(j * 64 + 32, i * 64 + 32, 32, 32)));
                            break;
                        case 10:
                            wallTiles.Add(new SceneObject(false, 7, dungeontilesTexture2D, new Rectangle(j * 64 + 32, i * 64, 32, 32)));
                            wallTiles.Add(new SceneObject(false, 10, dungeontilesTexture2D, new Rectangle(j * 64 + 32, i * 64 + 32, 32, 32)));
                            wallTiles.Add(new SceneObject(false, 1, dungeontilesTexture2D, new Rectangle(j * 64, i * 64 + 32, 32, 32)));
                            break;
                        case 11:
                            wallTiles.Add(new SceneObject(false, 1, dungeontilesTexture2D, new Rectangle(j * 64, i * 64 + 32, 32, 32)));
                            wallTiles.Add(new SceneObject(false, 1, dungeontilesTexture2D, new Rectangle(j * 64 + 32, i * 64 + 32, 32, 32)));
                            break;
                        case 12:
                            wallTiles.Add(new SceneObject(false, 4, dungeontilesTexture2D, new Rectangle(j * 64, i * 64 + 32, 32, 32)));
                            wallTiles.Add(new SceneObject(false, 4, dungeontilesTexture2D, new Rectangle(j * 64 + 32, i * 64 + 32, 32, 32)));
                            wallTiles.Add(new SceneObject(false, 9, dungeontilesTexture2D, new Rectangle(j * 64, i * 64, 32, 32)));
                            wallTiles.Add(new SceneObject(false, 10, dungeontilesTexture2D, new Rectangle(j * 64 + 32, i * 64, 32, 32)));
                            break;
                        case 13:
                            wallTiles.Add(new SceneObject(false, 6, dungeontilesTexture2D, new Rectangle(j * 64 + 32, i * 64 + 32, 32, 32)));
                            wallTiles.Add(new SceneObject(false, 7, dungeontilesTexture2D, new Rectangle(j * 64 + 32, i * 64, 32, 32)));
                            break;
                        case 14:
                            wallTiles.Add(new SceneObject(false, 3, dungeontilesTexture2D, new Rectangle(j * 64, i * 64 + 32, 32, 32)));
                            wallTiles.Add(new SceneObject(false, 8, dungeontilesTexture2D, new Rectangle(j * 64, i * 64, 32, 32)));
                            break;
                    }
                    
                }
            }

        }

        /// <summary>
        /// updates the position of the player and enemies on the grid
        /// </summary>
        public void UpdateGrid()
        {
            //clear old positions of enemies and players and save wall positions
            int[,] tempWallGrid = new int[20, 12];
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                for (int j = 0; j < grid.GetLength(0); j++)
                {
                    if (grid[j,i] == 1)
                    {
                        tempWallGrid[j,i] = 1;
                    }
                    if (grid[j,i] == 3 || grid[j,i] == 2)
                    {
                        grid[j,i] = 0;
                    }
                }
            }

            //add enemy positions
            foreach (Enemy enemy in enemies)
            {


                if (enemy.Position.X > 0 && enemy.Position.Y > 0
                && enemy.Position.X < window.Width && enemy.Position.Y < window.Height)
                {
                    if (enemy is ShortRangeEnemy)
                    {
                        ShortRangeEnemy SRenemy = (ShortRangeEnemy)enemy;
                        SRenemy.graphPoint = new Point(Convert.ToInt32(enemy.Position.X) / 64, Convert.ToInt32(enemy.Position.Y) / 64);
                        grid[Convert.ToInt32(enemy.Position.X) / 64, Convert.ToInt32(enemy.Position.Y) / 64] = 2;
                    }
                    
                }
            }

            //add player position
            if (player.Position.X > 0 && player.Position.Y > 0
                && player.Position.X < window.Width && player.Position.Y < window.Height)
            {
                player.graphPoint = new Point(Convert.ToInt32(player.Position.X) / 64, Convert.ToInt32(player.Position.Y) / 64);
                grid[Convert.ToInt32(player.Position.X) / 64, Convert.ToInt32(player.Position.Y) / 64] = 3;
            }

            //return walls to old values
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                for (int j = 0; j < grid.GetLength(0); j++)
                {
                    if (tempWallGrid[j, i] == 1)
                    {
                        grid[j, i] = 1;
                    }
                }
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
            // change number after player.RoomsCleared to be the amount of level files
            grid = fileManager_.LoadGrid($"Content/Level{player.RoomsCleared%6}.txt");
            
            enemies.Clear();
            //generates curent room based on grid
            GenerateRoom();

            if (player.RoomsCleared == 0)
            {
                // start with 90 xp so the player gets to level up
                // on the tutorial level (level0)
                player.Exp += 90;
            }
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

        /// <summary>
        /// Set the defualt values of all the upgrade buttons
        /// </summary>
        public void InitializeLevelUpButtons()
        {
            levelUpButtons.Add(new ImageButton(
                new Rectangle(window.Height * 2,0,
                (int)(window.Height * 0.2f), (int)(window.Height * 0.2f)),
                "Heal",
                BellMT24,
                abilityIcons,
                new Vector2(6,2)));

            levelUpButtons.Add(new ImageButton(
                new Rectangle(window.Height * 2, 0,
                (int)(window.Height * 0.2f), (int)(window.Height * 0.2f)),
                "Max Health",
                BellMT24,
                abilityIcons,
                new Vector2(12, 5)));

            levelUpButtons.Add(new ImageButton(
                new Rectangle(window.Height*2, 0,
                (int)(window.Height * 0.2f), (int)(window.Height * 0.2f)),
                "Attack Speed",
                BellMT24,
                abilityIcons,
                new Vector2(11, 3)));

            levelUpButtons.Add(new ImageButton(
                new Rectangle(window.Height*2, 0,
                (int)(window.Height * 0.2f), (int)(window.Height * 0.2f)),
                "Damage",
                BellMT24,
                abilityIcons,
                new Vector2(0, 3)));

            levelUpButtons.Add(new ImageButton(
                new Rectangle(window.Height*2, 0,
                (int)(window.Height * 0.2f), (int)(window.Height * 0.2f)),
                "Range",
                BellMT24,
                abilityIcons,
                new Vector2(10, 3)));
        }

        /// <summary>
        /// Randomly pick 3 abilities to offer
        /// </summary>
        public void RandomizeLevelUpAbilities()
        {
            // remove all buttons from the screen
            foreach (ImageButton button in levelUpButtons)
            {
                button.Rectangle = new Rectangle(button.Rectangle.X, window.Height*2,
                    button.Rectangle.Width, button.Rectangle.Height);
            }
            Random rng = new Random();

            // Generate 3 unique numbers
            int[] randomAbilities = new int[3]
            {
                -1,-1,-1
            };

            for (int i = 0; i < 3; i+= 0)
            {
                int next = rng.Next(0, 5);
                if (!randomAbilities.Contains(next))
                {
                    randomAbilities[i] = next;
                    i++;
                }
            }

            // 1st ability
            levelUpButtons[randomAbilities[0]].Rectangle =
                new Rectangle((int)(window.Width*0.1f),(int)(window.Height*0.4f),
                (int)(window.Width*0.2f),(int)(window.Width*0.2f));

            // 2nd ability
            levelUpButtons[randomAbilities[1]].Rectangle =
                new Rectangle((int)(window.Width * 0.4f), (int)(window.Height * 0.4f),
                (int)(window.Width * 0.2f), (int)(window.Width * 0.2f));

            // 3rd ability
            levelUpButtons[randomAbilities[2]].Rectangle =
                new Rectangle((int)(window.Width * 0.7f), (int)(window.Height * 0.4f),
                (int)(window.Width * 0.2f), (int)(window.Width * 0.2f));

        }
    }
}
