using DWP_API_task;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;



namespace Tests
{
    public class UserRequestsTests
    {

        [Test]
        public async Task TestGetAllUsersListedInACity1()
        {
            List<User> allUsers = await UserRequests.GetAllUsersListedInACity("London");
            Assert.AreEqual(allUsers.Count, 6);
        }

        [Test]
        public async Task TestGetAllUsersListedInACity2()
        {
            string exceptionMessage = "";
            try
            {
                List<User> allUsers = await UserRequests.GetAllUsersListedInACity("LonDon");
            }
            catch (Exception ex)
            {
                 exceptionMessage = ex.Message;
            }
            Assert.AreEqual("The city has not been entered in the correct format" +
                " i.e api/values/london or api/values/london/50", exceptionMessage);

        }


        [Test]
        public async Task TestGetAllUserGivenDistanceFromCity1()
        {
            List<User> allUsers = await UserRequests.GetAllUserGivenDistanceFromCity("London", 50);
            Assert.AreEqual(allUsers.Count, 3);
        }


        [Test]
        public async Task TestGetAllUsersInACityOrWithinDistance1()
        {
            List<User> allUsers = await UserRequests.GetAllUsersInACityOrWithinDistance("London", 50);
            Assert.AreEqual(allUsers.Count, 9);     
        }

        [Test]
        public async Task TestGetAllUsersInACityOrWithinDistance2()
        {
            List<User> allUsers = await UserRequests.GetAllUsersInACityOrWithinDistance("London", 30);
            Assert.AreEqual(allUsers.Count, 8);
        }

    }
}