using ICT4_Participation_ASP.Models.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ICT4_Participation_ASP.Models.Accounts
{
    //een User erft van Account
    public abstract class User : Account
    {
        public List<HelpRequest> HelpRequestsen { get; protected set; }

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

            HelpRequestsen = new List<HelpRequest>();
        }

        public User(DataRow dr)
            : this(Convert.ToInt32(dr["ID"]), dr["Username"].ToString(), dr["email"].ToString(), dr["Name"].ToString(), dr["adres"].ToString(), dr["city"].ToString(), dr["phonenumber"].ToString(), Convert.ToBoolean(dr["hasdrivinglicence"]), Convert.ToBoolean(dr["HasCar"]), Convert.ToBoolean(dr["IsWarned"]))
        {

        }

        public void AddHelpRequest(HelpRequest helpRequest)
        {
            if (HelpRequestsen.Contains(helpRequest) == false)
            {
                HelpRequestsen.Add(helpRequest);
            }
            else
            {
                throw new ArgumentException("Deze helprequest bestaat al");
            }
        }
    }
}