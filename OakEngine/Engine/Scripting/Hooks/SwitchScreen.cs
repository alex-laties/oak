using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oak.Engine.GameScreen;

namespace Oak.Engine.Scripting
{
    class SwitchScreen : IInterpretable
    {
        #region IInterpretable Members

        public void run(string function)
        {
            string[] command = function.Split(Interpreter.Mask);

            switch (command[1])
            {
                case "to":
                    ScreenManager.FocusScreen(command[2]);
                    break;
                case "on":  
                    ScreenManager.ToggleScreen(command[2], ScreenVisibleState.On);
                    break;
                case "off":
                    ScreenManager.ToggleScreen(command[2], ScreenVisibleState.Off);
                    break;
                case "transparent":
                    ScreenManager.ToggleScreen(command[2], ScreenVisibleState.Transparent);
                    break;
                default:
                    throw new ArgumentException(command[1] + " is not a valid command");
            }
            
        }

        #endregion
    }
}
