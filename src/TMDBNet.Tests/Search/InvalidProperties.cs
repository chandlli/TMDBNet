using Newtonsoft.Json;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TMDBNet.Search;
using TMDBNet.Search.DTO;
using TMDBNet.Search.Factories;
using TMDBNet.Search.Model;
using Xunit;

namespace TMDBNet.Tests.Search
{
    public sealed class InvalidProperties
    {
        private readonly SearchResultDTO nullProperties;

        public InvalidProperties()
        {
            nullProperties = new SearchResultDTO()
            {
                Page = 1,
                Results = new SearchResultItemDTO[]
                {
                    new SearchResultItemDTO()
                    {
                        PosterPath = null,
                        IsAdult = true,
                        Overview = null,
                        ReleaseDate = null,
                        GenresId = new int[]
                        {
                            878, 28, 12
                        },
                        Id = 24428,
                        OriginalTitle = null,
                        OriginalLanguage = null,
                        Title = null,
                        BackdropPath = null,
                        Popularity = 7.353212m,
                        VoteCount = 8503,
                        Video = true,
                        VoteAverage = 7.33m
                    },
                    new SearchResultItemDTO()
                    {
                        PosterPath = null,
                        IsAdult = true,
                        Overview = null,
                        ReleaseDate = null,
                        GenresId = new int[]
                        {
                            53
                        },
                        Id = 9320,
                        OriginalTitle = null,
                        OriginalLanguage = null,
                        Title = null,
                        BackdropPath = null,
                        Popularity = 2.270454m,
                        VoteCount = 111,
                        Video = true,
                        VoteAverage = 4.7m
                    }
                },
                TotalResults = 2,
                TotalPages = 1
            };
        }

        [Fact]
        public async Task Movie_Strings_Null()
        {
            var httpClient = HttpClientMockFactory.CreateClient(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(nullProperties))
            });

            var search = new SearchApi("", httpClient);

            var result = await search.MovieAsync("avengers");

            result.ShouldNotBeNull();
            result.Results.ShouldNotBeNull();
            result.Results.Count.ShouldBe(nullProperties.Results.Length);

            for (var index = 0; index < result.Results.Count; index++)
            {
                var movie = result.Results[index];
                var expectedMovie = SearchResultItemFactory.Create<Movie>(
                    nullProperties.Results[index]);

                movie.ShouldBe(expectedMovie);
            }
        }
    }
}
