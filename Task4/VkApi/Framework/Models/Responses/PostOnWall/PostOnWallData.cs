using Newtonsoft.Json;

namespace Framework.Models.Responses.PostOnWall
{
    public class PostOnWallData
    {
        [JsonProperty("post_id")]
        public long PostId { get; set; }
    }
}