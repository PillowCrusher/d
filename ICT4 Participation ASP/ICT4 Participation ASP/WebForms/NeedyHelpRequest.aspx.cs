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
        private NeedyHandler _needyHandler { get; set; }
        private Needy Needy { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedUser"] is Needy)
            {
                Needy = (Needy) Session["LoggedUser"];
                _needyHandler = new NeedyHandler();
                DdlTransport.Items.Clear();
                foreach (TransportationType r in Enum.GetValues(typeof(TransportationType)))
                {
                    ListItem item = new ListItem(Enum.GetName(typeof(TransportationType), r), r.ToString());
                    DdlTransport.Items.Add(item);
                }
                List<Skill> skills = _needyHandler.GetSkills();
                foreach (Skill s in skills)
                {
                    SkillCheckBoxList.Items.Add(s.ToString());
                }
            }
            else
            {
                Response.Redirect("LoginStandard.aspx");
            }
        }

        protected void btnSendHelpRequest_Click(object sender, EventArgs e)
        {
            Needy = (Needy)Session["LoggedUser"];
            string titel = inputTitle.Text;
            string description = inputText.Text;
            string location = inputLocation.Text;
            int traveltime = 0;
            if (inputRijsTijd.Text != string.Empty)
            {
               traveltime = Convert.ToInt32(inputRijsTijd.Text);
            }
            string start = inputStartDate.Text +" "+ inputStartTime.Text;
            DateTime startTime = Convert.ToDateTime(start);
            string end = inputEndDate.Text +" "+ inputEndTime.Text;
            DateTime endTime = Convert.ToDateTime(end);
            string transportation = DdlTransport.Text;
            int ammount = Convert.ToInt32(inputAantalVrijwilliger.Text);
            bool urgent = cbUrgent.Checked;
            bool meeting = cbMeeting.Checked;
            List<Skill> skills = _needyHandler.GetSkills();
            List<Skill> mySkills = new List<Skill>();
            foreach (ListItem item in SkillCheckBoxList.Items)
            {
                if (item.Selected)
                {
                    foreach (Skill s in skills)
                    {
                        if (item.ToString() == s.ToString())
                        {
                            mySkills.Add(s);
                        }
                    }
                }
            }
            if (startTime < endTime && traveltime >= 0)
            {
                _needyHandler.AddHelprequest(Needy, titel, description, location, traveltime, Convert.ToInt32(urgent), transportation, startTime, endTime, ammount, Convert.ToInt32(meeting), mySkills);
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Je hebt de helprequest "+titel+ " aangemaakt');window.open('NeedyHome.aspx','_self');", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script",
                    "<script>alert('De eind tijd moet later zijn dan de start tijd');</script>");
            }
        }
    }
}