using System;
using mdr_services.Interfaces;
using Nest;

namespace mdr_services.Services
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