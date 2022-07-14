using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Spaceship
{
    public class Controller
    {
        public List<Asteroid> Asteroids = new List<Asteroid>();
        public double Timer = 2;
        public double MaxTime = 2;
        public int NextSpeed = 240;
        public bool InGame = false;
        public double TotalTime = 0;

        public void conUpdate(GameTime gameTime)
        {
            if (InGame)
            {
                Timer -= gameTime.ElapsedGameTime.TotalSeconds;
                TotalTime += gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                KeyboardState keyState = Keyboard.GetState();

                if (keyState.IsKeyDown(Keys.Enter)) 
                {
                    InGame = true;
                    TotalTime = 0;
                    MaxTime = 2;
                    Timer = 2;
                    NextSpeed = 240;
                }
            }

            if (Timer <= 0)
            {
                Asteroids.Add(new Asteroid(NextSpeed));
                Timer = MaxTime;

                if (MaxTime > 0.5)
                {
                    MaxTime -= 0.1;
                }

                if (NextSpeed < 720)
                {
                    NextSpeed += 4;
                }
            }
        }
    }
}