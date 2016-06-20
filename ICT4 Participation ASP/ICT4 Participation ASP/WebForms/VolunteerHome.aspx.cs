using System;
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
        private HelpRequest _currentHelpRequest;
        private Volunteer _currentVolunteer;
        private VolunteerHandler _volunteerHandler;

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
                if (_currentVolunteer.HelpRequestsen.Count == 0)
                {
                    _volunteerHandler.GetAcceptedHelprequests(_currentVolunteer);
                }

                
            }
            else
            {
                Response.Redirect("LoginStandard.aspx");
            }

            if (!IsPostBack)
            {
                inputMessage.Visible = false;
                btnSendMessage.Visible = false;
            }

            //populate members of list
            lvList.DataSource = _currentVolunteer.HelpRequestsen;
            lvList.DataBind();
        }

        private void Page_Error(object sender, EventArgs e)
        {
            Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
        }

        protected void HelpRequestsListView_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (string.Equals(e.CommandName, "AddToChat"))
            {
                var dataItem = (ListViewDataItem)e.Item;
                var ID = Convert.ToInt32(e.CommandArgument);
                _currentHelpRequest = _currentVolunteer.HelpRequestsen.Find(x => x.ID == ID);
                Session["_currentHelpRequest"] = _currentHelpRequest;
                inputMessage.Visible = true;
                btnSendMessage.Visible = true;
                _volunteerHandler.GetChatMessages(_currentHelpRequest);


                RefreshChatMessages();
            }
        }

        protected void btnSendMessage_OnClick(object sender, EventArgs e)
        {
            inputChat.Text = string.Empty;
            var message = inputMessage.Text;
            _volunteerHandler.AddChatMessage(_currentHelpRequest, _currentVolunteer, message, DateTime.Now);
            inputMessage.Text = String.Empty;
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