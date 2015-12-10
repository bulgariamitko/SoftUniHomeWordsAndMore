namespace _02Bank
{
    public class Mortgage : Account
    {
        private const int GratisIndividuals = 6;
        private const int PromoPeriodCompanies = 12;
        private const decimal PromoInterestCompanies = 0.5M;

        public Mortgage(Customer customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
        {
        }

        public override decimal CalInterest(int months)
        {
            decimal interest = 0;

            if (this.Customer is Individuals && months > GratisIndividuals)
            {
                interest = this.Balance*(1 + (this.InterestRate/100)*(months - GratisIndividuals));
            }
            else if (this.Customer is Companies && months <= PromoPeriodCompanies)
            {
                interest = this.Balance*(1 + (this.InterestRate/100)*PromoPeriodCompanies*months);
            }
            else if (this.Customer is Companies && months > PromoPeriodCompanies)
            {
                interest = this.Balance*(1 + (this.InterestRate/100)*PromoInterestCompanies*PromoPeriodCompanies) +
                           this.Balance*(1 + (this.InterestRate/100)*(months - PromoPeriodCompanies));
            }

            return interest;
        }
    }
}