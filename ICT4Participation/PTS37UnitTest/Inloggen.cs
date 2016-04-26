using System;
using ICT4Participation.Classes.ClassObjects;
using ICT4Participation.Classes.Database;
using ICT4Participation.Classes.Intelligence;
using ICT4Participation.Classes.ClassObjects;
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
        public void Test_RegisterVolunteer()
        {
            string username = "test";
            string password = "test";
            string email = "test@test.com";
            string name = "testnaam";
            string address = "testaddress";
            string city = "testcity";
            string phonenumber = "0123456789";
            bool publicTransport = true;
            bool hasdrivinglicence = true;
            bool hascar = true;
            DateTime birthdate = DateTime.Now;
            string photo = "photo.png";
            string vog = "vog.pdf";
            _administration.AddVolunteer(username, password, email, name, address, city, phonenumber, publicTransport,
                hasdrivinglicence, hascar, birthdate, photo, vog);
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
            string username = "Harrie";
            string password = "HarriePotter";

            _administration.Login(username, password);
            _administration.Logout();
            
            Assert.IsNull(_administration.User);
        }
        [TestMethod]
        public void Test_Uitschrijven()
        {
            string username = "test";
            string password = "test";

            _administration.Login(username, password);
            Volunteer volunteer = new Volunteer();

            _administration.Unsubscribe(_administration.User);
        }
        [TestMethod]
        public void Test_Registreren_Volunteer()
        {
            
        }
        [TestMethod]
        public void Test_Update_Volunteer()
        {

        }
        [TestMethod]
        public void Test_Registreren_Needy()
        {

        }
    }
}
