using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Configurations;

namespace Framework.ConfigManager
{
    public static class ConfigDataManager
    {
        private static readonly ISettingsFile SettingsFile = AqualityServices.Get<ISettingsFile>();

        public static string BaseUrl() => SettingsFile.GetValue<string>(".remoteConnectionUrl");

        public static int TimeoutFromSeconds() => SettingsFile.GetValue<int>(".timeouts.timeoutCondition");

        public static string ApiUrl => SettingsFile.GetValue<string>(".apiUrl");
    }
}