using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThemovieDB.Net.Model.Search
{
    public class MultiSearchResult
    {
        public int Page { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        public IList<MultiSearchItemResult> Results { get; set; }
    }
}
