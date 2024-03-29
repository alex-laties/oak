﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Oak.Engine.Entities;
using Microsoft.Xna.Framework.Graphics;

namespace Oak.Engine.Graphics
{
    public static class GraphicsManager
    {
        static GraphicsDeviceManager gdm;
        public static GraphicsDeviceManager GDM
        {
            get
            {
                return gdm;
            }
            set
            {
                Renderer = new XNARenderer(value);
                gdm = value;
            }
        }

        static IRenderer Renderer
        {
            get;
            set;
        }

        static Camera Camera
        {
            get;
            set;
        }

        public static BaseWorld World
        {
            get;
            set;
        }

        public static bool RenderWorld
        {
            get;
            set;
        }

        public static int Width
        {
            get
            {
                return Camera.WorldView.Width;
            }
            set
            {
                Camera.UpdateWidth(value > 0 ? value : 1280);
                GDM.PreferredBackBufferWidth = (value > 0 ? value : 1280);
                GDM.ApplyChanges();
            }
        }

        public static int Height
        {
            get
            {
                return Camera.WorldView.Height;
            }
            set
            {
                Camera.UpdateHeight(value > 0 ? value : 1280);
                GDM.PreferredBackBufferHeight = (value > 0 ? value : 1280);
                GDM.ApplyChanges();
            }
        }

        public static bool FullScreen
        {
            get
            {
                return GDM.IsFullScreen;
            }
            set
            {
                GDM.IsFullScreen = value;
                GDM.ApplyChanges();
            }
        }

        public static Vector2 CameraPosition
        {
            get
            {
                return new Vector2(Camera.WorldView.X, Camera.WorldView.Y);
            }
        }

        static GraphicsManager()
        {
            Camera = new Camera();
        }

        public static void AddRenderable(Renderable toAdd)
        {
            Renderer.AddRenderable(toAdd);
        }

        /// <summary>
        /// Offsets Renderables from world coordinates to view coordinates 
        /// </summary>
        private static void OffsetRenderable(Renderable toOffset)
        {
            toOffset.frame.X -= Camera.WorldView.X;
            toOffset.frame.Y -= Camera.WorldView.Y;
        }

        #region debug functions
        public static void Left()
        {
            Camera.MoveLeft(1);
        }

        public static void Right()
        {
            Camera.MoveRight(1);
        }
        #endregion

        /// <summary>
        /// Adds all renderables in the current view.
        /// Auto adds the current background as well (although it does not move... I think).
        /// </summary>
        /// <param name="time"></param>
        public static void Update(GameTime time)
        {
            if (RenderWorld)
            {
                // update camera
                Camera.Update(time);

                // offset renderables and add
                foreach (Renderable r in Camera.Renderables)
                {
                    OffsetRenderable(r);
                    Renderer.AddRenderable(r);
                }

                //TODO redo this to support multiple backgrounds at different layers
                // create background renderable
                Renderable background = new Renderable();

                background.texture = World.WorldTexture;
                background.frame = World.WorldFrame;
                background.selection = null;
                background.rotation = 0;
                background.origin = new Vector2(Camera.WorldView.X, Camera.WorldView.Y);
                background.tint = Color.White;
                background.layerDepth = 0.1f;
                background.effect = SpriteEffects.None;

                Renderer.AddRenderable(background);
            }
        }

        public static void Draw(GameTime time)
        {
            Renderer.Draw(time);
            // clear queue for next pass
            Renderer.RemoveRenderables();
        }
    }
}
