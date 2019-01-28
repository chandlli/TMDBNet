using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMDBNet.Model.Search
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
        public bool? IsAdult { get; private set; }

        public Media(string posterPath = null, string overview = null, string originalLanguage = null, string backdropPath = null, decimal? popularity = null, int? voteCount = null,
            decimal? voteAverage = null, int? id = null, bool? isAdult = null, IList<int> genresId = null)
        {
            PosterPath = posterPath;
            Overview = overview;
            Id = id;
            OriginalLanguage = originalLanguage;
            BackdropPath = backdropPath;
            Popularity = popularity;
            VoteCount = voteCount;
            VoteAverage = voteAverage;
            IsAdult = isAdult;
            GenresId = genresId;
        }
    }
}
