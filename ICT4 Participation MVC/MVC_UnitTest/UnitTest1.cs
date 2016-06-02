using System;
using ICT4_Participation_MVC.Models.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MVC_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOracleConnection()
        {
            Assert.IsTrue(OracleManager.CheckConnection());
        }
    }
}
