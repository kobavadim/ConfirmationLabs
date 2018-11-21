using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.BloqBoard;

namespace ConfirmationLabsTests.GUI.Tests.BloqBoard
{
    [TestFixture]
    class IntegrationTests
    {
        [SetUp]
        public void TestInitialize()
        {
            Browser.StartWithExstension();
        }

        [Category("MPIntegration")]
        [Test]
        public void RecentLoansDateTest()
        {
            Integration.VerifyDatefromRecentLoans();
        }

        [Category("MPIntegration")]
        [Test]
        public void RecentLoansAmountTest()
        {
            Integration.VerifyAmountfromRecentLoans();
        }

        [Category("MPIntegration")]
        [Test]
        public void RecentLoansAprTest()
        {
            Integration.VerifyApRfromRecentLoans();
        }

        [Category("MPIntegration")]
        [Test]
        public void RecentLoansTermTest()
        {
            Integration.VerifyTermfromRecentLoans();
        }

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }
    }
}
