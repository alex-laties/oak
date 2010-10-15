using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Oak.Engine.Graphics
{
    public struct Renderable
    {
        public Texture2D texture;
        public Rectangle frame;
        public Rectangle selection;
        public Color tint;
        public float rotation;
        public Vector2 origin;
        public SpriteEffects effect;
        public int layerDepth;
    }

    interface IRenderer
    {
        public Renderable AddRenderable(Renderable toAdd);
        public List<Renderable> RemoveRenderables();
        public void Draw(GameTime time);
    }
}
