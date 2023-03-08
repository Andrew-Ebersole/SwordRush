using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace SwordRush
{
    enum GameFSM
    {
        Menu,
        Game,
        GameOver,
        Settings,
        Credits,
        Instructions,
        HighScores
    }

    internal class UI
    {
        // --- Fields --- //

        private int level;
        private int playerLevel;
        private int health;

        // Finite State Machine
        private GameFSM gameFSM;

        // Fonts
        private SpriteFont bellMT24;

        // Mouse State
        private MouseState currentMState;
        private MouseState previousMState;

        // Buttons
        private List<TextButton> menuButtons;

        // Window dimensions
        private Rectangle window;

        // --- Properties --- //

        public GameFSM GameFSM { get { return gameFSM; } }



        // --- Constructor --- //

        public UI(ContentManager content, GraphicsDeviceManager graphics)
        {
            // State Machine
            gameFSM = GameFSM.Menu;

            // Fonts
            bellMT24 = content.Load<SpriteFont>("Bell_MT-24");

            // Creates all the buttons
            initalizeButtons();

            // Controls Mouse
            currentMState = new MouseState();
            previousMState = new MouseState();

            // Used for window height and width
            window = new Rectangle(0,0,
                graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

        }



        // --- Methods --- //

        public void LoadContent()
        {

        }

        public void Update(GameTime gt)
        {
            currentMState = Mouse.GetState();

            // Testing Menu Text
            switch (gameFSM)
            {
                case GameFSM.Menu:
                    
                    // Updates hover color change
                    foreach (TextButton b in menuButtons)
                    {
                        b.Update(gt);
                    }

                    // changes states when clicked
                    if (menuButtons[0].IsClicked())
                    {
                        gameFSM = GameFSM.Instructions;
                    }
                    break;
                case GameFSM.Instructions:
                    if (currentMState.LeftButton == ButtonState.Pressed
                        && previousMState.LeftButton == ButtonState.Released)
                    {
                        gameFSM = GameFSM.Menu;
                    }
                    break;
            }

            previousMState = currentMState;
        }

        public void Draw(SpriteBatch sb)
        {
            // Testing Menu Text
            switch (gameFSM)
            {
                case GameFSM.Menu:
                    foreach (TextButton b in menuButtons)
                    {
                        b.Draw(sb);
                    }
                    break;

                case GameFSM.Game:
                    
                    break;
            }

            
        }

        private void initalizeButtons()
        {
            menuButtons = new List<TextButton>();

            menuButtons.Add(new TextButton(
                new Vector2(
                window.Width * 0.1f,
                window.Height * 0.3f),  // Location
                new Point(160, 30),     // Hover Hitbox ("Used to sense when mouse is over the button")
                "Start Game",           // Text
                bellMT24));             // Font

            menuButtons.Add(new TextButton(
                new Vector2(
                window.Width * 0.1f,
                window.Height * 0.42f),    // Location
                new Point(200, 30),     // Hover Hitbox ("Used to sense when mouse is over the button")
                "Instructions",         // Text
                bellMT24));             // Font

            menuButtons.Add(new TextButton(
                new Vector2(
                window.Width * 0.1f,
                window.Height * 0.54f),    // Location
                new Point(120, 30),     // Hover Hitbox ("Used to sense when mouse is over the button")
                "Credits",              // Text
                bellMT24));             // Font

            menuButtons.Add(new TextButton(
                new Vector2(
                window.Width * 0.1f,
                window.Height * 0.66f),    // Location
                new Point(180, 30),     // Hover Hitbox ("Used to sense when mouse is over the button")
                "High Scores",          // Text
                bellMT24));             // Font

            menuButtons.Add(new TextButton(
                new Vector2(
                window.Width * 0.1f,
                window.Height * 0.78f),    // Location
                new Point(140, 30),     // Hover Hitbox ("Used to sense when mouse is over the button")
                "Settings",             // Text
                bellMT24));             // Font
        }
    }
}
