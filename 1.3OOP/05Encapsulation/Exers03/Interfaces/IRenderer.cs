using System;

namespace Exers03.Interfaces
{
    public interface IRenderer
    {
        void WriteLine(string message, params string[] parameters);
    }
}