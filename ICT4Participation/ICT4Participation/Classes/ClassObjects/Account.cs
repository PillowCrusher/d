using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Participation.Classes.ClassObjects
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public Account(string username, string password, string email)
        {
            if (username == null)
            {
                throw new ArgumentNullException("username", "username is empty");
            }
            if (password == null)
            {
                throw new ArgumentNullException("passowrd", "password is empty");
            }
            if (email == null)
            {
                throw new ArgumentNullException("email", "email is empty");
            }
            this.Username = username;
            this.Password = password;
            this.Email = email;
        }
    }
}
