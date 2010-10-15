using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oak.Engine.Scripting
{
    interface ILoader
    {
        bool load(string name);
    }
}
