using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameShaderGL
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D textureA;
        private Texture2D textureB;
        private Texture2D texture;

        private RenderTarget2D renderTargetA;
        private RenderTarget2D renderTargetB;

        private Effect effect1;

        private Rectangle rectDraw;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 400;
            graphics.PreferredBackBufferHeight = 400;
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = Content.Load<Texture2D>("Texture");
            //textureA = Content.Load<Texture2D>("TextureA");
            //textureB = Content.Load<Texture2D>("TextureB");

            //GraphicsDevice.Textures[1] = textureA;
            //GraphicsDevice.Textures[2] = textureB;

            renderTargetA = new RenderTarget2D(GraphicsDevice, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, false,
                GraphicsDevice.PresentationParameters.BackBufferFormat, GraphicsDevice.PresentationParameters.DepthStencilFormat);
            renderTargetB = new RenderTarget2D(GraphicsDevice, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, false,
                GraphicsDevice.PresentationParameters.BackBufferFormat, GraphicsDevice.PresentationParameters.DepthStencilFormat);

            effect1 = Content.Load<Effect>("Effect1");

            rectDraw = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
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
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);

            //GraphicsDevice.SetRenderTarget(renderTargetA);
            //effect1.CurrentTechnique.Passes[0].Apply();
            //spriteBatch.Draw(texture, rectDraw, Color.White);


            GraphicsDevice.SetRenderTarget(renderTargetB);
            effect1.CurrentTechnique.Passes[1].Apply();
            spriteBatch.Draw(texture, rectDraw, Color.White);


            spriteBatch.End();
            GraphicsDevice.SetRenderTarget(null);

            // render everything to screen
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, SamplerState.PointClamp, null, null, null);


            //spriteBatch.Draw(renderTargetA, rectDraw, Color.White);
            spriteBatch.Draw(renderTargetB, rectDraw, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
