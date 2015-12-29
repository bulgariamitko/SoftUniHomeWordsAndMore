namespace Exam.Interfaces
{
    public interface ICreateBlobFactory
    {
        IBlob CreateBlob(string name, int health, int attackDamage);
    }
}