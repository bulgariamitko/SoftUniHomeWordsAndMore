using System.Collections.Specialized;

namespace Exam.Interfaces
{
    public interface IBlob : IAttacker, IDestroyable, IAttack, IUpdatable
    {
         string Name { get; }
    }
}