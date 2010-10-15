using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oak.Engine.Scripting
{
    class Switch : IInterpretable
    {
        #region IInterpretable Members

        public void run(string function)
        {
            /* TODO rework this completely
            string[] command = function.Split(Interpreter.Mask);

            switch (command[1])
            {
                case "to":
                    Game1.screenManager.SwitchTo(command[2]);
                    break;
                case "on":  
                    Game1.screenManager.SwitchOn(command[2]);
                    break;
                case "off":
                    Game1.screenManager.SwitchOff(command[2]);
                    break;
            }
             */
        }

        #endregion
    }
}
