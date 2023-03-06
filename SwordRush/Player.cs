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
        private PlayerStateMachine playerState;
        private int exp;
        private int level;
        private int atk;
        private int health;
        private float atkSpd;
        private float range;
        private GameObject sword;
        private MouseState currentMouseState;
        private MouseState preMouseState;

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public Point Size
        {
            get
            {
                return size;
            }
        }

        public Player()
        {
            exp = 0;
            level = 1;
            atk = 1;
            health = 10;
            atkSpd = 1;
            range = 1;
            currentMouseState = Mouse.GetState();
            preMouseState = Mouse.GetState();
            
        }

        //move left and top not working
        public void playerControl()
        {
            currentMouseState = Mouse.GetState();
            if (currentMouseState.LeftButton == ButtonState.Pressed && 
                preMouseState.LeftButton == ButtonState.Released)
            {
                //calculate the direction
                Vector2 difference = Vector2.Normalize(Vector2.Subtract(rectangle.Location.ToVector2(), currentMouseState.Position.ToVector2()));
                difference = new Vector2(-difference.X, -difference.Y);
                Debug.WriteLine(difference);

                //move the player's location 
                position += difference *10;
            }

            preMouseState = currentMouseState;
        }

        public void animation()
        {

        }

        public Vector2 GetDirection()
        {
            return new Vector2();
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
    }
}
