﻿using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.BloqBoard;
using ConfirmationLabsTests.Helpers;

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

        #region STAGING_Kovan
        [Category("Consistent_sk")]
        [Test]
        public void LedgerDialogueTest_sk()
        {
            TestRetrier.RunWithRetry(Integration.VerifyLedgerDialoguePresence, 3, TestReInitialize);
        }

        [Ignore("Recent loans removed from staging")]
        [Category("MPIntegration_sk")]
        [Test]
        public void RecentLoansDateTest_sk()
        {
            TestRetrier.RunWithRetry(Integration.VerifyDatefromRecentLoans, 3, TestReInitialize);
        }

        [Ignore("Recent loans removed from staging")]
        [Category("MPIntegration_sk")]
        [Test]
        public void RecentLoansAmountTest_sk()
        {
            TestRetrier.RunWithRetry(Integration.VerifyAmountfromRecentLoans, 3, TestReInitialize);
        }

        [Category("MPIntegration_sk")]
        [Ignore("Recent loans removed from staging")]
        [Test]
        public void RecentLoansAprTest_sk()
        {
            TestRetrier.RunWithRetry(Integration.VerifyApRfromRecentLoans, 3, TestReInitialize);
        }

        [Category("MPIntegration_sk")]
        [Ignore("Recent loans removed from staging")]
        [Test]
        public void RecentLoansTermTest_sk()
        {
            TestRetrier.RunWithRetry(Integration.VerifyTermfromRecentLoans, 3, TestReInitialize);
        }
        #endregion

        #region STAGING_Mainnet
        [Category("Consistent_sm")]
        [Test]
        public void LedgerDialogueTest_sm()
        {
            TestRetrier.RunWithRetry(Integration.VerifyLedgerDialoguePresence, 3, TestReInitialize);
        }

        [Category("MPIntegration_sm")]
        [Ignore("Recent loans removed from staging")]
        [Test]
        public void RecentLoansDateTest_sm()
        {
            TestRetrier.RunWithRetry(Integration.VerifyDatefromRecentLoans, 3, TestReInitialize);
        }

        [Category("MPIntegration_sm")]
        [Ignore("Recent loans removed from staging")]
        [Test]
        public void RecentLoansAmountTest_sm()
        {
            TestRetrier.RunWithRetry(Integration.VerifyAmountfromRecentLoans, 3, TestReInitialize);
        }

        [Category("MPIntegration_sm")]
        [Ignore("Recent loans removed from staging")]
        [Test]
        public void RecentLoansAprTest_sm()
        {
            TestRetrier.RunWithRetry(Integration.VerifyApRfromRecentLoans, 3, TestReInitialize);
        }

        [Category("MPIntegration_sm")]
        [Ignore("Recent loans removed from staging")]
        [Test]
        public void RecentLoansTermTest_sm()
        {
            TestRetrier.RunWithRetry(Integration.VerifyTermfromRecentLoans, 3, TestReInitialize);
        }
        #endregion

        #region PROD_Mainnet
        [Category("Consistent_pm")]
        [Test]
        public void LedgerDialogueTest_pm()
        {
            TestRetrier.RunWithRetry(Integration.VerifyLedgerDialoguePresence, 3, TestReInitialize);
        }

        [Category("MPIntegration_pm")]
        [Test]
        public void RecentLoansDateTest_pm()
        {
            TestRetrier.RunWithRetry(Integration.VerifyDatefromRecentLoans, 3, TestReInitialize);
        }

        [Category("MPIntegration_pm")]
        [Test]
        public void RecentLoansAmountTest_pm()
        {
            TestRetrier.RunWithRetry(Integration.VerifyAmountfromRecentLoans, 3, TestReInitialize);
        }

        [Category("MPIntegration_pm")]
        [Test]
        public void RecentLoansAprTest_pm()
        {
            TestRetrier.RunWithRetry(Integration.VerifyApRfromRecentLoans, 3, TestReInitialize);
        }

        [Category("MPIntegration_pm")]
        [Test]
        public void RecentLoansTermTest_pm()
        {
            TestRetrier.RunWithRetry(Integration.VerifyTermfromRecentLoans, 3, TestReInitialize);
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
