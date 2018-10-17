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
        //[Test]
        public void DataonDharmaCardformTableCorrespondingTest()
        {
            Integration.VerifyDataonDharmaCardcorrespondsDataFromTable();
        }


        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }

    }
}
