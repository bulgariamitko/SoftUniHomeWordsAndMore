using System;

namespace Company.Types
{
    public class Sale
    {
        private string name;
        private DateTime date;
        private double price;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public Sale(string name, DateTime date, double price)
        {
            Name = name;
            Date = date;
            Price = price;
        }

        public override string ToString()
        {
            return string.Format("Date: {0}, Product: {1}, Price: {2:F2}", Date.ToShortDateString(), Name, Price);
        }
    }
}