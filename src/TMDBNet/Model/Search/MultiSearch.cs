using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMDBNet.Model.Search
{
    public sealed class MultiSearch
    {
        public IList<Movie> Movies { get; private set; }
        public IList<Person> Persons { get; private set; }
        public IList<TvShow> TvShows { get; private set; }

        public MultiSearch()
        {
            Movies = new List<Movie>();
            Persons = new List<Person>();
            TvShows = new List<TvShow>();
        }
    }
}
