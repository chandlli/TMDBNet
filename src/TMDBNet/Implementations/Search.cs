using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using TMDBNet.Abstractions;
using TMDBNet.Model.Search;

namespace TMDBNet.Implementations
{
    internal sealed class Search : ISearch
    {
        private readonly string apiKey;
        private readonly HttpConnection httpConnection;

        public Search(string apiKey, HttpConnection httpConnection)
        {
            this.apiKey = apiKey;
            this.httpConnection = httpConnection;
        }

        public async Task<SearchResult<MultiSearch>> MultiSearchAsync(string query, string language, int page, bool includeAdult, string region)
        {
            var queryString = CreateQueryString();

            queryString.Add("query", query);
            queryString.Add("page", page.ToString());
            queryString.Add("includeAdult", includeAdult.ToString());
            queryString.Add("region", region);
            queryString.Add("language", language);

            return await MakeRequest<SearchResult<MultiSearch>>("search/multi", queryString);
        }

        public async Task<SearchResult<Movie>> MovieAsync(string query, string language = null, int page = 1, bool includeAdult = true, string region = null, int? year = null, int? primaryReleaseYear = null)
        {
            var queryString = CreateQueryString();

            queryString.Add("query", query);
            queryString.Add("page", page.ToString());
            queryString.Add("includeAdult", includeAdult.ToString());
            queryString.Add("region", region);
            queryString.Add("language", language);

            return await MakeRequest<SearchResult<Movie>>("search/movie", queryString);
        }

        private async Task<T> MakeRequest<T>(string path, NameValueCollection querystring)
        {
            string finalPath = $"{path}?{querystring.ToString()}";

            var client = httpConnection.GetClient();

            var response = await client.GetAsync(path);

            var content = await response.Content.ReadAsStringAsync();

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<T>(content);
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.Unauthorized:
                    var error = JsonConvert.DeserializeObject<ErrorResponse>(content);
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
