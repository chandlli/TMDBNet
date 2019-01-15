using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThemovieDB.Net.Tests.Mock;
using Xunit;

namespace ThemovieDB.Net.Tests
{
    public class MultiSearchTest
    {
        private const string apiKey = "1234";
        private HttpConnection connection;

        public MultiSearchTest()
        {
            connection = new HttpConnection(new MultiSearchHandler());
        }

        [Fact]
        public async Task Search_Query_Null_Should_Throw_Exception()
        {
            var client = new ThemovieClient(apiKey, connection);
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.MultiSearchAsync(null));
        }

        [Fact]
        public async Task Search_Query_Empty_Should_Throw_Exception()
        {
            var client = new ThemovieClient(apiKey, connection);
            await Assert.ThrowsAsync<ArgumentException>(() => client.MultiSearchAsync(string.Empty));
        }
    }
}
