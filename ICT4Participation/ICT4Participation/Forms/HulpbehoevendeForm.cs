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

namespace ICT4Participation.Forms
{
    public partial class HulpbehoevendeForm : Form
    {
        private Admin _admin;
        private readonly List<HelpRequest> _helpRequests;

        public HulpbehoevendeForm()
        {
            InitializeComponent();
            _admin = new Admin();
            _helpRequests = new List<HelpRequest>();
        }
    }
}
