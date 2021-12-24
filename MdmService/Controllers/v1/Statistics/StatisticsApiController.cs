using System;
using System.Threading.Tasks;
using MdmService.Contracts.Responses;
using MdmService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MdmService.Controllers.v1.Statistics
{
    public class StatisticsApiController : BaseApiController
    {
        private readonly IObjectRepository _objectRepository;
        private readonly IStudyRepository _studyRepository;

        public StatisticsApiController(
            IObjectRepository objectRepository,
            IStudyRepository studyRepository)
        {
            _objectRepository = objectRepository ?? throw new ArgumentNullException(nameof(objectRepository));
            _studyRepository = studyRepository ?? throw new ArgumentNullException(nameof(studyRepository));
        }

        [HttpGet("statistics/studies/total")]
        [SwaggerOperation(Tags = new []{"Statistics"})]
        public async Task<IActionResult> GetTotalStudies()
        {
            return Ok(new StatisticsResponse()
            {
                Total = await _studyRepository.GetTotalStudies()
            });    
        }

        [HttpGet("statistics/data-objects/total")]
        [SwaggerOperation(Tags = new []{"Statistics"})]
        public async Task<IActionResult> GetTotalDataObjects()
        {
            return Ok(new StatisticsResponse()
            {
                Total = await _objectRepository.GetTotalDataObjects()
            });    
        }
    }
}