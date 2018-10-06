using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfirmationLabsTests
{
    class TestData
    {
        public static string DefineBaseUrlDependingOnEnvironment()
        {
            return Environment.GetEnvironmentVariable("ENVIRONMENT_ENV", EnvironmentVariableTarget.User);
        }
    }
}
