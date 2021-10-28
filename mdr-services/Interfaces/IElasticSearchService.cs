using Nest;

namespace mdr_services.Interfaces
{
    public interface IElasticSearchService
    {
        ElasticClient GetConnection();
    }
}