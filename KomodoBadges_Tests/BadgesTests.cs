using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KomodoBadges_Repository;
using System.Collections.Generic;

namespace KomodoBadges_Tests
{
    [TestClass]
    public class BadgesTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            BadgesRepository MyBadges = new BadgesRepository();

            string check1 = MyBadges.CreateDataBase("", "");
            string check2 = MyBadges.ReadFromDataBase();
            string check3 = MyBadges.DeleteDataBase();
            Assert.IsNotNull(MyBadges.CreateDataBase("", ""));
            Assert.AreEqual("read", check2);
            Assert.AreEqual("deleted", check3);
        }
    }
}
