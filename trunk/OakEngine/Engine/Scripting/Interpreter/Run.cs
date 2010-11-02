using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Oak.Engine.Scripting
{
    class Run : IInterpretable
    {
        #region IInterpretable Members

        public void run(string function)
        {
            string[] command = function.Split(Interpreter.Mask);
            
            RageScript rs = Oak.ContentAccess.Load<RageScript>(command[1]);
            StreamReader reader = new StreamReader(rs.stream);

            LinkedList<string> file = new LinkedList<string>();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine().TrimStart().TrimEnd();
                file.AddFirst(line);
            }

            foreach (string line in file) {
                Interpreter.runFirst(line);
            }

            rs.Unload();
             
        }

        #endregion
    }
}
