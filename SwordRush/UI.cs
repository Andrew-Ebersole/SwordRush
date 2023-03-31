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
        private int roomsCleared;

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
        private Texture2D singleColor;

        // Event to communicate with GameManager
        public event ToggleGameState startGame;
        public event ToggleGameState quitGame;

        // Settings - Debug
        private int sfxLevel;
        private int musicLevel;
        private bool takeDamage;


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

        public int SfxLevel { get { return sfxLevel; } }

        public int MusicLevel { get { return musicLevel; } }

        public bool TakeDamage { get { return takeDamage; } }


        // --- Constructor --- //

        public void Initialize(ContentManager content, Point windowSize, GraphicsDevice gd)
        {
            // State Machine
            gameFSM = GameFSM.Menu;

            // Fonts
            bellMT36 = content.Load<SpriteFont>("Bell_MT-36");
            bellMT48 = content.Load<SpriteFont>("Bell_MT-48");
            bellMT72 = content.Load<SpriteFont>("Bell_MT-72");

            // Textures
            menuImageTexture = content.Load<Texture2D>("MenuBackground3");
            singleColor = new Texture2D(gd, 1, 1);
            singleColor.SetData(new Color[] { Color.White });


            // Controls Mouse
            currentMState = new MouseState();
            previousMState = new MouseState();

            // Used for window height and width
            this.window = new Rectangle(0,0,
                windowSize.X, windowSize.Y);

            // Creates all the buttons
            initalizeButtons();
            takeDamage = true;
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
                        GameManager.Get.LocalPlayer.NewRound();
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
                    // Code for quitting game in GameManager
                    break;

                case GameFSM.Settings:

                    foreach(TextButton b in settingButtons)
                    {
                        b.Update(gt);
                    }

                    // TODO: implement debug code here to adjust volumes and enable invincibility
                    if (currentMState.LeftButton == ButtonState.Pressed 
                        && previousMState.LeftButton == ButtonState.Released)
                    {
                        // Lower SFX
                        if (settingButtons[0].LeftClicked)
                        {
                            if (sfxLevel > 0)
                            {
                                sfxLevel--;
                            }
                        }
                        // Raise SFX
                        else if (settingButtons[1].LeftClicked)
                        {
                            if (sfxLevel < 10)
                            {
                                sfxLevel++;
                            }
                        }
                        // Lower Music
                        else if (settingButtons[2].LeftClicked)
                        {
                            if (musicLevel > 0)
                            {
                                musicLevel--;
                            }
                        }
                        // Raise Music
                        else if (settingButtons[3].LeftClicked)
                        {
                            if (musicLevel < 10)
                            {
                                musicLevel++;
                                
                            }
                        }
                        // Toggle TakeDamage
                        else if (settingButtons[4].LeftClicked)
                        {
                            if (takeDamage == false)
                            {
                                takeDamage = true;
                                settingButtons[4].Text = "True";
                            }
                            else
                            {
                                takeDamage = false;
                                settingButtons[4].Text = "False";
                            }
                            
                        }
                        else
                        {
                            gameFSM = GameFSM.Menu;
                        }
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

                    // Background Image
                    sb.Draw(
                     menuImageTexture,
                     window,
                     Color.White);

                    // Background for title
                    sb.Draw(singleColor,                                                        // Texture
                        new Rectangle((int)(window.Width * 0.10f), (int)(window.Height*0.1f),   // X / Y
                        (int)(window.Width*0.5f),(int)(window.Height*0.13f)),                   // Width / Height
                        new Color(32, 32, 32));                                                        // Color

                    // Draw Title
                    sb.DrawString(
                        bellMT72,                           // Font
                        "SWORD RUSH",                       // Text
                        new Vector2((window.Width * 0.10f), // X Pos
                        (window.Height * 0.10f)),           // Y Pos
                        Color.Goldenrod);                   // Color

                    // Rectangles behind the menu buttons
                    sb.Draw(singleColor,                                                        // Texture
                        new Rectangle((int)(window.Width * 0.10f), (int)(window.Height * 0.3f),   // X / Y
                        (int)(window.Width * 0.24f), (int)(window.Height * 0.08f)),                   // Width / Height
                        new Color(32, 32, 32));

                    sb.Draw(singleColor,                                                        // Texture
                        new Rectangle((int)(window.Width * 0.10f), (int)(window.Height * 0.42f),   // X / Y
                        (int)(window.Width * 0.25f), (int)(window.Height * 0.08f)),                   // Width / Height
                        new Color(32, 32, 32));

                    sb.Draw(singleColor,                                                        // Texture
                        new Rectangle((int)(window.Width * 0.10f), (int)(window.Height * 0.54f),   // X / Y
                        (int)(window.Width * 0.15f), (int)(window.Height * 0.08f)),                   // Width / Height
                        new Color(32, 32, 32));

                    sb.Draw(singleColor,                                                        // Texture
                        new Rectangle((int)(window.Width * 0.10f), (int)(window.Height * 0.66f),   // X / Y
                        (int)(window.Width * 0.25f), (int)(window.Height * 0.08f)),                   // Width / Height
                        new Color(32, 32, 32));

                    sb.Draw(singleColor,                                                        // Texture
                        new Rectangle((int)(window.Width * 0.10f), (int)(window.Height * 0.78f),   // X / Y
                        (int)(window.Width * 0.17f), (int)(window.Height * 0.08f)),                   // Width / Height
                        new Color(32, 32, 32));

                    // Draw all Buttons
                    foreach (TextButton b in menuButtons)
                    {
                        b.Draw(sb);
                    }
                    
                    break;

                case GameFSM.GameOver:  // --- Menu -----------------------------------------------//
                    // Draw Game over
                    sb.DrawString(
                        bellMT72,
                        "GAME OVER",
                        new Vector2((window.Width * 0.2f),
                        (window.Height * 0.3f)),
                        Color.DarkRed);

                    // Draw Score
                    sb.DrawString(
                        bellMT48,                           // Font
                        $"YOU CLEARED {roomsCleared} ROOMS",            // Text
                        new Vector2((window.Width * 0.2f),  // X Position
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
                        $"Bin Xu" +
                        $"\nJosh Leong" +
                        $"\nWeijie Ye" +
                        $"\nAndrew Ebersole",           // Text
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
                        $"\n0x72 \"Robert\"" +
                        $"\nThe Outlander",                  // Text
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
                        $"1: Not implemented yet" +
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

                    sb.DrawString(
                        bellMT48,                       // Font
                        $"SFX Volume",                  // Text
                        new Vector2(window.Width * 0.1f,// X Position
                        window.Height * 0.3f),          // Y Position
                        Color.White);                   // Color

                    sb.DrawString(
                        bellMT36,                       // Font
                        $"{sfxLevel}",                  // Text
                        new Vector2(window.Width * 0.63f,// X Position
                        window.Height * 0.30f),          // Y Position
                        Color.White);                   // Color

                    sb.DrawString(
                        bellMT48,                       // Font
                        $"Music Volume",                // Text
                        new Vector2(window.Width * 0.1f,// X Position
                        window.Height * 0.4f),          // Y Position
                        Color.White);                   // Color

                    sb.DrawString(
                        bellMT36,                       // Font
                        $"{musicLevel}",                // Text
                        new Vector2(window.Width * 0.63f,// X Position
                        window.Height * 0.40f),          // Y Position
                        Color.White);                   // Color

                    sb.DrawString(
                        bellMT48,                       // Font
                        $"Take Damage",                 // Text
                        new Vector2(window.Width * 0.1f,// X Position
                        window.Height * 0.5f),          // Y Position
                        Color.White);                   // Color

                    foreach (TextButton b in settingButtons)
                    {
                        b.Draw(sb);
                    }
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
                (int)(window.Width * 0.60f), (int)(window.Height * 0.30f),  // Location
                (int)(window.Width * 0.02f), (int)(window.Height * 0.09f)), // Hitbox
                "<",                                                        // Text
                bellMT36));                                                 // Font

            settingButtons.Add(new TextButton(new Rectangle(
                (int)(window.Width * 0.68f), (int)(window.Height * 0.30f),  // Location
                (int)(window.Width * 0.02f), (int)(window.Height * 0.09f)), // Hitbox
                ">",                                                        // Text
                bellMT36));                                                 // Font

            settingButtons.Add(new TextButton(new Rectangle(
                (int)(window.Width * 0.60f), (int)(window.Height * 0.40f),  // Location
                (int)(window.Width * 0.02f), (int)(window.Height * 0.09f)), // Hitbox
                "<",                                                        // Text
                bellMT36));                                                 // Font

            settingButtons.Add(new TextButton(new Rectangle(
                (int)(window.Width * 0.68f), (int)(window.Height * 0.40f),  // Location
                (int)(window.Width * 0.02f), (int)(window.Height * 0.09f)), // Hitbox
                ">",                                                        // Text
                bellMT36));                                                 // Font

            settingButtons.Add(new TextButton(new Rectangle(
                (int)(window.Width * 0.60f), (int)(window.Height * 0.50f),  // Location
                (int)(window.Width * 0.10f), (int)(window.Height * 0.09f)), // Hitbox
                "True",                                                     // Text
                bellMT36));                                                 // Font
        }

        public void EndGame(int roomsCleared)
        {
            gameFSM = GameFSM.GameOver;
            this.roomsCleared = roomsCleared;
        }
    }
}
