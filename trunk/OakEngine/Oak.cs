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

namespace Oak
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Oak : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        GraphicsManager gm;

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
            // TODO: Add your initialization logic here
            GameConsole.Initialize(this, "monofur", Color.White, Color.Gray, 0.8f, 10);
            Interpreter.Console = (IGameConsole)Services.GetService(typeof(IGameConsole));
            Interpreter.Initialize();

            Interpreter.Console.Open(Keys.OemTilde);

            //Add access to the ContentManager
            ContentAccess = Content;

            //Set up World
            BaseWorld world = new BaseWorld();
            world.WorldTexture = Content.Load<Texture2D>("./Engine/Test Graphics/Backgrounds/forest");
            world.WorldFrame = new Rectangle(0, 0, world.WorldTexture.Width, world.WorldTexture.Height);

            //Set up the Graphics Manager
            gm = new GraphicsManager(graphics);
            gm.World = world;
            gm.Width = 1280;
            gm.Height = 720;


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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                gm.texelWidth += 1;
                Interpreter.Console.Log(gm.texelWidth + ", " + gm.texelHeight);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                gm.texelWidth -= 1;
                Interpreter.Console.Log(gm.texelWidth + ", " + gm.texelHeight);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                gm.texelHeight += 1;
                Interpreter.Console.Log(gm.texelWidth + ", " + gm.texelHeight);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                gm.texelHeight -= 1;
                Interpreter.Console.Log(gm.texelWidth + ", " + gm.texelHeight);
            }

            // TODO: Add your update logic here
            gm.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            //XNARenderer.Draw(gameTime);
            gm.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
