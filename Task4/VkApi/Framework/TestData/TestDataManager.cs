using Framework.Extensions;
using Microsoft.Extensions.Configuration;

namespace Framework.TestData
{
    public static class TestDataManager
    {
        private static readonly IConfiguration Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("Resources\\testData.json", optional: true, reloadOnChange: true)
               .Build();

        public static T GetValue<T>(string key) => Configuration.GetValue<T>(GetSettingJsonPath(key));

        public static int TextForPostOnWallLength => GetValue<int>("TextForPostOnWallLength");

        public static string UploadFilePath => GetValue<string>("UploadFilePath");

        private static string GetSettingJsonPath(string key) => $"application:{key.ToLowerFirstChar()}";
    }
}