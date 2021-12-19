using System;
using System.Threading.Tasks;
using MdmService.Contracts.Requests.Filtering;
using MdmService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MdmService.Controllers.v1.Filtering
{
    public class FilteringControllerApi : BaseApiController
    {
        private readonly IObjectRepository _objectRepository;
        private readonly IStudyRepository _studyRepository;

        public FilteringControllerApi(
            IObjectRepository objectRepository,
            IStudyRepository studyRepository)
        {
            _objectRepository = objectRepository ?? throw new ArgumentNullException(nameof(objectRepository));
            _studyRepository = studyRepository ?? throw new ArgumentNullException(nameof(studyRepository));
        }

        /*
        [HttpPost("pagination/studies")]
        [SwaggerOperation(Tags = new []{"Pagination"})]
        public async Task<IActionResult> PaginateStudies(PaginationRequest paginationRequest)
        {
            return Ok();
        }

        [HttpPost("pagination/objects")]
        [SwaggerOperation(Tags = new []{"Pagination"})]
        public async Task<IActionResult> PaginateObjects(PaginationRequest paginationRequest)
        {
            return Ok();
        }

        [HttpPost("filter/studies/by-title")]
        [SwaggerOperation(Tags = new []{"Filtering - by title"})]
        public async Task<IActionResult> FilterStudiesByTitle(FilteringByTitleRequest filteringByTitleRequest)
        {
            return Ok();
        }
        
        [HttpPost("filter/objects/by-title")]
        [SwaggerOperation(Tags = new []{"Filtering - by title"})]
        public async Task<IActionResult> FilterObjectsByTitle(FilteringByTitleRequest filteringByTitleRequest)
        {
            return Ok();
        }
        */
    }
}