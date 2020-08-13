using Geolocation;
using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWP_API_task
{
    public class DistanceCalculations

    {

        private static string GoogleMapsApiKey = "AIzaSyAiX3oDMxF7P29rDQmGgReE1eC6W1BBNMk";

        //method to calculate the distance between to points, given coordinates
        public static double getDistanceBetweenToLocations(double lat1, double long1, double lat2, double long2)
        {

            // TODO call API and calculate distance

            Coordinate location1 = new Coordinate(lat1, long1);
            Coordinate location2 = new Coordinate(lat2, long2);

            //gives distance in miles
            double distance = GeoCalculator.GetDistance(location1, location2, 1);
            //double distance = GeoCalculator.GetDistance(lat1, long1, lat2, long2);
            return distance;
        }




        //method to get coordinates of a place i.e. London

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
