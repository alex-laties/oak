using System;

namespace OakEngine
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Oak game = new Oak())
            {
                game.Run();
            }
        }
    }
}

