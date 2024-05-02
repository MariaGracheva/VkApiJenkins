using Newtonsoft.Json;

namespace Framework.Models.Responses.GetLike
{
    public record GetLikeData
    {
        [JsonProperty("liked")]
        public long Liked { get; set; }

        [JsonProperty("copied")]
        public long Copied { get; set; }

        [JsonProperty("reaction_id")]
        public long ReactionId { get; set; }
    }
}