using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SwordRush
{
    internal class GameManager
    {
        private Texture2D spriteSheet;

        public GameManager(Texture2D spriteSheet)
        {
            this.spriteSheet = spriteSheet;
        }

        public void GenerateRoom(SpriteBatch sb)
        {
            sb.Draw(spriteSheet, new Vector2(0,0), new Rectangle(128, 64, 16, 32), Color.White);
        }
    }
}
