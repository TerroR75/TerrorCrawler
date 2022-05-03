using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myConsoleRPGCSharp
{
    internal class Encounter
    {
        private int choice;
        private bool isRunning = true;
        private int playerEscapeTries = 0;

        Enemy newEnemy;

        Random rand = new Random();


        // CONSTRUCTORS
        public Encounter()
        {
           
        }

        // GETTERS & SETTERS
        public bool IsRunning { get { return isRunning; } set { isRunning=value; } }

        // FUNCTIONS
        public void RandomEncounter(PlayerCharacter character, string type = "ENEMY")
        {
            if (type == "ENEMY")
            {
                CombatModule(type, character);
            }
            else
            {
                Console.WriteLine("XD");
            }
        }

        private void CombatModule(string type, PlayerCharacter character)
        {
            newEnemy = null;
            int randomNumberFirst = rand.Next(1, 101);
            if (randomNumberFirst <= 100)
            {
                newEnemy = new Boss(character);
            }
            else
            {
                newEnemy = new Enemy(character);
            }

            playerEscapeTries = 0;
            while (isRunning && !(character.Hp <= 0))
            {
                int randomNumber = 0;
                Console.Clear();
                if (newEnemy.Hp <=0)
                {
                    isRunning = false;
                    break;
                }
                newEnemy.PrintEnemyCombatInfo();
                character.PrintCharacterCombatInfo();

                if (playerEscapeTries == 1)
                {
                    Console.WriteLine("\n0: Try and run (LOCKED)");
                }
                else
                {
                    Console.WriteLine("\n0: Try and run");
                }
                Console.WriteLine("1: Attack");
                //"2: Defend\n" +
                //"3: Dodge");

                try 
                {
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                    {
                    default:
                        Console.WriteLine("WRONG INPUT!");
                        break;
                    case 0:
                            if (playerEscapeTries == 0)
                            {
                                randomNumber = rand.Next(1, 101);
                                EscapeModule(randomNumber, character);
                            }
                            else
                            {
                                Console.WriteLine("You cant escape now!");
                                Console.ReadKey();
                            }
                        
                        break;
                    case 1:
                            Attack(character, newEnemy);
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Wrong input!");
                }
            }
            if (newEnemy.Hp <= 0 && character.Hp > 0)
            {
                EncounterSuccess(newEnemy, character);
            }
            else if (newEnemy.Hp > 0 && character.Hp <= 0)
            {
                EncounterFailure(newEnemy, character);
            }
            
        }
        private void NpcModule()
        {

        }

        private void NormalEnemyModule()
        {

        }

        private void EscapeModule(int number, PlayerCharacter character)
        {
            if (number <= 100)
            {
                isRunning = false;
                Console.WriteLine("You successfully escaped!");
                character.CurrentArea -= 1;
                Console.ReadKey();
            }
            else
            {
                isRunning = true;
                Console.WriteLine("You FAILED!");
                playerEscapeTries++;
                Console.ReadKey();
            }
        }

        private void Attack(PlayerCharacter character, Enemy enemy)
        {
            // PLAYER TURN
            int outHit = rand.Next(character.DamageMin, character.DamageMax + 1);
            enemy.Hp -= outHit;
            Console.WriteLine("You hit " + enemy.Name + " for " + outHit + " damage!");

            // ENEMY TURN
            int inHit = rand.Next(enemy.DamageMin, enemy.DamageMax + 1);
            character.Hp -= inHit;
            Console.WriteLine("You received " + inHit + " damage!");
            Console.ReadKey();
        }

        private void EncounterSuccess(Enemy enemy, PlayerCharacter character)
        {
            //Item itemToAdd = new Item();
            //itemToAdd = enemy.itemOnKill;
            
            Console.WriteLine("You have slain " + enemy.Name + "!");
            Console.WriteLine("+" + enemy.ExpOnKill + " XP");
            Console.WriteLine("+" + enemy.GoldOnKill + " GOLD");
            character.AddExp(enemy.ExpOnKill);
            character.Gold += enemy.GoldOnKill;

            Console.ReadKey();
        }

        private void EncounterFailure(Enemy enemy, PlayerCharacter character)
        {
            Console.WriteLine("YOU LOST");
            Console.ReadKey();
        }
    }


    
    
}
