using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4_Participation_ASP.Models.Accounts;
using ICT4_Participation_ASP.Models.Handlers;

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
        }

        private void Page_Error(object sender, EventArgs e)
        {
            Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
        }
    }
}