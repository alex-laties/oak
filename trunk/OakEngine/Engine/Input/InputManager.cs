using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oak.Engine.Input
{
    public static class InputManager
    {

        static InputManager()
        {
            Keyboard = new KeyInput();
            Mouse = new MouseInput();
        }

        public static KeyInput Keyboard
        {
            get;
            set;
        }

        public static MouseInput Mouse
        {
            get;
            set;
        }
    }
}
