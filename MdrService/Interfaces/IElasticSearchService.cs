using Nest;

namespace MdrService.Interfaces
{
    public interface IElasticSearchService
    {
        ElasticClient GetConnection();
    }
}