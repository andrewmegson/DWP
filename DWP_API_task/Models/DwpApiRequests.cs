using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DWP_API_task.Models;

namespace DWP_API_task
{
    public static class DwpApiRequests
    {
        private static readonly string baseUrl = "https://bpdts-test-app.herokuapp.com/";

        private static async Task<List<User>> GetRequiredUsers(string url)
        {
            string response = await HttpRequests.GetHttpRequest(url);
            List<User> usersList = JsonConvert.DeserializeObject<List<User>>(response);           
            return usersList;
        }

        public static async Task<List<User>> GetAllUsers()
        {
            string url = baseUrl + "users";
            List<User> users = new List<User>();
            users = await DwpApiRequests.GetRequiredUsers(url);
            return users;
        }

        public static async Task<List<User>> GetAllUsersListedInCity(string city)
        {     
            string url = baseUrl + String.Format("city/{0}/users", city);
            List<User> users = new List<User>();
            users = await DwpApiRequests.GetRequiredUsers(url);
            return users;
        }
   
	}




















 
}
