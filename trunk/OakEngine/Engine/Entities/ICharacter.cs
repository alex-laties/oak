using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oak.Engine.Graphics;
using Microsoft.Xna.Framework;

namespace Oak.Engine.Entities
{
    public enum CharacterType
    {
        Player,
        Object,
        Enemy
    }

    public interface ICharacter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns a renderable struct for the GraphicsManager to render</returns>
        Renderable GetRenderable();

        /// <summary>
        /// Gets the coordinates with reference to the world
        /// </summary>
        /// <returns></returns>
        Vector2 GetGlobalCoordinates();

        void Update(GameTime time);
    }
}
