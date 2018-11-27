using System;
using System.Diagnostics;
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
            MainPageBB.VerifyNewOfferToLendCanbeCreated();
        }

        [Category("OtlRequests")]
        [Test]
        public void BorrowNewlyCreatedRequesttoLendTest()
        {
            MainPageBB.VerifyNewlyCreatedRequestToLendCanBeBorrowed();
        }





        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }
    }
}
