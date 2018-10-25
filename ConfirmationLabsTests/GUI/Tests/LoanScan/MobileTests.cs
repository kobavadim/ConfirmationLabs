using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.LoanScan;

namespace ConfirmationLabsTests.GUI.Tests.LoanScan
{


    [TestFixture]

    class MobileTests
    {
        [SetUp]
        public void TestInitialize()
        {
            Browser.StartMobile();
        }

        [Category("LoanscanMobile")]
        [Test]
        public void CheckMobileMainPage()
        {
            
        }

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }
    }
}
