using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.BloqBoard;

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

        [Category("Wallet")]
        [Test]
        public void WrapTest()
        {
            MainPageBb.VerifyEthCanBeWrapped();
        }

        [Category("Wallet")]
        [Test]
        public void UnwrapTest()
        {
            MainPageBb.VerifyETHCanBeUnwrapped();
        }

        [Category("Wallet")]
        [Test]
        public void EnablePermissionTest()
        {
            MainPageBb.VerifyPermissionCanBeEnabled();
        }

        [Category("Wallet")]
        [Test]
        public void DisablePermissionTest()
        {
            MainPageBb.VerifyPermissionCanBeDisabled();
        }

        [Category("Wallet")]
        [Test]
        public void EnablePermissionFromWalletTest()
        {
            MainPageBb.VerifyPermissionCanBeEnabled();
        }

        [Category("Wallet")]
        [Test]
        public void DisablePermissionFromWalletTest()
        {
            MainPageBb.VerifyPermissionCanBeDisabled();
        }

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }
    }
}
