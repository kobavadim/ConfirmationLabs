using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.GUI.Application.BloqBoard;

namespace ConfirmationLabsTests.GUI.Tests.BloqBoard
{


    [TestFixture]
    class IntegrationTests
    {
        [SetUp]
        public void TestInitialize()
        {
            Browser.StartWithExstension();
        }

        [Category("Integration")]
        [Test]
        public void RecentLoansDataTest()
        {
            Integration.VerifyDatafromRecentLoans();
        }
        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }
    }
}
