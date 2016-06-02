﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4_Participation_MVC.Models
{
    //een User erft van Account
    public class User : Account
    {
        /// <summary>
        /// de naam van de User
        /// </summary>
        public string Name { get; protected set; }
        public string Adres { get; protected set; }
        public string City { get; protected set; }
        /// <summary>
        /// Het telefoonnummer van de User
        /// </summary>
        public string Phonenumber { get; protected set; }
        /// <summary>
        /// een bool of de User een rijbewijs heeft
        /// </summary>
        public bool HasDrivingLincense { get; protected set; }
        /// <summary>
        /// een bool of de User een auto heeft
        /// </summary>
        public bool HasCar { get; protected set; }
        /// <summary>
        /// de datum dat de User zich heeft uitgeschreven
        /// </summary>
        public DateTime DeRegistrationDate { get; protected set; }
        /// <summary>
        /// een bool of de User is gewaarschuwd door de admin of niet
        /// </summary>
        public bool IsWarned { get; protected set; }

        /// <summary>
        ///  een instancie van een Account wat de id,username en email overneemt uit Account
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="phonenumber"></param>
        /// <param name="publicTransport"></param>
        /// <param name="hasDrivingLincense"></param>
        /// <param name="hasCar"></param>
        /// <param name="isWarned"></param>
        public User(int id, string username, string email, string name, string adres, string city, string phonenumber, bool hasDrivingLincense, bool hasCar, bool isWarned)
            : base(id, username, email)
        {
            if (name == null || phonenumber == null)
            {
                throw new ArgumentNullException("user", "please fill in all fields for the user");
            }
            this.Name = name;
            this.Adres = adres;
            this.City = city;
            this.Phonenumber = phonenumber;
            this.HasDrivingLincense = hasDrivingLincense;
            this.HasCar = hasCar;
            this.IsWarned = isWarned;
        }
    }
}