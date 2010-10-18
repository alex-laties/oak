using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Oak.Engine.Graphics
{
    interface ISpriteCollection
    {
        /// <summary>
        /// Adds a set of sprites for a named action.
        /// Assumes that sprites are of the format "name01", "name02", etc.
        /// </summary>
        /// <param name="name">The desired name for the set</param>
        /// <param name="path">The path to the sprite set from the ContentManager's root</param>
        public void AddSprites(string name, string path);

        /// <summary>
        /// Removes the set of specified sprites.
        /// </summary>
        /// <param name="name">The name of the sprite set to be removed</param>
        public void RemoveSprites(string name);

        /// <summary>
        /// Gets all sprites currently in this collection
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<Texture2D>> Sprites();

        public void Update(GameTime time);
    }
}
