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
            Assert.AreEqual(5, MyTest._MenuItems.Length);
        }
    }
}
