using System;
using System.Collections.Generic;
using System.Text;
using TMDBNet.Search.DTO;
using TMDBNet.Search.Model;

namespace TMDBNet.Search.Factories
{
    internal static class MediaFactory
    {
        internal static Media Create<T>(SearchResultItemDTO searchResultItem) where T : Media
        {
            if (typeof(T) == typeof(Movie))
            {
                return CreateMovie(searchResultItem);
            }
            else if (typeof(T) == typeof(TvShow))
            {
                return CreateTvShow(searchResultItem);
            }

            throw new Exception("Unrecognized media type");
        }

        private static Movie CreateMovie(SearchResultItemDTO searchResultItem)
        {
            return new Movie(
                posterPath: searchResultItem.PosterPath,
                isAdult: searchResultItem.IsAdult,
                overview: searchResultItem.Overview,
                releaseDate: searchResultItem.ReleaseDate,
                genresId: searchResultItem.GenresId,
                id: searchResultItem.Id,
                originalTitle: searchResultItem.OriginalTitle,
                originalLanguage: searchResultItem.OriginalLanguage,
                title: searchResultItem.Title,
                backdropPath: searchResultItem.BackdropPath,
                popularity: searchResultItem.Popularity,
                voteCount: searchResultItem.VoteCount,
                video: searchResultItem.Video,
                voteAverage: searchResultItem.VoteAverage
            );
        }

        private static TvShow CreateTvShow(SearchResultItemDTO searchResultItem)
        {
            return new TvShow(
                posterPath: searchResultItem.PosterPath,
                overview: searchResultItem.Overview,
                genresId: searchResultItem.GenresId,
                id: searchResultItem.Id,
                originalLanguage: searchResultItem.OriginalLanguage,
                backdropPath: searchResultItem.BackdropPath,
                popularity: searchResultItem.Popularity,
                voteCount: searchResultItem.VoteCount,
                voteAverage: searchResultItem.VoteAverage,
                firstAirDate: searchResultItem.FirstAirDate,
                originalCountry: searchResultItem.OriginalCountry,
                name: searchResultItem.Name,
                originalName: searchResultItem.OriginalName
                );
        }
    }
}
