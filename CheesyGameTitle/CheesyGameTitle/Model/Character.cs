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
        private int maxHealth;
        private int turns;

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

        public void setAgility(int value)
        {
            agility = value;
        }

        public int getStrength()
        {
            return strength;
        }

        public void setStrength(int value)
        {
            strength = value;
        }

        public int getIntelligence()
        {
            return intelligence;
        }

        public void setIntelligence(int value)
        {
            intelligence = value;
        }

        public string getName()
        {
            return name;
        }

        public int getMaxHealth()
        {
            return maxHealth;
        }

        public int getTurns()
        {
            return turns;
        }

        public void plusTurn()
        {
            turns++;
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
                maxHealth = 10;
                name = "Martin Mus";
            }

            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        // ============== Metoder ===================
    }
}