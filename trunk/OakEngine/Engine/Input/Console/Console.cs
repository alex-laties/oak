using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Oak.Engine.Scripting
{
    class Console : IInterpretable
    {
        #region IInterpretable Members

        public void run(string function)
        {
            string[] command = function.Split(Interpreter.Mask);

            
            Oak.console.Open(Keys.OemTilde);
        }

        #endregion
    }
}
