using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KomodoClaims_Repository;
namespace KomodoClaims_Tests
{
    [TestClass]
    public class ClaimsTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            ClaimsRepository Claim = new ClaimsRepository();
            Claim.queue.Add("Class");
            Assert.AreEqual(false, Claim.ValueFound("Test"));
        }
    }
}
