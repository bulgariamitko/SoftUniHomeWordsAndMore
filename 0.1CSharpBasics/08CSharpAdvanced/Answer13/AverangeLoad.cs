using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer13
{
    class AverangeLoad
    {
        static void Main(string[] args)
        {
            Console.Write("Enter parameters: ");
            string namesString = Console.ReadLine();
            string[] allNames = namesString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> letters = allNames.ToList<string>();
            letters.RemoveAt(0);
            letters.RemoveAt(0);
            Console.WriteLine("Write 'results' when you are done to see the results OR enter more data!");

            while (namesString != "")
            {
                Console.Write("Enter parameters: ");
                namesString = Console.ReadLine();
                if (namesString == "results" || namesString == "")
                {
                    break;
                }
                allNames = namesString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                List<string> letters2 = allNames.ToList<string>();
                letters.Add(letters2[2]);
                letters.Add(letters2[3]);
            }

            if (namesString == "")
            {
                Console.WriteLine("Something went wrong and the proggrame will now exit. Write 'results' to see the results!");
            }

            double softUniCounter = 0;
            double softUniTime = 0;
            double googleCounter = 0;
            double googleTime = 0;
            double nakovCounter = 0;
            double nakovTime = 0;
            for (int i = 0; i < letters.Count; i++)
            {
                if (letters[i] == "http://softuni.bg")
                {
                    softUniCounter++;
                    softUniTime = softUniTime + Convert.ToDouble(letters[i + 1], System.Globalization.CultureInfo.InvariantCulture);
                }
                else if (letters[i] == "http://www.google.com")
                {
                    googleCounter++;
                    googleTime = googleTime + Convert.ToDouble(letters[i + 1], System.Globalization.CultureInfo.InvariantCulture);
                }
                else if (letters[i] == "http://www.nakov.com")
                {
                    nakovCounter++;
                    nakovTime = nakovTime + Convert.ToDouble(letters[i + 1], System.Globalization.CultureInfo.InvariantCulture);
                }
            }

            Console.WriteLine("The results are:");
            if (softUniCounter > 0)
            {
                Console.WriteLine("http://softuni.bg -> " + softUniTime / softUniCounter);
            }
            if (googleCounter > 0)
            {
                Console.WriteLine("http://google.com -> " + googleTime / googleCounter);
            }
            if (nakovCounter > 0)
            {
                Console.WriteLine("http://nakov.com -> " + nakovTime / nakovCounter);
            }
        }
    }
}
