using Capitalism.Core.Interfaces;
using Capitalism.Core.Interfaces.UserInterfaces;

namespace Capitalism.Core
{
    public class CapitalismEngine : IEngine
    {
        private IUserInterface userInterface;
        private ICommandExecutor commandExecutor;

        public CapitalismEngine()
        {
            this.userInterface = new ConsoleUserInterface();
            this.commandExecutor = new CapitalismCommandExecutor();
        }

        public void Run()
        {
            while (true)
            {
                string commandLine = this.userInterface.ReadLine();
                if (commandLine == "end")
                {
                    break;
                }
                var command = new Command(commandLine);
                string CommandResult = this.commandExecutor.ExecuteCommand(command);
                if (CommandResult != null)
                {
                    userInterface.WriteLine(CommandResult);
                }
            }
        }
    }
}