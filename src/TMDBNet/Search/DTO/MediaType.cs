using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMDBNet.Search.DTO
{
    public enum MediaType
    {
        Movie,
        Tv,
        [JsonProperty("person")]
        People
    }
}
