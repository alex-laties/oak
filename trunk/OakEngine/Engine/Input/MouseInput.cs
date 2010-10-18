using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Oak.Engine.Input
{


    class MouseInput
    {
        MouseState lastState, currentState;

        public MouseInput()
        {
            lastState = new MouseState();
            currentState = Mouse.GetState();
        }

        public void Update()
        {
            lastState = currentState;
            currentState = Mouse.GetState();
            
        }
    }
}
