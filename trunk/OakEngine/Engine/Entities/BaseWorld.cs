using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Oak.Engine.Entities
{
    class BaseWorld
    {
        /// <summary>
        /// Gets all characters currently in this world
        /// </summary>
        public Dictionary<string, ICharacter> Characters
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the overall coordinate-space of the world. The world has no negative coordinates
        /// </summary>
        public Rectangle WorldFrame
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the background texture of the world
        /// </summary>
        public Texture2D WorldTexture
        {
            get;
            protected set;
        }

        public BaseWorld()
        {
            Characters = new Dictionary<string, ICharacter>();
        }

        /// <summary>
        /// Adds a character to the world under a name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="character"></param>
        public virtual void AddCharacter(string name, ICharacter character)
        {
            Characters[name] = character;
        }

        /// <summary>
        /// Removes a character from the world
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual bool RemoveCharacter(string name)
        {
            try
            {
                return Characters.Remove(name);
            }
            catch
            {
                return false;
            }
        }

        public virtual void Update(GameTime time)
        {
            foreach (ICharacter c in Characters.Values)
            {
                c.Update(time);
            }
        }
    }
}
