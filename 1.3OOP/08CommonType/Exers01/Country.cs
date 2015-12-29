using System;
using System.Collections.Generic;

namespace Exers01
{
    internal class Country : ICloneable, IComparable<Country>
    {
        private IList<string> cities;
        private double area;
        private string name;
        private long population;

        public Country(string name, long population, double area)
        {
            this.Name = name;
            this.Population = population;
            this.Area = area;
        }

        public Country(string name, long population, double area, IList<string> cities)
            : this(name, population, area)
        {
            this.Cities = cities;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Name can't be null.");
                }

                this.name = value;
            }
        }

        public long Population
        {
            get
            {
                return this.population;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Population can't be negative.");
                }

                this.population = value;
            }
        }

        public double Area
        {
            get
            {
                return this.area;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Area can't be negative.");
                }

                this.area = value;
            }
        }

        public IList<string> Cities { get; set; }

        public object Clone()
        {
            return new Country(this.Name, this.Population, this.Area, new List<string>(this.Cities));
        }

        public int CompareTo(Country other)
        {
            var country = other;
            if (country != null)
            {
                if (country.Area > this.Area)
                {
                    return 1;
                }

                if (country.Population > this.Population)
                {
                    return 1;
                }

                return country.Name.CompareTo(Name);
            }

            return 0;
        }

        public static bool operator ==(Country first, Country second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Country first, Country second)
        {
            return !first.Equals(second);
        }

        public override bool Equals(object obj)
        {
            if (obj is Country)
            {
                var otherCoutry = (Country)obj;

                if (this.Name == otherCoutry.Name)
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Name.GetHashCode();
        }
    }
}