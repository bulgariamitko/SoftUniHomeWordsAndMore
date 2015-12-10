namespace _02Bank
{
    public class Loan : Account
    {
        private const int GratisIndividuals = 3;
        private const int GratisCompanies = 2;

        public Loan(Customer customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
        {

        }

        public override decimal CalInterest(int months)
        {
            decimal interest = 0;

            if (this.Customer is Individuals && months > GratisIndividuals)
            {
                interest = this.Balance*(1 + (this.InterestRate/100)*(months - GratisIndividuals));
            }
            else if (this.Customer is Companies && months > GratisCompanies)
            {
                interest = this.Balance*(1 + (this.InterestRate/100)*(months - GratisCompanies));
            }

            return interest;
        }
    }
}