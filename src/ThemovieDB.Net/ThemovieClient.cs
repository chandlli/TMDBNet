using System;
using System.Net.Http;
using System.Threading.Tasks;
using ThemovieDB.Net.Model.Search;

namespace ThemovieDB.Net
{
    public sealed class ThemovieClient : ISearch
    {
        private readonly string apiKey;

        public ThemovieClient(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public Task<MultiSearchResult> MultiSearchAsync(string apiKey, string query, string language = null, int page = 1, bool includeAdult = true, string region = null)
        {
            throw new NotImplementedException();
        }
    }
}
