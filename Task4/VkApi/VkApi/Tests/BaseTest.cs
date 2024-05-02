using Aquality.Selenium.Browsers;
using Framework.ConfigManager;
using Framework.Utils;

namespace VkApi.Tests
{
    public class BaseTest : Hooks
    {
        [SetUp, Order(1)]
        public void GoToMainPage()
        {
            AqualityServices.Logger.Info("Go to main page");
            AqualityServices.Browser.GoTo(ConfigDataManager.BaseUrl());
            AqualityServices.Browser.WaitForPageToLoad();
        }
    }
}