using System;

namespace Answer06
{
    class StringsObjects
    {
        static void Main(string[] args)
        {
            string Hello = "Hello";
            string World = "World";
            object HelloWorld = Hello + " " + World;
            string toString = (string)HelloWorld;
            Console.WriteLine(toString);
        }
    }
}
