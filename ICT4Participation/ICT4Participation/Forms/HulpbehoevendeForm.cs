using ICT4Participation.Classes.ClassObjects;
using System.Collections.Generic;
using System.Windows.Forms;
using ICT4Participation.Classes.Intelligence;
using Oracle.ManagedDataAccess.Client;

namespace ICT4Participation.Forms
{
    public partial class HulpbehoevendeForm : Form
    {
        private Administration _administration;
        private List<HelpRequest> _helpRequests;

        public HulpbehoevendeForm()
        {
            InitializeComponent();
            _administration = new Administration();

            GetPersonalHelpRequests();

            UpdateHelpListGui();
        }

        private void GetPersonalHelpRequests()
        {
            
            OracleParameter[] parameters =
            {
                new OracleParameter("needyid", _administration.GetCurrentUser().Account.ID)
            };

            _helpRequests = _administration.GetHelpRequests(parameters);
        }

        private void UpdateHelpListGui()
        {
            int position = 0;

            pnlHulpVragen.Controls.Clear();

            foreach (HelpRequest h in _helpRequests)
            {
                if (!h.Completed)
                {
                    pnlHulpVragen.Controls.Add(
                        FormTools.NewHelpRequest(
                            h.NeedyName,
                            h.Titel,
                            h.Description,
                            h.Location,
                            h.Urgent,
                            h.Transportation,
                            h.DeadLine,
                            h.Interview,
                            position
                            )
                        );
                    position++;
                }
            }
        }
    }
}
