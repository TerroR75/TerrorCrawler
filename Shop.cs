using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myConsoleRPGCSharp
{
    internal class Shop
    {
        Random rand;
        private List<Item> items;
        private bool shopping;
        private int choice;


        // GETTERS
        public bool Shopping { get { return shopping; } set { shopping = value; } }

        // CONSTRUCTORS
        public Shop(PlayerCharacter character)
        {
            rand = new Random();
            items = new List<Item>();
            shopping = true;
            choice = 0;

            PopulateShopItems(character);

        }

        // FUNCTIONS
        public void ShopMenu(PlayerCharacter character)
        {
            while (shopping)
            {
                //Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("===SHOP===");
                Console.ResetColor();
                Console.WriteLine("0: Quit shop\n" +
                    "1: Buy items\n" + 
                    "2: Sell items\n" +
                    "3: New items delivery");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nGOLD: " + character.Gold);
                Console.ResetColor();

                Console.WriteLine("Choice: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        default:
                            Console.WriteLine("Wrong choice!");
                            break;
                        case 0:
                            shopping = false;
                            break;
                        case 1:
                            BuyItemsMenu();
                            break;
                        case 2:
                            SellItemsMenu(character);
                            break;
                        case 3:
                            character.Gold -= 100;
                            ReInitializeShop(character);
                            break;
                    }

                }
                catch
                {
                    Console.WriteLine("Wrong input");
                }
            }
        }


        private void ReInitializeShop(PlayerCharacter character)
        {
            items.Clear();
            PopulateShopItems(character);
        }

        private void PopulateShopItems(PlayerCharacter character)
        {
            int randomNumberOfItems = rand.Next(5, 8);
            for (int i = 0; i < randomNumberOfItems; i++)
            {
                items.Add(new Item());
            }
        }

        private void BuyItemsMenu()
        {
            Console.Clear();
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(i + ". " + items[i].Name);
            }
            Console.ReadKey();
        }
        private void SellItemsMenu(PlayerCharacter character)
        {
            Console.Clear();
            for (int i = 0;i < character.inventory.items.Count; i++)
            {
                Console.WriteLine((i+1) + ". " + character.inventory.items[i].Name);
            }
            Console.ReadKey();
        }
    }
}
