using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oak.Engine.Audio;
using Oak.Engine.Game;

namespace Oak.Engine.Scripting
{
    class Load : IInterpretable
    {
        public void run(string function)
        {
            string[] command = function.Split(Interpreter.Mask);
            
            switch (command[1])
            {
                case "sndpkg":
                    AudioManager.AddSoundLibrary(command[2], command[3]);
                    break;
                /* TODO rework most of this function
            case "map": {
                    Level level = new Level(command[2]);
                    Game1.screenManager.AddScreen("level", level);
                    break;
                     
                }
                 */
            }
        }
    }
}
