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
    public partial class VolunteerViewAllHelprequests : System.Web.UI.Page
    {
        private VolunteerHandler _volunteerHandler;
        private Volunteer _currentVolunteer;
        private HelpRequest _currentHelpRequest;

        public List<HelpRequest> AllHelpRequests; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _currentHelpRequest = (HelpRequest)Session["_currentHelpRequest"];
            }
            if (Session["LoggedUser"] is Volunteer)
            {
                _currentVolunteer = (Volunteer)Session["LoggedUser"];
                _volunteerHandler = new VolunteerHandler();

                AllHelpRequests = _volunteerHandler.GetHelpRequests();
            }
            else
            {
                Response.Redirect("LoginStandard.aspx");
            }
            if (!IsPostBack)
            {
                //populate members of list
                lvList.DataSource = AllHelpRequests;
                lvList.DataBind();
            }
        }
        protected void HelpRequestsListView_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (string.Equals(e.CommandName, "Accept"))
            {
                var ID = Convert.ToInt32(e.CommandArgument);
                _currentHelpRequest = _currentVolunteer.HelpRequestsen.Find(x => x.ID == ID);
                Session["_currentHelpRequest"] = _currentHelpRequest;
            }
        }
    }
}