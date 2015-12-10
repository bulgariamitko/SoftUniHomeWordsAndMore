using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02LaptopShop
{
    class Laptop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private int? ram;
        private string graphicCard;
        private string hdd;
        private string screen;
        private Battery battery;
        private decimal price;

        public string Model {
            get
            {
                return this.model;
            }
            set
            {
                if (value != null && value == string.Empty)
                {
                    throw new ArgumentException("Invalid input!");
                }
                else
                {
                    this.model = value;
                }
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (value != null && value == string.Empty)
                {
                    throw new ArgumentException("Invalid input!");
                }
                else
                {
                    this.manufacturer = value;
                }
            }
        }

        public string Processer
        {
            get
            {
                return this.processor;
            }
            set
            {
                if (value != null && value == string.Empty)
                {
                    throw new ArgumentException("Invalid input!");
                }
                else
                {
                    this.processor = value;
                }
            }
        }

        public int? Ram
        {
            get
            {
                return this.ram;
            }
            set
            {
                if (value != null && value < 0)
                {
                    throw new ArgumentException("Invalid amount of RAM.");
                }
                this.ram = value;
            }
        }

        public string GraphicCard
        {
            get
            {
                return this.graphicCard;
            }
            set
            {
                if (value != null && value == string.Empty)
                {
                    throw new ArgumentException("Invalid input!");
                }
                else
                {
                    this.graphicCard = value;
                }
            }
        }

        public string Hdd
        {
            get
            {
                return this.hdd;
            }
            set
            {
                if (value != null && value == string.Empty)
                {
                    throw new ArgumentException("Invalid input!");
                }
                else
                {
                    this.hdd = value;
                }
            }
        }

        public string Screen
        {
            get
            {
                return this.screen;
            }
            set
            {
                if (value != null && value == string.Empty)
                {
                    throw new ArgumentException("Invalid input!");
                }
                else
                {
                    this.screen = value;
                }
            }
        }

        public Battery Battery { get; set; }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public Laptop(string model, decimal price, string manufacturer = null, string processor = null, int? ram = null, string graphicCard = null, string hdd = null, string screen = null, Battery battery = null)
        {
            this.Model = model;
            this.Price = price;
            this.Manufacturer = manufacturer;
            this.Processer = processor;
            this.Ram = ram;
            this.GraphicCard = graphicCard;
            this.Hdd = hdd;
            this.Screen = screen;
            this.Battery = battery;
        }

        public override string ToString()
        {
            string output = string.Format("Model {0}\n\r", this.Model);

            if (!string.IsNullOrEmpty(this.Manufacturer))
            {
                output += string.Format("Manufacturer: {0}\n\r", this.Manufacturer);
            }
            if (!string.IsNullOrEmpty(this.Processer))
            {
                output += string.Format("Processer: {0}\n\r", this.Processer);
            }
            if (Ram != null)
            {
                output += string.Format("Ram: {0} GB\n\r", this.Ram);
            }
            if (!string.IsNullOrEmpty(this.GraphicCard))
            {
                output += string.Format("GraphicCard: {0}\n\r", this.GraphicCard);
            }
            if (!string.IsNullOrEmpty(this.Hdd))
            {
                output += string.Format("Hdd: {0}\n\r", this.Hdd);
            }
            if (!string.IsNullOrEmpty(this.Screen))
            {
                output += string.Format("Screen: {0}\n\r", this.Screen);
            }
            if (Battery != null)
            {
                output += string.Format("{0}\n\r", this.Battery);
            }

            output += string.Format("Price: {0} lv.\n\r", this.Price);
            return output;
        }

    }
}
