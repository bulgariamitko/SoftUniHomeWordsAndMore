using System;
using Logger;
using Logger.Interfaces;

namespace LoggerTester
{
    public class JsonFormatter : IFormatter
    {
        public string Format(string msg, ReportLevel level, DateTime date)
        {
            return string.Format("Josn format: {0}, {1}, {2}", date, level, msg);
        }
    }
}