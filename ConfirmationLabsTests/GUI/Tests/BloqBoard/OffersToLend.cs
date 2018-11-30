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

        [Category("Lend")]
        [Category("OtlCreate")]
        [Category("OtlRequests")]
        [Test]
        public void CreateNewOfferToLendTest()
        {
            MainPageBb.VerifyNewOfferToLendCanbeCreated();
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
