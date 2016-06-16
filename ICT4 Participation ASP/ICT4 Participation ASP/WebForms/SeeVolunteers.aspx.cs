using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4_Participation_ASP.WebForms
{
    public partial class SeeVolunteers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        private void Page_Error(object sender, EventArgs e)
        {
            Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
        }

        protected void vrijwilligersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void RecensiesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void AcceptButton_Click(object sender, EventArgs e)
        {

        }

        protected void DenyButton_Click(object sender, EventArgs e)
        {

        }
    }
}