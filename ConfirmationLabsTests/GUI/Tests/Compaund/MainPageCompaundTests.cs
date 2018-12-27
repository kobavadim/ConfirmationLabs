using ConfirmationLabsTests.GUI.Application.BloqBoard;
using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.Compaund;
using ConfirmationLabsTests.Helpers;


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

        #region STAGING_Kovan
        [Category("CmpndRequests_sk")]
        [Test]
        public void CheckLiquidityTableAvailabilityTest_sk()
        {
            //TestRetrier.RunWithRetry(MainPageCompaund.VerifyLendToLiquidityPoolTableisOpened, 3, TestReInitialize);
        }
        #endregion

        #region STAGING_Mainnet
        [Category("CmpndRequests_sm")]
        [Test]
        public void CheckLiquidityTableAvailabilityTest_sm()
        {
            //TestRetrier.RunWithRetry(MainPageCompaund.VerifyLendToLiquidityPoolTableisOpened, 3, TestReInitialize);
        }
        #endregion

        #region PROD_Mainnet
        [Category("CmpndRequests_pm")]
        [Test]
        public void CheckLiquidityTableAvailabilityTest_pm()
        {
            Browser.Pause(3000);
            Browser.Pause(8000);
            Browser.Pause(3000);
            //TestRetrier.RunWithRetry(MainPageCompaund.VerifyLendToLiquidityPoolTableisOpened, 3, TestReInitialize);
        }
        #endregion

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }

        private void TestReInitialize()
        {
            TestCleanUp();
            TestInitialize();
        }

    }
}
