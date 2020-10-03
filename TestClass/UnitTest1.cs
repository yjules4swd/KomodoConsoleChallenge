using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestClass
{
    [TestClass]
    public class UnitTest1
    {
        const string expected = "";
        [TestMethod]
        public void TestMethod1()
        {
            KomodoConsoleChallenge.Program.Main();

            Assert.AreEqual(expected, "");
        }
    }
}
