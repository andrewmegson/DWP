using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace DWP_API_task.Controllers
{
    /// <summary>
    /// API class
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values, returns a Json object of all users listed as living in London
        // or with coordinates within 50 miles of London (default method)
        [HttpGet]
        public async Task<ActionResult<string>> GetAsync()
        {
            List<User> users = await UserRequests.GetAllUsersInACityOrWithinDistance("London", 50);
            return JsonConvert.SerializeObject(users);;
        }

        // GET api/values/city/distance i.e. api/London/50
        // returns a Json object of all users listed as living in given city
        // or with coordinates within given distance (in miles) of city.
        [HttpGet("{city}/{distance}")]
        public async Task<ActionResult<string>> GetAsync(string city, double distance)
        {
            //try catch loop
            string output = "";
            try
            {
            List<User> users = await UserRequests.GetAllUsersInACityOrWithinDistance(city, distance);
            output = JsonConvert.SerializeObject(users);
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }
            return output;




        }


    }
}
