using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System;
using System.Linq;

namespace DWP_API_task
{
    /// <summary>
    /// Class containing methods to return required lists of users for given parameters
    /// </summary>
    public static class UserRequests
    {
        /// <summary>
        /// Method to get all users listed as living in a city
        /// </summary>
        /// <param name="city"> A string representing the city name </param>
        /// <returns> List<User> of   according to Dwp Api </returns>
        public static async Task<List<User>> GetAllUsersListedInACity(string city)
        {
            //paramter check city
            Regex expression = new Regex(@"^[a-z,A-Z][a-z]+$");
            bool result = expression.IsMatch(city);

            if(!result)
            {
                throw new Exception("The city has not been entered in the correct format");
            }


            city = char.ToUpper(city[0]) + city.Substring(1);

            List<User> usersInCity = new List<User>();
            usersInCity = await DwpApiRequests.GetAllUsersListedInCity(city);
            return usersInCity;
        }

        /// <summary>
        /// Method to get all users whose coordinates show they 
        /// are within a given distance of a given city
        /// </summary>
        /// <param name="city"> A string representing the city name </param>
        /// <param name="distance"> A double representing the distance from the city in miles </param>
        /// <returns> List<User> of all users whose coordinates show they are with the given
        /// distance from the given city according to Dwp Api </returns>
        public static async Task<List<User>> GetAllUserGivenDistanceFromCity(string city, double distance)
        {
            //get all users
            List<User> allUsers = new List<User>();
            allUsers = await DwpApiRequests.GetAllUsers();

            //get city coordinates
            double[] cityCoordinates = new double[2];
            cityCoordinates = DistanceCalculations.GetCoordinatesOfLocation(city);

            //check which users are within distance to city
            //loop if user in within distance add to Users object


            List<User> usersDistanceFromCity = allUsers.Where(u => DistanceCalculations.GetDistanceBetweenTwoLocations(
                u.latitude, u.longitude,cityCoordinates[0], cityCoordinates[1]) <= distance).ToList();


            return usersDistanceFromCity;
            
            //List<User> requiredUsers = new List<User>();
            //double dist = 0;

            //foreach (User u in allUsers)
            //{

            //    //for each u check if distance between coordinates equal or less than given distance
            //    // if so add to new list
            //    dist = DistanceCalculations.GetDistanceBetweenTwoLocations(u.latitude, u.longitude,
            //                                cityCoordinates[0], cityCoordinates[1]);
            //    if(dist <= distance)
            //    {
            //        requiredUsers.Add(u);
            //    }
            //}
            //return requiredUsers;

        }




        /// <summary>
        /// Method to get all users who are listed as living in a city or 
        /// whose coordinates show they are within a given distance of a given city
        /// </summary>
        /// <param name="city"> A string representing the city name </param>
        /// <param name="distance"> A double representing the distance from the city in miles </param>
        /// <returns> List<User> of all users listed as living in a city or whose coordinates show 
        /// they are with the given distance from the given city according to Dwp Api</returns>
        public static async Task<List<User>> GetAllUsersInACityOrWithinDistance(string city, double distance)
        {
                List<User> usersInCity = await UserRequests.GetAllUsersListedInACity(city);
                List<User> usersInDistance = await UserRequests.GetAllUserGivenDistanceFromCity(city, distance);

                ////add to Users together excluding repeats
                //List<User> usersInCityAndDistance = new List<User>();
                //usersInCityAndDistance.AddRange(usersInCity);
                //foreach (User u in usersInDistance)
                //{
                //    if (!usersInCity.Contains(u))
                //    {
                //        usersInCityAndDistance.Add(u);
                //    }

                //}

            List<User> usersInCityAndDistance = usersInCity.Union(usersInDistance).ToList();


                return usersInCityAndDistance;

        }

    }
}
