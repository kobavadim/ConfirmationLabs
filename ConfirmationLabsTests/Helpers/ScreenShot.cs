using ConfirmationLabsTests.GUI.Engine;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfirmationLabsTests.Helpers
{
    class ScreenShot
    {
        public static void TakeScreenshot()
        {
            Screenshot ss = ((ITakesScreenshot)Browser.CurrentBrowser).GetScreenshot();
            ss.SaveAsFile("C:\\Users\\Administrator\\Documents\\Screens\\" + TestData.GenerateConstant("scrn") + ".jpg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
        }
    }
}
