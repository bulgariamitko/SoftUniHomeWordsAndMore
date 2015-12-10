using System;

namespace _02Bank
{
    public abstract class Customer
    {
        private string name;
        private long customerId;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name cannot be null or empty!");
                }
                name = value;
            }
        }

        public long CustomerId
        {
            get { return customerId; }
            set
            {
                if (value <= 0)
                {
                    throw new AggregateException("The value cannot be less or equil to 0");
                }
                customerId = value;
            }
        }

        protected Customer(string name, long customerId)
        {
            this.Name = name;
            this.CustomerId = customerId;
        }
    }
}