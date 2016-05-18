using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4Participation.Classes.Intelligence;

namespace WebTechnieken
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void LogIn_Button_Click(object sender, EventArgs e)
        {
            ICT4Participation.Classes.Intelligence.Administration administration = new Administration();
            administration.Login("Harrie", "HarriePotter");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('"+administration.User.Email+"');</script>");

        }
    }
}