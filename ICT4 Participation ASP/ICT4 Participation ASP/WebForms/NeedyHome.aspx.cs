using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4_Participation_ASP.Models.Accounts;
using ICT4_Participation_ASP.Models.Handlers;
using ICT4_Participation_ASP.Models.Objects;

namespace ICT4_Participation_ASP.WebForms
{
    public partial class NeedyHome : Page
    {
        private HelpRequest _currentHelpRequest;
        private Needy _currentNeedy;
        private NeedyHandler _needyHandler;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _currentHelpRequest = (HelpRequest)Session["_currentHelpRequest"];
            }
            if (Session["LoggedUser"] is Needy)
            {
                _currentNeedy = (Needy)Session["LoggedUser"];
                _needyHandler = new NeedyHandler();
                if (_currentNeedy.HelpRequestsen.Count == 0)
                {
                    _needyHandler.GetHelprequests(_currentNeedy);
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
                LinkReview.Visible = false;
            }

            //populate members of list
            lvList.DataSource = _currentNeedy.HelpRequestsen;
            lvList.DataBind();
        }

        private void Page_Error(object sender, EventArgs e)
        {
            Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
        }

        protected void EmployeesListView_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (string.Equals(e.CommandName, "AddToChat"))
            {
                inputChat.Text = string.Empty;
                var dataItem = (ListViewDataItem)e.Item;
                var ID = Convert.ToInt32(e.CommandArgument);
                _currentHelpRequest = _currentNeedy.HelpRequestsen.Find(x => x.ID == ID);
                Session["_currentHelpRequest"] = _currentHelpRequest;
                inputMessage.Visible = true;
                btnSendMessage.Visible = true;
                _needyHandler.GetChatMessages(_currentHelpRequest);


                LinkReview.Visible = true;
                RefreshChatMessages();
            }
        }

        protected void btnSendMessage_OnClick(object sender, EventArgs e)
        {
            inputChat.Text = string.Empty;
            string message = inputMessage.Text;
            _needyHandler.AddChatMessage(_currentHelpRequest, _currentNeedy, message, DateTime.Now);
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

        protected void LinkReview_Click(object sender, EventArgs e)
        {
            Session["_currentHelpRequest"] = _currentHelpRequest;
            Response.Redirect("NeedyReview.aspx");
        }
    }
}