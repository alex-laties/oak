﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Oak.Engine.Graphics;
using FarseerPhysics.Dynamics;

namespace Oak.Engine.Entities
{
    class BaseCharacter : ICharacter
    {

        /// <summary>
        /// Gets the character's display frame with reference to the world
        /// </summary>
        protected Rectangle frame;
        public Rectangle Frame
        {
            get { return frame; }
        }

        protected IRenderableSprite Sprite
        {
            get;
            set;
        }

        protected ISpriteCollection SpriteCollection
        {
            get;
            set;
        }

        //TODO add physics representation?
        protected Body Body
        {
            get;
            set;
        }

        #region ICharacter Members

        public virtual global::Oak.Engine.Graphics.Renderable GetRenderable()
        {
            Renderable toReturn = new Renderable();

            toReturn.frame = Frame;
            toReturn.effect = SpriteEffects.None;
            toReturn.layerDepth = 0.9f;
            toReturn.origin = new Vector2(0, 0);
            toReturn.rotation = 0;
            toReturn.selection = null;
            toReturn.texture = Sprite.CurrentTexture();
            toReturn.tint = Color.White;

            return toReturn;
        }

        public virtual Microsoft.Xna.Framework.Vector2 GetGlobalCoordinates()
        {
            return new Vector2(Frame.X, Frame.Y);
        }

        public virtual void Update(GameTime time)
        {
            Sprite.Update(time);
            //TODO add physics update
        }

        #endregion

        
    }
}
