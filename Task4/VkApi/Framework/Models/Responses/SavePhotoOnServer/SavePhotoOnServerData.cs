using Newtonsoft.Json;

namespace Framework.Models.Responses.SavePhotoOnServer
{
    public record SavePhotoOnServerData
    {
        [JsonProperty("album_id")]
        public long AlbumId { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty("access_key")]
        public string AccessKey { get; set; }

        [JsonProperty("sizes")]
        public Size[] Sizes { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("web_view_token")]
        public string WebViewToken { get; set; }

        [JsonProperty("has_tags")]
        public bool HasTags { get; set; }
    }
}
