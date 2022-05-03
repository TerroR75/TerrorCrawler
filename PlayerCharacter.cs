using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myConsoleRPGCSharp
{
    internal class PlayerCharacter
    {
        // ATTRIBUTES
        private string name;
        private int level;
        private int currentArea;
        private int savedArea;

        private int exp;
        private int expNextLevel;

        private int strength;
        private int intelligence;
        private int dexterity;

        private double hpMax;
        private int hp;
        private double manaMax;
        private int mana;
        private double shieldMax;
        private int shield;
        private float critChance;
        private float critMulti;

        private int defense;
        private int damageMin;
        private int damageMax;

        private int gold;
        private float escapeChanceMax;
        private float escapeChance;

        private int statPoints;
        private int skillPoints;
        private int spentStatPoints;
        private int shopRestartStone;

        int spentPoints;
        int allocStrength;
        int allocIntelligence;
        int allocDexterity;


        // ATT: INVENTORY RELATED
        public Inventory inventory;

        // CONSTRUCTOR
        public void createNewCharacter(string playerName)
        {
            name = playerName;
            level = 1;
            currentArea = 0;
            savedArea = 0;

            exp = 0;
            expNextLevel = Convert.ToInt32((50 / 3) *
                ((Math.Pow(level, 3) - 6 * Math.Pow(level, 2)) +
                17 * level - 12)) + 100;

            strength = 10;
            intelligence = 10;
            dexterity = 10;

            hpMax = 100.5 + (strength / 2);
            hp = (int)hpMax;
            manaMax = 50 + (intelligence / 5);
            mana = (int)manaMax;
            shieldMax = 3*(intelligence / 2);
            shield = (int)shieldMax;
            critChance = 0.07f;
            critMulti = 1.5f;

            defense = 10;
            damageMin = 183;
            damageMax = 183;
    
            gold = 5000000;
            escapeChanceMax = 0.2f;
            escapeChance = escapeChanceMax;

            statPoints = 15;
            skillPoints = 0;
            spentStatPoints = 0;
            

            inventory = new Inventory();
            inventory.Initialize();
        }

        // GETTERS & SETTERS
        public string Name { get { return name; } set { name = value; } }
        public int Level { get { return level; } set { level = value; } }

        public int CurrentArea { get { return currentArea; } set { currentArea = value; } } 
        public int SavedArea { get { return savedArea; } set { savedArea = value; } }
        public int Exp { get { return exp; } set { exp = value; } }
        public int ExpNextLevel { get { return expNextLevel; } set { expNextLevel = value; } }
        public int Strength { get { return strength; } set { strength = value; } }
        public int Intelligence { get { return intelligence; } set { intelligence = value; } }
        public int Dexterity { get { return dexterity; } set { dexterity = value; } }
        public int Hp { get { return hp; } set { hp = value; } }
        public double HpMax { get { return hpMax; } set { hpMax = value; } }
        public int Gold { get { return gold; } set { gold = value; } }
        public float EscapeChance { get { return escapeChance; } }
        public int Defense { get { return defense; } set { defense = value; } }
        public int DamageMin { get { return damageMin; } set { damageMin = value; } }
        public int DamageMax { get { return damageMax; } set { damageMax = value; } }
        public int ShopRestartStones { get { return shopRestartStone; } set { shopRestartStone = value; } }
        public int StatPoints { get { return statPoints; } set { statPoints = value; } }
        public int SkillPoints { get { return skillPoints; } set { skillPoints = value; } }

        // FUNCTIONS
        public void PrintCharacterInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nCharacter info:\n"
                + "===========");
            Console.ResetColor();
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Level: " + level);

            Console.WriteLine("Exp: " + exp + " / " + expNextLevel);

            Console.WriteLine("STR: " + strength);
            Console.WriteLine("INT: " + intelligence);
            Console.WriteLine("DEX: " + dexterity);

            Console.WriteLine("HP: " + hp + " / " + (int)hpMax);
            Console.WriteLine("Shield: " + shield + " / " + (int)shieldMax);
            Console.WriteLine("Mana: " + mana + " / " + (int)manaMax);

            Console.WriteLine("==="+statPoints+"===");
            Console.WriteLine("STR: " + strength);
            Console.WriteLine("INT: " + intelligence);
            Console.WriteLine("DEX: " + dexterity);

            Console.WriteLine("Highest area: " + savedArea);

        }

        public void PrintCharacterCombatInfo()
        {
            Console.WriteLine("=====");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("PLAYER");
            Console.ResetColor();
            Console.WriteLine("=====");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Level: " + level);

            Console.WriteLine("HP: " + hp + " / " + (int)hpMax);
            Console.WriteLine("Shield: " + shield + " / " + (int)shieldMax);
            Console.WriteLine("Mana: " + mana + " / " + (int)manaMax);

            Console.WriteLine("Damage: " + damageMin + " - " + damageMax);
            Console.WriteLine("Defense: " + defense);

        }

        public void AddExp(int exp)
        {
            this.exp += exp;
            if (this.exp >= expNextLevel)
            {
                LevelUp();
            }
        }
        private void LevelUp()
        {
            int iterations = 0;
            while (this.exp >= this.expNextLevel)
            {
                this.level += 1;
                this.statPoints += 5;
                this.skillPoints += 1;
                hp = (int)hpMax;
                mana = (int)manaMax;
                shield = (int)shieldMax;

                this.exp -= this.expNextLevel;

                this.expNextLevel = Convert.ToInt32((50 / 3) *
                ((Math.Pow(level, 3) - 6 * Math.Pow(level, 2)) +
                17 * level - 12)) + 100;
                iterations++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nLEVEL UP! +" + iterations);
            Console.WriteLine("STAT POINTS +" + iterations*5);
            Console.WriteLine("SKILL POINTS +" + iterations);
            Console.ResetColor();
        }

        public void LevelUpMenu()
        {
            bool inLevelUpMenu = true;
            int previousStr = this.strength;
            int previousInt = this.intelligence;
            int previousDex = this.dexterity;
            int previousStatPoints = this.statPoints;
            spentPoints = 0;
            allocStrength = 0;
            allocIntelligence = 0;
            allocDexterity = 0;


            while (inLevelUpMenu)
            {
                Console.Clear();
                PrintCharacterInfo();
                try
                {
                    Console.WriteLine("\n0: Quit and save ");
                    Console.WriteLine("1: Allocate stat points ");
                    Console.WriteLine("2: Allocate skill points ");
                    Console.WriteLine("Choice: ");
                    char input = Console.ReadKey().KeyChar;
                    switch (input)
                    {
                        default:
                            Console.WriteLine("Wrong input!");
                            break;
                        case '0':
                            inLevelUpMenu = false;
                            break;
                        case '1':
                            StatAllocMenu(previousStr, previousInt, previousDex, previousStatPoints, spentPoints);
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("ERROR");
                }
            }
            



        }
        private void StatAllocMenu(int prevStr, int prevInt, int prevDex, int previousStatPoints, int spentStatPoints)
        {
            

            bool inStatAllocMenu = true;
            while (inStatAllocMenu)
            {
                
                Console.Clear();
                Console.WriteLine("0. Quit\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("1. STR: " + strength);
                Console.WriteLine("Maximum HP: " + (int)hpMax);
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n2. INT: " + intelligence);
                Console.WriteLine("Maximum MANA: " + (int)manaMax);
                Console.WriteLine("Maximum SHIELD: " + (int)shieldMax);
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n3. DEX: " + dexterity);
                Console.WriteLine("Escape Chance: " + (float)Math.Round(escapeChance*100f) + "%");
                Console.WriteLine("Crit Chance: " + (float)Math.Round(critChance*100f) + "%");
                Console.ResetColor();
                Console.WriteLine("\n4.Reset");

                Console.WriteLine("Allocate 1 stat " + "[" + statPoints + "]");

                try
                {
                    char input = Console.ReadKey().KeyChar;
                    switch (input)
                    {
                        default:
                            break;
                        case '0':
                            inStatAllocMenu = false;
                            break;
                        case '1':
                            if (!(statPoints <= 0))
                            {
                                this.statPoints--;
                                this.strength++;
                                allocStrength++;
                                hpMax += 0.5;
                            }
                            break;
                        case '2':
                            if (!(statPoints <= 0))
                            {
                                this.statPoints--;
                                this.intelligence++;
                                allocIntelligence++;
                                manaMax += 0.2;
                                shieldMax += 0.5;
                            }
                            break;
                        case '3':
                            if (!(statPoints <= 0))
                            {
                                this.statPoints--;
                                this.dexterity++;
                                allocDexterity++;
                                escapeChanceMax += 0.001f;
                                critChance += 0.001f;
                                escapeChance = escapeChanceMax;
                            }
                            break;
                        case '4':
                            strength = prevStr;
                            hpMax -= allocStrength*0.5;

                            intelligence = prevInt;
                            manaMax -= allocIntelligence*0.2;
                            shieldMax -= allocIntelligence*0.5;

                            dexterity = prevDex;
                            escapeChanceMax -= allocDexterity * 0.001f;
                            critChance -= allocDexterity * 0.001f;
                            statPoints = previousStatPoints;

                            allocStrength = 0;
                            allocIntelligence = 0;
                            allocDexterity = 0;
                            break;
                    }
                }
                catch
                {

                    
                }
            }
            
        }



    }
    
}
