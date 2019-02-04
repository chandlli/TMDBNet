using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMDBNet.Search.DTO
{
    internal sealed class SearchResultDTO
    {
        [JsonProperty("page")]
        public int? Page { get; set; }

        [JsonProperty("results")]
        public SearchResultItemDTO[] Results { get; set; }

        [JsonProperty("total_results")]
        public int? TotalResults { get; set; }

        [JsonProperty("total_pages")]
        public int? TotalPages { get; set; }
    }
}
