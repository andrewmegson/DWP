using System.Collections.Generic;
using System.Threading.Tasks;
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
            List<User> users = await UserRequests.GetAllUsersInACityOrWithinDistance("London", 50);
            return JsonConvert.SerializeObject(users);;
        }

        // GET api/values/London/50
        [HttpGet("{city}/{distance}")]
        public async Task<ActionResult<string>> GetAsync(string city, double distance)
        {
            //try catch loop


            List<User> users = await UserRequests.GetAllUsersInACityOrWithinDistance(city, distance);
            return JsonConvert.SerializeObject(users);

        }


    }
}
