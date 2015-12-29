using Logger.Formatters;
using Logger.Interfaces;

namespace Logger
{
    class Program
    {
        static void Main()
        {
            IFormatter formatter = new XmlFormatter();
            IAppender consoleAppender = new ConsoleAppender(formatter);

            Logger logger = new Logger(consoleAppender);
            logger.Critical("Out of memory");
            logger.Info("Unused local variable 'name'");
        }
    }
}
