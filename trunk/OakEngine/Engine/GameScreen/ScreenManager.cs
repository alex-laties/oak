using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Oak.Engine.GameScreen
{

    public static class ScreenManager
    {
        static List<BaseScreen> screens = new List<BaseScreen>();
        public static SpriteFont font;

        public static void AddScreen(BaseScreen screen)
        {
            screens.Add(screen);
        }

        public static void RemoveScreen(BaseScreen screen)
        {
            screens.Remove(screen);
        }

        public static void Update(GameTime gameTime)
        {
            foreach (BaseScreen screen in screens)
            {
                screen.Update(gameTime);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (BaseScreen screen in screens)
            {
                if (screen.State == ScreenStates.On)
                {
                    screen.Draw(spriteBatch);
                }
            }
        }

        public static void SetFont(SpriteFont newFont)
        {
            font = newFont;
        }
    }
}
