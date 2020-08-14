using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWP_API_task.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DWP_API_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<string>> GetAsync()
        {
            List<User> users = await UserRequests.getAllUsersInACityOrWithinDistance("London", 50);
            return JsonConvert.SerializeObject(users);;
        }

        // GET api/values/London/50
        [HttpGet("{city}/{distance}")]
        public async Task<ActionResult<string>> GetAsync(string city, double distance)
        {
            List<User> users = await UserRequests.getAllUsersInACityOrWithinDistance(city, distance);
            return JsonConvert.SerializeObject(users);

        }


    }
}
