using System;
using System.Text;
using System.Collections.Generic;
using ICT4Participation.Classes.Database;
using ICT4Participation.Classes.Intelligence;
using ICT4Participation.Classes.ClassObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PTS37UnitTest
{
    /// <summary>
    /// Summary description for Beheren
    /// </summary>
    [TestClass]
    public class Beheren
    {
        private readonly Administration _administration;
        private List<Volunteer> _volunteers;
        private List<Volunteer> _pendingVolunteers;
        public Beheren()
        {
            //
            // TODO: Add constructor logic here
            //
            _administration = new Administration();
            _administration.Login("Badman", "homo", "1c00fcfa13");
            _volunteers = _administration.GetAllVolunteers("GetAcceptedVolunteers");
            _pendingVolunteers = _administration.GetAllVolunteers("GetVOGVolunteers");
        }
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void Test_BlockUser()
        {
            //
            // TODO: Add test logic here
            //
            string name = "testnaam";
            Volunteer volunteer = _volunteers.Find(x => x.Name == name);
            _administration.BlockAccount(volunteer);
            _volunteers.Clear();
            _volunteers = _administration.GetAllVolunteers("GetAcceptedVolunteers");
            Assert.IsNull(_volunteers.Find(x => x.Name == name));
        }

        [TestMethod]
        public void Test_DeleteHelpRequest()
        {
            
        }
    }
}
