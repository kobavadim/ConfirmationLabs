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
        public void VerufyLTVCalculatedCorrectlyTest()
        {
            MainPageBb.VerifyLTVCalculation();
        }

        [Category("Calculations")]
        [Test]
        public void VerufyAPRCalculatedCorrectlyTest()
        {
            MainPageBb.VerifyAPRCalculation();
        }

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }
    }
}
