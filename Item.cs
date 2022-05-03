using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myConsoleRPGCSharp
{
    internal class Item
    {
        private string name;
        private int sellValue;
        private int buyValue;
        Random rand = new Random();


        // GETTERS & SETTERS
        public string Name { get { return name; } set { name = value; } }
        public int SellValue { get { return sellValue; } set { sellValue = value; } }
        public int BuyValue { get { return buyValue; } set { buyValue = value; } }

        // CONSTRUCTORS
        public Item()
        {
            name = RandomNameGenerator();
            sellValue = 0;
            buyValue = 0;
        }
        public Item(Enemy enemy)
        {
            name = enemy.Name;
            sellValue = 10;
            buyValue = 10;
        }
        public Item(string itemName, int itemSellValue, int itemBuyValue)
        {
            this.name = itemName;
            this.sellValue = itemSellValue;
            this.buyValue = itemBuyValue;
        }

        private string RandomNameGenerator()
        {
            int randomNumber = rand.Next(0, 3);

            switch (randomNumber)
            {
                case 0:
                    return "Hehe";
                    
                case 1:
                    return "LOL";
                    
                case 2:
                    return "KEK";
                    
                default:
                    return "XD";
                    
            }
        }
        // FUNCTIONS
    }
}
