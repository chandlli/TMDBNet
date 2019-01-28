using System;
using System.Collections.Generic;
using System.Text;

namespace TMDBNet.Model.Search
{
    internal static class SearchResultFactory
    {
        internal static Movie CreateMovie(SearchResultItemDTO searchResultDTO)
        {
            return new Movie(
                posterPath: searchResultDTO.PosterPath,
                isAdult: searchResultDTO.IsAdult,
                overview: searchResultDTO.Overview,
                releaseDate: searchResultDTO.ReleaseDate,
                genresId: searchResultDTO.GenresId,
                id: searchResultDTO.Id,
                originalTitle: searchResultDTO.OriginalTitle,
                originalLanguage: searchResultDTO.OriginalLanguage,
                title: searchResultDTO.Title,
                backdropPath: searchResultDTO.BackdropPath,
                popularity: searchResultDTO.Popularity,
                voteCount: searchResultDTO.VoteCount,
                video: searchResultDTO.Video,
                voteAverage: searchResultDTO.VoteAverage
            );
        }

        internal static TvShow CreateTvShow(SearchResultItemDTO searchResultDTO)
        {
            return new TvShow();
        }

        internal static Person CreatePerson(SearchResultItemDTO searchResultDTO)
        {
            return new Person();
        }
    }
}
