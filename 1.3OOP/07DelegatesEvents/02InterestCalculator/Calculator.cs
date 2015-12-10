using System;

namespace _02InterestCalculator
{
    public delegate double CalculateInterest(double sum, double interest, int years);

    public class Calculator
    {
        public decimal Sum { get; set; }
        public decimal Interest { get; set; }
        public int Years { get; set; }
        public decimal InterestCalculator { get; set; }

        public Calculator(decimal sum, decimal interest, int years, Func<decimal, decimal, int, decimal> interestCalculator)
        {
            Sum = sum;
            Interest = interest;
            Years = years;
            InterestCalculator = interestCalculator(sum, interest, years);
        }

        public override string ToString()
        {
            return string.Format("Money = {0}\nInterest = {1}\nYears = {2}\nTotalSum = {3:F4}\n", this.Sum, this.Interest, this.Years, this.InterestCalculator);
        }
    }
}