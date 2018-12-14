using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.BloqBoard;
using ConfirmationLabsTests.Helpers;

namespace ConfirmationLabsTests.GUI.Tests.BloqBoard
{
    [TestFixture]
    class CalculationTests
    {
        [SetUp]
        public void TestInitialize()
        {
            Browser.StartWithExstension();
        }

        #region STAGING_Kovan
        [Category("Calculations_sk")]
        [Test]
        public void VerifyLtvOnHistoryOrderTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyLtvOnHistoryOrder, 3, TestReInitialize);
        }

        [Category("Calculations_sk")]
        [Test]
        public void VerifyLtvOnJustCreatedOrderTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyLtvOnJustCreatedOrder, 3, TestReInitialize);
        }

        [Category("Calculations_sk")]
        [Test]
        public void VerifyAprOnHistoryOrderTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyAprOnHistoryOrder, 3, TestReInitialize);
        }

        [Category("Calculations_sk")]
        [Test]
        public void VerifyAprOnJustCreatedOrderTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyAPRCalculationOnJustCreatedOrder, 3, TestReInitialize);
        }

        [Category("Calculations_sk")]
        [Test]
        public void VerifyCollateralizationRatioTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyCollateralizationRatio, 3, TestReInitialize);
        }

        [Category("Calculations_sk")]
        [Test]
        public void VerifyRepayCalculationTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyRepayCalculation, 3, TestReInitialize);
        }
        #endregion

        #region STAGING_Mainnet
        [Category("Calculations_sm")]
        [Test]
        public void VerifyLtvOnHistoryOrderTest_sm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyLtvOnHistoryOrder, 3, TestReInitialize);
        }

        [Category("Calculations_sm")]
        [Test]
        public void VerifyLtvOnJustCreatedOrderTest_sm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyLtvOnJustCreatedOrder, 3, TestReInitialize);
        }

        [Category("Calculations_sm")]
        [Test]
        public void VerifyAprOnHistoryOrderTest_sm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyAprOnHistoryOrder, 3, TestReInitialize);
        }

        [Category("Calculations_sm")]
        [Test]
        public void VerifyAprOnJustCreatedOrderTest_sm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyAPRCalculationOnJustCreatedOrder, 3, TestReInitialize);
        }

        [Category("Calculations_sm")]
        [Test]
        public void VerifyCollateralizationRatioTest_sm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyCollateralizationRatio, 3, TestReInitialize);
        }

        [Category("Calculations_sm")]
        [Test]
        public void VerifyRepayCalculationTest_sm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyRepayCalculation, 3, TestReInitialize);
        }
        #endregion

        #region PROD_Mainnet
        [Category("Calculations_pm")]
        [Test]
        public void VerifyLtvOnHistoryOrderTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyLtvOnHistoryOrder, 3, TestReInitialize);
        }

        [Category("Calculations_pm")]
        [Test]
        public void VerifyLtvOnJustCreatedOrderTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyLtvOnJustCreatedOrder, 3, TestReInitialize);
        }

        [Category("Calculations_pm")]
        [Test]
        public void VerifyAprOnHistoryOrderTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyAprOnHistoryOrder, 3, TestReInitialize);
        }

        [Category("Calculations_pm")]
        [Test]
        public void VerifyAprOnJustCreatedOrderTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyAPRCalculationOnJustCreatedOrder, 3, TestReInitialize);
        }

        [Category("Calculations_pm")]
        [Test]
        public void VerifyCollateralizationRatioTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyCollateralizationRatio, 3, TestReInitialize);
        }

        [Category("Calculations_pm")]
        [Test]
        public void VerifyRepayCalculationTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyRepayCalculation, 3, TestReInitialize);
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
