using System;
using ICT4Participation.Classes.Database;
using ICT4Participation.Classes.Intelligence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phidgets;
using Phidgets.Events;

namespace PTS37UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Administration _administration;
        private RFID rfid;
        [TestInitialize]
        public void Initialize()
        {
            _administration = new Administration();
            
        }
        [TestMethod]
        public void Test_ConnectionString()
        {
            Assert.AreEqual(true, DatabaseManager.CheckConnection());
        }

        [TestMethod]
        public void Test_InloggenAlsGebruiker()
        {
            string username = "Harrie";
            string password = "HarriePotter";
            string false_username = "falseusername";
            string false_password = "falsepassword";
            string rfid = "2800a7c372";
            _administration.Login(username, password);
            _administration.Login(false_username, false_username);
            _administration.LoginWithRfid(rfid);
        }

        [TestMethod]
        public void Test_InloggenMetRFID()
        {
            
        }
    }
}
