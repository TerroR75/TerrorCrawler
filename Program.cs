using System;

namespace myConsoleRPGCSharp
{
    class Program
    {
        

        static void Main(string[] args)
        {
            GameEngine newGameEngine = new GameEngine();

            newGameEngine.Initialize();

            while (newGameEngine.IsPlayingQM)
            {
                while (newGameEngine.InMainMenu)
                {
                    newGameEngine.MainMenu();
                }

                //while (newGameEngine.newTravel.IsTravellingQM)
                //{
                //    Console.Clear();
                //    newGameEngine.newTravel.Traveling();
                //}
                
            }
        }

        
    }
}
