﻿using System;
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


        // --- Properties --- //

        public GameFSM GameFSM { get { return gameFSM; } }



        // --- Constructor --- //

        public UI(ContentManager content)
        {
            gameFSM = GameFSM.Menu;
            bellMT24 = content.Load<SpriteFont>("Bell_MT-24");
            initalizeButtons();
            currentMState = new MouseState();
            previousMState = new MouseState();
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
                new Vector2(10, 10),    // Location
                new Point(160, 30),     // Hover Hitbox ("Used to sense when mouse is over the button")
                "Test Button",          // Text
                bellMT24));             // Font
        }
    }
}
