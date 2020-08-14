using DWP_API_task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWP_API_task
{
    public static class UserRequests
    {

        //method to get Users object of all users in a given city


        public static async Task<List<User>> getAllUsersInACity(string city)
        {
            List<User> usersInCity = new List<User>();
            usersInCity = await DwpApiRequests.getAllUsersInCity(city);
            return usersInCity;
        }

        //method to get all users with a given distance of a given city
        public static async Task<List<User>> getAllUserGivenDistanceFromCity(string city, double distance)
        {
            //get all users
            List<User> allUsers = new List<User>();
            allUsers = await DwpApiRequests.getAllUsers();

            //get city coordinates
            double[] cityCoordinates = new double[2];
            cityCoordinates = DistanceCalculations.getCoordinatesOfLocation(city);

            //check which users are within distance to city
            //loop if user in within distance add to Users object

            List<User> requiredUsers = new List<User>();
            double dist = 0;

            foreach (User u in allUsers)
            {

                //for each u check if distance between coordinates equal or less than given distance
                // if so add to new list
                dist = DistanceCalculations.getDistanceBetweenToLocations(u.latitude, u.longitude,
                                            cityCoordinates[0], cityCoordinates[1]);








                if(dist <= distance)
                {
                    requiredUsers.Add(u);
                }

            }
            return requiredUsers;

        }




        //method to get in city or within distance of city
        public static async Task<List<User>> getAllUsersInACityOrWithinDistance(string city, double distance)
        {

            List<User> usersInCity = await UserRequests.getAllUsersInACity(city);
            List<User> usersInDistance = await UserRequests.getAllUserGivenDistanceFromCity(city, distance);

            //add to Users together excluding repeats

            List<User> usersInCityAndDistance = new List<User>();

            usersInCityAndDistance.AddRange(usersInCity);

            foreach (User u in usersInDistance)
            {
                if(!usersInCity.Contains(u))
                {
                    usersInCityAndDistance.Add(u);
                }

            }
            
            return usersInCityAndDistance;

        }

    }
}
