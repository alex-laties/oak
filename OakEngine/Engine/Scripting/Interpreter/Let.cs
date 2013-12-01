using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oak.Engine.Scripting
{
    class Let : IInterpretable
    {
        #region IInterpretable Members

        public void run(string function)
        {
            string[] command = function.Split(Interpreter.Mask);
            Interpreter.Env[command[1]] = command[2];
        }

        #endregion
    }
}
