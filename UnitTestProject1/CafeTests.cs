using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KomodoCafe_Repository;
namespace UnitTestProject1
{
    [TestClass]
    public class CafeTests
    {

        [TestMethod]
        public void TestMethod1()
        {
            CafeRepository MyTest = new CafeRepository();
            string check1 = MyTest.CreateDataBase("", "", "", "", "");
            string check2 = MyTest.ReadFromDataBase();
            string check3 = MyTest.DeleteDataBase();
            Assert.IsNotNull(check1);
            Assert.AreEqual("read", check2);
            Assert.AreEqual("deleted", check3);
        }
    }
}
