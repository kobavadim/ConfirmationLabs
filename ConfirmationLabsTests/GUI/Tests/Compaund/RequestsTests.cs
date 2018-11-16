using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.Compaund;


namespace ConfirmationLabsTests.GUI.Tests.Compaund
{
    [TestFixture]
    class RequestsTests
    {
        [SetUp]
        public void TestInitialize()
        {
            Browser.StartWithExstension();
        }

        [Category("Compound")]
        [Category("BlqRequests")]
        [Test]
        public void LendToLiquidityPoolTest()
        {
            MainPageCompaund.VerifyTokenCanbeLounedtoLiquidityPool();
        }

        [Category("Compound")]
        [Category("BlqRequests")]
        [Test]
        public void WithdrawFromLiquidityPoolTest()
        {
            MainPageCompaund.VerifyTokenCanbeWithdrawnedFromLiquidityPool();
        }

        [Category("Compound")]
        [Category("BlqRequests")]
        [Test]
        public void BorrowFromLiquidityPoolTest()
        {
            MainPageCompaund.VerifyTokenCanbeBorrowedFromLiquidityPool();
        }

        [Category("Compound")]
        [Category("BlqRequests")]
        [Test]
        public void RepayFromLiquidityPoolTest()
        {
            MainPageCompaund.VerifyTokenCanbeRepaidFromLiquidityPool();
        }

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }
    }
}
