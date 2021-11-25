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
    public class ObjectDataApiController : BaseApiController
    {
        private readonly IObjectRepository _dataObjectRepository;

        public ObjectDataApiController(IObjectRepository objectRepository)
        {
            _dataObjectRepository = objectRepository ?? throw new ArgumentNullException(nameof(objectRepository));
        }
        
        
        [HttpGet("data-objects/data")]
        [SwaggerOperation(Tags = new []{"Object data endpoint"})]
        public async Task<IActionResult> GetObjectData()
        {
            var objectData = await _dataObjectRepository.GetDataObjectsData();
            if (objectData == null)
                return NotFound(new ApiResponse<DataObjectDataDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No data objects have been found." },
                    Data = null
                });
            return Ok(new ApiResponse<DataObjectDataDto>()
            {
                Total = objectData.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objectData
            });
        }
        
        [HttpGet("data-objects/data/recent/{number:int}")]
        [SwaggerOperation(Tags = new []{"Object data endpoint"})]
        public async Task<IActionResult> GetRecentObjectData(int number)
        {
            var recentData = await _dataObjectRepository.GetRecentObjectData(number);
            if (recentData == null) return NotFound(new ApiResponse<DataObjectDataDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });
            
            return Ok(new ApiResponse<DataObjectDataDto>()
            {
                Total = recentData.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = recentData
            });
        }

        [HttpGet("data-objects/{sdOid}/data")]
        [SwaggerOperation(Tags = new []{"Object data endpoint"})]
        public async Task<IActionResult> GetObjectData(string sdOid)
        {
            var dataObject = await _dataObjectRepository.GetDataObjectData(sdOid);
            if (dataObject == null) return NotFound(new ApiResponse<DataObjectDataDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var objList = new List<DataObjectDataDto>() { dataObject };
            return Ok(new ApiResponse<DataObjectDataDto>()
            {
                Total = objList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objList
            });
        }

        [HttpPost("data-objects/data")]
        [SwaggerOperation(Tags = new []{"Object data endpoint"})]
        public async Task<IActionResult> CreateObjectData([FromBody] DataObjectDataDto dataObjectDataDto)
        {
            var dataObj = await _dataObjectRepository.CreateDataObjectData(dataObjectDataDto);
            if (dataObj == null)
                return BadRequest(new ApiResponse<DataObjectDataDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during data object creation." },
                    Data = null
                });

            var objList = new List<DataObjectDataDto>() { dataObj };
            return Ok(new ApiResponse<DataObjectDataDto>()
            {
                Total = objList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objList
            });
        }

        [HttpPut("data-objects/{sdOid}/data")]
        [SwaggerOperation(Tags = new []{"Object data endpoint"})]
        public async Task<IActionResult> UpdateObjectData(string sdOid, [FromBody] DataObjectDataDto dataObjectDataDto)
        {
            var dataObject = await _dataObjectRepository.GetDataObjectData(sdOid);
            if (dataObject == null) return NotFound(new ApiResponse<DataObjectDataDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data objects have been found." },
                Data = null
            });

            var updatedDataObject = await _dataObjectRepository.UpdateDataObjectData(dataObjectDataDto);
            if (updatedDataObject == null)
                return BadRequest(new ApiResponse<DataObjectDataDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>(){"Error during data object update."},
                    Data = null
                });

            var objList = new List<DataObjectDataDto>() { updatedDataObject };
            return Ok(new ApiResponse<DataObjectDataDto>()
            {
                Total = objList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objList
            });
        }
    }
}