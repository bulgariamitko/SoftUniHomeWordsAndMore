using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03PCCatalog
{
    class Components
    {
        private string name;
        private string details;
        private decimal price;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Invalid input");
                }
                this.name = value;
            }
        }

        public string Details
        {
            get
            {
                return this.details;
            }
            set
            {
                this.details = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input");
                }
                this.price = value;
            }
        }

        public Components()
        {
        }

        public Components(string name, decimal price) : this()
        {
            this.Name = name;
            this.Price = price;
        }

        public Components(string name, decimal price, string details) : this(name, price)
        {
            this.Details = details;
        }

        public override string ToString()
        {
            return string.Format("Component name: {0}, component price: {1}", this.name, this.price);
        }
    }
}
