﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfirmationLabsTests.Helpers
{
    
        public static class TestData
        {
            public static class Input
            {
                public static string seedPhrase = "inspire spy put mixed recipe snow afraid lava segment avocado flame luggage";
                public static string password = "2523888qQ";
            }

            public static class Urls
            {
                public static string MetaMaskChromeLanding = "https://chrome.google.com/webstore/detail/metamask/nkbihfbeogaeaoehlefnkodbefgpgknn";
                public static string MetaMaskMainPageKovan = "chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#unlock";
                public static string LoanScanMainPageProd = "https://loanscan.io/";
                public static string LoanScanMainPageKovan = "https://kovan.loanscan.io/";
                public static string BloqBoardProd = "https://app.bloqboard.com/";
                public static string BloqBoardKovan = "https://kovan-app.bloqboard.com/";
                public static string CompaundProd = "https://compound.bloqboard.com/";
                public static string CompaundKovan = "http://compound-rinkeby.bloqboard.com.s3-website-us-east-1.amazonaws.com/";
                public static string MetaMaskWeb = "chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#";




            }

            public static string DefineBaseUrlDependingOnEnvironment()
            {
                return Environment.GetEnvironmentVariable("ENVIRONMENT_ENV", EnvironmentVariableTarget.User);
            }

        }
    
}
