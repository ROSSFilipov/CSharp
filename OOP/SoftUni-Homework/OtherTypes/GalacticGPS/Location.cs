using GalacticGPS.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticGPS
{
    public struct Location
    {
        private const int MIN_LATITUDE = -90;
        private const int MAX_LATITUTE = 90;
        private const int MIN_LONGITUDE = -180;
        private const int MAX_LONGITUTE = 180;

        private double latitude;

        private double longitude;

        private Planet planet;

        public Location(double latitude, double longitude, Planet planet) 
            : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        public double Latitude
        {
            get
            {
                return this.latitude;
            }
            set
            {
                if (value < MIN_LATITUDE || value > MAX_LATITUTE)
                {
                    throw new LatitudeException(string.Format("The latitude must be in the range [{0}...{1}]!",
                        MIN_LATITUDE, MAX_LATITUTE));
                }

                this.latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return this.longitude;
            }
            set
            {
                if (value < -180 || value > 180)
                {
                    throw new LongitudeException(string.Format("The longitude must be in the range [{0}...{1}]!",
                        MIN_LONGITUDE, MAX_LONGITUTE));
                }

                this.longitude = value;
            }
        }

        public Planet Planet
        {
            get
            {
                return this.planet;
            }
            set
            {
                this.planet = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Location: {0}, {1} - {2}", this.Latitude, this.Longitude, this.Planet);
        }
    }
}
