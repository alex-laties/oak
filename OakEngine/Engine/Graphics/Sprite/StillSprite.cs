using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Oak.Engine.Graphics
{
    class StillSprite : IRenderableSprite
    {
        Texture2D sprite;

        public StillSprite(string sprite)
        {
            this.sprite = Oak.ContentAccess.Load<Texture2D>(sprite);
        }

        #region IRenderableSprite Members

        public Microsoft.Xna.Framework.Graphics.Texture2D CurrentTexture()
        {
            return sprite;
        }

        public void Update(GameTime time)
        { }

        #endregion
    }
}
