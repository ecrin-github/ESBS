using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RmsService.Contracts.Responses;
using RmsService.DTO;
using RmsService.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace RmsService.Controllers.v1.Dtp
{
    public class DtpDatasetsApiController : BaseApiController
    {
        private readonly IDtpRepository _dtpRepository;

        public DtpDatasetsApiController(IDtpRepository dtpRepository)
        {
            _dtpRepository = dtpRepository ?? throw new ArgumentNullException(nameof(dtpRepository));
        }
        
        
        [HttpGet("data-transfers/datasets")]
        [SwaggerOperation(Tags = new []{"Data transfer process datasets endpoint"})]
        public async Task<IActionResult> GetDtpDatasetList()
        {
            var dataset = await _dtpRepository.GetAllDtpDatasets();
            if (dataset == null) return Ok(new ApiResponse<DtpDatasetDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DTP datasets have been found."},
                Data = null
            });
            return Ok(new ApiResponse<DtpDatasetDto>()
            {
                Total = dataset.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = dataset
            });
        }

        [HttpGet("data-transfers/datasets/{id:int}")]
        [SwaggerOperation(Tags = new []{"Data transfer process datasets endpoint"})]
        public async Task<IActionResult> GetDtpDataset(int id)
        {
            var dtpDataset = await _dtpRepository.GetDtpDataset(id);
            if (dtpDataset == null) return Ok(new ApiResponse<DtpDatasetDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DTP datasets have been found."},
                Data = null
            });
            var datasetList = new List<DtpDatasetDto>() { dtpDataset };
            return Ok(new ApiResponse<DtpDatasetDto>()
            {
                Total = datasetList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = datasetList
            });
        }

        [HttpPost("data-transfers/datasets/{objectId}")]
        [SwaggerOperation(Tags = new []{"Data transfer process datasets endpoint"})]
        public async Task<IActionResult> CreateDta(string objectId, [FromBody] DtpDatasetDto dtpDatasetDto)
        {
            var dataset = await _dtpRepository.CreateDtpDataset(objectId, dtpDatasetDto);
            if (dataset == null)
                return Ok(new ApiResponse<DtpDatasetDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during DTP dataset creation." },
                    Data = null
                });
            var datasetList = new List<DtpDatasetDto>() { dataset };
            return Ok(new ApiResponse<DtpDatasetDto>()
            {
                Total = datasetList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = datasetList
            });
        }

        [HttpPut("data-transfers/datasets/{id:int}")]
        [SwaggerOperation(Tags = new []{"Data transfer process datasets endpoint"})]
        public async Task<IActionResult> UpdateDtpDataset(int id, [FromBody] DtpDatasetDto dtpDatasetDto)
        {
            var dtpDataset = await _dtpRepository.GetDtpDataset(id);
            if (dtpDataset == null) return Ok(new ApiResponse<DtpDatasetDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DTP datasets have been found."},
                Data = null
            });

            var updatedDataset = await _dtpRepository.UpdateDtpDataset(dtpDatasetDto);
            if (updatedDataset == null)
                return Ok(new ApiResponse<DtpDatasetDto>()
                {
                    Total = 0,
                    StatusCode = BadRequest().StatusCode,
                    Messages = new List<string>() { "Error during DTP dataset update." },
                    Data = null
                });
            var datasetList = new List<DtpDatasetDto>() { updatedDataset };
            return Ok(new ApiResponse<DtpDatasetDto>()
            {
                Total = datasetList.Count,
                StatusCode = Ok().StatusCode,
                Messages = null,
                Data = datasetList
            });
        }

        [HttpDelete("data-transfers/datasets/{id:int}")]
        [SwaggerOperation(Tags = new []{"Data transfer process datasets endpoint"})]
        public async Task<IActionResult> DeleteDtpDataset(int id)
        {
            var dtpDataset = await _dtpRepository.GetDtpDataset(id);
            if (dtpDataset == null) return Ok(new ApiResponse<DtpDatasetDto>()
            {
                Total = 0,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"No DTP datasets have been found."},
                Data = null
            });
            
            var count = await _dtpRepository.DeleteDtpDataset(id);
            return Ok(new ApiResponse<DtpDatasetDto>()
            {
                Total = count,
                StatusCode = Ok().StatusCode,
                Messages = new List<string>(){"DTP dataset has been removed."},
                Data = null
            });
        }
        
    }
}