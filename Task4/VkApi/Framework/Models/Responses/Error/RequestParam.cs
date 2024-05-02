using Newtonsoft.Json;

namespace Framework.Models.Responses.Error
{
    public record RequestParam
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
