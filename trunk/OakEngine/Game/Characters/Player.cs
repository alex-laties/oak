using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oak.Engine.Entities;
using Oak.Engine.Graphics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Oak.Engine.Input;
using Microsoft.Xna.Framework.Input;
using Oak.Engine.Scripting;

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
            Sprite = new AnimatedSprite();
            AnimatedSprite temp = (AnimatedSprite)Sprite;
            temp.AddSprites(PlayerState.Standing, "Stand/maincharstand", PATH_TO_SPRITES);
            temp.AddSprites(PlayerState.Walking, "Walk/maincharwalk", PATH_TO_SPRITES);
            temp.AddSprites(PlayerState.Running, "Run/Maincharun", PATH_TO_SPRITES);
            temp.AddSprites(PlayerState.Jumping, "Jump/Maincharjumpup", PATH_TO_SPRITES);
            temp.AddSprites(PlayerState.DoubleJumping, "Double Jump/maincharjumpflip", PATH_TO_SPRITES);
            temp.AddSprites(PlayerState.Lunging, "Lunge/maincharsidejump", PATH_TO_SPRITES);
            temp.CurrentState = (PlayerState.Standing);
            temp.FrameDelay = 3;
            #endregion

            #region Frame Setup
            frame = new Microsoft.Xna.Framework.Rectangle(50, 500, 240, 200);
            #endregion

            #region Physics Setup
            //Body = BodyFactory.CreateBody(null, new Vector2(Frame.X, Frame.Y));
            #endregion

            #region Key Setup
            //walk
            KeyboardManager.BindKey(Keys.D, new KeyboardManager.KeyBindDelegate(Walk));
            //stand
            KeyboardManager.BindKey(Keys.S, new KeyboardManager.KeyBindDelegate(Stand));
            //jump
            KeyboardManager.BindKey(Keys.Space, new KeyboardManager.KeyBindDelegate(Jump));
            //run
            KeyboardManager.BindKey(Keys.F, new KeyboardManager.KeyBindDelegate(Run));
            #endregion
        }

        public override Renderable GetRenderable()
        {
            Renderable tr = base.GetRenderable();
            tr.effect = Microsoft.Xna.Framework.Graphics.SpriteEffects.FlipHorizontally;
            return tr;
        }

        private void Walk(GameTime time)
        {
            ((AnimatedSprite)Sprite).CurrentState = PlayerState.Walking;
            ((AnimatedSprite)Sprite).StopAtEndOfAnimation = false;
            frame.X += 50;
            Interpreter.Console.Log("Moving Right");
        }

        private void Stand(GameTime time)
        {
            ((AnimatedSprite)Sprite).CurrentState = PlayerState.Standing;
            ((AnimatedSprite)Sprite).StopAtEndOfAnimation = false;
            Interpreter.Console.Log("Standing");
        }

        private void Jump(GameTime time)
        {
            ((AnimatedSprite)Sprite).CurrentState = PlayerState.Jumping;
            ((AnimatedSprite)Sprite).StopAtEndOfAnimation = true;
            Interpreter.Console.Log("Jumping");
        }

        private void Run(GameTime time)
        {
            ((AnimatedSprite)Sprite).CurrentState = PlayerState.Running;
            ((AnimatedSprite)Sprite).StopAtEndOfAnimation = false;
            Interpreter.Console.Log("Running");
        }
    }
}
