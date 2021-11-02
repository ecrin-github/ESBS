using System;
using MdrService.Interfaces;
using Nest;

namespace MdrService.Services
{
    public class ElasticSearchService : IElasticSearchService
    {
        public ElasticClient GetConnection()
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            return new ElasticClient(settings);
        }
    }
}