using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Oak.Engine.GameScreen;

namespace Oak.Engine.Graphics
{

    public class XNARenderer: IRenderer
    {

        public SpriteBatch SpriteBatch
        {
            get;
            set;
        }

        List<Renderable> toRender;

        public XNARenderer(GraphicsDeviceManager gdm)
        {
            toRender = new List<Renderable>();
            SpriteBatch = new SpriteBatch(gdm.GraphicsDevice);
        }

        /// <summary>
        /// Adds a renderable object in the form of the Renderable struct
        /// </summary>
        /// <param name="toAdd"></param>
        /// <returns>The added struct</returns>
        public Renderable AddRenderable(Renderable toAdd)
        {
            toRender.Add(toAdd);
            return toAdd;
        }

        /// <summary>
        /// Removes all renderable objects from the render list
        /// </summary>
        /// <returns>A copy of the list before the clearing was executed</returns>
        public List<Renderable> RemoveRenderables()
        {
            List<Renderable> newList = new List<Renderable>(toRender);
            toRender.Clear();
            return newList;
        }

        public void Draw(GameTime time)
        {
            SpriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.FrontToBack, SaveStateMode.SaveState);
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
            ScreenManager.Draw(SpriteBatch);
            SpriteBatch.End();
        }
    }
}
