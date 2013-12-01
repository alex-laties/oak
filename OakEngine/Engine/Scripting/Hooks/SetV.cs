using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oak.Engine.Graphics;

namespace Oak.Engine.Scripting
{
    class SetV : IInterpretable
    {
        #region IInterpretable Members

        public void run(string function)
        {
            string[] command = function.Split(Interpreter.Mask);
            command[1] = command[1].ToLower();
            switch (command[1])
            {
                    
                case "width":
                case "w":
                    GraphicsManager.Width =
                        Convert.ToInt32(command[2]);
                    break;
                case "height":
                case "h":
                    GraphicsManager.Height =
                        Convert.ToInt32(command[2]);
                    break;
                case "fullscreen":
                    GraphicsManager.FullScreen = true;
                    break;
                case "windowed":
                    GraphicsManager.FullScreen = false;
                    break;
                default:
                    throw new ArgumentException("invalid option", command[1]);
                     
            }
        }

        #endregion
    }
}
