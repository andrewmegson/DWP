using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DWP_API_task
{
    public class HttpRequests
    {
        private static readonly HttpClient client = new HttpClient();


        //public GET method to get a string response from http request
        public static async Task<string> getHttpRequest(string url)
        {
            string response = await client.GetStringAsync(url);           
            return response;

        }









    }
}
