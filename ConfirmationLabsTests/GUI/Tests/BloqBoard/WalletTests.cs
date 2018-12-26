using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.BloqBoard;
using ConfirmationLabsTests.GUI.Application.Compaund;
using ConfirmationLabsTests.Helpers;

namespace ConfirmationLabsTests.GUI.Tests.BloqBoard
{
    [TestFixture]
    class WalletTests
    {
        [SetUp]
        public void TestInitialize()
        {
            Browser.StartWithExstension();
        }

        #region STAGING_Kovan
        [Category("Wallet_sk")]
        [Test]
        public void WrapTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyEthCanBeWrapped, 3, TestReInitialize);
        }

        [Category("Wallet_sk")]
        [Test]
        public void UnwrapTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyETHCanBeUnwrapped, 3, TestReInitialize);
        }

        [Category("Wallet_sk")]
        [Test]
        public void EnablePermissionTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyPermissionCanBeEnabled, 3, TestReInitialize);
        }

        [Category("Wallet_sk")]
        [Test]
        public void DisablePermissionTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyPermissionCanBeDisabled, 3, TestReInitialize);
        }

        [Category("Wallet_sk")]
        [Test]
        public void EnablePermissionFromWalletTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyPermissionCanBeEnabled, 3, TestReInitialize);
        }

        [Category("Wallet_sk")]
        [Test]
        public void DisablePermissionFromWalletTest_sk()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyPermissionCanBeDisabled, 3, TestReInitialize);
        }
        #endregion

        #region STAGING_Mainnet
        [Category("Wallet_sm")]
        [Test]
        public void WrapTest_sm()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyEthCanBeWrapped, 3, TestReInitialize);
        }

        [Category("Wallet_sm")]
        [Test]
        public void UnwrapTest_sm()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyETHCanBeUnwrapped, 3, TestReInitialize);
        }

        [Category("Wallet_sm")]
        [Test]
        public void EnablePermissionTest_sm()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyPermissionCanBeEnabled, 3, TestReInitialize);
        }

        [Category("Wallet_sm")]
        [Test]
        public void DisablePermissionTest_sm()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyPermissionCanBeDisabled, 3, TestReInitialize);
        }

        [Category("Wallet_sm")]
        [Test]
        public void EnablePermissionFromWalletTest_sm()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyPermissionCanBeEnabled, 3, TestReInitialize);
        }

        [Category("Wallet_sm")]
        [Test]
        public void DisablePermissionFromWalletTest_sm()
        {
            //TestRetrier.RunWithRetry(MainPageBb.VerifyPermissionCanBeDisabled, 3, TestReInitialize);
        }
        #endregion

        #region PROD_Mainnet
        [Category("Wallet_pm")]
        [Test]
        public void WrapTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyEthCanBeWrapped, 3, TestReInitialize);
        }

        [Category("Wallet_pm")]
        [Test]
        public void UnwrapTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyETHCanBeUnwrapped, 3, TestReInitialize);
        }

        [Category("Wallet_pm")]
        [Test]
        public void EnablePermissionTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyPermissionCanBeEnabled, 3, TestReInitialize);
        }

        [Category("Wallet_pm")]
        [Test]
        public void DisablePermissionTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyPermissionCanBeDisabled, 3, TestReInitialize);
        }

        [Category("Wallet_pm")]
        [Test]
        public void EnablePermissionFromWalletTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyPermissionCanBeEnabled, 3, TestReInitialize);
        }

        [Category("Wallet_pm")]
        [Test]
        public void DisablePermissionFromWalletTest_pm()
        {
            TestRetrier.RunWithRetry(MainPageBb.VerifyPermissionCanBeDisabled, 3, TestReInitialize);
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
