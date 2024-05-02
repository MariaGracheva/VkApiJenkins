using Newtonsoft.Json;

namespace Framework.Models.Responses.GetComment
{
    public record GetCommentResponse
    {
        [JsonProperty("response")]
        public GetCommentData Response { get; set; }
    }
}