using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4_Participation_MVC.Models
{
    public class Admin : Account
    {
        /// <summary>
        /// Een RFID tag waarmee de admin kan inloggen
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// een instancie van een admin wat de id,username en email overneemt uit Account
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="barcode"></param>
        public Admin(int id, string username, string email, string barcode)
            : base(id, username, email)
        {
            Barcode = barcode;
        }
    }

}