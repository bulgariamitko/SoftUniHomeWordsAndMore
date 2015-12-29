using System.Collections.Generic;

namespace Capitalism.Core.Interfaces
{
    public interface ICommand
    {
        string Name { get; }
        IList<string> Parameters { get; }

    }
}