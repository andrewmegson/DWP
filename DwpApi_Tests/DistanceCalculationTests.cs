using DWP_API_task;
using NUnit.Framework;
using System;

namespace Tests
{
    public class DistanceCalculationTests
    {


        [Test]
        public void TestGetDistanceBetweenTwoLocations()
        {
            double distance = 248; 
            double lat1 = 51.507222;  //London
            double long1 = -0.1275;
            double lat2 = 54.9783; //Newcastle
            double long2 = -1.6578;

            double calculatedDistance = DistanceCalculations.GetDistanceBetweenTwoLocations(lat1, long1, lat2, long2);

            Assert.AreEqual(calculatedDistance, distance);
        }

        [Test]
        public void TestGetCoordinatesOfLocation()
        {
            double latN = 54.9783; //Newcastle coordinates
            double longN = -1.6178;

            double[] newcastleCoordinates = new double[2];
            newcastleCoordinates[0] = latN;
            newcastleCoordinates[1] = longN;

            double[] calculatedNewcastleCoordinates = DistanceCalculations.GetCoordinatesOfLocation("Newcastle upon Tyne");
            calculatedNewcastleCoordinates[0] = Math.Round(calculatedNewcastleCoordinates[0], 4);
            calculatedNewcastleCoordinates[1] = Math.Round(calculatedNewcastleCoordinates[1], 4);

            Assert.AreEqual(newcastleCoordinates, calculatedNewcastleCoordinates);


        }

    }
}