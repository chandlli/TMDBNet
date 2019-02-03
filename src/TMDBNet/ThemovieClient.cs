using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TMDBNet.Abstractions;
using TMDBNet.Implementations;
using TMDBNet.Model;

namespace TMDBNet
{
    public sealed class TMDBNetApiFactory
    {
        private readonly IServiceProvider serviceProvider;

        public TMDBNetApiFactory(string apiKey, IServiceProvider serviceProvider = null)
        {
            if (serviceProvider != null)
                this.serviceProvider = serviceProvider;
            else
                serviceProvider = BuildDefaultServiceProvider();
        }

        public T CreateApi<T>() where T : IApi
        {
            var service = serviceProvider.GetService<T>();

            if (service == null)
                throw new Exception("Type not registred");

            return service;
        }

        private IServiceProvider BuildDefaultServiceProvider()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddHttpClient<ISearch, Search>(client =>
            {
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            });

            return serviceCollection.BuildServiceProvider();
        }
    }
}
