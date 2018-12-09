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

        public static void FinilizeErrors(string ENV, string component, Exception exception, bool send)
        {
            string errormessage = "";
            try
            {
                ScreenShot.TakeScreenshot();
            }
            catch(Exception){}

            try
            {
                if (exception.Message.Contains("WebDriver") || exception.Message.Contains("WebException") || exception.Message.Contains("Selenium"))
                {
                    errormessage = "Page wasn't loaded during wait time... Please rerun tests or check manually";
                }
                else if (exception.Message.Contains("Input string was not in a correct format"))
                {
                    errormessage = "Page loading was too long... Please rerun tests or check manually";
                }
                else if (exception.Message.Contains("Unable to locate element"))
                {
                    errormessage = "Page wasn't loaded during wait time... Please rerun tests or check manually";
                    SlackClient.PostMessageToSlack("[" + ENV + "] " + component + ": site wasn't loaded correctly. Probably we have speed issue. Please recheck manually.", send);
                }
                else
                {
                    errormessage = "The page wasn't loaded correctly. " + exception.Message; 
                    SlackClient.PostMessageToSlack(exception.Message, send);
                }
            }
            catch (Exception){}

            try
            {
                Browser.CurrentBrowser.Close();
                Browser.CurrentBrowser.Quit();
            }catch(Exception){ }

            if (errormessage == "")
            {
                throw new Exception(exception.Message);
            }

            //throw
            if (errormessage.Contains("Page loading was too long"))
            {
                //skip false positive
            }
            else
            {
                throw new Exception(errormessage);
            }
        }
    }
}
