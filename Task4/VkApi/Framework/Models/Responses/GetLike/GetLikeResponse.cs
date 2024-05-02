using Newtonsoft.Json;

namespace Framework.Models.Responses.GetLike
{
    public record GetLikeResponse
    {
        [JsonProperty("response")]
        public GetLikeData Response { get; set; }
    }
}