using System;
using System.Collections.Generic;
using System.Data;
using ICT4_Participation_ASP.Models.Accounts;
using ICT4_Participation_ASP.Models.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesten
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Needy()
        {
            Handler handler = new Handler();

            List<object> parameters = new List<object>();

            parameters.Add("Henkie");
            parameters.Add("henkerd");
            parameters.Add("");

            Account account = handler.Login(parameters);
            Needy needy = (Needy) account;
            
            Assert.AreEqual(needy.Username, "Henkie");
            Assert.AreEqual(needy.Barcode, "2800a7c372");
        }

        [TestMethod]
        public void Test_Volunteer()
        {
            Handler handler = new Handler();

            List<object> parameters = new List<object>();

            parameters.Add("Harrie");
            parameters.Add("HarriePotter");
            parameters.Add("");

            Account account = handler.Login(parameters);
            Volunteer volunteer = (Volunteer)account;

            Assert.AreEqual(volunteer.Username, "Harrie");
        }

        [TestMethod]
        public void Test_Admin()
        {
            Handler handler = new Handler();

            List<object> parameters = new List<object>();

            parameters.Add("Badman");
            parameters.Add("Homo");
            parameters.Add("1c00fcfa13");

            Account account = handler.Login(parameters);
            Admin admin = (Admin)account;

            Assert.AreEqual(admin.Username, "Badman");
            Assert.AreEqual(admin.Barcode, "1c00fcfa13");
        }

        [TestMethod]
        public void Test_BarcodeLogin()
        {
            Handler handler = new Handler();
            
            List<object> parameters = new List<object>();

            parameters.Add("2800a7c372");

            //DataTable dt = handler.ExecuteReadQuery(null, "SELECT * FROM TABLE(LogInBar('2800a7c372'))");

            Needy needy = handler.LoginBar(parameters);

            Assert.AreEqual(needy.Barcode, parameters[0]);
        }
    }
}
