using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Oak.Engine.Scripting;

namespace Oak.Engine.GameScreen
{

    public static class ScreenManager
    {
        static Dictionary<string, BaseScreen> screens = new Dictionary<string, BaseScreen>();
        public static SpriteFont font;

        public static void AddScreen(string name, BaseScreen screen)
        {
            screens[name] = screen;
            //screen.State = ScreenVisibleState.Off;
        }

        public static void RemoveScreen(string name)
        {
            screens.Remove(name);
        }

        public static void ToggleScreen(string name)
        {
            screens[name].State = screens[name].State == ScreenVisibleState.On ? ScreenVisibleState.Off : ScreenVisibleState.On;
        }

        public static void ToggleScreen(string name, ScreenVisibleState state)
        {
            screens[name].State = state;
        }

        //TODO fix this method
        public static void FocusScreen(string name)
        {
            foreach (BaseScreen screen in screens.Values)
            {
                screen.State = ScreenVisibleState.Off;
            }

            screens[name].State = ScreenVisibleState.On;
            Interpreter.Console.Log("Sorry, this function is currently a little bugged out.");
        }

        public static void Update(GameTime gameTime)
        {
            foreach (BaseScreen screen in screens.Values)
            {
                screen.Update(gameTime);
            }
        }

        public static void SetFont(SpriteFont newFont)
        {
            font = newFont;
        }
    }
}
