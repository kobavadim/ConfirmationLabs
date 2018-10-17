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

        [Category("Loanscan")]
        [Category("Integration")]
        [Test]
        //bug LN-77
        public void DataonDharmaCardformTableCorrespondingTest()
        {
            Integration.VerifyDataonDharmaCardcorrespondsDataFromTable();
        }

        [Category("Loanscan")]
        [Category("Integration")]
        //bug LN-77
        [Test]
        public void LoanAmountDisplayTest()
        {
            Integration.VerifyLoanAmountisTheSameinTableandOnCard();
        }




        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }

    }
}
