using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03PCCatalog
{
    class Computer
    {
        private string name;
        private decimal price;
        private Components[] components;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Invalid value!");
                }
                this.name = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
        }

        public Components[] Components
        {
            get
            {
                return this.components;
            }
            set
            {
                this.components = value;
            }
        }

        public Computer(string name)
        {
            this.Name = name;
        }

        public Computer(string name, params Components[] components) : this(name)
        {
            this.Components = components;
            foreach (var component in components)
            {
                this.price += component.Price;
            }
        }

        public void Print()
        {
            string header = new string('-', 62) + "\n";
            string description = header;
            string compName = string.Format(" Computer: {0}", this.name);
            description += string.Format("|{0,60}|\n\r", compName);
            description += header;
            description += string.Format("|{0,-40}|{1,-19}|\n\r", " Components", " Price, BGN");
            description += header;

            if (this.components != null)
            {
                foreach (var component in components)
                {
                    description += string.Format("| {0,-39}| {1,-18:0.00}|\n\r", component.Name, component.Price);
                }
                description += header;
            }

            if (components != null)
            {
                description += string.Format("| {0,-39}| {1,-18:0.00}|\n\r", "Total price", this.price);
                description += header;
            }

            Console.WriteLine(description);
        }
    }
}
