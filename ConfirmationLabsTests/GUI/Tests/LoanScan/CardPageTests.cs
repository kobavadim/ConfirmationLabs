using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.LoanScan;

namespace ConfirmationLabsTests.GUI.Tests.LoanScan
{


    [TestFixture]

    class CardPageTests
    {
        [SetUp]
        public void TestInitialize()
        {
            Browser.Start();
        }

        [Category("Loanscan")]
        [Test]
        public void CardsElementsDharmaPrortocolTest()
        {
            CardPage.VerifyElementsonDharmaSingleCard();
        }

        [Ignore("Fix")]
        [Test]
        public void PaidOfCardsElementsValueDharmaPrortocolTest()
        {
            CardPage.VerifyPaidOfDharmaSingleCard();
        }

        [Category("NOTSTAGING")]
        [Category("Loanscan")]
        [Test]
        public void CardsElementsMakerDaoPrortocolTest()
        {
            CardPage.VerifyElementsonMakerDaoSingleCard();
        }

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }
    }
}
