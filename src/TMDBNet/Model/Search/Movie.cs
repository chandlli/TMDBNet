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

        public Movie(string posterPath = null, string overview = null, string originalLanguage = null, string backdropPath = null, string title = null, string originalTitle = null, string releaseDate = null,
            decimal? popularity = null, int? voteCount = null, decimal? voteAverage = null, int? id = null, bool? video = null, bool? isAdult = null
            , IList<int> genresId = null)
            : base(posterPath, overview, originalLanguage, backdropPath, popularity, voteCount, voteAverage, id, isAdult, genresId)
        {
            Title = title;
            OriginalTitle = originalTitle;
            ReleaseDate = releaseDate;
            Video = video;
        }
    }
}
