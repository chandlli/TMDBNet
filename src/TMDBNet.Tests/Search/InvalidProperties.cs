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
                        GenresId = null,
                        Id = null,
                        OriginalTitle = null,
                        OriginalLanguage = null,
                        Title = null,
                        BackdropPath = null,
                        Popularity = null,
                        VoteCount = null,
                        Video = null,
                        VoteAverage = null
                    },
                    new SearchResultItemDTO()
                    {
                        PosterPath = null,
                        IsAdult = null,
                        Overview = null,
                        ReleaseDate = null,
                        GenresId = null,
                        Id = null,
                        OriginalTitle = null,
                        OriginalLanguage = null,
                        Title = null,
                        BackdropPath = null,
                        Popularity = null,
                        VoteCount = null,
                        Video = null,
                        VoteAverage = null
                    }
                },
                TotalResults = 2,
                TotalPages = 1
            };
        }

        [Fact]
        public async Task Movie_Null()
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
