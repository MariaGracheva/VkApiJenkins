using Newtonsoft.Json;

namespace Framework.Models.Responses.GetAdressforPhotoLoad
{
    public record GetUrlForPhotoLoadData
    {
        [JsonProperty("album_id")]
        public long AlbumId { get; set; }

        [JsonProperty("upload_url")]
        public string UploadUrl { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }
    }
}
