using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace SwordRush
{
    enum PlayerStateMachine{
        Idle,
        Attack,
        Damaged
    }

    internal class Player : GameObject
    {
        // --- Fields --- //

        // Player State
        private PlayerStateMachine playerState;
        
        // Plater stats
        private int exp;
        private int level;
        private int atk;
        private int health;
        private int maxHealth;
        private float atkSpd;
        private float range;
        private float distance;
        private int levelUpExp;
        private int roomsCleared;

        // Player weapon
        private GameObject sword;

        // Mouse Controls
        private MouseState currentMouseState;
        private MouseState preMouseState;
        


        // --- Properties --- //

        public Point Size
        {
            get
            {
                return size;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }
        }

        public int MaxHealth
        {
            get
            {
                return maxHealth;
            }
        }

        public int Exp
        {
            get
            {
                return exp;
            }
        }

        public int LevelUpExp
        {
            get
            {
                return levelUpExp;
            }
        }

        public int RoomsCleared
        {
            get
            {
                return roomsCleared;
            }
        }
         

        // --- Constructor --- //

        public Player(Texture2D texture, Rectangle rectangle) : base(texture, rectangle)
        {
            NewRound();
            currentMouseState = Mouse.GetState();
            preMouseState = Mouse.GetState();
        }



        // --- Methods --- //

        /// <summary>
        /// move the player toward the mouse cursor when left clicked
        /// </summary>
        public void playerControl()
        {
            currentMouseState = Mouse.GetState();
            if (currentMouseState.LeftButton == ButtonState.Pressed && 
                preMouseState.LeftButton == ButtonState.Released)
            {
                //move the player's location
                Position -= GetDirection() * 25 * distance;
                
            }

            preMouseState = currentMouseState;
        }

        public void animation()
        {

        }

        /// <summary>
        /// Calculate the direction vector between the player and the cursor
        /// </summary>
        /// <returns>the direction vector</returns>
        public Vector2 GetDirection()
        {
            return Vector2.Normalize(position - currentMouseState.Position.ToVector2()); ;
        }

        public void Damage()
        {

        }

        public void LevelUp()
        {

        }

        public void Draw(SpriteBatch sb)
        {
            

        }

        public void Update(GameTime gt)
        {

        }

        public void NewRound()
        {
            roomsCleared = 0;
            exp = 0;
            levelUpExp = 100;
            level = 1;
            atk = 1;
            maxHealth = 10;
            health = maxHealth;
            atkSpd = 1;
            distance = 1;
            range = 1;
            roomsCleared = 0;
        }
    }
}
