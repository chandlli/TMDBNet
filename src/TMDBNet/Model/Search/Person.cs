using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDBNet.Model.Search
{
    public sealed class People
    {
        public string ProfilePath { get; private set; }
        public bool? IsAdult { get; private set; }
        public int? Id { get; private set; }
        public string Name { get; private set; }
        public decimal? Popularity { get; private set; }

        public IList<Movie> KnownForMovies { get; private set; }

        public IList<TvShow> KnownForTvShows { get; private set; }

        public People(int? id = null, string profilePath = null, bool? isAdult = null, string name = null, decimal? popularity = null)
        {
            ProfilePath = profilePath;
            IsAdult = isAdult;
            Id = id;
            Name = name;
            Popularity = popularity;

            KnownForMovies = new List<Movie>();
            KnownForTvShows = new List<TvShow>();
        }

        internal void AddKnownForMovie(Movie movie)
        {
            KnownForMovies.Add(movie);
        }

        internal void AddKnownForTvShow(TvShow tvShow)
        {
            KnownForTvShows.Add(tvShow);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            var people = (People)obj;

            return people.Id.Equals(Id) &&
                people.IsAdult.Equals(IsAdult) &&
                people.Name.Equals(Name) &&
                people.Popularity.Equals(Popularity) &&
                people.ProfilePath.Equals(ProfilePath) &&
                people.KnownForMovies.SequenceEqual(KnownForMovies) &&
                people.KnownForTvShows.SequenceEqual(KnownForTvShows);
        }

        public override int GetHashCode()
        {
            var hashCode = 1467362199;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProfilePath);
            hashCode = hashCode * -1521134295 + EqualityComparer<bool?>.Default.GetHashCode(IsAdult);
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<decimal?>.Default.GetHashCode(Popularity);
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<Movie>>.Default.GetHashCode(KnownForMovies);
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<TvShow>>.Default.GetHashCode(KnownForTvShows);
            return hashCode;
        }
    }
}
