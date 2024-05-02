using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Models.Responses.Error
{
    public record ErrorResponse
    {
        [JsonProperty("error")]
        public Error Error { get; set; }
    }
}
