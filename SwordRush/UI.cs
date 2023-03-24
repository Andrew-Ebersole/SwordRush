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
        private SpriteFont bellMT36;
        private SpriteFont bellMT48;
        private SpriteFont bellMT72;

        // Mouse State
        private MouseState currentMState;
        private MouseState previousMState;

        // Buttons
        private List<TextButton> menuButtons;
        private List<TextButton> settingButtons;

        // Window dimensions
        private Rectangle window;

        // Textures
        private Texture2D menuImageTexture;

        // Event to communicate with GameManager
        public event ToggleGameState startGame;
        public event ToggleGameState quitGame;



        private static UI instance = null;
        
        public static UI Get
        {
            get
            {
                if (instance == null)
                {
                    instance = new UI();
                }
                
                return instance;
            }
        }

        // --- Properties --- //

        public GameFSM GameFSM { get { return gameFSM; } }



        // --- Constructor --- //

        public void Initialize(ContentManager content, Point windowSize)
        {
            // State Machine
            gameFSM = GameFSM.Menu;

            // Fonts
            bellMT36 = content.Load<SpriteFont>("Bell_MT-36");
            bellMT48 = content.Load<SpriteFont>("Bell_MT-48");
            bellMT72 = content.Load<SpriteFont>("Bell_MT-72");

            // Textures
            menuImageTexture = content.Load<Texture2D>("DungeonTiles");

            // Controls Mouse
            currentMState = new MouseState();
            previousMState = new MouseState();

            // Used for window height and width
            this.window = new Rectangle(0,0,
                windowSize.X, windowSize.Y);

            // Creates all the buttons
            initalizeButtons();
        }



        // --- Methods --- //

        public void LoadContent()
        {

        }

        public void Update(GameTime gt)
        {
            currentMState = Mouse.GetState();

            // Loads the 
            switch (gameFSM)
            {
                case GameFSM.Menu: // --- Menu --------------------------------------------------//
                    
                    // Updates hover color change
                    foreach (TextButton b in menuButtons)
                    {
                        b.Update(gt);
                    }

                    // changes states when clicked
                    if (menuButtons[0].LeftClicked)
                    {
                        gameFSM = GameFSM.Game;

                        // Sends event that will be recieved by game manager
                        startGame();
                    }
                    if (menuButtons[1].LeftClicked)
                    {
                        gameFSM = GameFSM.Instructions;
                    }
                    if (menuButtons[2].LeftClicked)
                    {
                        gameFSM = GameFSM.Credits;
                    }
                    if (menuButtons[3].LeftClicked)
                    {
                        gameFSM = GameFSM.HighScores;
                    }
                    if (menuButtons[4].LeftClicked)
                    {
                        gameFSM = GameFSM.Settings;
                    }
                    break;

                case GameFSM.Game: // --- Game --------------------------------------------------//
                    // Right click to quit the game
                    if (currentMState.RightButton == ButtonState.Pressed
                        && previousMState.RightButton == ButtonState.Released)
                    {
                        quitGame();
                        gameFSM = GameFSM.Menu;
                        
                    }
                    break;

                default:  // --- Other ----------------------------------------------------------//
                    // In any state that is not game left click will bring you back to menu
                    if (currentMState.LeftButton == ButtonState.Pressed
                        && previousMState.LeftButton == ButtonState.Released)
                    {
                        gameFSM = GameFSM.Menu;
                    }
                    break;
            }

            previousMState = Mouse.GetState();
        }

        public void Draw(SpriteBatch sb)
        {
            // Testing Menu Text
            switch (gameFSM)
            {
                case GameFSM.Menu:  // --- Menu -------------------------------------------------//

                    // Draw Title
                    sb.DrawString(
                        bellMT72,                           // Font
                        "SWORD RUSH",                       // Text
                        new Vector2((window.Width * 0.10f), // X Pos
                        (window.Height * 0.10f)),           // Y Pos
                        Color.Goldenrod);                   // Color

                    // Draw all Buttons
                    foreach (TextButton b in menuButtons)
                    {
                        b.Draw(sb);
                    }

                    // Draw Image
                    
                    break;

                case GameFSM.GameOver:  // --- Menu -----------------------------------------------//
                    // Draw Game over
                    sb.DrawString(
                        bellMT72,
                        "GAME OVER",
                        new Vector2((window.Width * 0.3f),
                        (window.Height * 0.3f)),
                        Color.Red);

                    // Draw Score
                    sb.DrawString(
                        bellMT48,                           // Font
                        $"YOU CLEARED __ ROOMS",            // Text
                        new Vector2((window.Width * 0.3f),  // X Position
                        (window.Height * 0.5f)),            // Y Position
                        Color.White);                       // Color
                    break;

                case GameFSM.Instructions: // --- Instructions ----------------------------------//
                    sb.DrawString(
                        bellMT72,                       // Font
                        $"How to Play",                 // Text
                        new Vector2(window.Width * 0.1f,// X Position
                        window.Height * 0.1f),          // Y Position
                        Color.White);                   // Color

                    sb.DrawString(
                        bellMT72,                       // Font
                        $"Controls",                    // Text
                        new Vector2(window.Width * 0.6f,// X Position
                        window.Height * 0.1f),          // Y Position
                        Color.White);                   // Color

                    sb.DrawString(
                        bellMT36,                       // Font
                        $"Attack to move, Kill as " +
                        $"\nmany enemies as you can" +
                        $"\nto unlock the next room." +
                        $"\nSee how many rooms you " +
                        $"\ncan clear before you die." +
                        $"\nGain XP to unlock abilities.", // Text
                        new Vector2(window.Width * 0.1f,// X Position
                        window.Height * 0.3f),          // Y Position
                        Color.White);                   // Color

                    sb.DrawString(
                        bellMT36,                       // Font
                        $"Attack" +
                        $"\n - Left Click" +
                        $"\nMove" +
                        $"\n - Left Click" +
                        $"\nQuit" +
                        $"\n - Escape",                 // Text
                        new Vector2(window.Width * 0.6f,// X Position
                        window.Height * 0.3f),          // Y Position
                        Color.White);                   // Color


                    break;

                case GameFSM.Credits: // --- Credits --------------------------------------------//

                    sb.DrawString(
                        bellMT48,                       // Font
                        $"Developers",                  // Text
                        new Vector2(window.Width * 0.1f,// X Position
                        window.Height * 0.1f),          // Y Position
                        Color.White);                   // Color

                    sb.DrawString(
                        bellMT36,                       // Font
                        $"Andrew Ebersole" +
                        $"\nBin Xu" +
                        $"\nJosh Leong" +
                        $"\nWeijie Ye",                  // Text
                        new Vector2(window.Width * 0.1f,// X Position
                        window.Height * 0.3f),          // Y Position
                        Color.White);                   // Color


                    sb.DrawString(
                        bellMT48,                       // Font
                        $"Art",                         // Text
                        new Vector2(window.Width * 0.4f,// X Position
                        window.Height * 0.1f),          // Y Position
                        Color.LightGray);                   // Color

                    sb.DrawString(
                        bellMT36,                       // Font
                        $"frosty_rabbid" +
                        $"\nguilemus" +
                        $"\n0x72 \"Robert\"",                  // Text
                        new Vector2(window.Width * 0.4f,// X Position
                        window.Height * 0.3f),          // Y Position
                        Color.LightGray);                   // Color

                    sb.DrawString(
                        bellMT48,                       // Font
                        $"Audio",                       // Text
                        new Vector2(window.Width * 0.7f,// X Position
                        window.Height * 0.1f),          // Y Position
                        Color.White);                   // Color
                    break;

                case GameFSM.HighScores: // --- HighScores --------------------------------------//

                    sb.DrawString(
                        bellMT72,                       // Font
                        $"High Scores",                 // Text
                        new Vector2(window.Width * 0.1f,// X Position
                        window.Height * 0.1f),          // Y Position
                        Color.White);                   // Color

                    sb.DrawString(
                        bellMT48,                       // Font
                        $"1:" +
                        $"\n2:" +
                        $"\n3:" +
                        $"\n4:" +
                        $"\n5:",                        // Text
                        new Vector2(window.Width * 0.1f,// X Position
                        window.Height * 0.3f),          // Y Position
                        Color.White);                   // Color

                    break;

                case GameFSM.Settings: // --- Settings ------------------------------------------//
                    
                    sb.DrawString(
                        bellMT72,                       // Font
                        $"Settings",                    // Text
                        new Vector2(window.Width * 0.1f,// X Position
                        window.Height * 0.1f),          // Y Position
                        Color.White);                   // Color
                    break;

            }


        }

        private void initalizeButtons()
        {

            // --- Menu Buttons -----------------------------------------------------------------//
            menuButtons = new List<TextButton>();

            menuButtons.Add(new TextButton(new Rectangle(
                (int)(window.Width * 0.10f), (int)(window.Height * 0.30f),  // Location
                (int)(window.Width * 0.23f), (int)(window.Height * 0.09f)), // Hitbox
                "Start Game",                                               // Text
                bellMT48));                                                 // Font

            menuButtons.Add(new TextButton(new Rectangle(
                (int)(window.Width * 0.10f), (int)(window.Height * 0.42f),  // Location
                (int)(window.Width * 0.25f), (int)(window.Height * 0.09f)), // Hitbox
                "Instructions",                                             // Text
                bellMT48));                                                 // Font

            menuButtons.Add(new TextButton(new Rectangle(
                (int)(window.Width * 0.10f), (int)(window.Height * 0.54f),  // Location
                (int)(window.Width * 0.15f), (int)(window.Height * 0.09f)), // Hitbox
                "Credits",                                                  // Text
                bellMT48));                                                 // Font

            menuButtons.Add(new TextButton(new Rectangle(
                (int)(window.Width * 0.10f), (int)(window.Height * 0.66f),  // Location
                (int)(window.Width * 0.25f), (int)(window.Height * 0.09f)), // Hitbox
                "High Scores",                                              // Text
                bellMT48));                                                 // Font

            menuButtons.Add(new TextButton(new Rectangle(
                (int)(window.Width * 0.10f), (int)(window.Height * 0.78),  // Location
                (int)(window.Width * 0.17f), (int)(window.Height * 0.09f)), // Hitbox
                "Settings",                                                 // Text
                bellMT48));                                                 // Font

            // --- Settings Buttons -------------------------------------------------------------//
            settingButtons = new List<TextButton>();

            settingButtons.Add(new TextButton(new Rectangle(
                (int)(window.Width * 0.10f), (int)(window.Height * 0.30f),  // Location
                (int)(window.Width * 0.23f), (int)(window.Height * 0.09f)), // Hitbox
                "-",                                                        // Text
                bellMT36));                                                 // Font
        }

        public void EndGame()
        {
            gameFSM = GameFSM.GameOver;
        }
    }
}
