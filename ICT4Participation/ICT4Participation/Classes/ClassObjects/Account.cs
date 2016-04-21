﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Participation.Classes.ClassObjects
{
    public class Account
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public Account(int id, string username, string password, string email)
        {
            this.ID = id;
            this.Username = username;
            this.Password = password;
            this.Email = email;
        }
    }
}
