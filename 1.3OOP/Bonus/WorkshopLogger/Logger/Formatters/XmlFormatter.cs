using System;
using Logger.Interfaces;

namespace Logger.Formatters
{
    public class XmlFormatter : IFormatter
    {
        public string Format(string msg, ReportLevel level, DateTime date)
        {
            return string.Format("<log>\n<message>{0}</message>\n<date>{1}</date>\n<level>{2}</level>\n</log>\n", msg,
                date, level);
        }
    }
}