using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TMDBNet.Abstractions;
using TMDBNet.Model.Search;

namespace TMDBNet.Implementations
{
    public sealed class Search : ISearch
    {
        private readonly string apiKey;
        private readonly HttpConnection httpConnection;

        public Search(string apiKey, HttpConnection httpConnection)
        {
            this.apiKey = apiKey;
            this.httpConnection = httpConnection;
        }

        public async Task<SearchResult<IList<Movie>>> MovieAsync(string query, string language = null, int page = 1, bool includeAdult = true, string region = null, int? year = null, int? primaryReleaseYear = null)
        {
            var queryString = CreateQueryString();

            queryString.Add("query", query);
            queryString.Add("page", page.ToString());
            queryString.Add("includeAdult", includeAdult.ToString());
            queryString.Add("region", region);
            queryString.Add("language", language);

            var searchResultDTO = await GetSearchResultAsync("search/movie", queryString);

            var movies = new List<Movie>();

            if (searchResultDTO.Results != null)
            {
                foreach (var searchResult in searchResultDTO.Results)
                    movies.Add(SearchResultFactory.CreateMovie(searchResult));
            }

            return new SearchResult<IList<Movie>>(movies, searchResultDTO.Page,
                searchResultDTO.TotalResults, searchResultDTO.TotalPages);
        }

        public async Task<SearchResult<IList<TvShow>>> TvShowAsync(string query, string language = null, int page = 1, int? firstAirDateYear = null)
        {
            var queryString = CreateQueryString();

            queryString.Add("query", query);
            queryString.Add("language", language);
            queryString.Add("page", page.ToString());
            queryString.Add("first_air_date_year", firstAirDateYear.ToString());

            var searchResultDTO = await GetSearchResultAsync("search/tv", queryString);

            var tvShows = new List<TvShow>();

            if (searchResultDTO.Results != null)
            {
                foreach (var searchResult in searchResultDTO.Results)
                    tvShows.Add(SearchResultFactory.CreateTvShow(searchResult));
            }

            return new SearchResult<IList<TvShow>>(tvShows, searchResultDTO.Page,
                searchResultDTO.TotalResults, searchResultDTO.TotalPages);
        }

        public async Task<SearchResult<IList<Person>>> PersonAsync(string query, string language = null, int page = 1, bool includeAdult = true, string region = null)
        {
            var queryString = CreateQueryString();

            queryString.Add("query", query);
            queryString.Add("language", language);
            queryString.Add("page", page.ToString());
            queryString.Add("include_adult", includeAdult.ToString());
            queryString.Add("region", region);

            var searchResultDTO = await GetSearchResultAsync("search/person", queryString);

            var persons = new List<Person>();

            if (searchResultDTO.Results != null)
            {
                foreach (var searchResult in searchResultDTO.Results)
                {
                    var person = SearchResultFactory.CreatePerson(searchResult);

                    if (searchResult.KnowFor != null)
                    {
                        foreach (var knowForItem in searchResult.KnowFor)
                        {
                            switch (knowForItem.MediaType)
                            {
                                case Model.MediaType.Movie:
                                    person.AddKnowForMovie(SearchResultFactory.CreateMovie(searchResult));
                                    break;

                                case Model.MediaType.Tv:
                                    person.AddKnowForTvShow(SearchResultFactory.CreateTvShow(searchResult));
                                    break;
                            }
                        }
                    }

                    persons.Add(person);
                }
            }

            return new SearchResult<IList<Person>>(persons, searchResultDTO.Page,
                searchResultDTO.TotalResults, searchResultDTO.TotalPages);
        }

        public async Task<SearchResult<MultiSearch>> MultiSearchAsync(string query, string language = null, int page = 1, bool includeAdult = true, string region = null)
        {
            var queryString = CreateQueryString();

            queryString.Add("query", query);
            queryString.Add("language", language);
            queryString.Add("page", page.ToString());
            queryString.Add("include_adult", includeAdult.ToString());
            queryString.Add("region", region);

            var searchResultDTO = await GetSearchResultAsync("search/multi", queryString);

            var multiSearch = new MultiSearch();

            if (searchResultDTO.Results != null)
            {
                foreach (var searchResult in searchResultDTO.Results)
                {
                    switch (searchResult.MediaType)
                    {
                        case Model.MediaType.Movie:
                            multiSearch.AddMovie(SearchResultFactory.CreateMovie(searchResult));
                            break;

                        case Model.MediaType.Person:
                            multiSearch.AddPerson(SearchResultFactory.CreatePerson(searchResult));
                            break;

                        case Model.MediaType.Tv:
                            multiSearch.AddTvShow(SearchResultFactory.CreateTvShow(searchResult));
                            break;
                    }
                }
            }

            return new SearchResult<MultiSearch>(multiSearch, searchResultDTO.Page,
                searchResultDTO.TotalResults, searchResultDTO.TotalPages);
        }

        private async Task<SearchResultDTO> GetSearchResultAsync(string path, NameValueCollection queryString)
        {
            var client = httpConnection.GetClient();

            var response = await client.GetAsync(path);

            var content = await response.Content.ReadAsStringAsync();

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<SearchResultDTO>(content);
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.Unauthorized:
                    var error = JsonConvert.DeserializeObject<ErrorResponse>(content);
                    throw new Exception(error.StatusMessage);
                default:
                    throw new Exception("Error on server");
            }
        }

        private IList<Movie> CreateMoviesFromSearchResult(IList<SearchResultItemDTO> searchResults)
        {
            var movies = new List<Movie>();

            if (searchResults == null)
                return movies;

            foreach (var searchResult in searchResults)
                movies.Add(SearchResultFactory.CreateMovie(searchResult));

            return movies;
        }

        private NameValueCollection CreateQueryString()
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("api_key", apiKey);

            return queryString;
        }
    }
}
