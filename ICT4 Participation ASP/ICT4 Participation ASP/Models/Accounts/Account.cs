﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ICT4_Participation_ASP.Models.Accounts
{
    public class Account
    {
        /// <summary>
        /// Het ID van een Account
        /// </summary>
        public int ID { get; protected set; }
        /// <summary>
        /// De username van een account
        /// </summary>
        public string Username { get; protected set; }
        /// <summary>
        /// Het email adres van een account
        /// </summary>
        public string Email { get; protected set; }

        /// <summary>
        /// een instancie van een account 
        /// (Password wrodt voor de veiligheid niet opgeslagen)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        public Account(int id, string username, string email)
        {
            ID = id;
            Username = username;
            Email = email;
        }

        public Account(DataRow dr)
            : this((int)dr["ID"], dr["Username"].ToString(), dr["email"].ToString())
        {

        }
    }
}