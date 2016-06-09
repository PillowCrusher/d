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
        public List<HelpRequest> HelpRequestsen { get; protected set; }

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

            HelpRequestsen = new List<HelpRequest>();
        }

        public Needy(DataRow dr)
            : this((int)dr[0], dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), (bool)dr[7], (bool)dr[8], (bool)dr[9], dr[10].ToString(), (bool)dr[11])
        {
            HelpRequestsen = new List<HelpRequest>();
        }

      public void AddHelpRequest(HelpRequest helpRequest)
      {
          if (HelpRequestsen.Contains(helpRequest) == false)
          {
              HelpRequestsen.Add(helpRequest);
          }
          else
          {
              throw new ArgumentException("Deze helprequest bestaat al");
          }
       }
    }

}