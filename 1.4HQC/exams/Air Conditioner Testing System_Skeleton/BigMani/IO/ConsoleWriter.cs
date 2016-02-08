namespace BigMani.IO
{
    using System;

    using BigMani.Interfaces;

    public class ConsoleWriter : IOutputWriter
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}