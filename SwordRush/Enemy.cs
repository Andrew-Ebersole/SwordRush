using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace SwordRush
{
    public enum EnemyStateMachine
    {
        Idle,
        Move,
        Attack,
        Damaged
    }

    internal class Enemy : GameObject
    {
        private EnemyStateMachine enemyState;
        private int level;
        private int atk;
        private int health;

        // --- Constructor --- //

        public Enemy (Texture2D texture, Rectangle rectangle) : base (texture, rectangle)
        {

        }

        public void Damage()
        {

        }

        public void Updata(GameTime gt) { 
        }
    }
}
