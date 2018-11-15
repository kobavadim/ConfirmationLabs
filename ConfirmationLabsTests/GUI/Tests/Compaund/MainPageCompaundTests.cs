using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.Compaund;


namespace ConfirmationLabsTests.GUI.Tests.Compaund
{

    [TestFixture]
    class MainPageCompaundTests
    {

        [SetUp]
        public void TestInitialize()
        {
            Browser.StartWithExstension();
        }

        [Category("Compound")]
        [Test]
        public void CheckLiquidityTableAvailabilityTest()
        {
            MainPageCompaund.VerifyLendToLiquidityPoolTableisOpened();
        }

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }

    }
}
