using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMDBNet.Model.Search
{
    internal class SearchResultItemDTO
    {
        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        public string Overview { get; set; }

        [JsonProperty("genre_ids")]
        public IList<int> GenresId { get; set; }

        public int? Id { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("adult")]
        public bool? IsAdult { get; set; }

        public string Title { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        public bool? Video { get; set; }

        [JsonProperty("first_air_date")]
        public string FirstAirDate { get; set; }

        [JsonProperty("origin_country")]
        public IList<string> OriginalCountry { get; set; }

        public string Name { get; set; }

        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("media_type")]
        public MediaType? MediaType { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        public decimal? Popularity { get; set; }

        [JsonProperty("vote_count")]
        public int? VoteCount { get; set; }

        [JsonProperty("vote_average")]
        public decimal? VoteAverage { get; set; }

        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }

        [JsonProperty("known_for")]
        public IList<dynamic> KnowFor { get; set; }
    }
}
