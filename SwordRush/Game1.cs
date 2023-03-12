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
    // Delegates
    public delegate void ToggleGameState();

    public class Game1 : Game
    {
        #region fields
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Fonts
        SpriteFont bellMT24;
        // UI Manager
        private UI uiManager;
        //Game Manager
        private GameManager gameManager;

        // window
        Point windowSize;

        //blank rectangle
        Texture2D whiteRectangle;

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

            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //create blank rectangle sprite
            whiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
            whiteRectangle.SetData(new[] { Color.White });

            // Load Fonts
            bellMT24 = Content.Load<SpriteFont>("Bell_MT-24");

            // UI Manager
            uiManager = new UI(Content, windowSize);
            // Game Manager
            gameManager = new GameManager(Content, windowSize, whiteRectangle);
            
            // Events and delegates
            uiManager.startGame += gameManager.StartGame;
            gameManager.gameOver += uiManager.EndGame;
            uiManager.quitGame += gameManager.QuitGame;

            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            gameManager.Update(gameTime);
            uiManager.Update(gameTime);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(32,32,32));
            _spriteBatch.Begin();

            // Draw UI elements (Text, Menus, Icons)
            uiManager.Draw(_spriteBatch);

            
            gameManager.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}