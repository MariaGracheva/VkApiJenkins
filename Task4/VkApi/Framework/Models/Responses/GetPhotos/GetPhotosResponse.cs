using Newtonsoft.Json;

namespace Framework.Models.Responses.GetPhotos
{
    public record GetPhotosResponse
    {
        [JsonProperty("response")]
        public GetPhotosData Response { get; set; }
    }
}