using System;

namespace _01GPS
{
    public struct Location
    {
        private double latitude;
        private double longitude;
        private Planet planet;

        public double Latitude
        {
            get { return latitude; }
            set
            {
                if (value < -90 || value > 90)
                {
                    throw new ArgumentOutOfRangeException("The latitude should be between -90 and 90 degrees.");
                }
                latitude = value;
            }
        }

        public double Longitude
        {
            get { return longitude; }
            set
            {
                if (value < -180 || value > 180)
                {
                    throw new ArgumentOutOfRangeException("The longitude should be between -180 and 180 degrees.");
                }
                longitude = value;
            }
        }

        public Planet Planet
        {
            get { return planet; }
            set { planet = value; }
        }

        public Location(double latitude, double longitude, Planet planet) : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        public override string ToString()
        {
            return String.Format("{1}, {2} - {0}", Planet, Latitude, Longitude);
        }
    }
}