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

        // Textures
        private Texture2D dungeontilesTexture2D;
        // Fonts
        SpriteFont bellMT24;
        // UI Manager
        private UI uiManager;

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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load Fonts
            bellMT24 = Content.Load<SpriteFont>("Bell_MT-24");
            dungeontilesTexture2D = Content.Load<Texture2D>("DungeonTiles");
            // UI Manager
            uiManager = new UI(Content, windowSize);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.playerControl();
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

            _spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}