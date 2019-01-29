using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TMDBNet.Implementations;
using TMDBNet.Model.Search;
using Xunit;
using Shouldly;
using System.Linq;

namespace TMDBNet.Tests.Implementations
{
    public class SearchTest
    {
        private readonly SearchResultDTO allProperties;

        public SearchTest()
        {
            allProperties = new SearchResultDTO()
            {
                Page = 1,
                Results = new SearchResultItemDTO[]
                {
                    new SearchResultItemDTO()
                    {
                        PosterPath = "/cezWGskPY5x7GaglTTRN4Fugfb8.jpg",
                        IsAdult = true,
                        Overview = "When an unexpected enemy emerges and threatens global safety and security, Nick Fury, director of the international peacekeeping agency known as S.H.I.E.L.D., finds himself in need of a team to pull the world back from the brink of disaster. Spanning the globe, a daring recruitment effort begins!",
                        ReleaseDate = "2012-04-25",
                        GenresId = new int[]
                        {
                            878, 28, 12
                        },
                        Id = 24428,
                        OriginalTitle = "The Avengers",
                        OriginalLanguage = "en",
                        Title = "The Avengers",
                        BackdropPath = "/hbn46fQaRmlpBuUrEiFqv0GDL6Y.jpg",
                        Popularity = 7.353212m,
                        VoteCount = 8503,
                        Video = true,
                        VoteAverage = 7.33m
                    },
                    new SearchResultItemDTO()
                    {
                        PosterPath = "/7cJGRajXMU2aYdTbElIl6FtzOl2.jpg",
                        IsAdult = true,
                        Overview = "British Ministry agent John Steed, under direction from \"Mother\", investigates a diabolical plot by arch-villain Sir August de Wynter to rule the world with his weather control machine. Steed investigates the beautiful Doctor Mrs. Emma Peel, the only suspect, but simultaneously falls for her and joins forces with her to combat Sir August.",
                        ReleaseDate = "1998-08-13",
                        GenresId = new int[]
                        {
                            53
                        },
                        Id = 9320,
                        OriginalTitle = "The Avengers",
                        OriginalLanguage = "en",
                        Title = "The Avengers",
                        BackdropPath = "/8YW4rwWQgC2JRlBcpStMNUko13k.jpg",
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
        public async Task Validate_All_Properties()
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonConvert.SerializeObject(allProperties))
               })
               .Verifiable();


            var httpConnection = new HttpConnection(handlerMock.Object);

            var search = new Search("", httpConnection);

            var result = await search.MovieAsync("avengers");

            result.ShouldNotBeNull();
            result.Results.ShouldNotBeNull();
            result.Results.Count.ShouldBe(allProperties.Results.Length);

            var first = result.Results.First();
            var expectedFirst = allProperties.Results.First();

            first.PosterPath.ShouldBe(expectedFirst.PosterPath);
            first.IsAdult.HasValue.ShouldBeTrue();
            first.IsAdult.ShouldBe(expectedFirst.IsAdult);
            first.Overview.ShouldBe(expectedFirst.Overview);
            first.ReleaseDate.ShouldBe(expectedFirst.ReleaseDate);
            first.GenresId.ShouldNotBeNull();
            first.GenresId.Count.ShouldBe(expectedFirst.GenresId.Count);
            first.GenresId.ShouldBeSubsetOf(expectedFirst.GenresId);
            first.Id.HasValue.ShouldBeTrue();
            first.Id.ShouldBe(expectedFirst.Id);
            first.OriginalTitle.ShouldBe(expectedFirst.OriginalTitle);
            first.OriginalLanguage.ShouldBe(expectedFirst.OriginalLanguage);
            first.Title.ShouldBe(expectedFirst.Title);
            first.BackdropPath.ShouldBe(expectedFirst.BackdropPath);
            first.Popularity.HasValue.ShouldBeTrue();
            first.Popularity.ShouldBe(expectedFirst.Popularity);
            first.VoteCount.HasValue.ShouldBeTrue();
            first.VoteCount.ShouldBe(expectedFirst.VoteCount);
            first.Video.HasValue.ShouldBeTrue();
            first.Video.ShouldBe(expectedFirst.Video);
            first.VoteAverage.HasValue.ShouldBeTrue();
            first.VoteAverage.ShouldBe(expectedFirst.VoteAverage);
        }
    }
}
