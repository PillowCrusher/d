using ICT4Participation.Classes.ClassObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICT4Participation.Classes.Intelligence;

namespace ICT4Participation.Forms
{
    public partial class HulpbehoevendeForm : Form
    {
        private Administration _administration;
        private readonly List<HelpRequest> _helpRequests;

        public HulpbehoevendeForm()
        {
            InitializeComponent();
            _administration = new Administration();
            _helpRequests = new List<HelpRequest>();

            GetPersonalHelpRequests();

            UpdateHelpListGui();
        }

        private void GetPersonalHelpRequests()
        {

        }

        private void UpdateHelpListGui()
        {
            int position = 0;

            pnlHulpVragen.Controls.Clear();

            foreach (HelpRequest h in _helpRequests)
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
