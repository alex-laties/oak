using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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

        public static void Update(GameTime time)
        {
            //TODO make more robust
            keyboard.Update();

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
