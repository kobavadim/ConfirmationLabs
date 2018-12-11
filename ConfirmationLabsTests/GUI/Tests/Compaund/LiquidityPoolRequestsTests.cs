using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.Compaund;


namespace ConfirmationLabsTests.GUI.Tests.Compaund
{
    [TestFixture]
    class LiquidityPoolRequestsTests
    {
        [SetUp]
        public void TestInitialize()
        {
            Browser.StartWithExstension();
        }

        #region STAGING_Kovan
        [Category("Lend_sk")]
        [Category("CmpndRequests_sk")]
        [Test]
        public void LendToLiquidityPoolTest_sk()
        {
            MainPageCompaund.VerifyTokenCanbeLendedtoLiquidityPool();
        }

        [Ignore("Fix after redesign")]
        [Category("Withdraw_sk")]
        [Category("CmpndRequests_sk")]
        [Test]
        public void WithdrawFromLiquidityPoolTest_sk()
        {
            MainPageCompaund.VerifyTokenCanbeWithdrawnedFromLiquidityPool();
        }

        [Category("Borrow_sk")]
        [Category("CmpndRequests_sk")]
        [Test]
        public void BorrowFromLiquidityPoolTest_sk()
        {
            MainPageCompaund.VerifyTokenCanbeBorrowedFromLiquidityPool();
        }

        [Ignore("Fix after redesign")]
        [Category("Repay_sk")]
        [Category("CmpndRequests_sk")]
        [Test]
        public void RepayFromLiquidityPoolTest_sk()
        {
            MainPageCompaund.VerifyTokenCanbeRepaidFromLiquidityPool();
        }
        #endregion

        #region STAGING_Mainnet
        [Category("Lend_sm")]
        [Category("CmpndRequests_sm")]
        [Test]
        public void LendToLiquidityPoolTest_sm()
        {
            MainPageCompaund.VerifyTokenCanbeLendedtoLiquidityPool();
        }

        [Ignore("Fix after redesign")]
        [Category("Withdraw_sm")]
        [Category("CmpndRequests_sm")]
        [Test]
        public void WithdrawFromLiquidityPoolTest_sm()
        {
            MainPageCompaund.VerifyTokenCanbeWithdrawnedFromLiquidityPool();
        }

        [Ignore("Borrowing from the liquidity pool is temporarily disabled")]     
        [Category("Borrow_sm")]
        [Category("CmpndRequests_sm")]
        [Test]
        public void BorrowFromLiquidityPoolTest_sm()
        {
            MainPageCompaund.VerifyTokenCanbeBorrowedFromLiquidityPool();
        }

        [Ignore("Fix after redesign")]
        [Category("Repay_sm")]
        [Category("CmpndRequests_sm")]
        [Test]
        public void RepayFromLiquidityPoolTest_sm()
        {
            MainPageCompaund.VerifyTokenCanbeRepaidFromLiquidityPool();
        }
        #endregion

        #region PROD_Mainnet
        [Category("Lend_pm")]
        [Category("CmpndRequests_pm")]
        [Test]
        public void LendToLiquidityPoolTest_pm()
        {
            MainPageCompaund.VerifyTokenCanbeLendedtoLiquidityPool();
        }

        [Ignore("Fix after redesign")]
        [Category("Withdraw_pm")]
        [Category("CmpndRequests_pm")]
        [Test]
        public void WithdrawFromLiquidityPoolTest_pm()
        {
            MainPageCompaund.VerifyTokenCanbeWithdrawnedFromLiquidityPool();
        }

        [Category("Borrow_pm")]
        [Category("CmpndRequests_pm")]
        [Test]
        public void BorrowFromLiquidityPoolTest_pm()
        {
            MainPageCompaund.VerifyTokenCanbeBorrowedFromLiquidityPool();
        }

        [Ignore("Fix after redesign")]
        [Category("Repay_pm")]
        [Category("CmpndRequests_pm")]
        [Test]
        public void RepayFromLiquidityPoolTest_pm()
        {
            MainPageCompaund.VerifyTokenCanbeRepaidFromLiquidityPool();
        }
        #endregion

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }
    }
}
