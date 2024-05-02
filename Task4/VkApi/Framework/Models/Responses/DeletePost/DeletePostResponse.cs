using Newtonsoft.Json;

namespace Framework.Models.Responses.DeletePost
{
    public record DeletePostResponse
    {
        [JsonProperty("response")]
        public long Response { get; set; }
    }
}