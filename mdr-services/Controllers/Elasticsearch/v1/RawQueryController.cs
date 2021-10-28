using System.Threading.Tasks;
using mdr_services.Contracts.Requests.v1;
using mdr_services.Contracts.Responses.v1;
using mdr_services.Contracts.Routes.ApiRoutes.v1;
using mdr_services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace mdr_services.Controllers.Elasticsearch.v1
{
    [ApiController]
    public class RawQueryController : ControllerBase
    {
        private readonly IRawQueryRepository _rawQueryRepository;
        
        public RawQueryController(IRawQueryRepository rawQueryRepository)
        {
            _rawQueryRepository = rawQueryRepository;
        }

        [HttpPost(ApiRoutes.RawQuery.GetStudySearchResults)]
        public async Task<ActionResult<SearchResponse>> GetStudySearchResults(RawQueryRequest rawQueryRequest)
        {
            var response = await _rawQueryRepository.GetStudySearchResults(rawQueryRequest);
            return Ok(new SearchResponse()
            {
                Total = response.Total,
                Page = rawQueryRequest.Page,
                Size = rawQueryRequest.Size,
                Data = response.Data
            });
        }
        
        [HttpPost(ApiRoutes.RawQuery.GetObjectSearchResults)]
        public async Task<ActionResult<SearchResponse>> GetObjectSearchResults(RawQueryRequest rawQueryRequest)
        {
            var response = await _rawQueryRepository.GetObjectSearchResults(rawQueryRequest);
            return Ok(new SearchResponse()
            {
                Total = response.Total,
                Page = rawQueryRequest.Page,
                Size = rawQueryRequest.Size,
                Data = response.Data
            });
        }
    }
}