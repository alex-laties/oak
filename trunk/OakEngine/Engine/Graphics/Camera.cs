﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Oak.Engine.Entities;

namespace Oak.Engine.Graphics
{
    class Camera
    {
        /// <summary>
        /// Gets the View into the world. This is scaled to fit the Viewport.
        /// </summary>
        public Rectangle WorldView
        {
            get;
            protected set;
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

        public void Update(GameTime time)
        {
            Renderables.Clear();
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