using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Oak.Engine.Entities;

namespace Oak.Engine.Graphics
{
    class GraphicsManager
    {
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

        public GraphicsManager(GraphicsDeviceManager gdm)
        {
            Renderer = new XNARenderer(gdm);
            Camera = new Camera();
        }

        /// <summary>
        /// Offsets Renderables from world coordinates to view coordinates 
        /// </summary>
        private void OffsetRenderables()
        {
            //TODO implement this...
        }


        public void Update(GameTime time)
        {
            //TODO implement this...
        }
    }
}
