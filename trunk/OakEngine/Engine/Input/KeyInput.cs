using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Oak.Engine.Input
{
    class KeyInput
    {
        KeyboardState lastState, currentState;

        Keys[] keysPressed;

        public KeyInput()
        {
            lastState = new KeyboardState();
            currentState = Keyboard.GetState();
        }

        public Keys[] KeysPressed
        {
            get { return keysPressed; }
        }

        public void Update()
        {
            lastState = currentState;
            currentState = Keyboard.GetState();

            keysPressed = currentState.GetPressedKeys();
        }

        public bool KeyHeld(Keys key)
        {
            return (lastState.IsKeyDown(key) && currentState.IsKeyDown(key));
        }

        public bool KeyReleased(Keys key)
        {
            return (lastState.IsKeyDown(key) && currentState.IsKeyUp(key));
        }

        public bool NewKeyPress(Keys key)
        {
            return (lastState.IsKeyUp(key) && currentState.IsKeyDown(key));
        }

    }
}
