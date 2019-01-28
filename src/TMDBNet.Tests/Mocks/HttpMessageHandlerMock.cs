using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TMDBNet.Tests.Mocks
{
    public abstract class HttpMessageHandlerMock : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return DoSendAsync(request);
        }

        public abstract Task<HttpResponseMessage> DoSendAsync(HttpRequestMessage request);
    }
}
