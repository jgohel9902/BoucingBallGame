using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System.Runtime.CompilerServices;

namespace BouncingBallGame
{
    public class Ball
    {
        public Vector2 Position; //this represents the position of thr ball on the screen
        public Vector2 Speed; //speed vector shows the direction of the ball 
        private Texture2D texture; //image of the ball
        private Rectangle screenBounds;  //the screenbounds sets the boundaries for collission
        private SoundEffect hitSound;  // when the ball hits the wall, this sound is played
        private SoundEffect missSound; // when ball hits bottom

        public Ball(Texture2D texture, Rectangle screenBounds, SoundEffect hitSound, SoundEffect missSound)
        {
            this.texture = texture;
            this.screenBounds = screenBounds;
            this.hitSound = hitSound;
            this.missSound = missSound;
            Position = new Vector2(screenBounds.Width / 2, screenBounds.Height / 2);
            Speed = new Vector2(4, 4); //this vector shows the initial speed
            
        }

        public void Update(GameTime gameTime)
        {
            Position += Speed;

            // checking for collissions with left and right screen boundaries
            if (Position.X <= 0 || Position.X + texture.Width >= screenBounds.Width) 
            {
                Speed.X *= -1; // Reverse horizontal direction
                hitSound?.Play();
            }
            // this conditiion checks for collission with top boundary
            if (Position.Y <= 0)
            {
                Speed.Y *= -1; // Reverse vertical direction
                hitSound?.Play();
            }
            //this checks for collissions iwht the bottom boundary
            if (Position.Y + texture.Height >= screenBounds.Height)
            {
                Speed.Y *= -1; // Reverse vertical direction
                missSound?.Play();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,Position, Color.White);
        }
        public Rectangle GetBounds()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
        }

    }
}
