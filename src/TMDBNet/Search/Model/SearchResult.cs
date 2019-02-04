using System;
using System.Collections.Generic;
using System.Text;

namespace TMDBNet.Search.Model
{
    public class SearchResult<T>
    {
        public int? Page { get; private set; }
        public int? TotalResults { get; private set; }
        public int? TotalPages { get; private set; }
        public T Results { get; private set; }

        public SearchResult(T results, int? page = null, int? totalResults = null, int? totalPages = null)
        {
            Page = page;
            TotalResults = totalResults;
            TotalPages = totalPages;
            Results = results;
        }
    }
}
