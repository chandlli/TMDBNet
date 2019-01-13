using System;
using System.Net.Http;
using System.Threading.Tasks;
using ThemovieDB.Net.Model.Search;

namespace ThemovieDB.Net
{
    public sealed class ThemovieClient
    {
        private readonly ISearch search;

        public ThemovieClient(string apiKey, HttpConnection httpConnection = null)
        {
            if (httpConnection is null)
                httpConnection = new HttpConnection();

            this.search = new Search(apiKey, httpConnection);
        }

        public async Task<MultiSearchResult> MultiSearchAsync(string query, string language = null, int page = 1, bool includeAdult = true, string region = null)
        {
            if (query is null)
            {
                throw new ArgumentNullException("query");
            }

            return await search.MultiSearchAsync(query, language, page, includeAdult, region);
        }
    }
}
