using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.LoanScan;

namespace ConfirmationLabsTests.GUI.Tests.LoanScan
{


    [TestFixture]
    class IntegrationTests
    {

        [SetUp]
        public void TestInitialize()
        {
            Browser.Start();
        }

        [Category("Loanscan")]
        [Category("Integration")]
        [Test]
        public void CardisOpenedfromTableTest()
        {
           Integration.VerifySingleCardOpening();
        }

        [Category("NOTSTAGING")]
        [Category("Loanscan")]
        [Category("Integration")]
        [Test]
        //bug LN-77
        public void DataonDharmaCardformTableCorrespondingTest()
        {
            Integration.VerifyDataonDharmaCardcorrespondsDataFromTable();
        }

        [Ignore("FIX")]
        //bug LN-90
        [Test]
        public void LoanAmountDisplayDharmaTest()
        {
            Integration.VerifyLoanAmountisTheSameinTableandOnCard();
        }

        [Category("Loanscan")]
        [Category("Integration")]
        //bug LN-90
        [Test]
        public void CollateralAmountDisplayeDharmaTest()
        {
            Integration.VerifyCollateralistheSameThroughTableandCard();
        }

        [Category("NOTSTAGING")]
        [Category("Loanscan")]
        [Category("Integration")]
        [Test]
        public void DataonMakerDaoCardthroughTableandCardTest()
        {
            Integration.VerifyDataonMakerDaoCardcorrespondsDataFromTable();
        }

        [Category("Loanscan")]
        [Category("Integration")]
        [Test]
        public void CollateralAmountDisplayeMakerDaoTest()
        {
            Integration.VerifyCollateralistheSameThroughTableandCardMakerDao();
        }

        [Ignore("FIX")]
        [Test]
        public void DharmaDataAvailabilityonCardTest()
        {
            Integration.VerifyAllDataloadedDharma();
        }

        [Ignore("FIX")]
        [Test]
        public void MakerDaoDataAvailabilityonCardTest()
        {
            Integration.VerifyAllDataloadedMakerDao();
        }

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }

    }
}
