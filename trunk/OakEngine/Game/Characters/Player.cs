using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oak.Engine.Entities;
using Oak.Engine.Graphics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;

namespace Oak.Game.Characters
{
    public enum PlayerState
    {
        Standing,
        Walking,
        Running,
        Jumping,
        DoubleJumping,
        Lunging
    }

    class Player : BaseCharacter
    {
        static string PATH_TO_SPRITES = "./Game/Sprites/Player/";

        public Player() : base()
        {
            #region Sprite Setup
            Sprite = new StillSprite(PATH_TO_SPRITES + "Stand/maincharstand01");
            #endregion

            #region Frame Setup
            Frame = new Microsoft.Xna.Framework.Rectangle(50, 500, 240, 200);
            #endregion

            #region Physics Setup
            //Body = BodyFactory.CreateBody(null, new Vector2(Frame.X, Frame.Y));
            #endregion
        }

        public override void Update(Microsoft.Xna.Framework.GameTime time)
        {
            Sprite.Update(time);
            base.Update(time);
        }

        public override Renderable GetRenderable()
        {
            Renderable tr = base.GetRenderable();
            tr.effect = Microsoft.Xna.Framework.Graphics.SpriteEffects.FlipHorizontally;
            return tr;
        }
    }
}
