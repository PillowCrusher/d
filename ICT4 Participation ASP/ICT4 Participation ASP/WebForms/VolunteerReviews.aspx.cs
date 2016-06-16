using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4_Participation_ASP.WebForms
{
    public partial class VolunteerReviews1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void postComment_Click(object sender, EventArgs e)
        {

        }

        protected void ReviewsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Page_Error(object sender, EventArgs e)
        {
            Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
        }
    }
}