using System;

namespace Exers01
{
    public class AnimalFarm
    {
        public static void Main()
        {
            Chicken chicken = new Chicken("Mara", 3);
            Console.WriteLine(chicken.ProductPerDay);
        }
    }
}