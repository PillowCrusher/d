using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4Participation.Classes.Database;
using Oracle.ManagedDataAccess.Client;

namespace ICT4Participation.Classes.ClassObjects
{
    //Een admin erft van account
    public class Admin : Account
    {
        /// <summary>
        /// Een RFID tag waarmee de admin kan inloggen
        /// </summary>
        public string RFID { get; set; }

        /// <summary>
        /// een instancie van een admin wat de id,username en email overneemt uit Account
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="rfid"></param>
        public Admin(int id, string username, string email,string rfid)
            :base(id, username, email)
        {
            RFID = rfid;
        }

        /// <summary>
        /// Hiermee kan een admin een account blokeren indien nodig
        /// </summary>
        /// <param name="user"></param>
        

        /// <summary>
        /// Hiermee kan een admin een account waarschuwen voor zijn acties indien nodig
        /// </summary>
        /// <param name="message"></param>
        /// <param name="user"></param>
       

        /// <summary>
        /// Hiermee kan een admin een RFID tag aan een hulpbehoevende koppelen
        /// </summary>
        /// <param name="needy"></param>
        /// <param name="rfid"></param>
        
    }
}
