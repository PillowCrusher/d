using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4Participation.Classes.ClassObjects;

namespace ICT4Participation.Classes.Intelligence
{
    public class Administration
    {
        private static User _currentUser;

        public List<User> Users { get; private set; }

        public Administration()
        {
            Users = new List<User>();
        }

        public User Login(string username, string password)
        {
            return null;
        }

        public Admin Login(string username, string password, string RFID)
        {
            return null;
        }

        public User GetCurrentUser()
        {
            return _currentUser;
        }

        public User LoginWithRfid(string rfid)
        {
            return null;
        }

        public void Logout(string username)
        {

        }

        public void Unsubscribe(User user)
        {
            user.UnSubscribe();
        }

        public void AddVolunteer(string username, string password, string email, string name, string address, 
            string city, string phonenumber, bool publicTransport, bool hasdrivinglicence, bool hascar, 
            DateTime birthdate, string photo, string vog)
        {
            Users.Add(new Volunteer(new Account(username,password, email), name, address, city, phonenumber,publicTransport, hasdrivinglicence, hascar, birthdate, photo, vog));
        }

        public void AddNeedy(string username, string password, string email, string name, string address,
            string city, string phonenumber, bool publictransport, bool hasdrivinglicence,
            bool hascar, string rfid)
        {
            Users.Add(new Needy(new Account(username, password, email), name, address, city, phonenumber, publictransport, hasdrivinglicence, hascar, rfid));
        }
    }
}
