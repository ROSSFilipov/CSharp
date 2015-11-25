using GalacticGPS.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticGPS
{
    class GalacticGPS
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Planet planet;
                double latitude;
                double longitude;
                try
                {
                    Console.WriteLine("Please enter location details in the format: Latitude Longitude Planet");
                    string[] currentLine = Console.ReadLine()
                        .Split(new []{ ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    bool validLatitude = double.TryParse(currentLine[0], out latitude);

                    if (!validLatitude)
                    {
                        throw new LatitudeException("Invalid latitude input!");
                    }

                    bool validLongitude = double.TryParse(currentLine[1], out longitude);

                    if (!validLatitude)
                    {
                        throw new LongitudeException("Invalid longitude input!");
                    }

                    planet = ValidatePlanet(currentLine[2]);

                    latitude = double.Parse(currentLine[0]);
                    longitude = double.Parse(currentLine[1]);

                    Location home = new Location(latitude, longitude, planet);
                    Console.WriteLine(home);
                    break;
                }
                catch (LatitudeException ex)
                {
                    Console.WriteLine(ex.Message);   
                }
                catch (LongitudeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (PlanetException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static Planet ValidatePlanet(string input)
        {
            switch (input)
            {
                case "Mercury": 
                    return Planet.Mercury;
                case "Venus": 
                    return Planet.Venus;
                case "Mars": 
                    return Planet.Mars;
                case "Jupiter": 
                    return Planet.Jupiter;
                case "Saturn": 
                    return Planet.Saturn;
                case "Neptune": 
                    return Planet.Neptune;
                case "Uranus": 
                    return Planet.Uranus;
                case "Earth": 
                    return Planet.Earth;
                default:
                    {
                        throw new PlanetException("Invalid planet input!");
                    }
            }
        }
    }
}
