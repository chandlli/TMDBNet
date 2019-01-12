using System;
using System.Collections.Generic;
using System.Text;

namespace ThemovieDB.Net.Model.Search
{
    public class MultiSearchResult
    {
        public int Page { get; set; }
        public IList<MultiSearchItemResult> Results { get; set; }
        public MediaType MediaType { get; set; }
    }
}
