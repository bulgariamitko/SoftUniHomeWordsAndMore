namespace Capitalism.Interfaces
{
    public interface IPaidPerson : IPerson
    {
        decimal Salary { get; set; }
    }
}