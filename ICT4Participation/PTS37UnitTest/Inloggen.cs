using System;
using ICT4Participation.Classes.Database;
using ICT4Participation.Classes.Intelligence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PTS37UnitTest
{
    [TestClass]
    public class Inloggen
    {
        private Administration _administration;
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
            
            _administration.Login(username, password);
            string expected = "Harrie";
            string actual = _administration.User.Username;
            Assert.AreEqual(actual, expected);
            _administration.Login(false_username, false_username);
            
        }
        [TestMethod]
        public void Test_InloggenMetRFID()
        {
            string rfid = "2800a7c372";
            _administration.LoginWithRfid(rfid);
            string expected = "henkie";
            string actual = _administration.User.Username;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void Test_InloggenAlsAdmin()
        {
            string username = "Badman";
            string password = "Homo";
            string rfid = "1c00fcfa13";

            _administration.Login(username, password, rfid);
            string expected = "Badman";
            string actual = _administration.User.Username;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Uitloggen()
        {
            
        }


    }
}
