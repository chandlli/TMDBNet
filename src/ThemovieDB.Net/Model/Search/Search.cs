using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThemovieDB.Net.Model.Search
{
    internal sealed class Search : ISearch
    {
        private readonly string apiKey;
        private const string MULTI_SEARCH_PATH = "/search/multi";

        public Search(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public Task<MultiSearchResult> MultiSearchAsync(string apiKey, string query, string language = null, int page = 1, bool includeAdult = true, string region = null)
        {
            throw new NotImplementedException();
        }
    }
}
