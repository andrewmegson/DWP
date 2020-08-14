using Geolocation;
using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWP_API_task
{
    public static class DistanceCalculations

    {
        private static string GoogleMapsApiKey = "AIzaSyAiX3oDMxF7P29rDQmGgReE1eC6W1BBNMk";

        public static double getDistanceBetweenToLocations(double lat1, double long1, double lat2, double long2)
        {
            Coordinate location1 = new Coordinate(lat1, long1);
            Coordinate location2 = new Coordinate(lat2, long2);
            double distance = GeoCalculator.GetDistance(location1, location2, 1);
            return distance;
        }

        public static double[] getCoordinatesOfLocation(string location)
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
