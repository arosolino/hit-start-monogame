using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.GraphicsProfile = GraphicsProfile.HiDef;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        Texture2D _whiteTexture;
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _whiteTexture = new Texture2D(GraphicsDevice, 1, 1);
            _whiteTexture.SetData(new[] { Color.White });

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Loop a shader
            var effect = Content.Load<Effect>("Effect");
            /*
            effect.Parameters["Layer1Colors"].SetValue(new Matrix(
                64, 0, 0, 0,
                0, 64, 0, 0,
                0, 0, 64, 0,
                0, 0, 0, 0
            ));
            effect.Parameters["Layer1Colors"].SetValue(new Matrix(
                64, 0, 0, 0,
                0, 64, 0, 0,
                0, 0, 64, 0,
                0, 0, 0, 0
            ));
            */
            System.Diagnostics.Debug.WriteLine(effect.Parameters.Count);

            var basicEffect = new BasicEffect(GraphicsDevice);


            _spriteBatch.Begin(effect: effect);
            _spriteBatch.Draw(_whiteTexture, new Rectangle(0, 0, 512, 512), Color.White);
            _spriteBatch.End();

            _spriteBatch.Begin();
            _spriteBatch.Draw(_whiteTexture, new Rectangle(0, 0, 256, 256), Color.Red);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
