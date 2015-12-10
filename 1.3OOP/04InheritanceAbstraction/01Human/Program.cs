using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Human
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student("Ivan", "Ivanov", "5699745"),
                new Student("Petar", "Petrov", "3214598"),
                new Student("Stoyan", "Dimitrov", "1245896"),
                new Student("Gergana", "Vasileva", "3698547"),
                new Student("Stoil", "Karaivanov", "78413658"),
                new Student("Atanas", "Burov", "1236985"),
                new Student("Genadi", "Trayanov", "6547895"),
                new Student("Borimil", "Ravadinov", "68451119"),
                new Student("Zvezdelin", "Kynchev", "789855245"),
                new Student("Nikolay", "Nikolov", "36589745"),
            };

            List<Worker> workers = new List<Worker>()
            {
                new Worker("Strahil", "Nenchev", 562, 8),
                new Worker("Snezhana", "Atanasova", 124, 4),
                new Worker("Gichka", "Jeleva", 238, 7),
                new Worker("Miroslav", "Chakarov", 1024, 8),
                new Worker("Kostadin", "Goranov", 498, 6),
                new Worker("Agop", "Minosyan", 695, 8),
                new Worker("Lilia", "Uzunova", 398, 8),
                new Worker("Mincho", "Spasov", 190, 8),
                new Worker("Ivan", "Galabov", 502, 8),
                new Worker("Daniel", "Petrov", 412, 7),
            };

            foreach (var student in students.OrderBy(x => x.FacultyNum))
            {
                Console.WriteLine("Name: {0} {1}, FacultyNumber: {2}", student.FirstName, student.LastName, student.FacultyNum);
            }
            Console.WriteLine();

            foreach (var worker in workers.OrderBy(x => x.MoneyPerHour()))
            {
                Console.WriteLine("Name: {0} {1}, Money per hour: {2:F2}", worker.FirstName, worker.LastName, worker.MoneyPerHour());
            }
            Console.WriteLine();

            foreach (var person in students.Concat<Human>(workers).OrderBy(x => x.FirstName).ThenBy(y => y.LastName))
            {
                Console.WriteLine("Name: {0}", person);
            }
        }
    }
}
