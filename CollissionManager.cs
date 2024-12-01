using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;

namespace BouncingBallGame
{
    public class CollissionManager
    {
        private Ball ball;
        private Bat bat;
        private SoundEffect hitSound;

        public CollissionManager(Ball ball, Bat bat, SoundEffect hitSound)
        {
            this.ball = ball;
            this.bat = bat; 
            this.hitSound = hitSound;
        }
        
        // checks for the collission of the ball with the boundaries
        public void CheckCollission()
        {
            if (ball.GetBounds().Intersects(bat.GetBounds()))
            {
                ball.Speed.Y *= -1;
                hitSound.Play();
            }
        }
    }
}
