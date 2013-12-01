using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oak.Engine.Entities;
using Oak.Engine.Graphics;

namespace Oak.Engine.GameScreen
{
    class GameScreen : BaseScreen
    {
        protected BaseWorld world;
        public BaseWorld World
        {
            get { return world; }
            set { world = value; }
        }

        public override void UpdateOn(Microsoft.Xna.Framework.GameTime gameTime)
        {
            GraphicsManager.RenderWorld = true;
            if (GraphicsManager.World != world)
            {
                GraphicsManager.World = world;
            }
        }

        public override void UpdateOff(Microsoft.Xna.Framework.GameTime gameTime)
        {
            GraphicsManager.RenderWorld = false;
        }
    }
}
