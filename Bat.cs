using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BouncingBallGame
{
    public class Bat
    {
        public Vector2 Position; // shows the position of the bat
        private Texture2D texture; // shows the texture of the bat 
        private int speed;
        private Rectangle screenBounds;

        public Bat(Texture2D texture, Rectangle screenBounds)
        {
            this.texture = texture;
            this.screenBounds = screenBounds;
            Position = new Vector2(screenBounds.Width / 2 - texture.Width / 2, screenBounds.Height / 2 - texture.Height - 10);
            speed = 10;
        }

        // keeps updating the bat position when the user clicks left or right 
        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Left))
            {
                Position.X -= speed;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                Position.X += speed;
            }

            Position.X = MathHelper.Clamp(Position.X, 0,  screenBounds.Width - texture.Width);
        }

        //draws the bat
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }

        // gets the boundaries for the game 
        public Rectangle GetBounds()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
        }
    }
}
