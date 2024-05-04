using Framework.TestData;

namespace Framework.Constants
{
    public static class ApiParameters
    {
        public static Dictionary<string, string> CommonParameters = new()
        {
            {"v", "5.199"},
            {"owner_id", Environment.GetEnvironmentVariable("owner_id")},
            {"access_token", Environment.GetEnvironmentVariable("access_token")}
        };

        public static string OwnerId => CommonParameters.FirstOrDefault(x => x.Key == "owner_id").Value;

        public static KeyValuePair<string, string> Type = new("type", "post");
        public const string Message = "message";
        public const string PostId = "post_id";
        public const string CommentId = "comment_id";
        public const string ItemId = "item_id";
        public const string Attachments = "attachments";
        public const string Photo = "photo";
        public const string Server = "server";
        public const string Hash = "hash";

        public static string GetPhotoId(long ownerId, long photoId) => $"photo{ownerId}_{photoId}";
    }

    public static class ApiHeaders
    {
        public static KeyValuePair<string, string> MultipartContentType = new("Content-Type", "multipart/form-data");
    }
}