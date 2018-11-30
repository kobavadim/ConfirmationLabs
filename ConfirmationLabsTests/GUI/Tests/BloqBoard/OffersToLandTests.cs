using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.BloqBoard;

namespace ConfirmationLabsTests.GUI.Tests.BloqBoard
{
    [TestFixture]
    public class OffersToLandTests
    {
        [SetUp]
        public void TestInitialize()
        {
            Browser.StartWithExstension();
        }

        [Category("OtlCreate")]
        [Category("OtlRequests")]
        [Test]
        public void CreateNewOfferToLendTest()
        {
            MainPageBb.VerifyNewOfferToLendCanbeCreated();
        }

        //Already lended
        [Category("Borrow")]
        [Category("OtlRequests")]
        [Test]
        public void BorrowNewlyCreatedOffersToLandReques()
        {
            MainPageBb.VerifyNewlyCreatedRequestToLendCanBeBorrowed();
        }

        [Category("OtlRequests")]
        [Test]
        public void CheckOffersToLandValuesPresenceAfterRequests()
        {
            MainPageBb.VerifyOffersToLandValuesPresenceAfterRequests();
        }

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }
    }
}
