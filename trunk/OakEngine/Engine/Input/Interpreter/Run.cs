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
            /* TODO rework all of this
            string[] command = function.Split(Interpreter.Mask);

            RageScript rs = Game1.DefaultContent.Load<RageScript>("./Scripts/" + command[1]);
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
             */
        }

        #endregion
    }
}
