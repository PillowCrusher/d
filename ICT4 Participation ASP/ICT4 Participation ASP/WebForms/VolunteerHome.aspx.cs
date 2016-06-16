﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4_Participation_ASP.Models.Accounts;
using ICT4_Participation_ASP.Models.Handlers;
using ICT4_Participation_ASP.Models.Objects;

namespace ICT4_Participation_ASP.WebForms
{
    public partial class VolunteerHome : System.Web.UI.Page
    {
        private VolunteerHandler _volunteerHandler;
        private Volunteer _currentVolunteer;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedUser"] is Volunteer)
            {
                _currentVolunteer = (Volunteer)Session["LoggedUser"];
                _volunteerHandler = new VolunteerHandler();
            }
            else
            {
                Response.Redirect("LoginStandard.aspx");
            }


            List<HelpRequest> theList = new List<HelpRequest>
            {
                new HelpRequest(0, "MIJN COMPUTER IS KAPOT! T_______T", "Harryland", "Eindhoven", 100, true, TransportationType.Auto, DateTime.Today, DateTime.Now, 2, true, false, new List<Skill> {new Skill("Bob de bouwer")}),
                new HelpRequest(1, "FUS RO DAH!", "Skyrim", "Dragonlane 40", 50, false, TransportationType.Trein, DateTime.Today, DateTime.Now, 2, true, false, new List<Skill> { new Skill("Bam") }),
                new HelpRequest(2, "WAT EEN **** SITE ZEG!", "Skyrim", "Dragonlane 40", 50, false, TransportationType.Trein, DateTime.Today, DateTime.Now, 2, true, false, new List<Skill> { new Skill("Webdesign") })
            };

            //populate members of list
            lvList.DataSource = theList;
            lvList.DataBind();
        }
    }
}