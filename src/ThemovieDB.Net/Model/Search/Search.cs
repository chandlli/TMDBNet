using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ThemovieDB.Net.Model.Search
{
    internal sealed class Search : ISearch
    {
        private readonly string apiKey;
        private readonly HttpConnection httpConnection;
        private const string MULTI_SEARCH_PATH = "/search/multi";

        public Search(string apiKey, HttpConnection httpConnection)
        {
            this.apiKey = apiKey;
            this.httpConnection = httpConnection;
        }

        public async Task<MultiSearchResult> MultiSearchAsync(string query, string language = null, int page = 1, bool includeAdult = false, string region = null)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["query"] = query;
            queryString["page"] = page.ToString();
            queryString["includeAdult"] = includeAdult.ToString();
            queryString["region"] = region.ToString();

            if (!string.IsNullOrEmpty(language))
            {
                queryString["language"] = language;
            }

            string queryStringResult = queryString.ToString();

            var client = httpConnection.GetClient();

            var response = await client.GetAsync($"{queryStringResult}?{queryStringResult}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                return Newtonsoft.Json.JsonConvert.DeserializeObject<MultiSearchResult>(content);
            }

            return null;
        }
    }
}
