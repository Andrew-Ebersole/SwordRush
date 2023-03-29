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
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

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
        private int health;
        private int maxHealth;
        private float atk;
        private float atkSpd;
        private float range;
        private float distance;
        private int levelUpExp;
        private int roomsCleared;
        private double attackFrame;

        private Vector2 origin;
        // Player weapon
        private GameObject sword;

        // Mouse Controls
        private MouseState currentMouseState;
        private MouseState preMouseState;

        //Texture
        private Texture2D dungeontilesTexture2D;

        private AnimationComposer animation_;

        // --- Properties --- //
        public PlayerStateMachine PlayerState => playerState;

        public Point Size => size;

        public float Atk => atk;
        public int Health => health;

        public int MaxHealth
        {
            get
            {
                return maxHealth;
            }
        }

        public int Level => level;
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
            set
            {
                roomsCleared = value;
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

            List<Texture2D> frames = new List<Texture2D>();

            frames.Add(GameManager.Get.ContentManager.Load<Texture2D>("knight_f_idle_anim_f0"));
            frames.Add(GameManager.Get.ContentManager.Load<Texture2D>("knight_f_idle_anim_f1"));
            frames.Add(GameManager.Get.ContentManager.Load<Texture2D>("knight_f_idle_anim_f2"));
            frames.Add(GameManager.Get.ContentManager.Load<Texture2D>("knight_f_idle_anim_f3"));

            animation_ = new AnimationComposer();
            animation_.PlaySequence(new AnimationSequence(frames, 0.25, true));
        }



        // --- Methods --- //

        /// <summary>
        /// move the player toward the mouse cursor when left clicked
        /// </summary>
        public void playerControl(GameTime gameTime)
        {
            attackFrame += gameTime.ElapsedGameTime.TotalMilliseconds;
            currentMouseState = Mouse.GetState();
            if (attackFrame >= 600/atkSpd)
            {
                if (currentMouseState.LeftButton == ButtonState.Pressed && playerState == PlayerStateMachine.Idle)
                {
                    //move the player's location
                    Position -= GetDirection() * 25 * distance;

                    System.Diagnostics.Debug.WriteLine(position.X + "," + position.Y +":"+ atkSpd);

                    attackFrame = 0;
                }
            }
            
            if (attackFrame < 100)
            {
                playerState = PlayerStateMachine.Attack;
            }
            else
            {
                playerState = PlayerStateMachine.Idle;
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

        public void Damaged(int dmg)
        {
            health -= dmg;
        }

        public void LevelUp()
        {
            exp -= levelUpExp;
            level += 1;
            levelUpExp += level * 10;

            /*
             * the code below is just a place holder for level up
             */
            maxHealth += level;
            health = maxHealth;
            if (atkSpd < 9)
            {
                atkSpd += 0.5f;
            }
            atk += 0.5f;
            //end here
        }

        public void GainExp(int enemyLevel)
        {
            exp += enemyLevel * 10;

            if (exp >= levelUpExp)
            {
                LevelUp();
            }
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
            sb.Draw(animation_.GetCurrentSequence().GetCurrentFrame(), Rectangle, Color.White);
            //sb.Draw(dungeontilesTexture2D, Rectangle, new Rectangle(128, 64, 16, 32), Color.White);
            sb.Draw(dungeontilesTexture2D, sword.Position, new Rectangle(320, 80, 16, 32), Color.White, SwordRotateAngle(), new Vector2(8, -8), 2.0f, SpriteEffects.FlipVertically, 0.0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gt"></param>
        public void Update(GameTime gt)
        {
            playerControl(gt);
            SwordLocation();
            SwordRotateAngle();
            animation_.Update(gt);
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
