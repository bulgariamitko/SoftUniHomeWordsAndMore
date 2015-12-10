using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer19
{
    class StudentCables
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            var metersCables = new List<int>();
            for (int i = 0; i < input; i++)
            {
                int cable = int.Parse(Console.ReadLine());
                string meters = Console.ReadLine();

                if (cable < 20 && meters == "centimeters")
                {
                    continue;
                }
                if (meters == "meters")
                {
                    cable = cable * 100;
                }
                metersCables.Add(cable);
            }
            
            int joinCables = 0;
            foreach (var item in metersCables)
            {
                joinCables = joinCables + item;
            }

            int joinedCable = joinCables - 3 * (metersCables.Count - 1);

            Console.WriteLine(joinedCable / 504);
            Console.WriteLine(joinedCable % 504);
        }
    }
}
