using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TMDBNet.Abstractions;
using TMDBNet.Implementations;

namespace TMDBNet
{
    public sealed class TMDBNetApiFactory
    {
        private readonly IDictionary<Type, IApi> apis;

        public TMDBNetApiFactory(string apiKey, HttpConnection httpConnection = null)
        {
            if (httpConnection is null)
                httpConnection = new HttpConnection();

            apis = new Dictionary<Type, IApi>();

            apis.Add(typeof(ISearch), new Search(apiKey, httpConnection));
        }

        public T CreateApi<T>() where T : IApi
        {
            if (apis.ContainsKey(typeof(T)))
                return (T)apis[typeof(T)];

            throw new Exception("Type not registred");
        }
    }
}
