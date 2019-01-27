using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMDBNet.Model.Search;

namespace TMDBNet.Abstractions
{
    public interface ISearch : IApi
    {
        Task<SearchResult<MultiSearch>> MultiSearchAsync(string query, string language = null, int page = 1, bool includeAdult = true, string region = null);

        Task<SearchResult<Movie>> MovieAsync(string query, string language = null, int page = 1, bool includeAdult = true, string region = null, int? year = null, int? primaryReleaseYear = null);
    }
}
