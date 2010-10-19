using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Oak.Engine.Entities;
using Microsoft.Xna.Framework.Graphics;

namespace Oak.Engine.Graphics
{
    class GraphicsManager
    {
        GraphicsDeviceManager gdm;

        protected IRenderer Renderer
        {
            get;
            set;
        }

        protected Camera Camera
        {
            get;
            set;
        }

        public BaseWorld World
        {
            get
            {
                return Camera.World;
            }
            set
            {
                Camera.World = value;
            }
        }

        public int Width
        {
            get
            {
                return Camera.WorldView.Width;
            }
            set
            {
                Camera.UpdateWidth(value > 0 ? value : 1280);
                gdm.PreferredBackBufferWidth = (value > 0 ? value : 1280);
                gdm.ApplyChanges();
            }
        }

        public int Height
        {
            get
            {
                return Camera.WorldView.Height;
            }
            set
            {
                Camera.UpdateHeight(value > 0 ? value : 1280);
                gdm.PreferredBackBufferHeight = (value > 0 ? value : 1280);
                gdm.ApplyChanges();
            }
        }

        public GraphicsManager(GraphicsDeviceManager gdm)
        {
            Renderer = new XNARenderer(gdm);
            Camera = new Camera();
            this.gdm = gdm;
        }

        /// <summary>
        /// Offsets Renderables from world coordinates to view coordinates 
        /// </summary>
        private void OffsetRenderable(Renderable toOffset)
        {
            toOffset.frame.X -= Camera.WorldView.X;
            toOffset.frame.Y -= Camera.WorldView.Y;
        }

        public void Left()
        {
            Camera.MoveLeft(1);
        }

        public void Right()
        {
            Camera.MoveRight(1);
        }

        public void Update(GameTime time)
        {
            // update camera
            Camera.Update(time);

            // set up Renderer
            Renderer.RemoveRenderables();

            // offset renderables and add
            foreach (Renderable r in Camera.Renderables)
            {
                OffsetRenderable(r);
                Renderer.AddRenderable(r);
            }

            // create background renderable
            Renderable background = new Renderable();

            background.texture = World.WorldTexture;
            background.frame = World.WorldFrame;
            background.selection = null;
            background.rotation = 0;
            background.origin = new Vector2(Camera.WorldView.X, Camera.WorldView.Y);
            background.tint = Color.White;
            background.layerDepth = 1;
            background.effect = SpriteEffects.None;

            Renderer.AddRenderable(background);
        }

        public void Draw(GameTime time)
        {
            Renderer.Draw(time);
        }
    }
}
