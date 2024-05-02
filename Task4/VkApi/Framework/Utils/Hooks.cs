using Aquality.Selenium.Browsers;
using NUnit.Framework;

namespace Framework.Utils
{
    public class Hooks
    {
        [SetUp, Order(0)]
        public void SetUpApplication()
        {
            AqualityServices.Browser.Maximize();
        }

        [TearDown]
        public void QuitBrowser()
        {
            AqualityServices.Browser.Quit();
        }
    }
}