using DWP_API_task;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;



namespace Tests
{
    public class HttpRequestsTests
    {

        [Test]
        public async Task TestGetHttpRequest()
        {
            string url = "https://bpdts-test-app.herokuapp.com/city/Sydney/users";        

            string response = "";
            response = await HttpRequests.GetHttpRequest(url);
            Assert.AreNotEqual(response, "");
        }

    }  
}