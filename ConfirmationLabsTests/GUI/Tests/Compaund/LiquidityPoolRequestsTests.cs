using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.Compaund;
using ConfirmationLabsTests.Helpers;


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
            TestRetrier.RunWithRetry(MainPageCompaund.VerifyTokenCanbeLendedtoLiquidityPool, 3, TestReInitialize);
        }

        [Ignore("Waiting for tokens on kovan")]
        [Category("Withdraw_sk")]
        [Category("CmpndRequests_sk")]
        [Test]
        public void WithdrawFromLiquidityPoolTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageCompaund.VerifyTokenCanbeWithdrawnedFromLiquidityPool, 3, TestReInitialize);
        }

        [Category("Borrow_sk")]
        [Category("CmpndRequests_sk")]
        [Test]
        public void BorrowFromLiquidityPoolTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageCompaund.VerifyTokenCanbeBorrowedFromLiquidityPool, 3, TestReInitialize);
        }

        [Ignore("Waiting for tokens on kovan")]
        [Category("Repay_sk")]
        [Category("CmpndRequests_sk")]
        [Test]
        public void RepayFromLiquidityPoolTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageCompaund.VerifyTokenCanbeRepaidFromLiquidityPool, 3, TestReInitialize);
        }
        #endregion

        #region STAGING_Mainnet
        [Category("Lend_sm")]
        [Category("CmpndRequests_sm")]
        [Test]
        public void LendToLiquidityPoolTest_sm()
        {
            TestRetrier.RunWithRetry(MainPageCompaund.VerifyTokenCanbeLendedtoLiquidityPool, 3, TestReInitialize);
        }

        [Category("Withdraw_sm")]
        [Category("CmpndRequests_sm")]
        [Test]
        public void WithdrawFromLiquidityPoolTest_sm()
        {
            //TestRetrier.RunWithRetry(MainPageCompaund.VerifyTokenCanbeWithdrawnedFromLiquidityPool, 3, TestReInitialize);
        }

        //[Ignore("Borrowing from the liquidity pool is temporarily disabled")]     
        [Category("Borrow_sm")]
        [Category("CmpndRequests_sm")]
        [Test]
        public void BorrowFromLiquidityPoolTest_sm()
        {
            TestRetrier.RunWithRetry(MainPageCompaund.VerifyTokenCanbeBorrowedFromLiquidityPool, 3, TestReInitialize);
        }

        [Ignore("Budget needed")]
        [Category("Repay_sm")]
        [Category("CmpndRequests_sm")]
        [Test]
        public void RepayFromLiquidityPoolTest_sm()
        {
            //TestRetrier.RunWithRetry(MainPageCompaund.VerifyTokenCanbeRepaidFromLiquidityPool, 3, TestReInitialize);
        }
        #endregion

        #region PROD_Mainnet
        [Category("Lend_pm")]
        [Category("CmpndRequests_pm")]
        [Test]
        public void LendToLiquidityPoolTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageCompaund.VerifyTokenCanbeLendedtoLiquidityPool, 3, TestReInitialize);
        }

        [Ignore("Fix after redesign")]
        [Category("Withdraw_pm")]
        [Category("CmpndRequests_pm")]
        [Test]
        public void WithdrawFromLiquidityPoolTest_pm()
        {
            //TestRetrier.RunWithRetry(MainPageCompaund.VerifyTokenCanbeWithdrawnedFromLiquidityPool, 3, TestReInitialize);
        }

        //[Ignore("Borrowing from the liquidity pool is temporarily disabled")]
        [Category("Borrow_pm")]
        [Category("CmpndRequests_pm")]
        [Test]
        public void BorrowFromLiquidityPoolTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageCompaund.VerifyTokenCanbeBorrowedFromLiquidityPool, 3, TestReInitialize);
        }

    
        [Category("Repay_pm")]
        [Category("CmpndRequests_pm")]
        [Test]
        public void RepayFromLiquidityPoolTest_pm()
        {
            //TestRetrier.RunWithRetry(MainPageCompaund.VerifyTokenCanbeRepaidFromLiquidityPool, 3, TestReInitialize);
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
