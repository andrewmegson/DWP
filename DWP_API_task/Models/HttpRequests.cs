using System.Net.Http;
using System.Threading.Tasks;

namespace DWP_API_task
{
    public static class HttpRequests
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> getHttpRequest(string url)
        {
            string response = await client.GetStringAsync(url);           
            return response;
        }









    }
}
