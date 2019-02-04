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
        internal static SearchResult<T> CreateSearchResult<T>(SearchResultDTO searchResult)
        {
            if (searchResult == null)
                return null;

            searchResult.Results = searchResult.Results ?? Array.Empty<SearchResultItemDTO>();

            object results;

            if (typeof(T) == typeof(MultiSearch))
            {
                results = SearchResultItemFactory.Create(searchResult.Results);
            }
            else
            {
                results = CreateResults<T>(searchResult.Results);
            }

            var finalResults = (T)Convert.ChangeType(results, typeof(T));

            return new SearchResult<T>(finalResults, searchResult.Page, searchResult.TotalResults, searchResult.TotalPages);
        }

        private static IList<T> CreateResults<T>(SearchResultItemDTO[] searchResultItens)
        {
            var results = new List<T>();

            foreach (var serachResultItem in searchResultItens)
            {
                results.Add(SearchResultItemFactory.Create<T>(serachResultItem));
            }

            return results;
        }
    }
}