﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ICT4_Participation_ASP.Models.Objects;

namespace ICT4_Participation_ASP.Models.Accounts
{
    public class Needy : User
    {

        /// <summary>
        /// Geeft aan of de hulpbehoevende gebruik kan maken van het openbaar verveor
        /// </summary>
        public bool OVPosible { get; protected set; }
        /// <summary>
        /// Een Barcode tag waarmee de needy kan inloggen
        /// </summary>
        public string Barcode { get; protected set; }

        /// <summary>
        /// een instancie van een Needy wat de id,username, email, name, address, city, phonenumber
        /// hasdrivinglincense, en hasCar overneemt uit User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="adres"></param>
        /// <param name="city"></param>
        /// <param name="phonenumber"></param>
        /// <param name="publicTransport"></param>
        /// <param name="hasDrivingLincense"></param>
        /// <param name="hasCar"></param>
        /// <param name="barcode"></param>
        /// <param name="isWarned"></param>
        public Needy(int id, string username, string email, string name, string adres, string city, string phonenumber, bool publicTransport, bool hasDrivingLincense, bool hasCar, string barcode, bool isWarned)
            : base(id, username, email, name, adres, city, phonenumber, hasDrivingLincense, hasCar, isWarned)
        {
            Barcode = barcode;
            OVPosible = publicTransport;
        }

        public Needy(DataRow dr)
            : this(Convert.ToInt32(dr["ID"]), dr["Username"].ToString(), dr["email"].ToString(), dr["name"].ToString(), dr["adres"].ToString(), dr["city"].ToString(), dr["phonenumber"].ToString(), Convert.ToBoolean(dr["OVPossible"]), Convert.ToBoolean(dr["hasDrivinglicence"]), Convert.ToBoolean(dr["HasCar"]), dr["Barcode"].ToString(), Convert.ToBoolean(dr["IsWarned"]))
        {

        }

        public void CompleteHelprequest(HelpRequest helpRequest)
        {
            if (HelpRequestsen.Contains(helpRequest))
            {
                HelpRequestsen.Remove(helpRequest);
            }
        }
    }

}