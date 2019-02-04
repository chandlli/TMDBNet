using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDBNet.Search.Model
{
    public abstract class Media
    {
        public string PosterPath { get; private set; }
        public string Overview { get; private set; }
        public IList<int> GenresId { get; private set; }
        public int? Id { get; private set; }
        public string OriginalLanguage { get; private set; }
        public string BackdropPath { get; private set; }
        public decimal? Popularity { get; private set; }
        public int? VoteCount { get; private set; }
        public decimal? VoteAverage { get; private set; }

        public Media(string posterPath = null, string overview = null, string originalLanguage = null, string backdropPath = null, decimal? popularity = null, int? voteCount = null,
            decimal? voteAverage = null, int? id = null, IList<int> genresId = null)
        {
            PosterPath = posterPath;
            Overview = overview;
            Id = id;
            OriginalLanguage = originalLanguage;
            BackdropPath = backdropPath;
            Popularity = popularity;
            VoteCount = voteCount;
            VoteAverage = voteAverage;
            GenresId = genresId;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            var media = (Media)obj;

            return string.Equals(media.BackdropPath, BackdropPath) &&
                media.GenresId.SequenceEqual(GenresId) &&
                media.Id == Id &&
                string.Equals(media.OriginalLanguage, OriginalLanguage) &&
                string.Equals(media.Overview, Overview) &&
                media.Popularity == Popularity &&
                string.Equals(media.PosterPath, PosterPath) &&
                media.VoteAverage == VoteAverage &&
                media.VoteCount == VoteCount;
        }

        public override int GetHashCode()
        {
            var hashCode = 159860747;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PosterPath);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Overview);
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<int>>.Default.GetHashCode(GenresId);
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(OriginalLanguage);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BackdropPath);
            hashCode = hashCode * -1521134295 + EqualityComparer<decimal?>.Default.GetHashCode(Popularity);
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(VoteCount);
            hashCode = hashCode * -1521134295 + EqualityComparer<decimal?>.Default.GetHashCode(VoteAverage);
            return hashCode;
        }
    }
}
