using Newtonsoft.Json;

namespace Framework.Models.Responses.GetComment
{
    public record Likes
    {
        [JsonProperty("can_like")]
        public long CanLike { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("user_likes")]
        public long UserLikes { get; set; }

        [JsonProperty("can_publish")]
        public long CanPublish { get; set; }
    }
}