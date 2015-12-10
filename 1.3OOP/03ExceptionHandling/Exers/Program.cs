using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exers
{
    class Program
    {
        static void Main()
        {
            Person pesho = new Person("Pesho", "Peshev", 24);

            
            try
            {
                Person onName = new Person(string.Empty, "Gosho", 31);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }

            try
            {
                Person noLastName = new Person("Ivan", String.Empty, 63);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }

            try
            {
                Person negativeAge = new Person("Stoyan", "Kolev", -1);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }

            try
            {
                Person tooOld = new Person("Iskren", "Ivanov", 121);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }
        }
    }
}
