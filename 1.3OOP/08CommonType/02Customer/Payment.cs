using System;

namespace _02Customer
{
    public class Payment
    {
        private const double MinPrice = 0;

        private double _price;
        private string _productName;

        public Payment(string productName, double price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName
        {
            get
            {
                return this._productName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "Product name cannot be null, empty or white space.");
                }
                this._productName = value;
            }
        }

        public double Price
        {
            get
            {
                return this._price;
            }

            set
            {
                if (value <= MinPrice)
                {
                    throw new ArgumentOutOfRangeException("value", "Price cannot be negative or zero.");
                }
                this._price = value;
            }
        }
    }
}