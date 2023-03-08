using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Andrew, Bin, Weiji, Josh
// Started March 6, 2023
// Group Game "Sword Rush" for IGME 106 Class

namespace SwordRush
{
    

    public class Game1 : Game
    {
        #region fields
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player player;
        private List<Enemy> enemies;
        // Textures
        private Texture2D dungeontilesTexture2D;
        // Fonts
        SpriteFont bellMT24;
        // UI Manager
        private UI uiManager;
        //Game Manager
        private GameManager gameManager;

        // window
        Point windowSize;

        #endregion

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Change window size
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {

            // Window Size
            windowSize = new Point(
                _graphics.PreferredBackBufferWidth,
                _graphics.PreferredBackBufferHeight);

            // Temp Player
            player = new Player(null, new Rectangle(10, 10, 10, 10));
            // TODO: Add your initialization logic here
            enemies = new List<Enemy>();
            player = new Player(null, new Rectangle(10,10,16,16));
            enemies.Add(new ShortRangeEnemy(null,new Rectangle(10,10,16,16),player));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load Fonts
            bellMT24 = Content.Load<SpriteFont>("Bell_MT-24");
            dungeontilesTexture2D = Content.Load<Texture2D>("DungeonTiles");
            // UI Manager
            uiManager = new UI(Content);
            // Game Manager
            gameManager = new GameManager(dungeontilesTexture2D);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.playerControl();
            foreach(Enemy enemy in enemies){
                enemy.Update(gameTime);
            }
            uiManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(32,32,32));
            _spriteBatch.Begin();

            // Draw UI elements (Text, Menus, Icons)
            uiManager.Draw(_spriteBatch);

            _spriteBatch.Draw(dungeontilesTexture2D,player.Position,new Rectangle(128,64,16,32),Color.White);
            _spriteBatch.Draw(dungeontilesTexture2D, enemies[0].Position, new Rectangle(368, 80, 16, 16), Color.White);
            gameManager.GenerateRoom(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}