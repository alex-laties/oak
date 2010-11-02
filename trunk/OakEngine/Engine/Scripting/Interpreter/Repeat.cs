using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oak.Engine.Scripting
{
    class Repeat : IInterpretable
    {
        #region IInterpretable Members

        public void run(string function)
        {
            string[] command = function.Split(Interpreter.Mask);
            int repeats = Convert.ToInt32(command[1]);
            StringBuilder sb = new StringBuilder();
            for (int i = 2; i < command.Length; i++)
            {
                sb.Append(command[i]);
                sb.Append(" ");
            }

            string func = sb.ToString();

            for (int i = 0; i < repeats; i++)
            {
                Interpreter.Console.Log("Running " + func);
                Interpreter.run(func);
            }
        }

        #endregion
    }
}
