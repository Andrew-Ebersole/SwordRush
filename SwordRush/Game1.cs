using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Andrew, Bin, Weiji, Josh
// Created March 6, 2023
// Group Game "Sword Rush" for IGME 106 Class

namespace SwordRush
{
    public class Game1 : Game
    {
        #region fields
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Textures

        // Fonts
        SpriteFont bellMT24;

        #endregion

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load Fonts
            bellMT24 = Content.Load<SpriteFont>("Bell_MT-24");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            // Testing font
            _spriteBatch.DrawString(
                bellMT24,               // Font
                "Test",                 // Text
                new Vector2(10, 10),    // Location
                Color.White);           // Color

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}