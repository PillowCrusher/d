using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ICT4_Participation_ASP.Models.Accounts
{
    //een User erft van Account
    public class User : Account
    {
        public string Name { get; protected set; }
        public string Adres { get; protected set; }
        public string City { get; protected set; }
        public string Phonenumber { get; protected set; }
        public bool HasDrivingLincense { get; protected set; }
        public bool HasCar { get; protected set; }
        public DateTime DeRegistrationDate { get; protected set; }
        public bool IsWarned { get; protected set; }

        /// <summary>
        ///  een instancie van een Account wat de id,username en email overneemt uit Account
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="phonenumber"></param>
        /// <param name="publicTransport"></param>
        /// <param name="hasDrivingLincense"></param>
        /// <param name="hasCar"></param>
        /// <param name="isWarned"></param>
        protected User(int id, string username, string email, string name, string adres, string city, string phonenumber, bool hasDrivingLincense, bool hasCar, bool isWarned)
            : base(id, username, email)
        {
            if (name == null || phonenumber == null)
            {
                throw new ArgumentNullException("user", "please fill in all fields for the user");
            }
            Name = name;
            Adres = adres;
            City = city;
            Phonenumber = phonenumber;
            HasDrivingLincense = hasDrivingLincense;
            HasCar = hasCar;
            IsWarned = isWarned;
        }

        protected User(DataRow dr)
            : this((int)dr[0], dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), (bool)dr[7], (bool)dr[8], (bool)dr[9])
        {

        }
    }
}