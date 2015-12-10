using System;
using _02Bank.Interfaces;

namespace _02Bank
{
    public class Deposit : Account, IWithdrawable
    {
        private const int MinBalance = 1000;

        public Deposit(Customer customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
        {

        }

        public override decimal CalInterest(int months)
        {
            decimal interest = this.Balance*(1 + (this.InterestRate/100)*months);
            if (this.Balance <= MinBalance)
            {
                interest = 0;
            }

            return interest;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("The withdraw amount should be greater than zero!");
            }
            if (amount > this.Balance)
            {
                throw new ArgumentNullException("The withdraw amount can not exceed the current account balance!");
            }
            this.Balance -= amount;
        }
    }
}