using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02LaptopShop
{
    class Battery
    {
        private string batteryType;
        private double? batteryLife;

        public string BatteryType {
            get
            {
                return this.batteryType;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("Invalid input!");
                }
                else
                {
                    this.batteryType = value;
                }
            }
        }

        public double? BatteryLife
        {
            get
            {
                return this.batteryLife;
            }
            set
            {
                if (value == null || value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                else
                {
                    this.batteryLife = value;
                }
            }
        }

        public Battery(string batteryType = null, double? batteryLife = null)
        {
            this.BatteryType = batteryType;
            this.BatteryLife = batteryLife;
        }

        public override string ToString()
        {
            return string.Format("Battery type: {0}, Battery life: {1} hours", this.BatteryType, this.BatteryLife);
        }
    }
}
