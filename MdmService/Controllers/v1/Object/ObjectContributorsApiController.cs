using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MdmService.Contracts.Responses;
using MdmService.DTO.Object;
using MdmService.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace MdmService.Controllers.v1.Object
{
    public class ObjectContributorsApiController : BaseApiController
    {
        
        private readonly IObjectRepository _dataObjectRepository;

        public ObjectContributorsApiController(IObjectRepository objectRepository)
        {
            _dataObjectRepository = objectRepository ?? throw new ArgumentNullException(nameof(objectRepository));
        }


        [HttpGet("data-objects/{sdOid}/contributors")]
        [SwaggerOperation(Tags = new []{"Object contributors endpoint"})]
        public async Task<IActionResult> GetObjectContributors(string sdOid)
        {
            var dataObject = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObject == null) return Ok(new ApiResponse<ObjectContributorDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object has been found." },
                Data = null
            });

            var objectContributors = await _dataObjectRepository.GetObjectContributors(sdOid);
            if (objectContributors == null) return Ok(new ApiResponse<ObjectContributorDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object contributors have been found." },
                Data = null
            });
            
            return Ok(new ApiResponse<ObjectContributorDto>()
            {
                Total = objectContributors.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objectContributors
            });
        }
        
        [HttpGet("data-objects/{sdOid}/contributors/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object contributors endpoint"})]
        public async Task<IActionResult> GetObjectContributor(string sdOid, int id)
        {
            var dataObject = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObject == null) return Ok(new ApiResponse<ObjectContributorDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object has been found." },
                Data = null
            });

            var objContrib = await _dataObjectRepository.GetObjectContributor(id);
            if (objContrib == null) return Ok(new ApiResponse<ObjectContributorDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object contributor has been found." },
                Data = null
            });

            var objContribList = new List<ObjectContributorDto>() { objContrib };
            return Ok(new ApiResponse<ObjectContributorDto>()
            {
                Total = objContribList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objContribList
            });
        }

        [HttpPost("data-objects/{sdOid}/contributors")]
        [SwaggerOperation(Tags = new []{"Object contributors endpoint"})]
        public async Task<IActionResult> CreateObjectContributor(string sdOid,
            [FromBody] ObjectContributorDto objectContributorDto)
        {
            var dataObject = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObject == null) return Ok(new ApiResponse<ObjectContributorDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object has been found." },
                Data = null
            });

            var objContrib = await _dataObjectRepository.CreateObjectContributor(sdOid, objectContributorDto);
            if (objContrib == null)
                return Ok(new ApiResponse<ObjectContributorDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during data object contributor creation." },
                    Data = null
                });

            var objContribList = new List<ObjectContributorDto>() { objContrib };
            return Ok(new ApiResponse<ObjectContributorDto>()
            {
                Total = objContribList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objContribList
            });
        }

        [HttpPut("data-objects/{sdOid}/contributors/{id}")]
        [SwaggerOperation(Tags = new []{"Object contributors endpoint"})]
        public async Task<IActionResult> UpdateObjectContributor(string sdOid, int id, [FromBody] ObjectContributorDto objectContributorDto)
        {
            var dataObject = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObject == null) return Ok(new ApiResponse<ObjectContributorDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object has been found." },
                Data = null
            });

            var objectContrib = await _dataObjectRepository.GetObjectContributor(id);
            if (objectContrib == null) return Ok(new ApiResponse<ObjectContributorDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object contributor has been found." },
                Data = null
            });

            var updatedObjContrib = await _dataObjectRepository.UpdateObjectContributor(objectContributorDto);
            if (updatedObjContrib == null)
                return Ok(new ApiResponse<ObjectContributorDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>(){"Error during data object contributor update."},
                    Data = null
                });

            var objContribList = new List<ObjectContributorDto>() { updatedObjContrib };
            return Ok(new ApiResponse<ObjectContributorDto>()
            {
                Total = objContribList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objContribList
            });
        }
        
        [HttpDelete("data-objects/{sdOid}/contributors/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object contributors endpoint"})]
        public async Task<IActionResult> DeleteObjectContributor(string sdOid, int id)
        {
            var dataObject = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObject == null) return Ok(new ApiResponse<ObjectContributorDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object has been found." },
                Data = null
            });

            var objectContrib = await _dataObjectRepository.GetObjectContributor(id);
            if (objectContrib == null) return Ok(new ApiResponse<ObjectContributorDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object contributors have been found." },
                Data = null
            });
            
            var count = await _dataObjectRepository.DeleteObjectContributor(id);
            return Ok(new ApiResponse<ObjectContributorDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "Object contributor has been removed." },
                Data = null
            });
        }

        [HttpDelete("data-objects/{sdOid}/contributors")]
        [SwaggerOperation(Tags = new []{"Object contributors endpoint"})]
        public async Task<IActionResult> DeleteAllObjectContributors(string sdOid)
        {
            var dataObject = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObject == null) return Ok(new ApiResponse<ObjectContributorDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object has been found." },
                Data = null
            });
            
            var count = await _dataObjectRepository.DeleteAllObjectContributors(sdOid);
            return Ok(new ApiResponse<ObjectContributorDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "All object contributors have been removed." },
                Data = null
            });
        }
    }
}