using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using TMDBNet.Search.DTO;
using TMDBNet.Search.Model;

[assembly: InternalsVisibleTo("TMDBNet.Tests")]
namespace TMDBNet.Search.Factories
{
    internal static class SearchResultFactory
    {
        internal static SearchResult<MultiSearch> CreateMultiSearch(SearchResultDTO searchResult)
        {
            if (searchResult == null)
                return null;

            searchResult.Results = searchResult.Results ?? Array.Empty<SearchResultItemDTO>();

            var results = SearchResultItemFactory.Create(searchResult.Results);

            return new SearchResult<MultiSearch>(results, searchResult.Page, searchResult.TotalResults, searchResult.TotalPages);
        }

        internal static SearchResult<IList<T>> CreateList<T>(SearchResultDTO searchResult)
        {
            if (searchResult == null)
                return null;

            searchResult.Results = searchResult.Results ?? Array.Empty<SearchResultItemDTO>();

            var results = new List<T>();

            foreach (var serachResultItem in searchResult.Results)
            {
                results.Add(SearchResultItemFactory.Create<T>(serachResultItem));
            }

            return new SearchResult<IList<T>>(results, searchResult.Page, searchResult.TotalResults, searchResult.TotalPages);
        }
    }
}