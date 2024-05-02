using Newtonsoft.Json;

namespace Framework.Models.Responses.GetPhotos
{
    public record Size
    {
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}