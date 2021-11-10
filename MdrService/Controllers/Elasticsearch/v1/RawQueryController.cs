using System.Threading.Tasks;
using MdrService.Contracts.Requests.v1;
using MdrService.Contracts.Responses.v1;
using MdrService.Contracts.Routes.ApiRoutes.v1;
using MdrService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MdrService.Controllers.Elasticsearch.v1
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
    }
}