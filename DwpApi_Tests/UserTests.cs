using NUnit.Framework;
using DWP_API_task;
namespace Tests
{
    public class Tests
    {

        [Test]
        public void TestUserLogicalEquivalence1()
        {
            string first_name = "Mechelle";
            string last_name = "Boam";
            int id = 135;
            string email = "mboam3q@thetimes.co.uk";
            string ip_address = "113.71.242.187";
            double latitude = -6.5115909;
            double longitude = 105.652983;

            User user1 = new User(first_name, last_name, id, email, ip_address, latitude, longitude);
            User user2 = new User(first_name, last_name, id, email, ip_address, latitude, longitude);

            Assert.AreEqual(user1, user2);
        }

        [Test]
        public void TestUserLogicalEquivalence2()
        {
            string first_name1 = "Mechelle";
            string first_name2 = "Micheal";
            string last_name = "Boam";
            int id = 135;
            string email = "mboam3q@thetimes.co.uk";
            string ip_address = "113.71.242.187";
            double latitude = -6.5115909;
            double longitude = 105.652983;

            User user1 = new User(first_name1, last_name, id, email, ip_address, latitude, longitude);
            User user2 = new User(first_name2, last_name, id, email, ip_address, latitude, longitude);

            Assert.AreNotEqual(user1, user2);
        }

    }
}