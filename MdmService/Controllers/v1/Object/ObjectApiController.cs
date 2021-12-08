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
    public class ObjectApiController : BaseApiController
    {
        private readonly IObjectRepository _objectRepository;

        public ObjectApiController(IObjectRepository objectRepository)
        {
            _objectRepository = objectRepository ?? throw new ArgumentNullException(nameof(objectRepository));
        }
        
        [HttpGet("data-objects")]
        [SwaggerOperation(Tags = new []{"Data objects endpoint"})]
        public async Task<IActionResult> GetAllDataObjects()
        {
            var dataObjects = await _objectRepository.GetAllDataObjects();
            if (dataObjects == null)
                return Ok(new ApiResponse<DataObjectDto>()
                {
                    Total = 0,
                    StatusCode = NotFound().StatusCode,
                    Messages = new List<string>() { "No data objects have been found." },
                    Data = null
                });
            
            return Ok(new ApiResponse<DataObjectDto>()
            {
                Total = dataObjects.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dataObjects
            });
        }
        
        [HttpGet("data-objects/{sdOid}")]
        [SwaggerOperation(Tags = new []{"Data objects endpoint"})]
        public async Task<IActionResult> GetObjectById(string sdOid)
        {
            var dataObject = await _objectRepository.GetObjectById(sdOid);
            if (dataObject == null) return Ok(new ApiResponse<DataObjectDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object has been found." },
                Data = null
            });

            var objectList = new List<DataObjectDto>() { dataObject };
            return Ok(new ApiResponse<DataObjectDto>()
            {
                Total = objectList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = objectList
            });
        }

        [HttpPost("data-objects")]
        [SwaggerOperation(Tags = new []{"Data objects endpoint"})]
        public async Task<IActionResult> CreateDataObject([FromBody] DataObjectDto dataObjectDto)
        {
            var dataObj = await _objectRepository.CreateDataObject(dataObjectDto);
            if (dataObj == null)
                return Ok(new ApiResponse<DataObjectDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during data object creation." },
                    Data = null
                });

            var dataObjList = new List<DataObjectDto>() { dataObj };
            return Ok(new ApiResponse<DataObjectDto>()
            {
                Total = dataObjList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dataObjList
            });
        }
        
        [HttpPut("data-objects/{sdOid}")]
        [SwaggerOperation(Tags = new []{"Data objects endpoint"})]
        public async Task<IActionResult> UpdateDataObject(string sdOid, [FromBody] DataObjectDto dataObjectDto)
        {
            var dataObject = await _objectRepository.GetObjectById(sdOid);
            if (dataObject == null) return Ok(new ApiResponse<DataObjectDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object has been found." },
                Data = null
            });

            var updatedDataObj = await _objectRepository.UpdateDataObject(dataObjectDto);
            if (updatedDataObj == null)
                return Ok(new ApiResponse<DataObjectDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during data object update." },
                    Data = null
                });

            var dataObjList = new List<DataObjectDto>() { updatedDataObj };
            return Ok(new ApiResponse<DataObjectDto>()
            {
                Total = dataObjList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dataObjList
            });
        }

        [HttpDelete("data-objects/{sdOid}")]
        [SwaggerOperation(Tags = new []{"Data objects endpoint"})]
        public async Task<IActionResult> DeleteDataObject(string sdOid)
        {
            var dataObject = await _objectRepository.GetObjectById(sdOid);
            if (dataObject == null) return Ok(new ApiResponse<DataObjectDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>() { "No data object has been found." },
                Data = null
            });
            
            var count = await _objectRepository.DeleteDataObject(sdOid);
            return Ok(new ApiResponse<DataObjectDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>() { "Data object has been removed." },
                Data = null
            });
        }
    }
}