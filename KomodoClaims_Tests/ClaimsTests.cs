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
            string check = Claim.CreateDataBase("", "", "", "", "", "", "");
            string check1 = Claim.ReadFromDataBase();
            string check3 = Claim.DeleteDataBase();
            Assert.IsNotNull(check);
            Assert.IsNotNull(check1);
            Assert.IsNotNull(check3);

        }
    }
}
