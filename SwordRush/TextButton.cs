using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SwordRush
{
    internal class TextButton : GameObject
    {
        // --- Fields --- //

        private string text;
        private Color color;
        private SpriteFont font;
        private MouseState currentMState;
        private MouseState previousMState;

        // --- Constructor --- //

        public TextButton(Rectangle rectangle, string text, SpriteFont font) 
            : base(null, rectangle)
        {
            this.text = text;
            color = Color.Black;
            this.font = font;
            currentMState = new MouseState();
            previousMState = new MouseState();
        }

        public override void Update(GameTime gt)
        {
            currentMState = Mouse.GetState();

            // Highlight text when mouse hovers
            if (new Rectangle(currentMState.Position,new Point(0,0)).Intersects(rectangle))
            {
                color = Color.DarkGoldenrod;
            } else
            {
                color = Color.Black;
            }


            previousMState = Mouse.GetState();
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.DrawString(
                font,
                text,
                position,
                color);
        }

        public bool IsClicked()
        {
            if (color == Color.DarkGoldenrod
                && currentMState.LeftButton == ButtonState.Pressed
                && currentMState.RightButton == ButtonState.Released)
            {
                return true;
            }
            return false;
        }
    }
}
