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
        private List<ItemData> _listData;

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
                _listData = new List<ItemData>();
                _helpRequests = _needyHandler.GetPendingVolunteers(_currentNeedy);


                foreach (var hr in _helpRequests)
                {
                    foreach (Volunteer v in hr.Pending)
                    {
                        _listData.Add(new ItemData(v.Name, hr.Titel, v.ID, hr.ID));
                    }
                }
            }
            else
            {
                Response.Redirect("LoginStandard.aspx");
            }
            if (!IsPostBack)
            {
                //populate members of list
                lvList.DataSource = _listData;
                lvList.DataBind();
            }
        }
        protected void EmployeesListView_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (string.Equals(e.CommandName, "Accept"))
            {
                var dataItem = (ListViewDataItem)e.Item;
                var Volunteer_ID = Convert.ToInt32(e.CommandArgument);
                var HelpRequest_ID = _listData.Find(a => a.UserID == Volunteer_ID).HelpRequestID;
                //int HelpRequest_ID = _helpRequests[HelpRequest_Index];
                
                HelpRequest helprequest = _helpRequests.Find(x => x.ID == HelpRequest_ID);
                Volunteer volunteer = helprequest.Pending.Find(x => x.ID == Volunteer_ID);
                _needyHandler.AcceptVolunteer(volunteer, helprequest);
                Response.Redirect(Request.RawUrl);
            }
            if (string.Equals(e.CommandName, "Decline"))
            {
                var dataItem = (ListViewDataItem)e.Item;
                var Volunteer_ID = Convert.ToInt32(e.CommandArgument);
                var HelpRequest_ID = _listData.Find(a => a.UserID == Volunteer_ID).HelpRequestID;
                //int HelpRequest_ID = _helpRequests[HelpRequest_Index];

                HelpRequest helprequest = _helpRequests.Find(x => x.ID == HelpRequest_ID);
                Volunteer volunteer = helprequest.Pending.Find(x => x.ID == Volunteer_ID);
                _needyHandler.DeclineVolunteer(volunteer, helprequest);
                Response.Redirect(Request.RawUrl);
            }
        }
    }
    public class ItemData
    {
        public string Name { get; set; }
        public string Titel { get; set; }
        public int UserID { get; set; }
        public int HelpRequestID { get; set; }

        public ItemData(string name, string titel, int userid, int helprequestid)
        {
            Name = name;
            Titel = titel;
            UserID = userid;
            HelpRequestID = helprequestid;
        }
    }
}