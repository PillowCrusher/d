using System;
using System.Security;
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
            Assert.IsNotNull(_administration.GetAccountId(username));
        }

        [TestMethod]
        public void Test_RegisterNeedy()
        {
            string username = "testneedy";
            string password = "testneedy";
            string email = "test@test.com";
            string name = "testneedynaam";
            string address = "testaddress 1";
            string city = "testneedycity";
            string phonenumber = "0123456789";
            bool publicTransport = true;
            bool hasdrivinglicence = true;
            bool hascar = true;
            string rfid = "355353544";
            _administration.AddNeedy(username, password, email, name, address, phonenumber, publicTransport, hasdrivinglicence, hascar, rfid);
            Assert.IsNotNull(_administration.GetAccountId(username));
        }
        [TestMethod]
        public void Test_InloggenAlsGebruiker()
        {
            string username = "Henkie";
            string password = "henkerd";
            string false_username = "falseusername";
            string false_password = "falsepassword";
            
            _administration.Login(username, password);
            string expected = "Henkie";
            string actual = _administration.User.Username;
            Assert.AreEqual(actual, expected);
            _administration.Login(false_username, false_username);
            
        }
        [TestMethod]
        public void Test_InloggenMetRFID()
        {
            string rfid = "2800a7c372";
            _administration.LoginWithRfid(rfid);
            string expected = "Henkie";
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
            string username = "Henkie";
            string password = "henkerd";

            _administration.Login(username, password);
            _administration.Logout();
            
            Assert.IsNull(_administration.User);
        }
        

        [TestMethod]
        public void Test_UpdateProfile()
        {            
            string username = "test";
            string password = "test";
            int id = _administration.GetAccountId(username);
            _administration.AcceptedVolunteer(id);

            _administration.Login(username, password);
            Volunteer volunteer = (Volunteer)_administration.User;
            _administration.UpdateVolunteer(password, "Harrylaan 31", volunteer.City, volunteer.Phonenumber, volunteer.PublicTransport, volunteer.HasDrivingLincense, volunteer.HasCar, volunteer.BirthDate, volunteer.Photo, volunteer.VOG);
            volunteer = (Volunteer)_administration.User;
            string actual = volunteer.Address;
            string expected = "Harrylaan 31";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Uitschrijven()
        {
            string username = "test";
            string password = "test";

            _administration.Login(username, password);
            Volunteer volunteer = (Volunteer)_administration.User;
            Assert.IsNotNull(volunteer);

            _administration.Unsubscribe(volunteer);
            Assert.IsNotNull(volunteer.DeRegistrationDate);
            _administration.DenyVolunteer(volunteer.ID);
        }
    }
}
