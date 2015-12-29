namespace Capitalism.Core.Interfaces
{
    public interface ICommandExecutor
    {
        string ExecuteCommand(ICommand command);
    }
}