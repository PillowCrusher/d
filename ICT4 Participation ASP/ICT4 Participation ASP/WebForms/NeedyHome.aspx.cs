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


        private readonly List<HelpRequest> theList = new List<HelpRequest>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _currentHelpRequest = (HelpRequest) Session["_currentHelpRequest"];
            }
            if (Session["LoggedUser"] is Needy)
            {
                _currentNeedy = (Needy) Session["LoggedUser"];
                _needyHandler = new NeedyHandler();

            }
            else
            {
                Response.Redirect("LoginStandard.aspx");
            }
            if (!IsPostBack)
            {
                var h = 
                new HelpRequest(0, "ja", "kekef", "locatie", 100, true, TransportationType.Auto,
                    DateTime.Today,
                    DateTime.Now, 5, true, new List<Skill>());
                theList.Add(h);
                _currentNeedy.AddHelpRequest(h);

                //populate members of list
                lvList.DataSource = _needyHandler.GetHelprequests(_currentNeedy);
                lvList.DataBind();
            }
        }

        private void Page_Error(object sender, EventArgs e)
        {
            Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
        }

        protected void EmployeesListView_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (string.Equals(e.CommandName, "AddToChat"))
            {
                // Verify that the employee ID is not already in the list. If not, add the
                // employee to the list.
                var dataItem = (ListViewDataItem) e.Item;
                var ID = Convert.ToInt32(e.CommandArgument);
                _currentHelpRequest = _currentNeedy.HelpRequestsen.Find(x => x.ID == ID);
                Session["_currentHelpRequest"] = _currentHelpRequest;
                RefreshChatMessages();
            }
        }

        protected void btnSendMessage_OnClick(object sender, EventArgs e)
        {
            var message = inputMessage.Text;
            _currentHelpRequest.AddChatMessages(new ChatMessage(_currentNeedy, message, DateTime.Now));
            inputMessage.Text = String.Empty;
            RefreshChatMessages();
        }

        protected void RefreshChatMessages()
        {
            inputChat.Text = String.Empty;
            foreach (var c in _currentHelpRequest.ChatMessages)
            {
                inputChat.Text += Environment.NewLine + c.Sender.Name + ": " + c.Message;
            }
        }
    }
}