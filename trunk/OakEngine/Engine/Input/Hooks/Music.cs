using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oak.Engine.Audio;

namespace Oak.Engine.Scripting
{
    class Music : IInterpretable
    {
        ///<summary>
        ///plays media files
        ///</summary>

        #region IInterpretable Members

        public void run(string function)
        {
            string[] command = function.Split(Interpreter.Mask);
            switch (command[1])
            {
                case "play":
                case "p":
                    AudioManager.PlaySound(command[2]);
                    break;
                case "pause":
                case "a":
                    AudioManager.PauseAll();
                    break;
                case "stop":
                case "s":
                    AudioManager.StopAll();
                    break;
                case "resume":
                case "r":
                    AudioManager.ResumeAll();
                    break;
                default:
                    throw new ArgumentException("invalid option", command[1]);
            }
        }

        #endregion
    }
}
