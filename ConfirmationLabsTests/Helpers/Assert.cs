using ConfirmationLabsTests.GUI.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfirmationLabsTests.Helpers
{
    public class Assert
    {
        public static void IsTrue(bool condition, string component, string error)
        {
            if(!condition)
            {
                throw new Exception(component + ": " + error);
            }
        }

        public static void FinilizeErrors(Exception exception)
        {
            try
            {
                ScreenShot.TakeScreenshot();
            }
            catch(Exception){}

            try
            {
                if (exception.Message.Contains("WebDriver") || exception.Message.Contains("WebException") || exception.Message.Contains("Selenium"))
                {

                }
                else
                {
                    SlackClient.PostMessage(exception.Message);
                }

            }
            catch (Exception)
            {

            }

            try
            {
                Browser.CurrentBrowser.Close();

                Browser.CurrentBrowser.Quit();
            }
            catch(Exception)
            { }

            //throw new Exception(exception.Message);
        }
    }
}
