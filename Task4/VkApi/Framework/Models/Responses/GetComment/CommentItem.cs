using Newtonsoft.Json;

namespace Framework.Models.Responses.GetComment
{
    public record CommentItem
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("from_id")]
        public long FromId { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("can_edit")]
        public long CanEdit { get; set; }

        [JsonProperty("can_delete")]
        public long CanDelete { get; set; }

        [JsonProperty("post_id")]
        public long PostId { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty("parents_stack")]
        public object[] ParentsStack { get; set; }

        [JsonProperty("likes")]
        public Likes Likes { get; set; }

        [JsonProperty("thread")]
        public GetCommentData Thread { get; set; }

        [JsonProperty("is_from_post_author")]
        public bool IsFromPostAuthor { get; set; }
    }
}
