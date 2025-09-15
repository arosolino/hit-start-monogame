using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;


namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            //_graphics.GraphicsProfile = GraphicsProfile.HiDef;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        Texture2D _whiteTexture;
        RenderTarget2D _renderTarget1;
        RenderTarget2D _renderTarget2;
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _renderTarget1 = new RenderTarget2D(GraphicsDevice, 512, 512, false, SurfaceFormat.Color, DepthFormat.None);
            _renderTarget2 = new RenderTarget2D(GraphicsDevice, 512, 512, false, SurfaceFormat.Color, DepthFormat.None);

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

        bool setOnce;
        protected override void Draw(GameTime gameTime)
        {

            if (setOnce == false)
            {
                GraphicsDevice.SetRenderTargets(_renderTarget1);
                GraphicsDevice.Clear(Color.Red);

                _spriteBatch.Begin();
                _spriteBatch.Draw(_whiteTexture, new Rectangle(0, 0, 32, 32), Color.Blue);
                _spriteBatch.End();
                setOnce = true;

                using (var fileStream = new FileStream("test.png", FileMode.Create))
                    _renderTarget1.SaveAsPng(fileStream, _renderTarget1.Width, _renderTarget1.Height);

                GraphicsDevice.SetRenderTarget(null);
                GraphicsDevice.Clear(Color.Black);
            }

            else
            {
                GraphicsDevice.SetRenderTarget(null);
                GraphicsDevice.Clear(Color.Black);

                _spriteBatch.Begin();
                _spriteBatch.Draw(_renderTarget1, _renderTarget1.Bounds, Color.White);
                //_spriteBatch.Draw(_whiteTexture, _whiteTexture.Bounds, Color.White);
                _spriteBatch.End();

            }

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
