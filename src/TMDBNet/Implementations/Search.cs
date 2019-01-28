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

            string finalPath = $"search/movie?{queryString.ToString()}";

            var client = httpConnection.GetClient();

            var response = await client.GetAsync(finalPath);

            var content = await response.Content.ReadAsStringAsync();

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:

                    var searchResultDTO = JsonConvert.DeserializeObject<SearchResultDTO>(content);

                    var movies = CreateMoviesFromSearchResult(searchResultDTO.Results);

                    var searchResult = new SearchResult<IList<Movie>>(movies,
                        searchResultDTO.Page, searchResultDTO.TotalResults, searchResultDTO.TotalPages);

                    return searchResult;
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
