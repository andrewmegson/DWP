using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using DWP_API_task.Models;

namespace DWP_API_task
{
    public class DwpApiRequests
    {


        private static string baseUrl = "https://bpdts-test-app.herokuapp.com/";


        //private method to get Users object of response
        private static async Task<List<User>> getRequiredUsers(string url)
        {
            string response = await HttpRequests.getHttpRequest(url);
            List<User> usersList = JsonConvert.DeserializeObject<List<User>>(response);           
            return usersList;

        }

        //method to get all users
        public static async Task<List<User>> getAllUsers()
        {
            string url = baseUrl + "users";
            List<User> users = new List<User>();
            users = await DwpApiRequests.getRequiredUsers(url);
            return users;
        }



        //method to get all users in a city  London

        public static async Task<List<User>> getAllUsersInCity(string city)
        {     
            string url = baseUrl + String.Format("city/{0}/users", city);
            List<User> users = new List<User>();
            users = await DwpApiRequests.getRequiredUsers(url);
            return users;



        }



     
	}




















 
}
