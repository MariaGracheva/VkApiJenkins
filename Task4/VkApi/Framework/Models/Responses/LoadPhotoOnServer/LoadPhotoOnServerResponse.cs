using Newtonsoft.Json;

namespace Framework.Models.Responses.LoadPhotoOnServer
{
    public record LoadPhotoOnServerResponse
    {
        [JsonProperty("server")]
        public long Server { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }
    }
}
