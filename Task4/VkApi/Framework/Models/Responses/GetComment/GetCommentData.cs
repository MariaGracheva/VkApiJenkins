using Newtonsoft.Json;

namespace Framework.Models.Responses.GetComment
{
    public record GetCommentData
    {
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public CommentItem[] Items { get; set; }

        [JsonProperty("can_post")]
        public bool CanPost { get; set; }

        [JsonProperty("show_reply_button")]
        public bool ShowReplyButton { get; set; }

        [JsonProperty("groups_can_post")]
        public bool GroupsCanPost { get; set; }

        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        public long? Count { get; set; }
    }
}