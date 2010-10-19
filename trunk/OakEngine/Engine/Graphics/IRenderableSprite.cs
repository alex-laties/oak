using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Oak.Engine.Graphics
{
    interface IRenderableSprite
    {
        /// <summary>
        /// Gets the current texture of the animation
        /// </summary>
        /// <returns></returns>
        Texture2D CurrentTexture();
    }
}
