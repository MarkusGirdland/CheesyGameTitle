using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheesyGameTitle
{
    public enum CardType            // Typ av kort
    {
        Empty = 1,
        Monster,
        Item,
        Trap
    }

    public class Card
    {
        // ============== Fält ===================

        private int health;
        private int strength;
        private int agility;
        private int intelligence;
        private string name;
        private CardType type;
        private string image;
        private string description;
        private int actionCode;

        // TODO: Images

        /* Action Code index: 
         
         
         * 0: Ingenting
         * 1: Helande Ost
         * 2: Möglig Ost
         * 3: Marsvinspellets
         * 4: Kaffepulver
         * 5: Linnéuniversitetet
         * 6: Musfälla
         * 7: Kvast-attack!
         * 8: Råttgift

         */

        // ============== Access ===================

        public int GetHealth()
        {
            return health;
        }

        public int GetStrength()
        {
            return strength;
        }

        public int GetAgility()
        {
            return agility;
        }

        public int GetIntelligence()
        {
            return intelligence;
        }

        public string GetName()
        {
            return name;
        }

        public CardType GetCardType()
        {
            return type;
        }

        public string GetImage()
        {
            return image;
        }

        public string GetDescription()
        {
            return description;
        }

        public int GetActionCode()
        {
            return actionCode;
        }

       /* public int GetHighestAttribute()
        {
            int maxValue = Math.Max(strength, Math.Max(intelligence, agility));

            return maxValue;
        } */

        // ============== Metoder ===================

        public T GetRandomCardType<T>()
        {
            T[] values = (T[])Enum.GetValues(typeof(T));                // Slumpar en enum

            return values[new Random().Next(0, values.Length)];
        }

        // ============== Konstruktor ===================

        public Card()
        {
            Random random = new Random();

            int randomTime = random.Next(1, 2000);

            CardType TheType = GetRandomCardType<CardType>();

            // ===== Tomt =====

            if (TheType == CardType.Empty)
            {
                System.Threading.Thread.Sleep(randomTime);
                type = CardType.Empty;
                name = "Tomt";
                description = "Absolut ingenting...";
                actionCode = 0;
            }

            // ===== Föremål =====

            if (TheType == CardType.Item)
            {
                type = CardType.Item;

                System.Threading.Thread.Sleep(randomTime);
                Random randomItemType = new Random();

                int randomItem = randomItemType.Next(1, 6);

                if (randomItem == 1)
                {
                    name = "Helande Ost";
                    description = "Din karaktär får full hälsa.";
                    actionCode = 1;
                }

                if (randomItem == 2)
                {
                    name = "Mögligt Ost";
                    description = "Din karaktär förlorar 3 hälsa.";
                    actionCode = 2;
                }

                if (randomItem == 3)
                {
                    name = "Marsvinspellets Med Extra C-vitamin";
                    description = "Din karaktär får 3 styrka.";
                    actionCode = 3;
                }

                if (randomItem == 4)
                {
                    name = "Spillt Kaffepulver";
                    description = "Din karaktär får 3 smidighet.";
                    actionCode = 4;
                }

                if (randomItem == 5)
                {
                    name = "Broschyr Från Linnéuniversitetet";
                    description = "Din karaktär får 3 intelligens.";
                    actionCode = 5;
                }
            }

            // ===== Monster =====

            if (TheType == CardType.Monster)
            {
                type = CardType.Monster;

                System.Threading.Thread.Sleep(randomTime);
                Random randomMonsterType = new Random();

                int randomMonster = randomMonsterType.Next(1, 7);

                if (randomMonster == 1)
                {
                    name = "Rivaliserande Råtta";
                    description = "Primär attribut: Styrka, 4 poäng. \n Hälsa: 3";
                    intelligence = 0;
                    agility = 0;
                    strength = 4;
                    health = 3;
                }

                if (randomMonster == 2)
                {
                    name = "Husets Marsvin";
                    description = "Primär attribut: Styrka, 5 poäng. \n Hälsa: 4";
                    intelligence = 0;
                    agility = 0;
                    strength = 5;
                    health = 4;
                }

                if (randomMonster == 3)
                {
                    name = "Rivaliserande Mus";
                    description = "Primär attribut: Smidighet, 4 poäng. \n Hälsa: 2";
                    intelligence = 0;
                    agility = 4;
                    strength = 0;
                    health = 2;
                }

                if (randomMonster == 4)
                {
                    name = "Irriterande Fluga";
                    description = "Primär attribut: Smidighet, 6 poäng. \n Hälsa: 2";
                    intelligence = 0;
                    agility = 6;
                    strength = 0;
                    health = 1;
                }

                if (randomMonster == 5)
                {
                    name = "Kråka";
                    description = "Primär attribut: Intelligens, 3 poäng. \n Hälsa: 5";
                    intelligence = 3;
                    agility = 0;
                    strength = 0;
                    health = 5;
                }

                if (randomMonster == 6)
                {
                    name = "Mus Einstein";
                    description = "Primär attribut: Intelligens, 6 poäng. \n Hälsa: 2";
                    intelligence = 6;
                    agility = 0;
                    strength = 0;
                    health = 2;
                }
            }

            // ===== Fällor =====

            if (TheType == CardType.Trap)
            {
                type = CardType.Trap;
                System.Threading.Thread.Sleep(randomTime);
                Random randomTrapType = new Random();

                int randomTrap = randomTrapType.Next(1, 4);

                if (randomTrap == 1)
                {
                    name = "Musfälla";
                    description = "Du går in i musfällan och tar 4 skada. Om du slår under eller lika med din styrka lyckas du böja bort fällan.";
                    actionCode = 6;
                }

                if (randomTrap == 2)
                {
                    name = "Kvast-attack!";
                    description = "Du blir slagen av en kvast och tar 4 skada. Om du slår under eller lika med din smidighet lyckas du undvika attacken.";
                    actionCode = 7;
                }

                if (randomTrap == 3)
                {
                    name = "Råttgift";
                    description = "Du är dum nog att äta råttgift och tar 4 skada. Om du slår under eller lika med din intelligens kommer du på bättre tankar.";
                    actionCode = 8;
                }
            }
        }
    }
}