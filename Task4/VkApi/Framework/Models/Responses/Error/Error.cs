using Newtonsoft.Json;

namespace Framework.Models.Responses.Error
{
    public record Error
    {
        [JsonProperty("error_code")]
        public long ErrorCode { get; set; }

        [JsonProperty("error_msg")]
        public string ErrorMsg { get; set; }

        [JsonProperty("request_params")]
        public RequestParam[] RequestParams { get; set; }
    }
}
