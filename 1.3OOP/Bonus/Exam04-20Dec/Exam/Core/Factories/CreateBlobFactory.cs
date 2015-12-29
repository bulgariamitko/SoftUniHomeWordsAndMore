using Exam.Interfaces;
using Exam.Models;

namespace Exam.Core.Factories
{
    public class CreateBlobFactory : ICreateBlobFactory
    {
        public IBlob CreateBlob(string name, int health, int attackDamage)
        {
            return new Blob(name, health, attackDamage);
        }
    }
}