using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMDBNet.Model.Search;

namespace TMDBNet.Abstractions
{
    /// <summary>
    /// Search interface
    /// </summary>
    public interface ISearch : IApi
    {
        /// <summary>
        /// Search multiple models in a single request. Multi search currently supports searching for movies, tv shows and people in a single request.
        /// </summary>
        /// <param name="query">Pass a text query to search</param>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it.</param>
        /// <param name="page">Specify which page to query.</param>
        /// <param name="includeAdult">Choose whether to inlcude adult (pornography) content in the results.</param>
        /// <param name="region">Specify a ISO 3166-1 code to filter release dates. Must be uppercase.</param>
        /// <returns></returns>
        Task<SearchResult<MultiSearch>> MultiSearchAsync(string query, string language = null, int page = 1, bool includeAdult = true, string region = null);

        /// <summary>
        /// Search for movies.
        /// </summary>
        /// <param name="query">Pass a text query to search</param>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it.</param>
        /// <param name="page">Specify which page to query.</param>
        /// <param name="includeAdult">Choose whether to inlcude adult (pornography) content in the results.</param>
        /// <param name="region">Specify a ISO 3166-1 code to filter release dates. Must be uppercase.</param>
        /// <param name="year">Pass movie year</param>
        /// <param name="primaryReleaseYear">Primary release movie year</param>
        /// <returns></returns>
        Task<SearchResult<IList<Movie>>> MovieAsync(string query, string language = null, int page = 1, bool includeAdult = true, string region = null, int? year = null, int? primaryReleaseYear = null);

        /// <summary>
        /// Search for a TV show.
        /// </summary>
        /// <param name="query">Pass a text query to search. This value should be URI encoded.</param>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it.</param>
        /// <param name="page">Specify which page to query.</param>
        /// <param name="firstAirDateYear">First air date</param>
        /// <returns></returns>
        Task<SearchResult<IList<TvShow>>> TvShowAsync(string query, string language = null, int page = 1, int? firstAirDateYear = null);

        /// <summary>
        /// Search for people.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="language"></param>
        /// <param name="page"></param>
        /// <param name="includeAdult"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        Task<SearchResult<IList<People>>> PeopleAsync(string query, string language = null, int page = 1, bool includeAdult = true, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<SearchResult<IList<KeyWord>>> KeyWordAsync(string query, int page = 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="language"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<SearchResult<IList<Collection>>> CollectionAsync(string query, string language = null, int page = 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<SearchResult<IList<Company>>> CompaniesAsync(string query, int page = 1);
    }
}
