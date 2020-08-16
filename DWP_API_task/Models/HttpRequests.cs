using System.Net.Http;
using System.Threading.Tasks;

namespace DWP_API_task
{
    /// <summary>
    /// Class for handling an Http request
    /// </summary>
    public static class HttpRequests
    {
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Method to handle an http GET method
        /// </summary>
        /// <param name="url"> A string that represents the url being sent </param>
        /// <returns> A string representing the response in Json format </returns>
        public static async Task<string> GetHttpRequest(string url)
        {
            string response = await client.GetStringAsync(url);           
            return response;
        }









    }
}
