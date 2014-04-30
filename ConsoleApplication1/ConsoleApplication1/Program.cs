using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                Random randomMonsterType = new Random();

                int randomMonster = randomMonsterType.Next(1, 7);

                Console.WriteLine(randomMonster);

                System.Threading.Thread.Sleep(1000);
            } while (true);
        }
    }
}
