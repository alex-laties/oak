using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Oak.Engine.Graphics
{
    class BaseSprite : ISpriteCollection, IRenderableSprite
    {
        protected Dictionary<string, List<Texture2D>> InternalSprites
        {
            get;
            set;
        }

        protected Texture2D currentTexture
        {
            get;
            set;
        }

        public BaseSprite()
        {
            InternalSprites = new Dictionary<string, List<Texture2D>>();
            currentTexture = null;
        }

        #region ISpriteCollection Members

        public virtual void AddSprites(string name, string path)
        {
            //gather all sprites
            List<Texture2D> textures = new List<Texture2D>();
            string basePath = path + name;
            int count = 1;
            while (true)
            {
                try
                {
                    textures.Add(Oak.ContentAccess.Load<Texture2D>(basePath + (count < 10 ? "0" + count : "" + count)));
                    count++;
                }
                catch
                {
                    break;
                }
            }

            //add sprite collection
            InternalSprites[name] = textures;
        }

        public virtual void RemoveSprites(string name)
        {
            InternalSprites.Remove(name);
        }

        public virtual Dictionary<string, List<Texture2D>> Sprites()
        {
            return InternalSprites;
        }

        public virtual void Update(Microsoft.Xna.Framework.GameTime time)
        {
            //TODO implement this... somehow...
        }

        #endregion

        #region IRenderableSprite Members

        public virtual Texture2D CurrentTexture()
        {
            return currentTexture;
        }

        #endregion
    }
}
