using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4_Participation_ASP.Models.Handlers;
using ICT4_Participation_ASP.Models.Objects;

namespace ICT4_Participation_ASP.WebForms
{
    public partial class NeedyHelpRequest : System.Web.UI.Page
    {
        private NeedyHandler NeedyHandler { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            NeedyHandler = new NeedyHandler();
        }

        protected void btnSendHelpRequest_Click(object sender, EventArgs e)
        {
            
            string titel = inputTitle.Text;
            string description = inputText.Text;
            string location = inputLocation.Text;
            string start = inputStartDate.Text +" "+ inputStartTime.Text;
            DateTime startTime = Convert.ToDateTime(start);
            string end = inputEndDate.Text +" "+ inputEndTime.Text;
            DateTime endTime = Convert.ToDateTime(end);
            bool DrivingLicence = false;
            if (cbDrivingLicence.Checked)
            {
                DrivingLicence = true;
            }
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
                NeedyHandler.AddHelprequest(titel, description, location, startTime, endTime, DrivingLicence, urgent, meeting, skills);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script",
                    "<script>alert('De eind tijd moet later zijn dan de start tijd');</script>");
            }
        }
    }
}