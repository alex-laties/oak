using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Oak.Engine.Graphics
{
    public struct Renderable
    {
        public Texture2D texture;
        public Rectangle frame;
        public Rectangle? selection;
        public Color tint;
        public float rotation;
        public Vector2 origin;
        public SpriteEffects effect;
        public float layerDepth;
    }

    interface IRenderer
    {
        Renderable AddRenderable(Renderable toAdd);
        List<Renderable> RemoveRenderables();
        void Draw(GameTime time);
    }
}
