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
    public partial class NeedyHelpRequest : System.Web.UI.Page
    {
        private NeedyHandler NeedyHandler { get; set; }
        private Needy Needy { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Needy = (Needy)Session["LoggedUser"];
            NeedyHandler = new NeedyHandler();
            DdlTransport.Items.Clear();
            foreach (TransportationType r in Enum.GetValues(typeof(TransportationType)))
            {
                ListItem item = new ListItem(Enum.GetName(typeof(TransportationType), r), r.ToString());
                DdlTransport.Items.Add(item);
            }

        }

        protected void btnSendHelpRequest_Click(object sender, EventArgs e)
        {
            Needy = (Needy)Session["LoggedUser"];
            string titel = inputTitle.Text;
            string description = inputText.Text;
            string location = inputLocation.Text;
            int traveltime = Convert.ToInt32(inputRijsTijd.Text);
            string start = inputStartDate.Text +" "+ inputStartTime.Text;
            DateTime startTime = Convert.ToDateTime(start);
            string end = inputEndDate.Text +" "+ inputEndTime.Text;
            DateTime endTime = Convert.ToDateTime(end);
            string transportation = DdlTransport.Text;
            int ammount = Convert.ToInt32(inputAantalVrijwilliger.Text);
            bool urgent = false;
            if (cbUrgent.Checked)
            {
                urgent = true;
            }
            bool meeting = false;
            if (cbMeeting.Checked)
            {
                meeting = true;
            }
            string skills = null;
            foreach (ListItem item in SkillCheckBoxList.Items)
            {
                if (item.Selected)
                {
                    skills+="$"+item.Value;
                }
            }
            if (startTime < endTime)
            {
                NeedyHandler.AddHelprequest(Needy, titel, description, location, traveltime, Convert.ToInt32(urgent), transportation, startTime, endTime, ammount, Convert.ToInt32(meeting));
                Response.Redirect("NeedyHome.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script",
                    "<script>alert('De eind tijd moet later zijn dan de start tijd');</script>");
            }
        }
    }
}