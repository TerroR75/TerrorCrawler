using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myConsoleRPGCSharp
{
    internal class Inventory
    {
        private int inventorySize;
        private int numberOfItems;
        public List<Item> items;


        // GETTERS & SETTERS
        public int NumberOfItems { get { return numberOfItems; } set { numberOfItems = value; } }

        // FUNCTIONS
        public void Initialize()
        {
            inventorySize = 50;
            numberOfItems = 0;
            items = new List<Item>();

        }

        public void PrintItems()
        {
            //foreach (Item item in items)
            //{
            //    Console.WriteLine(item.Name);
            //}
            for (int i = 0; i < numberOfItems; i++)
            {
                Console.WriteLine(i + ": " + items[i].Name);
            }
            Console.ReadKey();
        }
        public void AddItem(Item item, PlayerCharacter character)
        {
            character.inventory.items.Add( item );
        }
        public void RemoveItem(int index)
        {
            
        }
    }
}
