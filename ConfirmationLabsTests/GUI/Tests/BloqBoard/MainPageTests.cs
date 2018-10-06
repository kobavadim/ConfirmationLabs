using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using ConfirmationLabsTests.GUI.Engine;
using ConfirmationLabsTests.Helpers;



namespace ConfirmationLabsTests.GUI.Tests.BloqBoard
{
    [TestFixture]
    public class MainPageTests
    {
        [SetUp]
        public void TestInitialize()
        {
            Browser.Start();
        }

        [Category("Bloqboard")]
        [Category("Login")]
        [Test]
        public void CreateLoan()
        {
            //Wallets.LoginToMetaMaskWallet();
        }

        [TearDown]
        public void TestCleanUp()
        {
            Browser.Close();
        }
    }
}
