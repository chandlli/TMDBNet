using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMDBNet.Extensions;

namespace TMDBNet.Search.Model
{
    public sealed class TvShow : Media
    {
        public string FirstAirDate { get; private set; }
        public IList<string> OriginalCountry { get; private set; }
        public string Name { get; private set; }
        public string OriginalName { get; private set; }

        public TvShow(int? id = null, string posterPath = null, string overview = null, string originalLanguage = null, string backdropPath = null, string firstAirDate = null,
            string name = null, string originalName = null, decimal? popularity = null, int? voteCount = null, decimal? voteAverage = null, IList<int> genresId = null, IList<string> originalCountry = null)
            : base(posterPath, overview, originalLanguage, backdropPath, popularity, voteCount, voteAverage, id, genresId)
        {
            OriginalCountry = originalCountry;
            FirstAirDate = firstAirDate;
            Name = name;
            OriginalName = originalName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            var tvShow = (TvShow)obj;

            return tvShow.OriginalCountry.SafeSequenceEquals(OriginalCountry) &&
                string.Equals(tvShow.FirstAirDate, FirstAirDate) &&
                string.Equals(tvShow.Name, Name) &&
                string.Equals(tvShow.OriginalName, OriginalName) &&
                base.Equals(tvShow);
        }

        public override int GetHashCode()
        {
            var hashCode = 891511721;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstAirDate);
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<string>>.Default.GetHashCode(OriginalCountry);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(OriginalName);
            return hashCode;
        }
    }
}
