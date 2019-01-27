using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMDBNet.Model.Search
{
    public sealed class Movie
    {
        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("adult")]
        public bool? IsAdult { get; set; }

        public string Overview { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("genre_ids")]
        public IList<int> Genres { get; set; }

        public string Id { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        public string Title { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        public decimal? Popularity { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        public bool? Video { get; set; }

        [JsonProperty("vote_average")]
        public decimal VoteAverage { get; set; }
    }
}
