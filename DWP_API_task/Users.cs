using DWP_API_task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWP_API_task
{
    public class Users
    {
        private List<User> allUsers { get; set; }



        public Users()
        {
        allUsers = new List<User>();

        }

        public void addUser(User u)               //remove duplicates with a set??
        {                                    //need to overwrite equals method for logical equivalence
            allUsers.Add(u);                  //immutability, final, factory
        }

        public List<User> getListOfUsers()
        {
            return allUsers;
        }

        public void setListOfUsers(List<User> usersList)
        {
            allUsers = usersList;
        }


        // public List<User> getUsersInGivenCity(string city)
        // {
        public int
            MyProperty { get; set; }




        //  return


        // }
    }
}
