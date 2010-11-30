using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using Oak.Engine.Graphics;
using Oak.Engine.Scripting;
using Oak.Engine.Entities;
using Oak.Engine.GameScreen;
using Oak.Engine.Input;
using Oak.Game.Characters;
using Oak.Engine.Audio;

namespace Oak
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Oak : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        KeyboardManager kbm; //top level keyboard manager. should maintain commands that come before anything else in the update loop

        public static ContentManager ContentAccess
        {
            get;
            private set;
        }


        public Oak()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //Initialize Top Level Keyboard Manager
            kbm = new KeyboardManager();

            //Initialize Console
            GameConsole.Initialize(this, "monofur", Color.White, Color.Gray, 0.8f, 10);
            Interpreter.Console = (IGameConsole)Services.GetService(typeof(IGameConsole));
            Interpreter.Initialize();

            //Add access to the ContentManager
            ContentAccess = Content;

            //Set up World
            BaseWorld world = new BaseWorld();
            world.WorldTexture = Content.Load<Texture2D>("./Engine/Test Graphics/Backgrounds/forest");
            world.WorldFrame = new Rectangle(0, 0, world.WorldTexture.Width, world.WorldTexture.Height);

            //Set up the Graphics Manager
            GraphicsManager.GDM = graphics;
            GraphicsManager.World = world;
            GraphicsManager.Width = 1280;
            GraphicsManager.Height = 720;

            //Create a Player
            Player p = new Player();
            GraphicsManager.World.AddCharacter("player", p);

            //set up Screen Manager
            ScreenManager.SetFont(Content.Load<SpriteFont>("monofur"));
            TestScreen t = new TestScreen();
            t.State = ScreenVisibleState.On;
            ScreenManager.AddScreen("test", t);

            //Set up the Keyboard Manager
            kbm.BindKey(Keys.OemTilde, delegate(GameTime time)
            {
                if (!Interpreter.Console.IsOpen)
                {
                    Interpreter.Console.Open(Keys.OemTilde);
                }
            });

            kbm.BindKey(Keys.Escape, delegate(GameTime time)
            {
                this.Exit();
            });

            //Debug Keys


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //top level keyboard manager (for functions that should always be available)
            kbm.Update(gameTime);

            //CORE GAME UPDATES
            //Any graphics updates must occur before the GraphicsManager updates
            Interpreter.Update(gameTime);
            ScreenManager.Update(gameTime);
            GraphicsManager.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            GraphicsManager.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
