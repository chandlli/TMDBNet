using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ThemovieDB.Net.Model;

namespace ThemovieDB.Net.Factories
{
    internal static class RequestClientFactory
    {
        private const string URL_API_V3 = "https://api.themoviedb.org/3/";

        public static HttpClient CreateRequestClient(ApiVersion apiVersion)
        {
            var client = new HttpClient();

            switch (apiVersion)
            {
                case ApiVersion.V3:
                    client.BaseAddress = new Uri(URL_API_V3);
                    break;
                default:
                    throw new Exception("API version not recognized");
            }

            return client;
        }
    }
}
