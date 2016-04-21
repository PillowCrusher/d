using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICT4Participation.Classes.ClassObjects;
using ICT4Participation.Classes.Intelligence;
using Oracle.ManagedDataAccess.Client;
using ICT4Participation.Classes.Database;

namespace ICT4Participation.Forms
{
    public partial class VrijwilligersForm : Form
    {
        private readonly Administration _administration;
        private readonly List<HelpRequest> _helpRequests;

        public VrijwilligersForm()
        {
            InitializeComponent();
            _administration = new Administration();
            _helpRequests = new List<HelpRequest>();

            GetAllHelpRequests();

            UpdateHelpListGui();
            UpdatePersonalRecords();
        }

        private void GetAllHelpRequests()
        {
            /*
            OracleParameter[] parameter =
            {
                new OracleParameter("USERID", Convert.ToInt32(row[3]))
            };
            */

            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllHelpRequests"], null);

            foreach (DataRow dr in dt.Rows)
            {

                _helpRequests.Add(
                    new HelpRequest(
                        Convert.ToInt32(dr["ID"]),
                        dr["Name"].ToString(),
                        dr["Title"].ToString(),
                        dr["Description"].ToString(),
                        dr["Location"].ToString(),
                        Convert.ToBoolean(dr["Urgent"]),
                        (TransportationType)Enum.Parse(typeof(TransportationType), dr["TransportType"].ToString()),
                        DateTime.Now, //Convert.ToDateTime(dr["StartDate"]),
                        DateTime.Now, //Convert.ToDateTime(dr["EndDate"]),
                        Convert.ToBoolean(dr["Interview"])
                        )
                    );
            }
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
                        h.StartDate,
                        h.DeadLine,
                        h.Urgent,
                        h.Interview,
                        h.Transportation,
                        position
                        )
                    );
                position++;

            }
        }

        private void UpdatePersonalRecords()
        {
            if (_administration.GetCurrentUser() is Volunteer)
            {
                Volunteer currentUser = (Volunteer)_administration.GetCurrentUser();

                lblPersonalInfo.Text =
                    "Naam: " + currentUser.Name + Environment.NewLine +
                    "Rijbewijs: " + FormTools.ConvertBoolToString(currentUser.HasDrivingLincense) +
                    Environment.NewLine +
                    "Auto beschikbaar: " + FormTools.ConvertBoolToString(currentUser.HasCar) + Environment.NewLine;
                //"Openbaar vervoer: " + FormTools.ConvertBoolToString(currentUser.)
            }
        }
    }
}
