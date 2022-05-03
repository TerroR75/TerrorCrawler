using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myConsoleRPGCSharp
{
    internal class Travel
    {
        int choice;
        private bool isTravellingQM = false;
        Random rand = new Random();
        Encounter newEncounter = new Encounter();


        // GETTERS
        public bool IsTravellingQM { get { return isTravellingQM; } set { isTravellingQM = value; } }


        // FUNCTIONS
        public void Traveling(PlayerCharacter character, GameEngine gameEngine)
        {
            while (isTravellingQM)
            {
                Console.Clear();
                int randomNumber = 0;
                newEncounter.IsRunning = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=TRAVEL=");
                Console.ResetColor();
                Console.WriteLine(
                                "AREA - " + character.CurrentArea + "\n" +
                                "==========\n" +
                                "0: Go back\n" +
                                "1: Move forward by 1\n" +
                                "2: Move forward by 5\n" +
                                "3: Move forward by 10\n" +
                                "4: Move forward by 20\n" +
                                "5: Return to your highest area: " + character.SavedArea +
                                "\n9: Return to area 0" +
                                "\nChoice: ");

                // PICKING CHOICE
                try
                {
                    char input = Console.ReadKey().KeyChar;

                    switch (input)
                    {
                        default:
                            Console.WriteLine("Wrong choice!");
                            break;
                        case '0':
                            Console.WriteLine("Save you current area? (0: no, 1: yes)");
                            char nextInput = Console.ReadKey().KeyChar;

                            switch (input)
                            {
                                default:
                                    Console.WriteLine("WRONG INPUT!");
                                    break;
                                case '0':
                                    isTravellingQM = false;
                                    gameEngine.InMainMenu = true;
                                    character.CurrentArea = 0;
                                    break;
                                case '1':
                                    character.SavedArea = character.CurrentArea;
                                    character.CurrentArea = 0;
                                    isTravellingQM = false;
                                    gameEngine.InMainMenu = true;
                                    break;
                            }



                            //character.HighestArea = character.CurrentArea;
                            //character.CurrentArea = 0;
                            //isTravellingQM = false;
                            //gameEngine.InMainMenu = true;
                            Console.Clear();
                            break;
                        case '1':
                            randomNumber = rand.Next(1, 101);
                            character.CurrentArea += 1;
                            if (randomNumber >= 1)
                            {
                                newEncounter.RandomEncounter(character);
                            }
                            break;
                        case '2':
                            character.CurrentArea += 5;
                            break;
                        case '3':
                            character.CurrentArea += 10;
                            break;
                        case '4':
                            character.CurrentArea += 20;
                            break;
                        case '5':
                            character.CurrentArea = character.SavedArea;
                            break;
                        case '9':
                            character.CurrentArea = 0;
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("");
                }
            }
            


        }
    }
}
