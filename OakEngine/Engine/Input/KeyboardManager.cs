using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Oak.Engine.Scripting;

namespace Oak.Engine.Input
{
    public class KeyboardManager
    {
        public delegate void KeyBindDelegate(GameTime time);
        Dictionary<Keys, KeyBindDelegate> keyBinds = new Dictionary<Keys, KeyBindDelegate>();
        KeyInput keyboard = new KeyInput();

        public void BindKey(Keys key, KeyBindDelegate toBind)
        {
            keyBinds[key] = toBind;
        }

        public void UnbindKey(Keys key)
        {
            if (keyBinds.ContainsKey(key))
            {
                keyBinds.Remove(key);
            }
        }

        public void RebindKey(Keys from, Keys to)
        {
            if (keyBinds.ContainsKey(from))
            {
                keyBinds[to] = keyBinds[from];
                keyBinds.Remove(from);
            }
        }

        public void RebindKey(string from, string to)
        {
            from = from.ToLower();
            to = to.ToLower();

            //TODO actually implement this
        }

        public void Update(GameTime time)
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
