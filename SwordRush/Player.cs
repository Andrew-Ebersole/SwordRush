using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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

        //Texture
        private Texture2D dungeontilesTexture2D;

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

        public GameObject Sword
        {
            get
            {
                return sword;
            }
        }

        // --- Constructor --- //

        public Player(Texture2D texture, Rectangle rectangle) : base(texture, rectangle)
        {
            exp = 0;
            levelUpExp = 100;
            level = 1;
            atk = 1;
            maxHealth = 10;
            health = maxHealth;
            atkSpd = 1;
            distance = 1;
            range = 1;
            currentMouseState = Mouse.GetState();
            preMouseState = Mouse.GetState();

            sword = new GameObject(null, Rectangle);
            dungeontilesTexture2D = texture;
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

        /// <summary>
        /// get the location of the sword
        /// </summary>
        /// <returns>return the vector2 of the sword's location</returns>
        public Vector2 SwordLocation()
        {
            sword.Position = new Vector2(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height / 1.5f);
            return sword.Position;
        }

        /// <summary>
        /// calculate the angle for the sword, depend on the mouse cursor location
        /// </summary>
        /// <returns>the value of the angle</returns>
        public float SwordRotateAngle()
        {
            float angle = (float)Math.Atan2(currentMouseState.Y - Position.Y, currentMouseState.X - Position.X);
            float rotationAngle = angle - (float)(Math.PI / 2);
            
            return rotationAngle;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(dungeontilesTexture2D, Rectangle, new Rectangle(128, 64, 16, 32), Color.White);
            sb.Draw(dungeontilesTexture2D, sword.Position, new Rectangle(320, 80, 16, 32), Color.White, SwordRotateAngle(), new Vector2(8, -8), 2.0f, SpriteEffects.FlipVertically, 0.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gt"></param>
        public void Update(GameTime gt)
        {
            playerControl();
            SwordLocation();
        }

        /// <summary>
        /// init player's stats
        /// </summary>
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
