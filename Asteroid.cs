using System;
using Microsoft.Xna.Framework;

namespace Spaceship
{
    public class Asteroid
    {
        public Vector2 Position = new Vector2(600, 300);
        public int Speed;
        public int Radius = 59;

        public Asteroid(int newSpeed)
        {
            Random rand = new Random();
                
            Speed = newSpeed;
            Position = new Vector2(1380,rand.Next(0, 721));
        }
        public void asteroidUpdate(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Position.X -= Speed * dt;
        }
    }
}