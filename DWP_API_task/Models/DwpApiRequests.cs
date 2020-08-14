using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DWP_API_task.Models;

namespace DWP_API_task
{
    public static class DwpApiRequests
    {
        private static string baseUrl = "https://bpdts-test-app.herokuapp.com/";

        private static async Task<List<User>> getRequiredUsers(string url)
        {
            string response = await HttpRequests.getHttpRequest(url);
            List<User> usersList = JsonConvert.DeserializeObject<List<User>>(response);           
            return usersList;
        }

        public static async Task<List<User>> getAllUsers()
        {
            string url = baseUrl + "users";
            List<User> users = new List<User>();
            users = await DwpApiRequests.getRequiredUsers(url);
            return users;
        }

        public static async Task<List<User>> getAllUsersInCity(string city)
        {     
            string url = baseUrl + String.Format("city/{0}/users", city);
            List<User> users = new List<User>();
            users = await DwpApiRequests.getRequiredUsers(url);
            return users;
        }
>    
	}




















 
}
