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

    public class MouseInput
    {
        Vector2 currentPos, lastPos;
        MouseState lastState, currentState;

        public MouseInput()
        {
            currentPos = new Vector2();
            lastState = new MouseState();
            currentState = Mouse.GetState();
            Update();
        }

        public void Update()
        {
            lastState = currentState;
            currentState = Mouse.GetState();

            lastPos = currentPos;
            currentPos = new Vector2(currentState.X, currentState.Y);
        }

        #region Properties
        public Vector2 MousePosition
        {
            get { return currentPos; }
            set
            {
                currentPos = value;
                Mouse.SetPosition((int)value.X, (int)value.Y);
            }
        }

        public Vector2 UnitsChanged
        {
            get { return currentPos - lastPos; }
        }
        #endregion

        #region Boolean Methods
        public bool ButtonHeld(Buttons button)
        {
            switch (button)
            {
                case Buttons.LeftMouse:
                    return (lastState.LeftButton == ButtonState.Pressed 
                        && currentState.LeftButton == ButtonState.Pressed);
                case Buttons.RightMouse:
                    return (lastState.RightButton == ButtonState.Pressed
                        && currentState.RightButton == ButtonState.Pressed);
                default:
                    //not a registered button
                    return false;
            }
        }

        public bool ButtonReleased(Buttons button)
        {
            switch (button)
            {
                case Buttons.LeftMouse:
                    return (lastState.LeftButton == ButtonState.Pressed
                        && currentState.LeftButton == ButtonState.Released);
                case Buttons.RightMouse:
                    return (lastState.RightButton == ButtonState.Pressed
                        && currentState.RightButton == ButtonState.Released);
                default:
                    //not a registered button
                    return false;
            }
        }

        public bool NewButtonPress(Buttons button)
        {
            switch (button)
            {
                case Buttons.LeftMouse:
                    return (lastState.LeftButton == ButtonState.Released
                        && currentState.LeftButton == ButtonState.Pressed);
                case Buttons.RightMouse:
                    return (lastState.RightButton == ButtonState.Released
                        && currentState.RightButton == ButtonState.Pressed);
                default:
                    //not a registered button
                    return false;
            }
        }

        public bool IsButtonDown(Buttons button)
        {
            switch (button)
            {
                case Buttons.LeftMouse:
                    return (currentState.LeftButton == ButtonState.Pressed);
                case Buttons.RightMouse:
                    return (currentState.RightButton == ButtonState.Pressed);
                default:
                    //not a registered button
                    return false;
            }
        }

        public bool IsButtonUp(Buttons button)
        {
            switch (button)
            {
                case Buttons.LeftMouse:
                    return (currentState.LeftButton == ButtonState.Released);
                case Buttons.RightMouse:
                    return (currentState.RightButton == ButtonState.Released);
                default:
                    //not a registered button
                    return false;
            }
        }
        #endregion 
    }
}
