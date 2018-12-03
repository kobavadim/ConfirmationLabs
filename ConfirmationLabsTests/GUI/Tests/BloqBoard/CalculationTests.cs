using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.BloqBoard;

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

        [Category("Calculations")]
        [Test]
        public void VerifyLtvOnHistoryOrderTest()
        {
            MainPageBb.VerifyLtvOnHistoryOrder();
        }

        [Category("Calculations")]
        [Test]
        public void VerifyLtvOnJustCreatedOrderTest()
        {
            MainPageBb.VerifyLtvOnJustCreatedOrder();
        }

        [Category("Calculations")]
        [Test]
        public void VerifyAprOnHistoryOrderTest()
        {
            MainPageBb.VerifyAprOnHistoryOrder();
        }

        [Category("Calculations")]
        [Test]
        public void VerifyAprOnJustCreatedOrderTest()
        {
            MainPageBb.VerifyAPRCalculationOnJustCreatedOrder();
        }

        [Category("Calculations")]
        [Test]
        public void VerifyCollateralizationRatioTest()
        {
            MainPageBb.VerifyCollateralizationRatio();
        }

        [Category("Calculations")]
        [Test]
        public void VerifyRepayCalculationTest()
        {
            MainPageBb.VerifyRepayCalculation();
        }

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }
    }
}
