using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MdmService.Contracts.Responses;
using MdmService.DTO.Object;
using MdmService.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authentication;

namespace MdmService.Controllers.v1.Object
{
    public class ObjectDatasetsApiController : BaseApiController
    {
        
        private readonly IObjectRepository _dataObjectRepository;

        public ObjectDatasetsApiController(IObjectRepository objectRepository)
        {
            _dataObjectRepository = objectRepository ?? throw new ArgumentNullException(nameof(objectRepository));
        }
        
        
        [HttpGet("data-objects/{sdOid}/datasets")]
        [SwaggerOperation(Tags = new []{"Object datasets endpoint"})]
        public async Task<IActionResult> GetObjectDatasets(string sdOid)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectDatasetDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objDatasets = await _dataObjectRepository.GetObjectDatasets(sdOid);
            if (objDatasets == null)
                return Ok(new ApiResponse<ObjectDatasetDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No data object datasets have been found." },
                    Data = null
                });
            
            return Ok(new ApiResponse<ObjectDatasetDto>()
            {
                Total = 1,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = new List<ObjectDatasetDto>(){objDatasets}
            });
        }
        
        
        [HttpGet("data-objects/{sdOid}/datasets/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object datasets endpoint"})]
        public async Task<IActionResult> GetObjectDatasets(string sdOid, int id)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectDatasetDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objDataset = await _dataObjectRepository.GetObjectDataset(id);
            if (objDataset == null) return Ok(new ApiResponse<ObjectDatasetDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects datasets have been found." },
                Data = null
            });

            var objDatasetList = new List<ObjectDatasetDto>() { objDataset };
            return Ok(new ApiResponse<ObjectDatasetDto>()
            {
                Total = objDatasetList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objDatasetList
            });
        }
        

        [HttpPost("data-objects/{sdOid}/datasets")]
        [SwaggerOperation(Tags = new []{"Object datasets endpoint"})]
        public async Task<IActionResult> CreateObjectDataset(string sdOid,
            [FromBody] ObjectDatasetDto objectDatasetDto)
        {
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectDatasetDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var accessTokenRes = await HttpContext.GetTokenAsync("access_token");
            var accessToken = accessTokenRes?.ToString();
            
            objectDatasetDto.SdOid ??= sdOid;
            var objDataset = await _dataObjectRepository.CreateObjectDataset(objectDatasetDto, accessToken);
            if (objDataset == null)
                return Ok(new ApiResponse<ObjectDatasetDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during dataset creation." },
                    Data = null
                });

            var objDatasetList = new List<ObjectDatasetDto>() { objDataset };
            return Ok(new ApiResponse<ObjectDatasetDto>()
            {
                Total = objDatasetList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objDatasetList
            });
        }

        [HttpPut("data-objects/{sdOid}/datasets/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object datasets endpoint"})]
        public async Task<IActionResult> UpdateObjectDataset(string sdOid, int id, [FromBody] ObjectDatasetDto objectDatasetDto)
        {
            objectDatasetDto.Id ??= id;
            objectDatasetDto.SdOid ??= sdOid;
            
            var dataObj = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObj == null) return Ok(new ApiResponse<ObjectDatasetDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objDataset = await _dataObjectRepository.GetObjectDataset(id);
            if (objDataset == null) return Ok(new ApiResponse<ObjectDatasetDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object datasets have been found." },
                Data = null
            });

            var accessTokenRes = await HttpContext.GetTokenAsync("access_token");
            var accessToken = accessTokenRes?.ToString();

            var updatedObjDataset = await _dataObjectRepository.UpdateObjectDataset(objectDatasetDto, accessToken);
            if (updatedObjDataset == null)
                return Ok(new ApiResponse<ObjectDatasetDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during dataset update." },
                    Data = null
                });

            var datasetList = new List<ObjectDatasetDto>() { updatedObjDataset };
            return Ok(new ApiResponse<ObjectDatasetDto>()
            {
                Total = datasetList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = datasetList
            });
        }
        
        [HttpDelete("data-objects/{sdOid}/datasets/{id:int}")]
        [SwaggerOperation(Tags = new []{"Object datasets endpoint"})]
        public async Task<IActionResult> DeleteObjectDataset(string sdOid, int id)
        {
            var dataObject = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObject == null) return Ok(new ApiResponse<ObjectDatasetDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objectDataset = await _dataObjectRepository.GetObjectDataset(id);
            if (objectDataset == null) return Ok(new ApiResponse<ObjectDatasetDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object datasets have been found." },
                Data = null
            });
            
            var count = await _dataObjectRepository.DeleteObjectDataset(id);
            return Ok(new ApiResponse<ObjectDatasetDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "Object dataset has been removed." },
                Data = null
            });
        }

        [HttpDelete("data-objects/{sdOid}/datasets")]
        [SwaggerOperation(Tags = new []{"Object datasets endpoint"})]
        public async Task<IActionResult> DeleteAllObjectDatasets(string sdOid)
        {
            var dataObject = await _dataObjectRepository.GetObjectById(sdOid);
            if (dataObject == null) return Ok(new ApiResponse<ObjectDatasetDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });
            
            var count = await _dataObjectRepository.DeleteAllObjectDatasets(sdOid);
            return Ok(new ApiResponse<ObjectDatasetDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "All object datasets have been removed." },
                Data = null
            });
        }
        
    }
}