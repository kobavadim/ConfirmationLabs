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

        [Category("Lend")]
        [Category("Compound")]
        [Category("CmpndLnd")]
        [Category("CmpndRequests")]
        [Test]
        public void LendToLiquidityPoolTest()
        {
            MainPageCompaund.VerifyTokenCanbeLendedtoLiquidityPool();
        }

        [Category("Compound")]
        [Category("CmpndRequests")]
        [Test]
        public void WithdrawFromLiquidityPoolTest()
        {
            MainPageCompaund.VerifyTokenCanbeWithdrawnedFromLiquidityPool();
        }

        //Borrow from liquidity pool
        [Category("Borrow")]
        [Category("Compound")]
        [Category("CmpndRequests")]
        [Test]
        public void BorrowFromLiquidityPoolTest()
        {
            MainPageCompaund.VerifyTokenCanbeBorrowedFromLiquidityPool();
        }

        [Category("Compound")]
        [Category("CmpndRequests")]
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
