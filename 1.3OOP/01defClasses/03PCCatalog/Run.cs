using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03PCCatalog
{
    class Run
    {
        static void Main(string[] args)
        {
            Components hdd1 = new Components("128GB SSD", 200);
            Components graphicCard1 = new Components("NVidia GT560", 250);
            Components processor1 = new Components("Intel i5-4210U", 440);
            Components ram1 = new Components("8GB DDR3", 170);

            Components hdd2 = new Components("1TB", 222);
            Components grapicalCard2 = new Components("AMD Radeon R5 M230", 135);
            Components processor2 = new Components("Intel i7-4450", 640);
            Components ram2 = new Components("8GB DDR3", 140);

            Components hdd3 = new Components("2TB", 422);
            Components grapicalCard3 = new Components("AMD Radeon R5 M330", 185);
            Components processor3 = new Components("Intel i3-4450", 240);
            Components ram3 = new Components("4GB DDR3", 40);

            Components hdd4 = new Components("700GB SSD", 582);
            Components grapicalCard4 = new Components("NVidia GT880", 735);
            Components processor4 = new Components("Intel i7-4450", 640);
            Components ram4 = new Components("80GB DDR3", 870);

            List<Computer> computers = new List<Computer>();

            computers.Add(new Computer("Work", hdd1, graphicCard1, processor1, ram1));
            computers.Add(new Computer("Home", hdd2, grapicalCard2, processor2, ram2));
            computers.Add(new Computer("Laptop", hdd3, grapicalCard3, processor3, ram3));
            computers.Add(new Computer("Beast!!!", hdd4, grapicalCard4, processor4, ram4));

            foreach (var computer in computers.OrderBy(x => x.Price))
            {
                computer.Print();
            }
        }
    }
}
