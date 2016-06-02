using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4_Participation_MVC.Models
{
    public class Account
    {
        /// <summary>
        /// Het ID van een Account
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// De username van een account
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Het email adres van een account
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// een instancie van een account 
        /// (Password wrodt voor de veiligheid niet opgeslagen)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        public Account(int id, string username, string email)
        {
            this.ID = id;
            this.Username = username;
            this.Email = email;
        }
    }
}