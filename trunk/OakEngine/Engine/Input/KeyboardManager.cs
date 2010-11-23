using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Oak.Engine.Scripting;

namespace Oak.Engine.Input
{
    public static class KeyboardManager
    {
        public delegate void KeyBindDelegate(GameTime time);
        static Dictionary<Keys, KeyBindDelegate> keyBinds = new Dictionary<Keys, KeyBindDelegate>();
        static KeyInput keyboard = new KeyInput();

        public static void BindKey(Keys key, KeyBindDelegate toBind)
        {
            keyBinds[key] = toBind;
        }

        public static void UnbindKey(Keys key)
        {
            if (keyBinds.ContainsKey(key))
            {
                keyBinds.Remove(key);
            }
        }

        public static void RebindKey(Keys from, Keys to)
        {
            if (keyBinds.ContainsKey(from))
            {
                keyBinds[to] = keyBinds[from];
                keyBinds.Remove(from);
            }
        }

        public static void RebindKey(string from, string to)
        {
            from = from.ToLower();
            to = to.ToLower();

            //TODO actually implement this
        }

        public static void Update(GameTime time)
        {
            //TODO make more robust
            keyboard.Update();

            //check to see if console is open. if so, ignore commands
            if (Interpreter.Console.IsOpen)
                return;

            foreach (Keys key in keyBinds.Keys)
            {
                if (keyboard.NewKeyPress(key))
                {
                    keyBinds[key](time);
                }
            }
        }
    }
}
