using Newtonsoft.Json;

namespace Framework.Models.Responses.GetPhotos
{
    public record GetPhotosData
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("items")]
        public PhotoItem[] Items { get; set; }

        [JsonProperty("next_from")]
        public string NextFrom { get; set; }
    }
}