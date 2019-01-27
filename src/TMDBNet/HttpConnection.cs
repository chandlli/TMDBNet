using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ThemovieDB.Net.Model;

namespace TMDBNet
{
    public class HttpConnection
    {
        private static HttpClient client;
        private const string URL_API_V3 = "https://api.themoviedb.org/3/";

        public HttpConnection(HttpMessageHandler handler = null, ApiVersion apiVersion = ApiVersion.V3)
        {
            if (handler is null)
                client = new HttpClient();
            else
                client = new HttpClient(handler);

            switch (apiVersion)
            {
                case ApiVersion.V3:
                    client.BaseAddress = new Uri(URL_API_V3);
                    break;
            }
        }

        internal HttpClient GetClient()
        {
            if (client.BaseAddress is null)
                throw new Exception("Api version not configured");

            return client;
        }
    }
}
