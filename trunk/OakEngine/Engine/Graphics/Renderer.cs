﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Oak.Engine.Graphics
{

    static class XNARenderer: IRenderer
    {

        public static SpriteBatch SpriteBatch
        {
            get;
            set;
        }

        static List<Renderable> toRender;

        XNARenderer()
        {
            toRender = new List<Renderable>();
        }

        /// <summary>
        /// Adds a renderable object in the form of the Renderable struct
        /// </summary>
        /// <param name="toAdd"></param>
        /// <returns>The added struct</returns>
        public static Renderable AddRenderable(Renderable toAdd)
        {
            toRender.Add(toAdd);
            return toAdd;
        }

        /// <summary>
        /// Removes all renderable objects from the render list
        /// </summary>
        /// <returns>A copy of the list before the clearing was executed</returns>
        public static List<Renderable> RemoveRenderables()
        {
            List<Renderable> newList = new List<Renderable>(toRender);
            toRender.Clear();
            return newList;
        }

        public static void Draw(GameTime time)
        {
            SpriteBatch.Begin();
            foreach (Renderable tr in toRender)
            {
                SpriteBatch.Draw(
                    tr.texture,
                    tr.frame,
                    tr.selection,
                    tr.tint,
                    tr.rotation,
                    tr.origin,
                    tr.effect,
                    tr.layerDepth
                );
            }
            SpriteBatch.End();
        }
    }
}
