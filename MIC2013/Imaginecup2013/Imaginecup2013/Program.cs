using System;

namespace Imaginecup2013
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Leoni game = new Leoni())
            {
                game.Run();
            }
        }
    }
#endif
}

