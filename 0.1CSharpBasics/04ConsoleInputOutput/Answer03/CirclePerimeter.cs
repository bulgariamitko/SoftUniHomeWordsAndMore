using System;

namespace Answer03
{
    class CirclePerimeter
    {
        static void Main()
        {
            Console.WriteLine("Pease, use COMMA and not a dot!!!");
            double num = double.Parse(Console.ReadLine());
            double perCir = 2 * Math.PI * num;
            double areaCir = Math.PI * num * num;

            Console.WriteLine("The perimeter is: {0}\nThe area is {1}", String.Format("{0:0.00}", perCir), String.Format("{0:0.00}", areaCir));
        }
    }
}
