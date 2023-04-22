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
using System.Dynamic;
using Microsoft.Xna.Framework.Audio;
using Color = Microsoft.Xna.Framework.Color;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace SwordRush
{
    enum PlayerStateMachine
    {
        Idle,
        Attack,
        Damaged,
        AttackCoolDown
    }

    enum LevelUpAbility
    {
        Heal,
        MaxHealth,
        AttackSpeed,
        AttackDamage,
        Range,
        BackUp
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
        private Vector2 direction;
        public Point graphPoint;

        //player Power ups
        private bool backUpPower;
        private int backUpLevel; // max should be 3
        private double backUpFrame;


        // Player weapon
        private GameObject sword;

        // Mouse Controls
        private MouseState currentMouseState;
        private MouseState preMouseState;

        //Keyboard Controls
        private KeyboardState currentKeyboardState;

        private KeyboardState preKeyboardState;

        //Texture
        private Texture2D dungeontilesTexture2D;
        private Texture2D singleColor;

        private PlayerEffectScreen _pes = new PlayerEffectScreen(new Point(1280, 764));

        private Animation<Texture2D> animation_ = new(0.2f);
        // --- Properties --- //

        public bool BackUpPower { get; set; }

        public PlayerStateMachine PlayerState => playerState;

        public Point Size => size;

        public float Atk => atk;
        public int Health => health;

        public int MaxHealth
        {
            get { return maxHealth; }
        }

        public int Level => level;

        public int Exp
        {
            get { return exp; }
        }

        public int LevelUpExp
        {
            get { return levelUpExp; }
        }

        public int RoomsCleared
        {
            get { return roomsCleared; }
            set { roomsCleared = value; }
        }

        public GameObject Sword
        {
            get { return sword; }
        }

        public float AtkSpd
        {
            get { return atkSpd; }
        }

        public float Range
        {
            get { return range; }
        }

        // --- Constructor --- //

        public Player(Texture2D texture, Rectangle rectangle, GraphicsDevice graphics) : base(texture, rectangle)
        {
            exp = 90;
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
            currentKeyboardState = Keyboard.GetState();
            preKeyboardState = currentKeyboardState;
            direction = new Vector2();

            // Create a texture for blank rectangle
            singleColor = new Texture2D(graphics, 1, 1);
            singleColor.SetData(new[] { Color.White });

            sword = new GameObject(null, Rectangle);
            dungeontilesTexture2D = texture;

            animation_.AddFrame(GameManager.Get.ContentManager.Load<Texture2D>("knight_f_idle_anim_f0"));
            animation_.AddFrame(GameManager.Get.ContentManager.Load<Texture2D>("knight_f_idle_anim_f1"));
            animation_.AddFrame(GameManager.Get.ContentManager.Load<Texture2D>("knight_f_idle_anim_f2"));
            animation_.AddFrame(GameManager.Get.ContentManager.Load<Texture2D>("knight_f_idle_anim_f3"));
        }


        // --- Methods --- //

        /// <summary>
        /// move the player toward the mouse cursor when left clicked
        /// </summary>
        public void playerControl(GameTime gameTime)
        {
            // Move when attacking
            if (attackFrame < 100 * range)
            {
                playerState = PlayerStateMachine.Attack;

                //move the player's location
                Position -= direction * distance*(1+range/20);
            }
            // Cooldown after attack based off attack speed
            else if (attackFrame >= 100 * range && attackFrame <= 100 * range + 800 - 75 * atkSpd)
            {
                playerState = PlayerStateMachine.AttackCoolDown;
            }
            // Wait until next attack in idle
            else
            {
                playerState = PlayerStateMachine.Idle;
            }

            // Update mouse state and attack time
            attackFrame += gameTime.ElapsedGameTime.TotalMilliseconds;
            currentMouseState = Mouse.GetState();
            currentKeyboardState = Keyboard.GetState();

            // If player clicks and attack
            if (currentMouseState.LeftButton == ButtonState.Pressed
                && preMouseState.LeftButton == ButtonState.Released
                && playerState == PlayerStateMachine.Idle)
            {
                SoundManager.Get.PlayerAttackEffect.Play();
                direction = GetDirection();
                attackFrame = 0;
            }

            if (playerState != PlayerStateMachine.Attack && currentMouseState.RightButton == ButtonState.Pressed &&
                preMouseState.RightButton == ButtonState.Released && backUpFrame > 1000)
            {
                backUpFrame = 0;
            }

            // Auto level up
            if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                exp = LevelUpExp;
            }

            // Previous state
            preMouseState = currentMouseState;
            preKeyboardState = currentKeyboardState;
        }

        public void LevelUp(LevelUpAbility ability)
        {
            SoundManager.Get.PlayerLevelUpEffect.Play();
            exp -= levelUpExp;
            level += 1;
            levelUpExp += (level * level * 20);

            switch (ability)
            {
                case LevelUpAbility.Heal:
                    health += maxHealth / 2;
                    if (health > maxHealth)
                    {
                        health = maxHealth;
                    }

                    break;

                case LevelUpAbility.MaxHealth:
                    int healthDiff = maxHealth - health;
                    maxHealth = (int)(maxHealth * 1.5f);
                    health = maxHealth - healthDiff;
                    break;

                case LevelUpAbility.AttackSpeed:
                    atkSpd += 2;
                    break;

                case LevelUpAbility.AttackDamage:
                    atk *= 1.5f;
                    break;

                case LevelUpAbility.Range:
                    range += 1f;
                    break;

                case LevelUpAbility.BackUp:
                    backUpLevel += 1;
                    break;
            }
        }

        public void BackUp(GameTime gameTime)
        {
            Vector2 movement = GetDirection() * (10 + backUpLevel * 4);
            if (backUpFrame < 100)
            {
                playerState = PlayerStateMachine.Attack;

                //move the player's location
                Position += movement;
            }

            backUpFrame += gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        /// <summary>
        /// Calculate the direction vector between the player and the cursor
        /// </summary>
        /// <returns>the direction vector</returns>
        public Vector2 GetDirection()
        {
            Vector2 returnVector = Vector2.Normalize(position - currentMouseState.Position.ToVector2());

            // Check if the vector has real numbers in it
            if (Math.Abs(returnVector.X) >= 0)
            {
                return returnVector;
            }

            // If not return defualt vector
            return new Vector2(-1, 0);
        }

        public void Damaged(int dmg)
        {
            _pes.Start();
            health -= dmg;
            SoundManager.Get.PlayerDamagedEffect.Play();
        }


        public void GainExp(int enemyLevel)
        {
            exp += enemyLevel * 10 * ((int)(enemyLevel / 2) + 1);
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
            sb.Draw(animation_.Frame, Rectangle, Color.White);
            //sb.Draw(dungeontilesTexture2D, Rectangle, new Rectangle(128, 64, 16, 32), Color.White);

            Color swordTint;
            // Make sword transparent during cooldown
            if (playerState == PlayerStateMachine.AttackCoolDown)
            {
                swordTint = Color.White * 0.2f;
            }
            else
            {
                swordTint = Color.White;
            }

            sb.Draw(dungeontilesTexture2D, sword.Position, new Rectangle(320, 80, 16, 32), swordTint,
                SwordRotateAngle(), new Vector2(8, -8), 2.0f, SpriteEffects.FlipVertically, 0.0f);

            // Draw Hitboxes
            if (UI.Get.ShowHitboxes == true)
            {
                sb.Draw(singleColor,
                    new Rectangle(rectangle.X, rectangle.Y + rectangle.Height / 2,
                        rectangle.Width, rectangle.Height / 2),
                    Color.White * 0.2f);
            }

            _pes.Draw(sb);
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
            if (animation_.Done)
            {
                animation_.Reset();
            }

            BackUp(gt);
            if (UI.Get.TakeDamage == false)
            {
                maxHealth = 9999;
                health = 9999;
                atkSpd = 10;
            }

            _pes.Update(gt);
        }

        /// <summary>
        /// init player's stats
        /// </summary>
        public void NewRound()
        {
            roomsCleared = 0;
            exp = 90;
            levelUpExp = 100;
            level = 1;
            atk = 1;
            maxHealth = 10;
            health = maxHealth;
            atkSpd = 5f;
            distance = 10f;
            range = 3f;
            roomsCleared = 0;
        }

        public void NewRoom()
        {
            attackFrame = 100 * range + 800 - 50 * atkSpd;
        }

        /// <summary>
        /// Kills the player
        /// </summary>
        public void Die()
        {
            health = 0;
        }
    }
}