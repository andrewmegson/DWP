using DWP_API_task;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace Tests
{
    public class DwpApiRequestsTests
    {


        [Test]
        public async Task TestGetAllUsersAsync()
        {
            List<User> allUsers = await DwpApiRequests.GetAllUsers();
            Assert.AreEqual(allUsers.Count, 1000);
        }

        [Test]
        public async Task TestGetAllUsersListedInCity1()
        {
            List<User> allUsersInCity = await DwpApiRequests.GetAllUsersListedInCity("London");
            Assert.AreEqual(allUsersInCity.Count, 6);
        }

        [Test]
        public async Task TestGetAllUsersListedInCity2()
        {
            List<User> allUsersInCity = await DwpApiRequests.GetAllUsersListedInCity("Sydney");
            Assert.AreEqual(allUsersInCity.Count, 1);
        }


    }
}