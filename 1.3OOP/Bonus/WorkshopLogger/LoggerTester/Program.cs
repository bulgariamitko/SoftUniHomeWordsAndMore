using System;
using Logger;
using Logger.Formatters;
using Logger.Interfaces;

namespace LoggerTester
{
    class Program
    {
        static void Main()
        {
            IFormatter formatter = new JsonFormatter();
            FileAppender appender = new FileAppender("../../file.txt", formatter);
            Logger.Logger logger = new Logger.Logger(appender);

            int a = 5;

            try
            {
                logger.Critical("a cannot be 5");
                logger.Warn("Be carful for that 5!");
            }
            finally
            {

                appender.Close();
            }
        }
    }
}
