using System;
using Exers03.Interfaces;

namespace Exers03.UI
{
    public class ConsoleInputHandler : IInputHandler
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}