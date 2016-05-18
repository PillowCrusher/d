using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ICT4Participation.Classes.Database;
using ICT4Participation.Classes.Intelligence;
using ICT4Participation.Classes.ClassObjects;
using System.Data.OracleClient;

namespace PTS37UnitTest
{
    [TestClass]
    public class Hulpbehoevenden
    {
        private Administration _administration;
        private Database _database;
        private List<HelpRequest> _helpRequests;
        [TestInitialize]
        public void Initialize()
        {
            _administration = new Administration();
            _administration.Login("Henkie", "henkerd");
            OracleParameter[] parameters =
            {
                new OracleParameter("needyid", _administration.User.ID)
            };

          //  _helpRequests = _administration.GetHelpRequests("GetUserHelpRequests", parameters);
        }
        [TestMethod]
        public void Test_HulpvraagMaken()
        {
            string title = "Test hulpvraag";
            string description = "Test description to test the test methods. Test test test.";
            bool urgent = true;
            TransportationType tt = TransportationType.Benenwagena;
            DateTime dt = DateTime.Today;
            DateTime dt2 = DateTime.Now;
            bool meeting = true;
            Needy currentNeedy = (Needy)_administration.User;
            currentNeedy.AddHelpRequest(title, description, urgent, tt, dt, dt2, meeting);

            Assert.IsNotNull(_helpRequests.Find(x => x.Title == title));
        }
    }
}
