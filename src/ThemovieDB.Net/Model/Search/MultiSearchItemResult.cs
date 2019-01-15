using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThemovieDB.Net.Model.Search
{
    public class MultiSearchItemResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("media_type")]
        public MediaType MediaType { get; set; }

        [JsonProperty("release_date")]
        public DateTime? ReleasedDate { get; set; }
    }
}
