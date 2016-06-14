using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4_Participation_ASP.Models.Accounts;
using ICT4_Participation_ASP.Models.Handlers;

namespace ICT4_Participation_ASP
{
    public partial class AdminPage : System.Web.UI.Page
    {
        private AdminHandler _adminHandler;
        private Admin _currentAdmin;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedUser"] is Admin)
            {
                _currentAdmin = (Admin)Session["LoggedUser"];
                _adminHandler = new AdminHandler();
            }
            else
            {
                Response.Redirect("LoginStandard.aspx");
            }
        }
    }
}