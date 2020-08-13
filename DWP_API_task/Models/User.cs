using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWP_API_task.Models
{
    public class User
    {
       
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string ip_address { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }


        public User()
        { }

        public User(string firstName, string lastName, int id, string email,string ipAddress,
            double latitude, double longitude)
        {
            this.first_name = firstName;
            this.last_name = lastName;
            this.id = id;
            this.email = email;
            this.ip_address = ipAddress;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as User);
        }

        public bool Equals(User other)
        {
            return other != null &&
                   id == other.id &&
                   first_name == other.first_name &&
                   last_name == other.last_name &&
                   email == other.email &&
                   ip_address == other.ip_address &&
                   latitude == other.latitude &&
                   longitude == other.longitude;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, first_name, last_name, email, ip_address, latitude, longitude);
        }
    }
}
