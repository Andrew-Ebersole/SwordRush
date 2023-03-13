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
        protected Player player;
        protected int level;
        protected int atk;
        protected int health;

        // --- Constructor --- //

        public Enemy (Texture2D texture, Rectangle rectangle, Player player) : base (texture, rectangle)
        {
            this.player = player;
        }

        // --- Constructor --- //

        public Enemy (Texture2D texture, Vector2 position, Point size) : base (texture, position, size)
        {

        }

        public void Damage()
        {

        }

        public virtual void Update(GameTime gt) { 
        }
    }
}
