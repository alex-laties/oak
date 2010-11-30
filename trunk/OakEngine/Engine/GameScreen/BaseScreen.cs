using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Oak.Engine.Input;

namespace Oak.Engine.GameScreen
{
    public enum ScreenVisibleState
    {
        On,
        Off,
        Transparent
    }



    public class BaseScreen
    {
        protected KeyboardManager kbm;

        public ScreenVisibleState State
        {
            get;
            set;
        }

        public BaseScreen()
        {
            kbm = new KeyboardManager();
        }

        public void Update(GameTime gameTime)
        {
            kbm.Update(gameTime);

            switch (State)
            {
                case ScreenVisibleState.On:
                    UpdateOn(gameTime);
                    break;
                case ScreenVisibleState.Off:
                    UpdateOff(gameTime);
                    break;
                case ScreenVisibleState.Transparent:
                    UpdateTrans(gameTime);
                    break;
                default:
                    break;
            }
        }

        public virtual void UpdateOn(GameTime gameTime)
        {
        }

        public virtual void UpdateOff(GameTime gameTime)
        {
        }

        public virtual void UpdateTrans(GameTime gameTime)
        {
        }
    }
}
