namespace Capitalism.Core.Interfaces.UserInterfaces
{
    public interface IWriter
    {
        void WriteLine(string output);
        void WriteLine(string str, params object[] args);
    }
}