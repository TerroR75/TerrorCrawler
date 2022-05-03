using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myConsoleRPGCSharp
{
    class GameEngine
    {
        // ATTRIBUTES
        private bool isPlayingQM = true;
        private bool inMainMenu = true;
        

        private int choice = 0;

        // TRAVEL
        public Travel newTravel;


        // PLAYER
        public int currentPlayer;
        public List<PlayerCharacter> characters;

        // SHOP
        Shop newShop;

        // GETTERS & SETTERS
        public bool IsPlayingQM { get { return isPlayingQM; } set { isPlayingQM = value; } }
        public int CurrentPlayer { get { return currentPlayer; } set { currentPlayer = value; } }
        public bool InMainMenu { get { return inMainMenu; } set { inMainMenu = value; } }


        // FUNCTIONS
        public void Initialize()
        {
            string name = "";
            isPlayingQM = true;
            inMainMenu = true;
            newTravel = new Travel();
            characters = new List<PlayerCharacter>();

            characters.Add(new PlayerCharacter());
            Console.WriteLine("Name: ");
            name = Console.ReadLine();

            currentPlayer = characters.Count - 1;
            
            characters[currentPlayer].createNewCharacter(name);
            newShop = new Shop(characters[currentPlayer]);

        }

        public void MainMenu()
        {
            newShop.Shopping = true;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nMAIN MENU");
            Console.ResetColor();
            Console.WriteLine(
                "===========\n" +
                "0: Quit\n" +
                "1: Character info\n" +
                "2: Shop\n" +
                "3: Level up\n" +
                "4: Inventory\n\n" +
                "5: =TRAVEL=\n" +
                "Choice: ");

            // PICKING CHOICE
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                    case 0:
                        isPlayingQM = false;
                        break;
                    case 1:
                        characters[currentPlayer].PrintCharacterInfo();
                        Console.ReadKey();
                        break;
                    case 2:
                        newShop.ShopMenu(characters[currentPlayer]);
                        break;
                    case 3:
                        characters[currentPlayer].LevelUpMenu();
                        break;
                    case 4:
                        characters[currentPlayer].inventory.PrintItems();
                        Console.WriteLine(characters[currentPlayer].inventory.NumberOfItems);
                        break;
                    case 5:
                        inMainMenu = false;
                        newTravel.IsTravellingQM = true;
                        newTravel.Traveling(characters[currentPlayer], this);
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Wrong input!");
            }


        }



    }
}
