using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05HTMLDispatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            ElementBuilder div = new ElementBuilder("div");
            div.AddAtributes("id", "page");
            div.AddAtributes("class", "big");
            div.AddContent("<p>Hello</p>");
            Console.WriteLine(div * 2);

            Console.WriteLine(HTMLDispatcher.CreateImage("http://image.jpg", "this is a great image", "Mona Lisa"));
        }
    }
}
