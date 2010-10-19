using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oak.Engine.Graphics;
using Microsoft.Xna.Framework;

namespace Oak.Engine.Entities
{
    public interface ICharacter
    {

        Renderable GetRenderable();

        /// <summary>
        /// Gets the coordinates with reference to the world
        /// </summary>
        /// <returns></returns>
        Vector2 GetGlobalCoordinates();

        void Update(GameTime time);
    }
}
