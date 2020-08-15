using DWP_API_task;
using Newtonsoft.Json;
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
        public void TestGetAllUsersListedInACity2()
        {
            // List<User> allUsers = await UserRequests.GetAllUsersListedInACity("LonDon");


            Exception exceptionMessage = Assert.Throws<Exception>(async () => 
            await UserRequests.GetAllUsersListedInACity("LonDon"));
            Assert.AreEqual("The city has not been entered in the correct format",
                exceptionMessage.Message);
        }


        [Test]
        public async Task TestGetAllUserGivenDistanceFromCity()
        {
            List<User> allUsers = await UserRequests.GetAllUserGivenDistanceFromCity("London", 50);


            //Assert.AreEqual(allUsers.Count, 1000);
        }

        [Test]
        public async Task TestGetAllUsersInACityOrWithinDistance()
        {
            List<User> allUsers = await UserRequests.GetAllUsersInACityOrWithinDistance("London", 50);


            //Assert.AreEqual(allUsers.Count, 1000);
        }

    }
}