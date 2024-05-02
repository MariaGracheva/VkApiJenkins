using Newtonsoft.Json;

namespace Framework.Models.Responses.GetAdressforPhotoLoad
{
    public record GetUrlForPhotoLoadResponse
    {

        [JsonProperty("response")]
        public GetUrlForPhotoLoadData Response { get; set; }
    }
}
