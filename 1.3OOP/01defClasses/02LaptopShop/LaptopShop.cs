using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02LaptopShop
{
    class LaptopShop
    {
        static void Main(string[] args)
        {
            Laptop myLaptop = new Laptop("Lenova Yoga 2 Pro", 2259.00M, "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache", 8, "Intel HD Graphics 4400", "128GB SSD", "13.3\" (33.78cm) - 3200x1800 (QHD+), IPS sensor display", new Battery("Li-Ion, 4-cells,2550 mAh", 4.5));
            Laptop otherLaptop = new Laptop("HP 250 G2", 699.00M);
            Laptop yetOtherLaptop = new Laptop("Acer Aspire 5750G", 1499.00M);

            yetOtherLaptop.GraphicCard = "GeForce 550M";
            yetOtherLaptop.Ram = 8;
            yetOtherLaptop.Hdd = "128GB SSD";

            Console.WriteLine("Sample laptop description (full)");
            Console.WriteLine(myLaptop);
            Console.WriteLine();
            Console.WriteLine("Sample laptop description mandatory properties only");
            Console.WriteLine(otherLaptop);
            Console.WriteLine("My persoanl laptop");
            Console.WriteLine(yetOtherLaptop);
        }
    }
}
