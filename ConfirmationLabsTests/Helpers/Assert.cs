using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfirmationLabsTests.Helpers
{
    public class Asert
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
                SlackClient.PostMessage(exception.Message.ToString());
            }
            catch (Exception)
            {

            }
        }
    }
}
