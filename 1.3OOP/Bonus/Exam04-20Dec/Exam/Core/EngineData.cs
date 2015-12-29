using System;
using System.Collections.Generic;
using Exam.Interfaces;

namespace Exam.Core
{
    public class EngineData : IBlobData
    {
        private readonly ICollection<IBlob> blobs = new List<IBlob>();

        public EngineData()
        {
            
        }

        public ICollection<IBlob> Blobs => this.blobs;
        public void AddBlob(IBlob blob)
        {
            if (blob == null)
            {
                throw new ArgumentNullException(nameof(blob));
            }
            Blobs.Add(blob);
        }
    }
}