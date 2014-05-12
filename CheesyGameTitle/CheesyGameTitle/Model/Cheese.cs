using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheesyGameTitle
{
    public class Cheese
    {
        int value;
        string name;
        int timesCalled;

        public int getValue()
        {
            return value;
        }

        public string getName()
        {
            return name;
        }

        public int getTimesCalled()
        {
            return timesCalled;
        }

        public void timesCalledPlus()
        {
            timesCalled++;
        }

        public void randomCheese()
        {
            Random randomCheese = new Random();

            int random = randomCheese.Next(1, 7);

            if (random == 1)
            {
                name = "Goudaost";
                value = 10;
            }

            if (random == 2)
            {
                name = "Mozarella";
                value = 20;
            }

            if (random == 3)
            {
                name = "Schweizerost";
                value = 30;
            }

            if (random == 4)
            {
                name = "String Cheese";
                value = 0;
            }

            if (random == 5)
            {
                name = "Fetaost";
                value = 40;
            }

            if (random == 6)
            {
                name = "Parmesanost";
                value = 50;
            }
        }

        public Cheese()
        {
            timesCalled = 1;
        }
    }
}