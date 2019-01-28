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
        private readonly dynamic allProperties;

        public SearchTest()
        {
            allProperties = new
            {
                page = 1,
                results = new[]
                {
                    new
                    {
                        poster_path = "/cezWGskPY5x7GaglTTRN4Fugfb8.jpg",
                        adult = true,
                        overview = "When an unexpected enemy emerges and threatens global safety and security, Nick Fury, director of the international peacekeeping agency known as S.H.I.E.L.D., finds himself in need of a team to pull the world back from the brink of disaster. Spanning the globe, a daring recruitment effort begins!",
                        release_date = "2012-04-25",
                        genre_ids = new int[]
                        {
                            878, 28, 12
                        },
                        id = 24428,
                        original_title = "The Avengers",
                        original_language = "en",
                        title = "The Avengers",
                        backdrop_path = "/hbn46fQaRmlpBuUrEiFqv0GDL6Y.jpg",
                        popularity = 7.353212,
                        vote_count = 8503,
                        video = true,
                        vote_average = 7.33
                    },
                    new
                    {
                        poster_path = "/7cJGRajXMU2aYdTbElIl6FtzOl2.jpg",
                        adult = true,
                        overview = "British Ministry agent John Steed, under direction from \"Mother\", investigates a diabolical plot by arch-villain Sir August de Wynter to rule the world with his weather control machine. Steed investigates the beautiful Doctor Mrs. Emma Peel, the only suspect, but simultaneously falls for her and joins forces with her to combat Sir August.",
                        release_date = "1998-08-13",
                        genre_ids = new int[]
                        {
                            53
                        },
                        id = 9320,
                        original_title = "The Avengers",
                        original_language = "en",
                        title = "The Avengers",
                        backdrop_path = "/8YW4rwWQgC2JRlBcpStMNUko13k.jpg",
                        popularity = 2.270454,
                        vote_count = 111,
                        video = true,
                        vote_average = 4.7
                    }
                },
                total_results = 2,
                total_pages = 1
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
            result.Results.Count.ShouldBe(2);

            var first = result.Results.First();
            var expectedFirst = allProperties.results[0];

            first.PosterPath.ShouldBe(expectedFirst.poster_path as string);
#warning TO_DO
        }
    }
}
