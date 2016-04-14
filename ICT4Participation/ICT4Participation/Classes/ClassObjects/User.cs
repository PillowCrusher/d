using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Participation.Classes.ClassObjects
{
    public abstract class User
    {
        public string Name { get; protected set; }
        public string Address { get; protected set; }
        public string City { get; protected set; }
        public string Phonenumber { get; protected set; }
        public bool HasDrivingLincense { get; protected set; }
        public bool HasCar { get; protected set; }
        public DateTime DeRegistrationDate { get; protected set; }

        public User(string name, string address, string city, string phonenumber, bool hasDrivingLincense, bool hasCar)
        {
            if (name == null || address == null || city == null || phonenumber == null)
            {
                throw new ArgumentNullException("user", "please fill in all fields for the user");
            }
            this.Name = name;
            this.Address = address;
            this.City = city;
            this.Phonenumber = phonenumber;
            this.HasDrivingLincense = hasDrivingLincense;
            this.HasCar = hasCar;
        }

        public void UpdateProfiel(User user)
        {

        }
    }
}
