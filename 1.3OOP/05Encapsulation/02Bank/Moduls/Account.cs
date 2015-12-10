using System;
using _02Bank.Interfaces;

namespace _02Bank
{
    public abstract class Account : IDepositable, IInterestable
    {
        private Customer customer;
        private decimal balance;
        private decimal interestRate;

        public Customer Customer
        {
            get { return customer; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Customer cannot be null!");
                }
                customer = value;
            }
        }

        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Balance cannot be negative number!");
                }
                balance = value;
            }
        }

        public decimal InterestRate
        {
            get { return interestRate; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Interest rate cannot be 0 or negative");
                }
                interestRate = value;
            }
        }

        protected Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }


        public virtual void DepositMoney(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("The withdraw amount should be greater than zero!");
            }
            this.Balance += amount;
        }

        public abstract decimal CalInterest(int months);
    }
}