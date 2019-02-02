using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMDBNet.Model.Search
{
    public sealed class MultiSearch
    {
        public IList<Movie> Movies { get; private set; }
        public IList<People> People { get; private set; }
        public IList<TvShow> TvShows { get; private set; }

        public MultiSearch()
        {
            Movies = new List<Movie>();
            People = new List<People>();
            TvShows = new List<TvShow>();
        }

        internal void AddMovie(Movie movie)
        {
            Movies.Add(movie);
        }

        internal void AddPeople(People people)
        {
            People.Add(people);
        }

        internal void AddTvShow(TvShow tvShow)
        {
            TvShows.Add(tvShow);
        }
    }
}
