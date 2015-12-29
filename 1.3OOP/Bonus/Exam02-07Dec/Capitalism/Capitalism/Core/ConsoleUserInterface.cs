using System;
using Capitalism.Core.Interfaces.UserInterfaces;

namespace Capitalism.Core
{
    public class ConsoleUserInterface : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }

        public void WriteLine(string str, params object[] args)
        {
            Console.WriteLine(str, args);
        }
    }
}