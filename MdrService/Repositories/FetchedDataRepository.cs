using System.Linq;
using System.Threading.Tasks;
using MdrService.Contracts.Responses.v1.FetchedData;
using MdrService.Interfaces;
using MdrService.Models.Elasticsearch.Object;
using MdrService.Models.Elasticsearch.Study;


namespace MdrService.Repositories
{
    public class FetchedDataRepository : IFetchedDataRepository
    {
        private readonly IElasticSearchService _elasticSearchService;

        public FetchedDataRepository(IElasticSearchService elasticSearchService)
        {
            _elasticSearchService = elasticSearchService;
        }

        public async Task<FetchedObjects> GetStudyObjects(int[] ids)
        {
            var result = await _elasticSearchService.GetConnection().SearchAsync<Object>(s => s
                .Index("data-object")
                .Query(q => q
                    .Bool(b => b
                        .Filter(f => f
                            .Terms(t => t
                                .Field(p => p.Id)
                                .Terms(ids)
                            )
                        )
                    )
                )
            );
            var fetchedObjects = new FetchedObjects()
            {
                Total = result.Total,
                Objects = result.Documents.ToList()
            };
            return fetchedObjects;
        }
        
        
        public async Task<FetchedStudies> GetObjectStudies(int[] ids)
        {
            var result = await _elasticSearchService.GetConnection().SearchAsync<Study>(s => s
                .Index("study")
                .Query(q => q
                    .Bool(b => b
                        .Filter(f => f
                            .Terms(t => t
                                .Field(p => p.Id)
                                .Terms(ids)
                            )
                        )
                    )
                )
            );
            var fetchedStudies = new FetchedStudies()
            {
                Total = result.Total,
                Studies = result.Documents.ToList()
            };
            return fetchedStudies;
        }
    }
}