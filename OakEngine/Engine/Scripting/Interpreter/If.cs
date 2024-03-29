﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oak.Engine.Scripting
{
    class If : IInterpretable
    {
        #region IInterpretable Members

        public void run(string function)
        {
            string[] command = function.Split(Interpreter.Mask);
            StringBuilder sb = new StringBuilder();
            StringBuilder sbelse = new StringBuilder();
            bool haselse = false;
            for (int i = 2; i < command.Length; i++)
            {
                if (haselse)
                {
                    sbelse.Append(command[i]);
                    sbelse.Append(" ");
                }
                else if (command[i] == "else")
                {
                    haselse = true;
                }
                else
                {
                    sb.Append(command[i]);
                    sb.Append(" ");
                }
            }
                
            
            if (command[1] == "1")
            {
                Interpreter.run(sb.ToString());
            }
            else if(haselse)
            {
                Interpreter.run(sbelse.ToString());
            }
            else
            {
                throw new ArgumentException("Does not evaluate to 1", command[1]);
            }
        }

        #endregion
    }
}
