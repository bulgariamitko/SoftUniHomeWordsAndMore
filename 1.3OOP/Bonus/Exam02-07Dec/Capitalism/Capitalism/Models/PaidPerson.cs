using System;
using Capitalism.Interfaces;

namespace Capitalism
{
    public abstract class PaidPerson : IPaidPerson
    {
        private string firstName;
        private string lastName;
        private decimal salary;

        protected PaidPerson(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                ValidationNullOrEmpty(value, "First name");
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                ValidationNullOrEmpty(value, "Last name");
                lastName = value;
            }
        }

        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("salary", "The salary cannot be 0 or negative value!");
                }
                salary = value;
            }
        }

        public void ValidationNullOrEmpty(string text, string input)
        {
            if (string.IsNullOrWhiteSpace(text) || text.Length < 2)
            {
                throw new ArgumentException("{0} cannot be null, empty or whitespace only!", input);
            }
        }
    }
}