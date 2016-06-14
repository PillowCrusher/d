using System;
using System.Collections.Generic;
using System.Data;
using ICT4_Participation_ASP.Models.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesten
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_SqlFunction()
        {
            Handler handler = new Handler();

            List<object> parameters = new List<object>();

            parameters.Add("Badman");
            parameters.Add("Homo");
            parameters.Add("1c00fcfa13");

            string query = handler.ExecuteSqlFunction(parameters, "LogIn").ToString();

            const string goedeQuery = "SELECT a.ID, a.Username, a.email, a.Roll, ad.Barcode FROM \"Account\" a JOIN \"Admin\" ad ON a.ID = ad.ID WHERE a.ID = 3 AND ad.Barcode = 1c00fcfa13";

            Assert.AreEqual(query, goedeQuery);
        }

        [TestMethod]
        public void Test_BarcodeLogin()
        {
            Handler handler = new Handler();
            
            DataTable dt = handler.ExecuteReadQuery(null, "SELECT * FROM TABLE(LogInBar('2800a7c372'))");

            Assert.AreEqual(dt.Rows.Count, 1);
        }
    }
}
