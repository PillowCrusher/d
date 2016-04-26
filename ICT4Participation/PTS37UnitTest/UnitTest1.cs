using System;
using ICT4Participation.Classes.Database;
using ICT4Participation.Classes.Intelligence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PTS37UnitTest
{
    [TestClass]
    public class UnitTest1
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
    }
}
