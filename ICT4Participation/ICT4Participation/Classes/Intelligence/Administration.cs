﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4Participation.Classes.ClassObjects;

namespace ICT4Participation.Classes.Intelligence
{
    class Administration
    {
         
        public List<User> Users { get; private set; }

        public Administration()
        {
            Users = new List<User>();
        }

        public void Login(string username, string password)
        {
            
        }

        public void LoginWithRfid()
        {
            
        }

        public void Logout(string username)
        {
            
        }

        public void Unsubscribe(User user)
        {
            user.UnSubscribe();
        }

        public void AddVolunteer(string name, string address, string city, string phonenumber, bool hasdrivinglicence, bool hascar, DateTime birthdate, string photo, string vog)
        {
            Users.Add(new Volunteer(name, address, city, phonenumber, hasdrivinglicence, hascar, birthdate, photo, vog));
        }

        public void AddNeedy(string name, string address, string city, string phonenumber, bool hasdrivinglicence,
            bool hascar, bool publictransport, string rfid)
        {
            Users.Add(new Needy(name, address, city, phonenumber, hasdrivinglicence, hascar,  publictransport, rfid));
        }
    }
}
