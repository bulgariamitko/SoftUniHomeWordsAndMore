using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> myIntList = new GenericList<int>(2);

            myIntList.Add(34);
            myIntList.Add(23);
            myIntList.Add(-1);
            myIntList.Add(4344);
            myIntList[3] = 0;
            myIntList.Add(122);

            Console.WriteLine(myIntList);

            myIntList.RemoveAtIndex(2);

            myIntList.InsertAtIndex(0, 0);
            Console.WriteLine(myIntList);

            Console.WriteLine(myIntList.Find(23));
            Console.WriteLine(myIntList.Contains(145));

            Console.WriteLine(myIntList.Min());
            Console.WriteLine(myIntList.Max());

            myIntList.Clear();
            Console.WriteLine(myIntList);

            GenericList<string> myStrList = new GenericList<string>();

            myStrList.Add("ivan");
            myStrList.Add("asen");
            myStrList.Add("gosho");
            myStrList.Add("pesho");

            myStrList.InsertAtIndex("bobi", 0);
            myStrList.RemoveAtIndex(1);

            Console.WriteLine(myStrList);

        }
    }
}
