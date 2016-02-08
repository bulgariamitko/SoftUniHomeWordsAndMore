namespace BigMani.Models
{
    using System;
    using IO;

    public class AirConditioner : IAirConditioner
    {
        private const int MinCarVolume = 3;
        private const int MinPlaneElectricity = 150;
        private const int ManufacturerMinLength = 4;
        private const int ModelMinLength = 2;

        private string manufacturer;

        private readonly int PowerUsage;
        private int volumeCovered;
        private int electricityUsed;
        private readonly string type;
        private string model;

        public AirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            switch (energyEfficiencyRating)
            {
                case "A":
                    this.EnergyRating = 10;
                    break;
                case "B":
                    this.EnergyRating = 12;
                    break;
                case "C":
                    this.EnergyRating = 15;
                    break;
                case "D":
                    this.EnergyRating = 20;
                    break;
                case "E":
                    this.EnergyRating = 90;
                    break;
            }

            this.PowerUsage = powerUsage;
            this.type = "stationary";
        }

        public AirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.VolumeCovered = volumeCoverage;
            this.ElectricityUsed = Convert.ToInt32(electricityUsed);
            this.type = "plane";
        }

        public AirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.VolumeCovered = volumeCoverage;
            this.type = "car";
        }

        public int EnergyRating { get; set; }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < ManufacturerMinLength)
                {
                    throw new ArgumentException(string.Format("{0}'s name must be at least {1} symbols long.", this.Manufacturer, ManufacturerMinLength));
                }

                this.manufacturer = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < ModelMinLength)
                {
                    throw new ArgumentException(string.Format("{0}'s name must be at least {1} symbols long.", this.Model, ModelMinLength));
                }

                this.model = value;
            }
        }

        public int VolumeCovered
        {
            get
            {
                return this.volumeCovered;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format("{0} must be a positive integer.", this.VolumeCovered));
                }

                this.volumeCovered = value;
            }
        }

        public int ElectricityUsed
        {
            get
            {
                return this.electricityUsed;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format("{0} must be a positive integer.", this.ElectricityUsed));
                }

                this.electricityUsed = value;
            }
        }

        public int Test()
        {
            if (this.type == "stationary")
            {
                if (this.PowerUsage / 100 <= this.EnergyRating)
                {
                    return 1;
                }
            }
            else if (this.type == "car")
            {
                double sqrtVolume = Math.Sqrt(this.volumeCovered);
                if (sqrtVolume < MinCarVolume)
                {
                    return 1;
                }

                return 2;
            }
            else if (this.type == "plane")
            {
                double sqrtVolume = Math.Sqrt(this.volumeCovered);
                if (this.ElectricityUsed / sqrtVolume < MinPlaneElectricity)
                {
                    return 1;
                }
            }

            return 0;
        }

        public override string ToString()
        {
            string print = "Air Conditioner" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " +
                           this.Manufacturer + "\r\n" + "Model: " + this.Model + "\r\n";

            if (this.type == "stationary")
            {
                string energy = string.Empty;
                switch (this.EnergyRating)
                {
                    case 10:
                        energy = "A";
                        break;
                    case 12:
                        energy = "B";
                        break;
                    case 15:
                        energy = "C";
                        break;
                    case 20:
                        energy = "D";
                        break;
                    case 90:
                        energy = "E";
                        break;
                }

                print += "Required energy efficiency rating: " + energy + "\r\n" + "Power Usage(KW / h): " +
                         this.PowerUsage + "\r\n";
            }
            else if (this.type == "car")
            {
                print += "Volume Covered: " + this.VolumeCovered + "\r\n";
            }
            else
            {
                print += "Volume Covered: " + this.VolumeCovered + "\r\n" + "Electricity Used: " + this.ElectricityUsed + "\r\n";
            }

            print += "====================";

            return print;
        }
    }
}
