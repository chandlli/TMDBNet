using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDBNet.Search.Model
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

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            var multisearch = (MultiSearch)obj;

            return multisearch.Movies.SequenceEqual(Movies) &&
                multisearch.TvShows.SequenceEqual(TvShows) &&
                multisearch.People.SequenceEqual(People);
        }

        public override int GetHashCode()
        {
            var hashCode = -396937003;
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<Movie>>.Default.GetHashCode(Movies);
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<People>>.Default.GetHashCode(People);
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<TvShow>>.Default.GetHashCode(TvShows);
            return hashCode;
        }
    }
}
