using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oak.Engine.Scripting
{
    class Show : IInterpretable
    {
        #region IInterpretable Members

        public void run(string function)
        {
            string[] command = function.Split(Interpreter.Mask);
            switch (command[1])
            {
                case "fps":
                    //Game1.fps.IsVisible = !Game1.fps.IsVisible; TODO rework this
                    break;
            }
        }

        #endregion
    }
}
