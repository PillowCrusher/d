using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4Participation.Classes.Database;
using Oracle.ManagedDataAccess.Client;

namespace ICT4Participation.Classes.ClassObjects
{
    public abstract class User : Account
    {
        public string Name { get; protected set; }
        public string Phonenumber { get; protected set; }
        public bool PublicTransport { get; protected set; }
        public bool HasDrivingLincense { get; protected set; }
        public bool HasCar { get; protected set; }
        public DateTime DeRegistrationDate { get; protected set; }

        public User(int id, string username, string email, string name, string phonenumber, bool publicTransport, bool hasDrivingLincense, bool hasCar)
            :base(id, username, email)
        {
            if (name == null || phonenumber == null)
            {
                throw new ArgumentNullException("user", "please fill in all fields for the user");
            }
            this.Name = name;
            this.Phonenumber = phonenumber;
            this.PublicTransport = publicTransport;
            this.HasDrivingLincense = hasDrivingLincense;
            this.HasCar = hasCar;
        }

        public void UpdateProfiel(User user)
        {
           // Name = user.Name;
            Phonenumber = user.Phonenumber;
            HasDrivingLincense = user.HasDrivingLincense;
            HasCar = HasCar;
            //Wat willen we toestaan dat de user kan veranderen?
        }

        public void UnSubscribe()
        {
            try
            {
                DeRegistrationDate = DateTime.Now;
                OracleParameter[] userParameter =
                {
                new OracleParameter("deregistrationdate", DeRegistrationDate),
                new OracleParameter("id", ID)
                };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["UnsubscribeAccount"], userParameter);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
