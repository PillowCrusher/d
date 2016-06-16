using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4_Participation_ASP.Models.Accounts;
using ICT4_Participation_ASP.Models.Handlers;
using ICT4_Participation_ASP.Models.Objects;

namespace ICT4_Participation_ASP.WebForms
{
    public partial class NeedyHome : System.Web.UI.Page
    {
        private NeedyHandler _needyHandler;
        private Needy _currentNeedy;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedUser"] is Needy)
            {
                _currentNeedy = (Needy) Session["LoggedUser"];
                _needyHandler = new NeedyHandler();
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

        private void Page_Error(object sender, EventArgs e)
        {
            Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
        }

        protected void btnSendMessage_OnClick(object sender, EventArgs e)
        {
            
        }
        protected void templateButton_OnClick(object sender, EventArgs e)
        {
            Button myButton = (Button)sender;
            
        }
    }
}