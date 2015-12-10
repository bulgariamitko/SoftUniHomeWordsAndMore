using System;
using Company.Interfaces;

namespace Company
{
    public class Customer : Person, ICustomer
    {
        private double perchuseAmount;

        public double PerchuseAmount
        {
            get { return perchuseAmount; }
            set { perchuseAmount = value; }
        }

        public Customer(int id, string firstName, string lastName) : base(id, firstName, lastName)
        {
            
        }

        public void AddPerchuse(double purchase)
        {
            perchuseAmount += purchase;
        }

        public override string ToString()
        {
            return String.Format("Customer: {0} {1}, Net profit: {2}", FirstName, LastName, PerchuseAmount);
        }
    }
}