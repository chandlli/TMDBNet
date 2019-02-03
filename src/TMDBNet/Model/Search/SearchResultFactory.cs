using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("TMDBNet.Tests")]
namespace TMDBNet.Model.Search
{
    internal static class SearchResultFactory
    {
        internal static SearchResult<IList<Movie>> CreateMovieSearchResult(SearchResultDTO searchResultDTO)
        {
            if (searchResultDTO == null)
                return null;

            searchResultDTO.Results = searchResultDTO.Results ?? Array.Empty<SearchResultItemDTO>();

            var movies = new List<Movie>();

            foreach (var serachResultItem in searchResultDTO.Results)
            {
                movies.Add(CreateMovie(serachResultItem));
            }

            return new SearchResult<IList<Movie>>(movies, searchResultDTO.Page, searchResultDTO.TotalResults
                , searchResultDTO.TotalPages);
        }

        internal static SearchResult<IList<People>> CreatePeopleSearchResult(SearchResultDTO searchResultDTO)
        {
            if (searchResultDTO == null)
                return null;

            searchResultDTO.Results = searchResultDTO.Results ?? Array.Empty<SearchResultItemDTO>();

            var people = new List<People>();

            foreach (var serachResultItem in searchResultDTO.Results)
            {
                people.Add(CreatePeople(serachResultItem));
            }

            return new SearchResult<IList<People>>(people, searchResultDTO.Page, searchResultDTO.TotalResults
                , searchResultDTO.TotalPages);
        }

        internal static SearchResult<IList<TvShow>> CreateTvShowSearchResult(SearchResultDTO searchResultDTO)
        {
            if (searchResultDTO == null)
                return null;

            searchResultDTO.Results = searchResultDTO.Results ?? Array.Empty<SearchResultItemDTO>();

            var tvShows = new List<TvShow>();

            foreach (var serachResultItem in searchResultDTO.Results)
            {
                tvShows.Add(CreateTvShow(serachResultItem));
            }

            return new SearchResult<IList<TvShow>>(tvShows, searchResultDTO.Page, searchResultDTO.TotalResults
                , searchResultDTO.TotalPages);
        }

        internal static SearchResult<MultiSearch> CreateMultiSearchResult(SearchResultDTO searchResult)
        {
            var multiSearch = CreateMultiSearch(searchResult);

            return new SearchResult<MultiSearch>(multiSearch, searchResult.Page, searchResult.TotalResults
                , searchResult.TotalPages);
        }

        internal static SearchResult<IList<KeyWord>> CreateKeyWordSearchResult(SearchResultDTO searchResultDTO)
        {
            if (searchResultDTO == null)
                return null;

            searchResultDTO.Results = searchResultDTO.Results ?? Array.Empty<SearchResultItemDTO>();

            var keyWords = new List<KeyWord>();

            foreach (var serachResultItem in searchResultDTO.Results)
            {
                keyWords.Add(CreateKeyWord(serachResultItem));
            }

            return new SearchResult<IList<KeyWord>>(keyWords, searchResultDTO.Page, searchResultDTO.TotalResults
                , searchResultDTO.TotalPages);
        }

        internal static SearchResult<IList<Collection>> CreateCollectionSearchResult(SearchResultDTO searchResultDTO)
        {
            if (searchResultDTO == null)
                return null;

            searchResultDTO.Results = searchResultDTO.Results ?? Array.Empty<SearchResultItemDTO>();

            var collections = new List<Collection>();

            foreach (var serachResultItem in searchResultDTO.Results)
            {
                collections.Add(CreateCollection(serachResultItem));
            }

            return new SearchResult<IList<Collection>>(collections, searchResultDTO.Page, searchResultDTO.TotalResults
                , searchResultDTO.TotalPages);
        }

        internal static Collection CreateCollection(SearchResultItemDTO searchResultItem)
        {
            return new Collection(searchResultItem.Id.Value, searchResultItem.BackdropPath,
                searchResultItem.Name, searchResultItem.PosterPath);
        }

        internal static SearchResult<IList<Company>> CreateCompanySearchResult(SearchResultDTO searchResultDTO)
        {
            if (searchResultDTO == null)
                return null;

            searchResultDTO.Results = searchResultDTO.Results ?? Array.Empty<SearchResultItemDTO>();

            var companies = new List<Company>();

            foreach (var serachResultItem in searchResultDTO.Results)
            {
                companies.Add(CreateCompany(serachResultItem));
            }

            return new SearchResult<IList<Company>>(companies, searchResultDTO.Page, searchResultDTO.TotalResults
                , searchResultDTO.TotalPages);
        }

        internal static Movie CreateMovie(SearchResultItemDTO searchResultDTO)
        {
            return new Movie(
                posterPath: searchResultDTO.PosterPath,
                isAdult: searchResultDTO.IsAdult,
                overview: searchResultDTO.Overview,
                releaseDate: searchResultDTO.ReleaseDate,
                genresId: searchResultDTO.GenresId,
                id: searchResultDTO.Id,
                originalTitle: searchResultDTO.OriginalTitle,
                originalLanguage: searchResultDTO.OriginalLanguage,
                title: searchResultDTO.Title,
                backdropPath: searchResultDTO.BackdropPath,
                popularity: searchResultDTO.Popularity,
                voteCount: searchResultDTO.VoteCount,
                video: searchResultDTO.Video,
                voteAverage: searchResultDTO.VoteAverage
            );
        }

        internal static TvShow CreateTvShow(SearchResultItemDTO searchResultDTO)
        {
            return new TvShow(
                posterPath: searchResultDTO.PosterPath,
                overview: searchResultDTO.Overview,
                genresId: searchResultDTO.GenresId,
                id: searchResultDTO.Id,
                originalLanguage: searchResultDTO.OriginalLanguage,
                backdropPath: searchResultDTO.BackdropPath,
                popularity: searchResultDTO.Popularity,
                voteCount: searchResultDTO.VoteCount,
                voteAverage: searchResultDTO.VoteAverage,
                firstAirDate: searchResultDTO.FirstAirDate,
                originalCountry: searchResultDTO.OriginalCountry,
                name: searchResultDTO.Name,
                originalName: searchResultDTO.OriginalName
                );
        }

        internal static People CreatePeople(SearchResultItemDTO searchResultItemDTO)
        {
            var people = new People(
                profilePath: searchResultItemDTO.ProfilePath,
                isAdult: searchResultItemDTO.IsAdult,
                id: searchResultItemDTO.Id,
                name: searchResultItemDTO.Name,
                popularity: searchResultItemDTO.Popularity);

            if (searchResultItemDTO.KnownFor != null)
            {
                foreach (var knownForItem in searchResultItemDTO.KnownFor)
                {
                    if (knownForItem.MediaType == MediaType.Movie)
                    {
                        people.AddKnownForMovie(CreateMovie(knownForItem));
                    }
                    else if (knownForItem.MediaType == MediaType.Tv)
                    {
                        people.AddKnownForTvShow(CreateTvShow(knownForItem));
                    }
                }
            }

            return people;
        }

        internal static MultiSearch CreateMultiSearch(SearchResultDTO searchResultItemDTO)
        {
            var multiSearch = new MultiSearch();

            searchResultItemDTO.Results = searchResultItemDTO.Results ?? Array.Empty<SearchResultItemDTO>();

            foreach (var searchResultItem in searchResultItemDTO.Results)
            {
                switch (searchResultItem.MediaType)
                {
                    case Model.MediaType.Movie:
                        multiSearch.AddMovie(CreateMovie(searchResultItem));
                        break;

                    case Model.MediaType.People:
                        multiSearch.AddPeople(CreatePeople(searchResultItem));
                        break;

                    case Model.MediaType.Tv:
                        multiSearch.AddTvShow(CreateTvShow(searchResultItem));
                        break;
                }
            }

            return multiSearch;
        }

        internal static KeyWord CreateKeyWord(SearchResultItemDTO searchResultItemDTO)
        {
            return new KeyWord(searchResultItemDTO.Id.Value, searchResultItemDTO.Name);
        }

        internal static Company CreateCompany(SearchResultItemDTO searchResultItemDTO)
        {
            return new Company(searchResultItemDTO.Id.Value, searchResultItemDTO.LogoPath, searchResultItemDTO.Name);
        }
    }
}
