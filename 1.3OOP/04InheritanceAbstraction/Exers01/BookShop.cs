using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exers01
{
    class BookShop
    {
        static void Main(string[] args)
        {
            Book book = new Book("Pod Igoto", "Ivan Vazov", 15.90M);
            Console.WriteLine(book);

            GoldenEditionBook goldenBook = new GoldenEditionBook("Tutun", "Dimitar Dimov", 22.90M);
            Console.WriteLine(goldenBook);
        }
    }
}
