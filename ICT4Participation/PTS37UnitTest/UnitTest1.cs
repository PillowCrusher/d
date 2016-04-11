using System;
using ICT4Participation.Classes.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PTS37UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_ConnectionString()
        {
            Assert.AreEqual(true, DatabaseManager.CheckConnection());
        }
    }
}
