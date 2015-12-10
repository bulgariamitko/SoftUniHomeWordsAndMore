using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace _04StudentClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Peter", 22);
            student.PropertyHandlerChanged += (sender, eventArgs) =>
            {
                Console.WriteLine("Property changed: {0} (from {1} to {2})", eventArgs.PropertyName, eventArgs.OldValue,
                    eventArgs.NewValue);
            };
            student.Name = "Maria";
            student.Age = 19;
        }
    }
}
