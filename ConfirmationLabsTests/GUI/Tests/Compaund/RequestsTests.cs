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
        [Test]
        public void LendToLiquidityPoolFinctionaltityTest()
        {
            MainPageCompaund.VerifyTokenCanbeLounedtoLiquidityPool();
        }

        [Category("Compound")]
        [Test]
        public void WithdrawFromLiquidityPoolTest()
        {
            MainPageCompaund.VerifyTokenCanbeWithdrawnedFromLiquidityPool();
        }

        [Category("Compound")]
        [Test]
        public void BorrowFromLiquidityPoolTest()
        {
            MainPageCompaund.VerifyTokenCanbeBorrowedFromLiquidityPool();
        }


        [Category("Compound")]
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
