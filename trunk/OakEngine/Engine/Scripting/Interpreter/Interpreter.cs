using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Oak.Engine.Scripting
{
    static class Interpreter
    {
        static LinkedList<string> commandQueue;
        internal static int commandDelay;
        static StringBuilder commandBuffer;
        static Dictionary<string, IInterpretable> functions;
        static Dictionary<string, string> env;
        
        public static Dictionary<string, string> Env
        {
            get
            {
                return env;
            }
        }

        public static IGameConsole Console
        {
            get;
            set;
        }

        public static Char[] Mask = new Char[] { ' ' };

        public static void Initialize()
        {
            functions = new Dictionary<string, IInterpretable>();
            env = new Dictionary<string, string>();
            commandBuffer = new StringBuilder();
            commandQueue = new LinkedList<string>();
            commandDelay = 0;
            loadFunctions();
        }

        private static void loadFunctions()
        {
            #region interpreterBinds

            functions["bind"] = new Bind();
            functions["clear"] = new Clear();
            functions["console"] = new Console();
            functions["exit"] = new Exit();
            functions["if"] = new If();
            functions["let"] = new Let();
            functions["load"] = new Load();
            functions["music"] = new Music();
            functions["repeat"] = new Repeat();
            functions["run"] = new Run();
            functions["setv"] = new SetV();
            functions["setc"] = new SetC();
            functions["show"] = new Show();
            functions["switchscreen"] = new SwitchScreen();
            
            #endregion

            foreach (string key in functions.Keys)
            {
                Console.BindCommandHandler(key, new ConsoleCommandHandler(run), new Char[] { ' ' });
            }
        }

        private static void runQueue()
        {
            bool multiline = false;
            string function = commandQueue.First();
            commandQueue.RemoveFirst();
            if (function == null)
            {
                return;
            }

            string[] command = function.Split(new Char[] { ' ' });
            //comment checking stuff
            #region comment check
            if (command[0].Contains("#")) //if # is the first in the line, meaning the line is a comment
                return;
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i].Contains("#"))
                {
                    string[] temp = new string[i];
                    Array.ConstrainedCopy(command, 0, temp, 0, i);
                    command = temp;
                    break;
                }
            }
            #endregion
            //replace marked variables
            #region bash replace
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i].Contains('$'))
                {
                    try
                    {
                        command[i] = command[i].Split(new Char[] { '$' })[1];
                        command[i] = env[command[i]];
                    }
                    catch (Exception e)
                    {
                        Console.Log(e.Message);
                    }
                }
            }
            #endregion
            //multilining stuff
            #region multiline
            if (command[0] == "\\\\") //if the start of line is a multiline
                return;

            if (command[command.Length - 1] == "\\\\" || commandBuffer.Length > 0)
            {
                if (commandBuffer.Length > 0 && command[command.Length - 1] != "\\\\") //if this is the last line in a multiline statement
                {
                    for (int i = 0; i < command.Length; i++) //linus torvalds would cry
                    {
                        commandBuffer.Append(command[i]);
                        commandBuffer.Append(" ");
                    }

                    multiline = true;
                }
                else //we need to continue adding to the buffer
                {
                    for (int i = 0; i < command.Length - 1; i++) 
                    {
                        commandBuffer.Append(command[i]);
                        commandBuffer.Append(" ");
                    }

                    return;
                }
            }

            #endregion

            #region execute
            try
            {
                //check to see if function is null
                if (command[0].Contains("None"))
                {
                    return;
                }

                //check to see if function is a wait
                if (command[0] == "wait")
                {
                    commandDelay += Convert.ToInt32(command[1]);
                    return;
                }

                StringBuilder f = new StringBuilder();

                //check to see if multiline
                if (multiline)
                {
                    command = commandBuffer.ToString().Split(Interpreter.Mask);
                    commandBuffer = new StringBuilder();
                }

                //create new function from modified command array
                for (int i = 0; i < command.Length; i++)
                {
                    f.Append(command[i]);
                    f.Append(" ");
                }

                //run
                functions[command[0]].run(f.ToString());
            }
            catch (Exception e)
            {
                if (function == String.Empty)
                    return;

                Console.Log(e.Message);
            }
            #endregion
        }

        public static void Update(GameTime gameTime)
        {
            while (commandDelay == 0)
            {
                if (commandQueue.Count > 0)
                {
                    runQueue();
                    commandDelay = 1;
                }
                else
                {
                    return;
                }
            }

            if (commandDelay > 0)
                commandDelay--;
        }

        /********************************
         * Stub/Compatability Functions *
         * *****************************/
        public static void run(string function)
        {
            commandQueue.AddLast(function);
        }

        public static void runFirst(string function)
        {
            commandQueue.AddFirst(function);
        }

        public static void run(
            Microsoft.Xna.Framework.GameTime t, string function)
        {
            run(function);
        }
    }
}
