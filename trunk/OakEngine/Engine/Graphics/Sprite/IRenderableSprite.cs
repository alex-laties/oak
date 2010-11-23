using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Oak.Engine.Graphics
{
    interface IRenderableSprite
    {
        /// <summary>
        /// Gets the current texture of the animation
        /// </summary>
        /// <returns></returns>
        Texture2D CurrentTexture();

        void Update(GameTime time);
    }
}
