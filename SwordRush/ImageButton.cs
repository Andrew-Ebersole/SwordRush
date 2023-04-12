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
    internal class ImageButton : TextButton
    {
        // --- Fields --- //

        private Texture2D image;
        private Vector2 tile;


        // --- Properties --- //

        /// <summary>
        /// Returns if the button was left clicked or not
        /// </summary>
        public bool LeftClicked { get { return leftClicked; } }

        /// <summary>
        /// The text the button will display
        /// </summary>
        public string Text { get { return text; } set { text = value; } }

        /// <summary>
        /// Rectangle of the image
        /// </summary>
        public Rectangle Rectangle { get { return rectangle; } set { rectangle = value; } }

        // --- Constructor --- //

        public ImageButton(Rectangle rectangle, string text, SpriteFont font, Texture2D image, Vector2 tile) 
            : base(rectangle,text,font)
        {
            this.image = image;
            this.tile = tile;
        }


        // --- Methods --- //

        public override void Update(GameTime gt)
        {
            currentMState = Mouse.GetState();

            // Highlight text when mouse hovers
            if (new Rectangle(currentMState.Position, new Point(0, 0)).Intersects(rectangle))
            {
                color = Color.DarkGoldenrod;
            }
            else
            {
                color = Color.LightGray;
            }

            // When the button is clicked sets leftClicked to true
            if (color == Color.DarkGoldenrod
                && currentMState.LeftButton == ButtonState.Pressed
                && previousMState.LeftButton == ButtonState.Released)
            {
                leftClicked = true;
            }
            else
            {
                leftClicked = false;
            }

            previousMState = Mouse.GetState();
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(image,
                rectangle,
                new Rectangle((int)(tile.X*(image.Width/16)),(int)(tile.Y*(image.Height/16)),
                (int)(image.Width/16),(int)(image.Height/16)),
                Color.White,
                0f,
                new Vector2(0,0),
                SpriteEffects.None,
                0);

            sb.DrawString(
                font,
                text,
                new Vector2(rectangle.X+rectangle.Width*(0.5f-(text.Count()*0.03f)), rectangle.Y+rectangle.Height),
                color);
        }
    }
}
