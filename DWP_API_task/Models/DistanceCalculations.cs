using Geolocation;
using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWP_API_task
{   /// <summary>
    /// Class for distance and location calculations
    /// </summary>
    public static class DistanceCalculations

    {
        private static readonly string GoogleMapsApiKey = "AIzaSyAiX3oDMxF7P29rDQmGgReE1eC6W1BBNMk";

        /// <summary>
        /// Method to get the distance in miles between to sets of coordinates
        /// </summary>
        /// <param name="lat1"> Double of the first locations latitude </param>
        /// <param name="long1"> Double of the first locations longitude </param>
        /// <param name="lat2"> Double of the second locations latitude </param>
        /// <param name="long2"> Double of the second locations longitude </param>
        /// <returns> Double representing the distance between the 2 given locations in miles </returns>
        public static double GetDistanceBetweenTwoLocations(double lat1, double long1, double lat2, double long2)
        {
            Coordinate location1 = new Coordinate(lat1, long1);
            Coordinate location2 = new Coordinate(lat2, long2);
            double distance = GeoCalculator.GetDistance(location1, location2, 1);
            return distance;
        }

        /// <summary>
        /// Method to get the coordinates of a given location
        /// </summary>
        /// <param name="location"> A string representing the location i.e. "London" </param>
        /// <returns> Double[] of the locations coordinates, [0] is the latitude and [1] is the longitude</returns>
        public static double[] GetCoordinatesOfLocation(string location)
        {
            string address = location;
            var locationService = new GoogleLocationService(GoogleMapsApiKey);
            var point = locationService.GetLatLongFromAddress(address);
            double[] coordinates = new double[2];       
            coordinates[0] = point.Latitude;
            coordinates[1] = point.Longitude;
            return coordinates;
        }










    }
}
