using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMDBNet.Model.Search
{
    public sealed class Movie : Media
    {
        public string Title { get; private set; }
        public string OriginalTitle { get; private set; }
        public string ReleaseDate { get; private set; }
        public bool? Video { get; private set; }
        public bool? IsAdult { get; private set; }

        public Movie(string posterPath = null, string overview = null, string originalLanguage = null, string backdropPath = null, string title = null, string originalTitle = null, string releaseDate = null,
            decimal? popularity = null, int? voteCount = null, decimal? voteAverage = null, int? id = null, bool? video = null, bool? isAdult = null
            , IList<int> genresId = null)
            : base(posterPath, overview, originalLanguage, backdropPath, popularity, voteCount, voteAverage, id, genresId)
        {
            Title = title;
            OriginalTitle = originalTitle;
            ReleaseDate = releaseDate;
            Video = video;
            IsAdult = isAdult;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            var movie = (Movie)obj;

            return movie.Title.Equals(Title) &&
                movie.OriginalTitle.Equals(OriginalTitle) &&
                movie.ReleaseDate.Equals(ReleaseDate) &&
                movie.Video.Equals(Video) &&
                movie.IsAdult.Equals(IsAdult) &&
                base.Equals(movie);
        }

        public override int GetHashCode()
        {
            var hashCode = -1646177912;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(OriginalTitle);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ReleaseDate);
            hashCode = hashCode * -1521134295 + EqualityComparer<bool?>.Default.GetHashCode(Video);
            hashCode = hashCode * -1521134295 + EqualityComparer<bool?>.Default.GetHashCode(IsAdult);
            return hashCode;
        }
    }
}
