using System;
using Exers02.Characters;

namespace Exers02
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior conan = new Warrior();
            Warrior hercules = new Warrior();
            Mage mage = new Mage();
            Priest priest = new Priest();

            Console.WriteLine("Round 0:\r\n");
            Console.WriteLine(conan);
            Console.WriteLine(mage);
            Console.WriteLine(priest);

            conan.Attack(mage);
            priest.Heal(mage);
            priest.Attack(conan);

            Console.WriteLine("Round 1:\r\n");
            Console.WriteLine(conan);
            Console.WriteLine(mage);
            Console.WriteLine(priest);
        }
    }
}
