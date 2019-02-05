using System;
using System.Collections.Generic;
using System.Text;
using TMDBNet.Search.DTO;
using TMDBNet.Search.Model;

namespace TMDBNet.Search.Factories
{
    internal static class SearchResultItemFactory
    {
        internal static T Create<T>(SearchResultItemDTO searchResultItem)
        {
            object result = null;

            if (typeof(T) == typeof(Collection))
            {
                result = CreateCollection(searchResultItem); ;
            }
            else if (typeof(T) == typeof(Company))
            {
                result = CreateCompany(searchResultItem); ;
            }
            else if (typeof(T) == typeof(KeyWord))
            {
                result = CreateKeyWord(searchResultItem); ;
            }
            else if (typeof(T) == typeof(Movie))
            {
                result = MediaFactory.Create<Movie>(searchResultItem);
            }
            else if (typeof(T) == typeof(People))
            {
                result = CreatePeople(searchResultItem); ;
            }
            else if (typeof(T) == typeof(TvShow))
            {
                result = MediaFactory.Create<TvShow>(searchResultItem);
            }

            if (result is null)
                throw new Exception("Unrecognized type");

            return (T)Convert.ChangeType(result, typeof(T));
        }

        internal static MultiSearch Create(SearchResultItemDTO[] searchResults)
        {
            var multiSearch = new MultiSearch();

            foreach (var searchResultItem in searchResults)
            {
                switch (searchResultItem.MediaType)
                {
                    case MediaType.Movie:
                        multiSearch.AddMovie(Create<Movie>(searchResultItem));
                        break;

                    case MediaType.People:
                        multiSearch.AddPeople(Create<People>(searchResultItem));
                        break;

                    case MediaType.Tv:
                        multiSearch.AddTvShow(Create<TvShow>(searchResultItem));
                        break;
                }
            }

            return multiSearch;
        }

        private static Collection CreateCollection(SearchResultItemDTO searchResultItem)
        {
            return new Collection(searchResultItem.Id, searchResultItem.BackdropPath,
                searchResultItem.Name, searchResultItem.PosterPath);
        }

        private static Company CreateCompany(SearchResultItemDTO searchResultItem)
        {
            return new Company(searchResultItem.Id, searchResultItem.LogoPath, searchResultItem.Name);
        }

        private static KeyWord CreateKeyWord(SearchResultItemDTO searchResultItem)
        {
            return new KeyWord(searchResultItem.Id, searchResultItem.Name);
        }

        private static People CreatePeople(SearchResultItemDTO searchResultItem)
        {
            var people = new People(
                profilePath: searchResultItem.ProfilePath,
                isAdult: searchResultItem.IsAdult,
                id: searchResultItem.Id,
                name: searchResultItem.Name,
                popularity: searchResultItem.Popularity);

            if (searchResultItem.KnownFor != null)
            {
                foreach (var knownForItem in searchResultItem.KnownFor)
                {
                    if (knownForItem.MediaType == MediaType.Movie)
                    {
                        people.AddKnownForMovie((Movie)MediaFactory.Create<Movie>(knownForItem));
                    }
                    else if (knownForItem.MediaType == MediaType.Tv)
                    {
                        people.AddKnownForTvShow((TvShow)MediaFactory.Create<TvShow>(knownForItem));
                    }
                }
            }

            return people;
        }
    }
}
