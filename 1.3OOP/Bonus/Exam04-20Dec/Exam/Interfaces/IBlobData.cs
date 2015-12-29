using System.Collections.Generic;

namespace Exam.Interfaces
{
    public interface IBlobData
    {
        ICollection<IBlob> Blobs { get; }

        void AddBlob(IBlob blob);
    }
}