using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DWP_API_task
{
    /// <summary>
    /// Class with methods to call the DWP Api used to access User information
    /// </summary>
    public static class DwpApiRequests
    {
        private static readonly string baseUrl = "https://bpdts-test-app.herokuapp.com/";

        /// <summary>
        /// Private class method used to get a list of users from the DWP Api with a given url request
        /// </summary>
        /// <param name="url"> A string representing the url request </param>
        /// <returns> List<User> representing all the users generated from the given url request </User></returns>
        private static async Task<List<User>> GetRequiredUsers(string url)
        {
            string response = await HttpRequests.GetHttpRequest(url);
            List<User> usersList = JsonConvert.DeserializeObject<List<User>>(response);           
            return usersList;
        }

        /// <summary>
        /// Method to get a list of all the current Users from the DWP Api
        /// </summary>
        /// <returns> List<User> representing all the current users </returns>
        public static async Task<List<User>> GetAllUsers()
        {
            string url = baseUrl + "users";
            List<User> users = new List<User>();
            users = await DwpApiRequests.GetRequiredUsers(url);
            return users;
        }

        /// <summary>
        /// Method to get a list of all the Users listed in a current city from the DWP Api
        /// </summary>
        /// <param name="city"> A string representing the city i.e. "London" </param>
        /// <returns> List<User> representing all the users listed in the given city </returns>
        public static async Task<List<User>> GetAllUsersListedInCity(string city)
        {     
            string url = baseUrl + String.Format("city/{0}/users", city);
            List<User> users = new List<User>();
            users = await DwpApiRequests.GetRequiredUsers(url);
            return users;
        }
   
	}




















 
}
