using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oak.Engine.Graphics;
using Microsoft.Xna.Framework;

namespace Oak.Engine.Entities
{
    interface ICharacter
    {

        public Renderable GetRenderable();

        /// <summary>
        /// Gets the coordinates with reference to the world
        /// </summary>
        /// <returns></returns>
        public Vector2 GetGlobalCoordinates();

        public void Update(GameTime time);
    }
}
