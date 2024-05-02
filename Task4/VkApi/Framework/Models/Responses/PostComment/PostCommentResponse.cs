using Newtonsoft.Json;

namespace Framework.Models.Responses.Comment
{
    public record PostCommentResponse
    {
        [JsonProperty("response")]
        public PostCommentData Response { get; set; }
    }
}