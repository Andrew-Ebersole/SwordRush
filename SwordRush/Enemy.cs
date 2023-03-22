﻿using Microsoft.Xna.Framework;
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

        //Texture
        private Texture2D dungeontilesTexture2D;

        public Texture2D DungeonTilesTexture2D
        {
            get
            {
                return dungeontilesTexture2D;
            }
        }


        // --- Constructor --- //
        public Enemy (Texture2D texture, Rectangle rectangle, Player player) : base (texture, rectangle)
        {
            this.player = player;
            dungeontilesTexture2D = texture;
        }

        // --- Constructor --- //
        /*
        public Enemy (Texture2D texture, Vector2 position, Point size) : base (texture, position, size)
        {

        }
        */
        public void Damage()
        {

        }

        public virtual void Update(GameTime gt) { 
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(dungeontilesTexture2D, Rectangle, new Rectangle(368, 80, 16, 16), Color.White);
        }
    }
}
