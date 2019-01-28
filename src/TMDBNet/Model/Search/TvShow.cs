using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMDBNet.Model.Search
{
    public sealed class TvShow : Media
    {
        public string FirstAirDate { get; private set; }
        public IList<string> OriginalCountry { get; private set; }
        public string Name { get; private set; }
        public string OriginalName { get; private set; }
        public string ProfilePath { get; private set; }

        public TvShow(int? id = null, string posterPath = null, string overview = null, string originalLanguage = null, string backdropPath = null, string firstAirDate = null,
            string name = null, string originalName = null, string profilePath = null, decimal? popularity = null, int? voteCount = null, decimal? voteAverage = null, bool? isAdult = null)
            : base(posterPath, overview, originalLanguage, backdropPath, popularity, voteCount, voteAverage, id, isAdult)
        {
            OriginalCountry = new List<string>();

            FirstAirDate = firstAirDate;
            Name = name;
            OriginalName = originalName;
            ProfilePath = profilePath;
        }

        internal void AddOriginalCountry(string originalCountry)
        {
            OriginalCountry.Add(originalCountry);
        }

        internal void AddOriginalCountryRange(IList<string> originalCountryRange)
        {
            foreach (var originalCountry in originalCountryRange)
                OriginalCountry.Add(originalCountry);
        }
    }
}
