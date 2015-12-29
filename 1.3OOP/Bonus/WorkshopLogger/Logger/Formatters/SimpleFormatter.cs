using System;
using Logger.Interfaces;

namespace Logger.Formatters
{
    public class SimpleFormatter : IFormatter
    {
        public string Format(string msg, ReportLevel level, DateTime date)
        {
            return string.Format("{0} - {1} - {2}", date, level, msg);
        }
    }
}