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

        // Menu Coordinates
        

        // Buttons



        // --- Properties --- //

        public GameFSM GameFSM { get { return gameFSM; } }



        // --- Constructor --- //

        public UI(ContentManager content)
        {
            gameFSM = GameFSM.Menu;
            bellMT24 = content.Load<SpriteFont>("Bell_MT-24");
        }



        // --- Methods --- //

        public void LoadContent()
        {

        }

        public void Update(GameTime gt)
        {
            // Temporary input to change text
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                gameFSM = GameFSM.Game;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            // Testing Menu Text
            switch (gameFSM)
            {
                case GameFSM.Menu:
                    // Testing font
                    sb.DrawString(
                        bellMT24,               // Font
                        "Menu",                 // Text
                        new Vector2(10, 10),    // Location
                        Color.White);           // Color
                    break;

                case GameFSM.Game:
                    // Testing font
                    sb.DrawString(
                        bellMT24,               // Font
                        "Game",                // Text
                        new Vector2(10, 10),    // Location
                        Color.White);           // Color
                    break;
            }

            
        }

    }
}
