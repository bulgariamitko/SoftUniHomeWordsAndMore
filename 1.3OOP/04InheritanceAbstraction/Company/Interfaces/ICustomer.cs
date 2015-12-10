namespace Company.Interfaces
{
    public interface ICustomer
    {
        double PerchuseAmount { get; }
        void AddPerchuse(double amount);
    }
}