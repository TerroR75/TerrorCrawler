using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myConsoleRPGCSharp
{
    internal class Enemy
    {
        private float diffModifier;

        Random rand = new Random();
        private string name;
        private string type;
        private string prefix;
        private string suffix;
        private string rarity;

        private float hpMax;
        private int hp;
        private float manaMax;
        private int mana;

        private int defense;
        private int damageMin;
        private int damageMax;

        private int goldOnKill;
        private int expOnKill;
        public Item itemOnKill;

        // GETTERS & SETTERS
        public float DiffModifier { get { return diffModifier; } set { diffModifier = value; } }
        public string Name { get { return name; } set { name=value; } }
        public string Type { get { return type; } set { type=value; } }
        public string Prefix { get { return prefix; } set { prefix=value; } }
        public string Suffix { get { return suffix; } set { suffix=value; } }
        public string Rarity { get { return rarity; } set { rarity=value; } }
        public float HPMax { get { return hpMax; } set { hpMax=value; } }
        public int Hp { get { return hp; } set { hp = value; } }
        public float ManaMax { get { return manaMax; } set { manaMax=value; } }
        public int Mana { get { return mana; } set { mana = value; } }
        public int Defense { get { return defense; } set { defense=value; } }
        public int DamageMin { get { return damageMin; } set { damageMin=value; } }
        public int DamageMax { get { return damageMax; } set { damageMax=value; } }
        public int GoldOnKill { get { return goldOnKill; } set { goldOnKill=value; } }
        public int ExpOnKill { get { return expOnKill; } set { expOnKill=value; } }

        // CONSTRUCTOR
        public Enemy()
        {

        }
        public Enemy(PlayerCharacter character)
        {
            diffModifier = 1 + (character.CurrentArea / 20);

            type = RandomNameGenerator();
            prefix = RandomPrefixGenerator();
            suffix = RandomSuffixGenerator();
            name = prefix + type + suffix;
            rarity = "normal";

            hpMax = 100 * diffModifier;
            hp = (int)hpMax;
            manaMax = 20 * diffModifier;
            mana = (int)manaMax;

            defense = 10 * (int)diffModifier;
            damageMin = 1 * (int)diffModifier;
            damageMax = 4 * (int)diffModifier;

            goldOnKill = 20 * (int)diffModifier;
            expOnKill = Convert.ToInt32((50 / 3) *
            ((Math.Pow(character.Level, 3) - 6 * Math.Pow(character.Level, 2)) +
            17 * character.Level - 12)) + 1000;

            itemOnKill = new Item("sdfdgfg", 102, 101);

        }

        // ENEMY'S NAME GENERATION
        private string RandomNameGenerator()
        {
            int randomNumber = rand.Next(0,3);
            string randomName = "";
            switch (randomNumber)
            {
                case 0:
                    randomName = " [Bandit] ";
                    return randomName;
                case 1:
                    randomName = " [Skeleton] ";
                    return randomName;
                case 2:
                    randomName = " [Zombie] ";
                    return randomName;
                default:
                    randomName = " [DEFAULT] ";
                    return randomName;

            }

        }
        private string RandomPrefixGenerator()
        {
            int randomNumber = rand.Next(0, 4);
            string randomPrefix = "";
            switch (randomNumber)
            {
                case 0:
                    randomPrefix = "Angry";
                    return randomPrefix;
                case 1:
                    randomPrefix = "Cruel";
                    return randomPrefix;
                case 2:
                    randomPrefix = "Arrogant";
                    return randomPrefix;
                default:
                    return randomPrefix;
            }
        }
        private string RandomSuffixGenerator()
        {
            int randomNumber = rand.Next(0, 4);
            string randomSuffix = "";
            switch (randomNumber)
            {
                case 0:
                    randomSuffix = "of Hate";
                    return randomSuffix;
                case 1:
                    randomSuffix = "of Misery";
                    return randomSuffix;
                case 2:
                    randomSuffix = "of Cruelty";
                    return randomSuffix;
                default:
                    return randomSuffix;
            }
        }

        public void PrintEnemyCombatInfo()
        {
            if (rarity == "boss")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=====");
                Console.WriteLine("[BOSS]");
                Console.WriteLine("=====");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("=====");
                Console.WriteLine("ENEMY");
                Console.WriteLine("=====");
                Console.ResetColor();
            }
            
            Console.WriteLine("Name: " + name);
            Console.WriteLine("HP: " + hp + " / " + (int)hpMax);
            Console.WriteLine("Mana: " + mana + " / " + (int)manaMax);
            Console.WriteLine("Defense: " + defense);
            Console.WriteLine("Damage: " + damageMin + " - " + damageMax +"\n");
        }
    }
}
