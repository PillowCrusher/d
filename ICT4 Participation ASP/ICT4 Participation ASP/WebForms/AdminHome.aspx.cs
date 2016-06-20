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
        private Admin _currentAdmin;
        private AdminHandler _currentAdminHandler;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedUser"] is Admin)
            {
                _currentAdmin = (Admin)Session["LoggedUser"];
                _currentAdminHandler = new AdminHandler();
            }
            else
            {
                Response.Redirect("~/WebForms/LoginStandard.aspx");
            }


        }

        protected void ListBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void ListBox2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void ListBox3_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void Button2_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void Button4_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void Button3_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void ListBox4_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}