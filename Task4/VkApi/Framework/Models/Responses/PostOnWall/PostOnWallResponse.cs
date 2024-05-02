using Newtonsoft.Json;

namespace Framework.Models.Responses.PostOnWall
{
    public record PostOnWallResponse
    {
        [JsonProperty("response")]
        public PostOnWallData Response { get; set; }
    }
}