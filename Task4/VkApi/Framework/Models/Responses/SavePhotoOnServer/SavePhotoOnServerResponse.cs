using Newtonsoft.Json;

namespace Framework.Models.Responses.SavePhotoOnServer
{
    public record SavePhotoOnServerResponse
    {
        [JsonProperty("response")]
        public SavePhotoOnServerData[] Response { get; set; }
    }
}
