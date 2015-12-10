using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04GenericVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<string> myStrList = new GenericList<string>();

            myStrList.Add("ivan");
            myStrList.Add("asen");
            myStrList.Add("gosho");
            myStrList.Add("pesho");

            myStrList.InsertAtIndex("bobi", 0);
            myStrList.RemoveAtIndex(1);

            Console.WriteLine(myStrList);

            myStrList.GetVersion();
        }
    }
}
