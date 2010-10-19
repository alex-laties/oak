using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oak.Engine.Input
{
    public static class InputManager
    {
        static KeyInput keyboard;
        static MouseInput mouse;

        static InputManager()
        {
            keyboard = new KeyInput();
            mouse = new MouseInput();
        }

        public static KeyInput Keyboard
        {
            get { return keyboard; }
        }

        public static MouseInput Mouse
        {
            get { return mouse; }
        }
    }
}
