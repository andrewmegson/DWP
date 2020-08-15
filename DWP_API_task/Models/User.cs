using System;

namespace DWP_API_task

{
    /// <summary>
    /// Class to hold all info of a User
    /// </summary>
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

        /// <summary>
        /// Constructor of class to create a User
        /// </summary>
        /// <param name="firstName"> A string to represent first name </param>
        /// <param name="lastName"> A string to represent first name </param>
        /// <param name="id"> A double to represent id </param>
        /// <param name="email"> A string to represent email </param>
        /// <param name="ipAddress"> A string to represent Ip Address </param>
        /// <param name="latitude"> A double to represent latitude </param>
        /// <param name="longitude"> A double to represent longitude </param>
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


        /// <summary>
        /// Equals override method to ensure logical equivalence
        /// </summary>
        /// <param name="obj"></param>
        /// <returns> A boolean value </returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as User);
        }

        /// <summary>
        /// Equals override method to ensure logical equivalence
        /// </summary>
        /// <param name="other"></param>
        /// <returns> A boolean value </returns>
        private bool Equals(User other)
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

        /// <summary>
        /// Hashcode override method to ensure logical equivalence
        /// </summary>
        /// <returns> A unigue hashcode generated from class members </returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(id, first_name, last_name, email, ip_address, latitude, longitude);
        }
    }
}
