using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

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
        private float distance;
        private float range;
        private GameObject sword;
        private MouseState mouse;

        public void playerConteol()
        {

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
