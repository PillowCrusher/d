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
        private HelpRequest _currentHelpRequest;

        private List<HelpRequest> _acceptedHelpRequests = new List<HelpRequest>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _currentHelpRequest = (HelpRequest)Session["_currentHelpRequest"];
                _acceptedHelpRequests = HttpContext.Current.Session["_acceptedHelpRequests"] as List<HelpRequest>;
            }
            if (Session["LoggedUser"] is Volunteer)
            {
                _currentVolunteer = (Volunteer)Session["LoggedUser"];
                _volunteerHandler = new VolunteerHandler();
                inputMessage.Visible = false;
                btnSendMessage.Visible = false;
            }
            else
            {
                Response.Redirect("LoginStandard.aspx");
            }
            if (!IsPostBack)
            {
                var h = new HelpRequest(0, "ja", "kekef", "locatie", 100, true, TransportationType.Auto,
                    DateTime.Today,
                    DateTime.Now, 5, true, new List<Skill>());
                _acceptedHelpRequests.Add(h);
                Session["_acceptedHelpRequests"] = _acceptedHelpRequests;

                //populate members of list
                lvList.DataSource = _acceptedHelpRequests;
                lvList.DataBind();
            }
        }

        protected void HelpRequestsListView_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (string.Equals(e.CommandName, "AddToChat"))
            {
                var dataItem = (ListViewDataItem)e.Item;
                var ID = Convert.ToInt32(e.CommandArgument);
                _currentHelpRequest = _acceptedHelpRequests.Find(x => x.ID == ID);
                Session["_currentHelpRequest"] = _currentHelpRequest;
                inputMessage.Visible = true;
                btnSendMessage.Visible = true;
                _currentHelpRequest.GetPreviousChatMessages();
                RefreshChatMessages();
            }
        }

        protected void btnSendMessage_OnClick(object sender, EventArgs e)
        {
            var message = inputMessage.Text;
            _volunteerHandler.AddChatMessage(_currentHelpRequest, _currentVolunteer, message, DateTime.Now);
            inputMessage.Text = String.Empty;
            Session["_acceptedHelpRequests"] = _acceptedHelpRequests;
            RefreshChatMessages();
        }

        protected void RefreshChatMessages()
        {
            inputChat.Text = String.Empty;
            foreach (var c in _currentHelpRequest.ChatMessages)
            {
                inputChat.Text += c.TotalString + Environment.NewLine;
            }
        }
    }
}