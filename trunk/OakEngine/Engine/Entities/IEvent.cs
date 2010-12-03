using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Oak.Engine.Entities
{
    interface IEvent
    {
        bool Active();
        void Activate(); //my trap card
        void Deactivate();
        void Update(GameTime time);
    }
}
