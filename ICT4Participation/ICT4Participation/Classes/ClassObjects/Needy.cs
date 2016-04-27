using ICT4Participation.Classes.Database;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Participation.Classes.ClassObjects
{
    //een Needy erft van User
    public class Needy : User 
    {
        private string _location;

        /// <summary>
        /// Een RFID tag waarmee de needy kan inloggen
        /// </summary>
        public string RFID { get; set; }
        /// <summary>
        /// De locatie(tehuis) waar de needy woont
        /// </summary>
        public string Location { get; private set; }

        /// <summary>
        /// een instancie van een Needy wat de id,username, email, name, address, city, phonenumber
        /// publictransport, hasdrivinglincense, en hasCar overneemt uit User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="phonenumber"></param>
        /// <param name="publicTransport"></param>
        /// <param name="hasDrivingLincense"></param>
        /// <param name="hasCar"></param>
        /// <param name="rfid"></param>
        /// <param name="isWarned"></param>
        public Needy(int id, string username, string email, string name, string location, string phonenumber, bool publicTransport, bool hasDrivingLincense, bool hasCar, string rfid, bool isWarned)
            : base(id, username, email, name, phonenumber, publicTransport, hasDrivingLincense, hasCar, isWarned)
        {
            RFID = rfid;
            _location = location;
        }

        /// <summary>
        /// Een methode waarmee een needy een hulpvraag kan posten
        /// </summary>
        /// <param name="titel"></param>
        /// <param name="description"></param>
        /// <param name="urgent"></param>
        /// <param name="transportType"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="requestintroduction"></param>
        public void AddHelpRequest(string titel, string description, bool urgent, TransportationType transportType, DateTime startDate, DateTime endDate, bool requestintroduction)
        {
            OracleParameter[] parameters =
            {
                new OracleParameter("needyid", ID),
                new OracleParameter("title", titel),
                new OracleParameter("description", description),
                new OracleParameter("location", _location),
                new OracleParameter("urgent", Convert.ToInt32(urgent)),
                new OracleParameter("transporttype", transportType.ToString()),
                new OracleParameter("startdate", startDate),
                new OracleParameter("enddate", endDate),
                new OracleParameter("interview", Convert.ToInt32(requestintroduction))
            };
            DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertHelprequest"], parameters);
        }

        public void DeleteHelpRequest(HelpRequest helprequest)
        {

        }
    }
}
