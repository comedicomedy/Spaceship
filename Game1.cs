using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spaceship
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D shipSprite;
        private Texture2D backgroundSprite;
        private Texture2D asteroidSprite;
        private SpriteFont spaceFont;
        private SpriteFont timerFont;

        private Ship player = new Ship();
        private Controller gameController = new Controller();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            shipSprite = Content.Load<Texture2D>("ship");
            asteroidSprite = Content.Load<Texture2D>("asteroid");
            backgroundSprite = Content.Load<Texture2D>("space");

            spaceFont = Content.Load<SpriteFont>("spaceFont");
            timerFont = Content.Load<SpriteFont>("timerFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (gameController.InGame)
            {
                player.shipUpdate(gameTime);   
            }

            gameController.conUpdate(gameTime);

            for (int i = 0; i < gameController.Asteroids.Count; i++)
            {
                gameController.Asteroids[i].asteroidUpdate(gameTime);

                int sum = gameController.Asteroids[i].Radius + player.Radius;

                if (Vector2.Distance(gameController.Asteroids[i].Position, player.Position) < sum)
                {
                    gameController.InGame = false;
                    player.Position = Ship.defaultPosition;

                    gameController.Asteroids.Clear();
                }
            }
            
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundSprite, Vector2.Zero, Color.White);
            _spriteBatch.Draw(shipSprite, new Vector2(player.Position.X - 34, player.Position.Y - 50), Color.White);
            
            for (int i = 0; i < gameController.Asteroids.Count; i++)
            {
                _spriteBatch.Draw(asteroidSprite, new Vector2(gameController.Asteroids[i].Position.X - gameController.Asteroids[i].Radius, gameController.Asteroids[i].Position.Y - gameController.Asteroids[i].Radius), Color.White);
            }

            if (gameController.InGame == false)
            {
                string menuMessage= "Press ENTER to start";
                Vector2 sizeOfText = spaceFont.MeasureString(menuMessage);
                int halfWidth = _graphics.PreferredBackBufferWidth / 2;
                
                
                _spriteBatch.DrawString(spaceFont, menuMessage, new Vector2(halfWidth - sizeOfText.X /2, 200), Color.White);
            }
            _spriteBatch.DrawString(timerFont, "Time: " + Math.Floor(gameController.TotalTime), Vector2.Zero, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}