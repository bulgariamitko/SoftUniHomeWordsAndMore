using System;
using Logger.Interfaces;

namespace Logger
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(IFormatter formatter) : base(formatter)
        {

        }

        public void Append(string msg, ReportLevel level, DateTime date)
        {
            string output = this.Formatter.Format(msg, level, date);
            Console.WriteLine(output);
        }
    }
}