using DWP_API_task.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DWP_API_task
{
    public static class UserRequests
    {
        public static async Task<List<User>> GetAllUsersListedInACity(string city)
        {

            //check parameters format

            city = char.ToUpper(city[0]) + city.Substring(1);

            List<User> usersInCity = new List<User>();
            usersInCity = await DwpApiRequests.GetAllUsersListedInCity(city);
            return usersInCity;
        }

        public static async Task<List<User>> GetAllUserGivenDistanceFromCity(string city, double distance)
        {

            //check parameters


            //get all users
            List<User> allUsers = new List<User>();
            allUsers = await DwpApiRequests.GetAllUsers();

            //get city coordinates
            double[] cityCoordinates = new double[2];
            cityCoordinates = DistanceCalculations.GetCoordinatesOfLocation(city);

            //check which users are within distance to city
            //loop if user in within distance add to Users object

            List<User> requiredUsers = new List<User>();
            double dist = 0;

            foreach (User u in allUsers)
            {

                //for each u check if distance between coordinates equal or less than given distance
                // if so add to new list
                dist = DistanceCalculations.GetDistanceBetweenToLocations(u.latitude, u.longitude,
                                            cityCoordinates[0], cityCoordinates[1]);
                if(dist <= distance)
                {
                    requiredUsers.Add(u);
                }
            }
            return requiredUsers;

        }




        //method to get in city or within distance of city
        public static async Task<List<User>> GetAllUsersInACityOrWithinDistance(string city, double distance)
        {
            List<User> usersInCity = await UserRequests.GetAllUsersListedInACity(city);
            List<User> usersInDistance = await UserRequests.GetAllUserGivenDistanceFromCity(city, distance);

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
