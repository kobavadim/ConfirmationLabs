using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.BloqBoard;

namespace ConfirmationLabsTests.GUI.Tests.BloqBoard
{
    [TestFixture]
    public class OffersToLend
    {
        [SetUp]
        public void TestInitialize()
        {
            Browser.StartWithExstension();
        }

        //https://staging.bloqboard.com/add-offer-to-lend
        [Category("Lend")]
        [Category("OtlCreate")]
        [Category("OtlRequests")]
        [Test]
        public void CreateNewOfferToLendTest()
        {
            MainPageBb.VerifyNewOfferToLendCanBeCreated();
        }

        //Already created lend request
        [Category("Borrow")]
        [Category("OtlRequests")]
        [Test]
        public void BorrowNewlyCreatedOffersToLendRequest()
        {
            MainPageBb.VerifyNewlyCreatedRequestToLendCanBeBorrowed();
        }

        //Already created borrow request
        [Category("Lend")]
        [Category("OtlRequests")]
        [Test]
        public void LendNewlyCreatedBorrowOfferRequest()
        {
            MainPageBb.VerifyNewlyCreatedRequestToBorrowCanBeLend();
        }

        [Ignore("Fix after redesign")]
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
