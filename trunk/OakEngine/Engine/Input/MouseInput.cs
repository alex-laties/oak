using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Oak.Engine.Input
{
    public enum Buttons
    {
        LeftMouse,
        RightMouse
    }

    class MouseInput
    {
        Vector2 mousePos;
        MouseState lastState, currentState;

        public Vector2 MousePosition
        {
            get { return mousePos; }
            set
            {
                mousePos = value;
                Mouse.SetPosition((int)value.X, (int)value.Y);
            }
        }

        public MouseInput()
        {
            mousePos = new Vector2();
            lastState = new MouseState();
            currentState = Mouse.GetState();
            Update();
        }

        public void Update()
        {
            lastState = currentState;
            currentState = Mouse.GetState();

            mousePos = new Vector2(currentState.X, currentState.Y);
        }

        public bool ButtonHeld(Buttons button)
        {
            switch (button)
            {
                case Buttons.LeftMouse:
                    return (lastState.LeftButton == ButtonState.Pressed 
                        && currentState.LeftButton == ButtonState.Pressed);
                    break;
                case Buttons.RightMouse:
                    return (lastState.RightButton == ButtonState.Pressed
                        && currentState.RightButton == ButtonState.Pressed);
                    break;
                default:
                    //not a registered button
                    break;
            }
        }

        public bool ButtonReleased(Buttons button)
        {
            switch (button)
            {
                case Buttons.LeftMouse:
                    return (lastState.LeftButton == ButtonState.Pressed
                        && currentState.LeftButton == ButtonState.Released);
                    break;
                case Buttons.RightMouse:
                    return (lastState.RightButton == ButtonState.Pressed
                        && currentState.RightButton == ButtonState.Released);
                    break;
                default:
                    //not a registered button
                    break;
            }
        }

        public bool NewButtonPress(Buttons button)
        {
            switch (button)
            {
                case Buttons.LeftMouse:
                    return (lastState.LeftButton == ButtonState.Released
                        && currentState.LeftButton == ButtonState.Pressed);
                    break;
                case Buttons.RightMouse:
                    return (lastState.RightButton == ButtonState.Released
                        && currentState.RightButton == ButtonState.Pressed);
                    break;
                default:
                    //not a registered button
                    break;
            }
        }

        public bool IsButtonDown(Buttons button)
        {
            switch (button)
            {
                case Buttons.LeftMouse:
                    return (currentState.LeftButton == ButtonState.Pressed);
                    break;
                case Buttons.RightMouse:
                    return (currentState.RightButton == ButtonState.Pressed);
                    break;
                default:
                    //not a registered button
                    break;
            }
        }

        public bool IsButtonUp(Buttons button)
        {
            switch (button)
            {
                case Buttons.LeftMouse:
                    return (currentState.LeftButton == ButtonState.Released);
                    break;
                case Buttons.RightMouse:
                    return (currentState.RightButton == ButtonState.Released);
                    break;
                default:
                    //not a registered button
                    break;
            }
        }
    }
}
