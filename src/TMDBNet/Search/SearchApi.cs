using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TMDBNet.Search;
using TMDBNet.Search.DTO;
using TMDBNet.Search.Factories;
using TMDBNet.Search.Model;

namespace TMDBNet.Search
{
    public sealed class SearchApi : ISearchApi
    {
        private readonly string apiKey;
        private readonly HttpClient httpClient;

        public SearchApi(string apiKey, HttpClient httpClient)
        {
            this.apiKey = apiKey;
            this.httpClient = httpClient;
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

            return SearchResultFactory.CreateList<Movie>(searchResultDTO);
        }

        public async Task<SearchResult<IList<TvShow>>> TvShowAsync(string query, string language = null, int page = 1, int? firstAirDateYear = null)
        {
            var queryString = CreateQueryString();

            queryString.Add("query", query);
            queryString.Add("language", language);
            queryString.Add("page", page.ToString());
            queryString.Add("first_air_date_year", firstAirDateYear.ToString());

            var searchResultDTO = await GetSearchResultAsync("search/tv", queryString);

            return SearchResultFactory.CreateList<TvShow>(searchResultDTO);
        }

        public async Task<SearchResult<IList<People>>> PeopleAsync(string query, string language = null, int page = 1, bool includeAdult = true, string region = null)
        {
            var queryString = CreateQueryString();

            queryString.Add("query", query);
            queryString.Add("language", language);
            queryString.Add("page", page.ToString());
            queryString.Add("include_adult", includeAdult.ToString());
            queryString.Add("region", region);

            var searchResultDTO = await GetSearchResultAsync("search/person", queryString);

            return SearchResultFactory.CreateList<People>(searchResultDTO);
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

            return SearchResultFactory.CreateMultiSearch(searchResultDTO);
        }

        public async Task<SearchResult<IList<KeyWord>>> KeyWordAsync(string query, int page = 1)
        {
            var queryString = CreateQueryString();

            queryString.Add("query", query);
            queryString.Add("page", page.ToString());

            var searchResultDTO = await GetSearchResultAsync("search/keyword", queryString);

            return SearchResultFactory.CreateList<KeyWord>(searchResultDTO);
        }

        public async Task<SearchResult<IList<Collection>>> CollectionAsync(string query, string language = null, int page = 1)
        {
            var queryString = CreateQueryString();

            queryString.Add("query", query);
            queryString.Add("language", language);
            queryString.Add("page", page.ToString());

            var searchResultDTO = await GetSearchResultAsync("search/collection", queryString);

            return SearchResultFactory.CreateList<Collection>(searchResultDTO);
        }

        public async Task<SearchResult<IList<Company>>> CompaniesAsync(string query, int page = 1)
        {
            var queryString = CreateQueryString();

            queryString.Add("query", query);
            queryString.Add("page", page.ToString());

            var searchResultDTO = await GetSearchResultAsync("search/company", queryString);

            return SearchResultFactory.CreateList<Company>(searchResultDTO);
        }

        private async Task<SearchResultDTO> GetSearchResultAsync(string path, NameValueCollection queryString)
        {
            var response = await httpClient.GetAsync(path);

            var content = await response.Content.ReadAsStringAsync();

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<SearchResultDTO>(content);
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.Unauthorized:
                    var error = JsonConvert.DeserializeObject<ErrorResponseDTO>(content);
                    throw new Exception(error.StatusMessage);
                default:
                    throw new Exception("Error on server");
            }
        }

        private NameValueCollection CreateQueryString()
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("api_key", apiKey);

            return queryString;
        }
    }
}
