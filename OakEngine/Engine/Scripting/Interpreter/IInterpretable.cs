using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oak.Engine.Scripting
{
    interface IInterpretable
    {
        void run(string function);
    }
}
