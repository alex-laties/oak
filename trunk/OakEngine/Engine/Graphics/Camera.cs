using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Oak.Engine.Entities;

namespace Oak.Engine.Graphics
{
    class Camera
    {
        Rectangle worldView;
        /// <summary>
        /// Gets the View into the world. This is scaled to fit the Viewport.
        /// </summary>
        public Rectangle WorldView
        {
            get 
            { 
                return worldView; 
            }
            protected set
            {
                worldView = value;
            }
        }

        public BaseWorld World
        {
            get;
            set;
        }

        /// <summary>
        /// All renderable objects currently in view
        /// </summary>
        public List<Renderable> Renderables
        {
            get;
            protected set;
        }

        public Camera()
        {
            Renderables = new List<Renderable>();
        }

        public void MoveLeft(int pixels)
        {
            worldView.X -= pixels;
        }

        public void MoveRight(int pixels)
        {
            worldView.X += pixels;
        }

        public void UpdateWidth(int width)
        {
            worldView.Width = width;
        }

        public void UpdateHeight(int height)
        {
            worldView.Height = height;
        }

        public void Update(GameTime time)
        {
            Renderables.Clear();
            World.Update(time);
            //check for all objects currently in view
            foreach (ICharacter c in World.Characters.Values)
            {
                if (c.GetRenderable().frame.Intersects(WorldView))
                {
                    Renderables.Add(c.GetRenderable());
                }
            }
        }
    }
}
