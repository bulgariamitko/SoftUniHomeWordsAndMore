namespace BigMani.IO
{
    using System;

    using BigMani.Interfaces;

    public class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
