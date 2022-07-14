using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Spaceship
{
    public class Ship
    {
        static public Vector2 defaultPosition = new Vector2(200, 360);
        public Vector2 Position = defaultPosition;
        public int Radius = 30;

        public void shipUpdate(GameTime gameTime)
        {
            int speed = 300;
            KeyboardState keyState = Keyboard.GetState();
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if (keyState.IsKeyDown(Keys.W) && Position.Y > 0) 
            {
                Position.Y -= speed * dt;
            }
            if (keyState.IsKeyDown(Keys.S) && Position.Y < 720) 
            {
                Position.Y += speed * dt;   
            }
            if (keyState.IsKeyDown(Keys.D) && Position.X < 1280) 
            {
                Position.X += speed *  dt;
            }
            if (keyState.IsKeyDown(Keys.A) && Position.X > 0) 
            {
                Position.X -= speed * dt;
            }   
            
        }
    }
}