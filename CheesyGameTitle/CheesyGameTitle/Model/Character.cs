using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheesyGameTitle
{
    public class Character
    {
        // ============== Fält ===================

        private int health;
        private int agility;
        private int strength;
        private int intelligence;
        private string name;

        // ============== Access ===================

        public int getHealth()
        {
            return health;
        }

        public void setHealth(int value)
        {
            health = value;
        }

        public int getAgility()
        {
            return agility;
        }

        public int getStrength()
        {
            return strength;
        }

        public int getIntelligence()
        {
            return intelligence;
        }

        public string getName()
        {
            return name;
        }

        // ============== Konstruktor ===================

        public Character(int value)
        {
            if (value == 1)
            {
                strength = 6;
                agility = 3;
                intelligence = 2;
                health = 10;
                name = "Roger Råtta";
            }

            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        // ============== Metoder ===================
    }
}