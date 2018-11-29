#region Using Statements

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using RPGEngine.Scenes;

#endregion

namespace RPGEngine
{
    /// <summary>
    ///     This is the main type for your game.
    /// </summary>
    public class RPGGame : Game
    {
        public static RPGGame Game;

        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public RPGGame()
        {
            Game = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;

#if WINDOWS
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 540;
            graphics.ApplyChanges();

            Window.AllowAltF4 = false;
            Window.AllowUserResizing = false;
            Window.Title = "RPGEngine";
            graphics.IsFullScreen = false;
#else
            graphics.IsFullScreen = true;
#endif
        }

        public static T GetContent<T>(string name)
        {
            return Game.Content.Load<T>(name);
        }

        public static Rectangle GetClientBounds()
        {
            return Game.Window.ClientBounds;
        }

        protected override void OnActivated(object sender, EventArgs args)
        {
            base.OnActivated(sender, args);
        }

        protected override void OnDeactivated(object sender, EventArgs args)
        {
            base.OnDeactivated(sender, args);
        }

        /// <summary>
        ///     Allows the game to perform any initialization it needs to before starting to run.
        ///     This is where it can query for any required services and load any non-graphic
        ///     related content.  Calling base.Initialize will enumerate through any components
        ///     and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            Input.Initialize();

            // TODO: Add your initialization logic here
        }

        protected override bool BeginDraw()
        {
            return base.BeginDraw();
        }

        /// <summary>
        ///     LoadContent will be called once per game and is the place to load
        ///     all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //TODO: use this.Content to load your game content here 
        }

        /// <summary>
        ///     Allows the game to run logic such as updating the world,
        ///     checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (!IsActive)
                return;

            if (SceneManager.Scene == null)
                SceneManager.SwitchTo<MainMenu>();

            // For Mobile devices, this logic will close the Game when the Back button is pressed
            // Exit() is obsolete on iOS
#if !__IOS__ && !__TVOS__
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
#endif
            SceneManager.Update(gameTime.ElapsedGameTime.TotalSeconds);
            base.Update(gameTime);
        }

        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SceneManager.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}