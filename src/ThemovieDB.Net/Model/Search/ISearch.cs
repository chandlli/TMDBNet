using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThemovieDB.Net.Model.Search
{
    public interface ISearch
    {
        Task<MultiSearchResult> MultiSearchAsync(string apiKey, string query, string language = null, int page = 1, bool includeAdult = true, string region = null);
    }
}
