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
    public partial class NeedyPendingVolunteers : System.Web.UI.Page
    {
        private Needy _currentNeedy;
        private NeedyHandler _needyHandler;
        private List<Volunteer> _volunteers;
        private List<HelpRequest> _helpRequests;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                //_volunteers = _needyHandler.GetPendingVolunteers();
            }
            if (Session["LoggedUser"] is Needy)
            {
                _currentNeedy = (Needy)Session["LoggedUser"];
                _needyHandler = new NeedyHandler();
                List<object> everything = _needyHandler.GetPendingVolunteers(_currentNeedy);
                _volunteers = (List<Volunteer>)everything[0];
                _helpRequests = (List<HelpRequest>) everything[1];
            }
            else
            {
                Response.Redirect("LoginStandard.aspx");
            }
            if (!IsPostBack)
            {
                //populate members of list
                lvList.DataSource = _volunteers;
                lvList.DataBind();
            }
        }
        protected void EmployeesListView_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (string.Equals(e.CommandName, "Accept"))
            {
                var dataItem = (ListViewDataItem)e.Item;
                var ID = Convert.ToInt32(e.CommandArgument);
                Volunteer volunteer = _volunteers.Find(x => x.ID == ID);
                _needyHandler.AcceptVolunteer(_currentNeedy, volunteer);
            }
            if (string.Equals(e.CommandName, "Decline"))
            {
                var dataItem = (ListViewDataItem)e.Item;
                var ID = Convert.ToInt32(e.CommandArgument);
                //_currentVolunteer = _volunteers.Find(x => x.ID == ID);
                //Session["_currentHelpRequest"] = _currentHelpRequest;
            }
        }

    }
}