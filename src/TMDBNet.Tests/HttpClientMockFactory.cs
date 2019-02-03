using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TMDBNet.Tests
{
    public static class HttpClientMockFactory
    {
        public static HttpClient CreateClient(HttpResponseMessage responseMessage)
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(responseMessage)
               .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object);
            httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");

            return httpClient;
        }
    }
}
