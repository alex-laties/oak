using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oak.Engine.Graphics
{
    interface IRenderableSprite
    {
        /// <summary>
        /// Gets the current texture of the animation
        /// </summary>
        /// <returns></returns>
        public Texture2D CurrentTexture();
    }
}
