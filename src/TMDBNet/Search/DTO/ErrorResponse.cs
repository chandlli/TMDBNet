using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMDBNet.Search.DTO
{
    internal sealed class ErrorResponseDTO
    {
        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }
        [JsonProperty("status_code")]
        public int? StatusCode { get; set; }
    }
}
