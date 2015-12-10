using System;
using Exers03.Interfaces;

namespace Exers03.UI
{
    public class ConsoleRenderer : IRenderer
    {
        public void WriteLine(string message, params string[] parameters)
        {
            Console.WriteLine(message, parameters);
        }
    }
}