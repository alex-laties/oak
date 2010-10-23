using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Oak.Engine.GameScreen
{
    class TestScreen : BaseScreen
    {
        public TestScreen()
            : base()
        {
            State = ScreenStates.On;
            TextItem textItem = new TextItem("Test Text", ScreenManager.font);
            textItem.Position = new Microsoft.Xna.Framework.Vector2(50, 50);
            AddMenuItem(textItem);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {

            foreach (IMenuItem item in menuItems)
            {
                if (item.IsSelected(Input.InputManager.Mouse.MousePosition))
                {
                    if (Input.InputManager.Mouse.ButtonHeld(global::Oak.Engine.Input.Buttons.LeftMouse))
                    {
                        item.Deselect();
                    }
                    else
                    {
                        item.Select();
                    }
                }
                else
                {
                    item.Deselect();
                }
            }

            base.Update(gameTime);
        }

    }
}
