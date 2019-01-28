using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMDBNet.Model.Search
{
    public sealed class Person
    {
        public string ProfilePath { get; private set; }

        public bool? Adult { get; private set; }

        public int? Id { get; private set; }

        public IList<Movie> KnowForMovies { get; private set; }

        public IList<TvShow> KnowForTvShows { get; private set; }

        public Person(int? id = null, string profilePath = null, bool? adult = null)
        {
            ProfilePath = profilePath;
            Adult = adult;
            Id = id;

            KnowForMovies = new List<Movie>();
            KnowForTvShows = new List<TvShow>();
        }

        internal void AddKnowForMovie(Movie movie)
        {
            KnowForMovies.Add(movie);
        }

        internal void AddKnowForMovieRange(IList<Movie> moviesRange)
        {
            foreach (var movie in moviesRange)
                AddKnowForMovie(movie);
        }

        internal void AddKnowForTvShow(TvShow tvShow)
        {
            KnowForTvShows.Add(tvShow);
        }

        internal void AddKnowForTvShowRange(IList<TvShow> tvShowsRange)
        {
            foreach (var tvShow in tvShowsRange)
                AddKnowForTvShow(tvShow);
        }
    }
}
