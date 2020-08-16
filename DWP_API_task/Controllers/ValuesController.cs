using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace DWP_API_task.Controllers
{
    /// <summary>
    /// Controller class to handle API requests
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// GET api/values, returns a Json object of all users listed as living in London
        // or with coordinates within 50 miles of London (default method)
        /// </summary>
        /// <returns> A string in Json format representing a list of the required users </returns>
        [HttpGet]
        public async Task<ActionResult<string>> GetAsync()
        {
            List<User> users = await UserRequests.GetAllUsersInACityOrWithinDistance("London", 50);
            return JsonConvert.SerializeObject(users);;
        }

        /// <summary>
        /// GET api/values/city/distance i.e. api/London/50
        // returns a Json object of all users listed as living in given city
        // or with coordinates within given distance (in miles) of city
        /// </summary>
        /// <param name="city"> A string representing the city </param>
        /// <param name="distance"> A double representing the distance </param>
        /// <returns> A string in Json format representing a list of the required users </returns>
        [HttpGet("{city}/{distance}")]
        public async Task<ActionResult<string>> GetAsync(string city, double distance)
        {
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

        /// <summary>
        /// GET api/values/city i.e. api/London
        // returns a Json object of all users listed as living in given city
        /// </summary>
        /// <param name="city"> A string representing the city </param>
        /// <returns> A string in Json format representing a list of the required users </returns>
        [HttpGet("{city}")]
        public async Task<ActionResult<string>> GetAsync(string city)
        {
            string output = "";
            try
            {
                List<User> users = await UserRequests.GetAllUsersListedInACity(city);
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
