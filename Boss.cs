using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myConsoleRPGCSharp
{
    internal class Boss : Enemy
    {
        Random rand = new Random();

        public Boss(PlayerCharacter character)
        {
            base.DiffModifier = 1 + (character.CurrentArea / 20);

            base.Prefix = RandomBossPrefix();
            base.Type = RandomBossType();
            base.Suffix = RandomBossSuffix();
            base.Rarity = "boss";

            base.HPMax = 100 * DiffModifier;
            base.Hp = (int)base.HPMax;
            base.ManaMax = (50 * DiffModifier) / 3;
            base.Mana = (int)base.ManaMax;

            base.Defense = 10;
            base.DamageMin = 10;
            base.DamageMax = 15;
            base.GoldOnKill = 50;
            base.ExpOnKill = 50;



            base.Name = base.Prefix + base.Type + base.Suffix;
        }


        // FUNCTIONS
        private string RandomBossPrefix()
        {
            int randomNumber = rand.Next(0, 4);
            switch (randomNumber)
            {
                default:
                    return "";
                    
                case 0:
                    return "Destructive";
                    
                case 1:
                    return "Murderous";
                    
                case 2:
                    return "Devious";
                    
            }
        }
        private string RandomBossType()
        {
            int randomNumber = rand.Next(0, 3);
            switch (randomNumber)
            {
                default:
                    return "";
                    
                case 0:
                    return " [Goliath] ";
                    
                case 1:
                    return " [Golem] ";
                    
                case 2:
                    return " [Giant] ";
                    
            }
        }
        private string RandomBossSuffix()
        {
            int randomNumber = rand.Next(0, 4);
            switch (randomNumber)
            {
                default:
                    return "";
                    
                case 0:
                    return "of Piercing Blows";
                    
                case 1:
                    return "of Tankiness";
                    
                case 2:
                    return "of Flexibility";
                    
            }
        }

    }
}
