using Newtonsoft.Json;

namespace Framework.Models.Responses.Comment
{
    public record PostCommentData
    {
        [JsonProperty("comment_id")]
        public long CommentId { get; set; }

        [JsonProperty("parents_stack")]
        public object[] ParentsStack { get; set; }
    }
}