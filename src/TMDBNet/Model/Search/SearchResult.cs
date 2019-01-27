using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMDBNet.Model.Search
{
    public sealed class SearchResult<T> where T : class
    {
        public int? Page { get; set; }
        public IList<T> Results { get; set; }
        [JsonProperty("total_results")]
        public int? TotalResults { get; set; }
        [JsonProperty("total_pages")]
        public int? TotalPages { get; set; }
    }
}
