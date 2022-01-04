using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContextService.Contracts.Requests.v1.OrganisationRequests;
using ContextService.Contracts.Responses;
using ContextService.Interfaces;
using ContextService.Models.Ctx;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ContextService.Controllers.v1
{
    public class CtxApiController : BaseApiController
    {
        private readonly ICtxRepository _ctxRepository;

        public CtxApiController(ICtxRepository ctxRepository)
        {
            _ctxRepository = ctxRepository ?? throw new ArgumentNullException(nameof(ctxRepository));
        }
        
        
        [HttpGet("organisations")]
        [SwaggerOperation(Tags = new[] { "Context - Organisations" })]
        public async Task<IActionResult> GetOrganisations()
        {
            var data = await _ctxRepository.GetOrganisations();
            if (data == null) return Ok(new ApiResponse<Organisation>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<Organisation>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("organisations/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Organisations" })]
        public async Task<IActionResult> GetOrganisation(int id)
        {
            var data = await _ctxRepository.GetOrganisation(id);
            if (data == null) return Ok(new ApiResponse<Organisation>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<Organisation>()
            {
                Total = 1,
                Data = new List<Organisation>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }

        [HttpPost("organisations/search/by-title")]
        [SwaggerOperation(Tags = new[] { "Context - Organisations" })]
        public async Task<IActionResult> GetOrganisationsByName(SearchByTitleRequest searchByTitleRequest)
        {
            var data = await _ctxRepository.GetOrganisationsByName(searchByTitleRequest.OrganisationName);
            if (data == null) return Ok(new ApiResponse<Organisation>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<Organisation>()
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("organisations/{id:int}/attributes")]
        [SwaggerOperation(Tags = new[] { "Context - Organisation" })]
        public async Task<IActionResult> GetOrgAttributes(int id)
        {
            var data = await _ctxRepository.GetOrgAttributes(id);
            if (data == null) return Ok(new ApiResponse<OrgAttribute>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<OrgAttribute>()
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("organisations/{id:int}/links")]
        [SwaggerOperation(Tags = new[] { "Context - Organisations" })]
        public async Task<IActionResult> GetOrgLinks(int id)
        {
            var data = await _ctxRepository.GetOrgLinks(id);
            if (data == null) return Ok(new ApiResponse<OrgLink>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<OrgLink>()
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("organisations/{id:int}/locations")]
        [SwaggerOperation(Tags = new[] { "Context - Organisations" })]
        public async Task<IActionResult> GetOrgLocations(int id)
        {
            var data = await _ctxRepository.GetOrgLocations(id);
            if (data == null) return Ok(new ApiResponse<OrgLocation>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<OrgLocation>()
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("organisations/{id:int}/names")]
        [SwaggerOperation(Tags = new[] { "Context - Organisations" })]
        public async Task<IActionResult> GetOrgNames(int id)
        {
            var data = await _ctxRepository.GetOrgNames(id);
            if (data == null) return Ok(new ApiResponse<OrgName>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<OrgName>()
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("organisations/{id:int}/relationships")]
        [SwaggerOperation(Tags = new[] { "Context - Organisations" })]
        public async Task<IActionResult> GetOrgRelationships(int id)
        {
            var data = await _ctxRepository.GetOrgRelationships(id);
            if (data == null) return Ok(new ApiResponse<OrgRelationship>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<OrgRelationship>()
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }


        [HttpGet("organisations/{id:int}/memberships")]
        [SwaggerOperation(Tags = new[] { "Context - Organisations" })]
        public async Task<IActionResult> GetOrgMemberships(int id)
        {
            var data = await _ctxRepository.GetOrgTypeMemberships(id);
            if (data == null) return Ok(new ApiResponse<OrgTypeMembership>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<OrgTypeMembership>()
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        
        [HttpGet("people")]
        [SwaggerOperation(Tags = new[] { "Context - People" })]
        public async Task<IActionResult> GetPeople()
        {
            var data = await _ctxRepository.GetPeople();
            if (data == null) return Ok(new ApiResponse<People>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<People>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("people/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - People" })]
        public async Task<IActionResult> GetPerson(int id)
        {
            var data = await _ctxRepository.GetPerson(id);
            if (data == null) return Ok(new ApiResponse<People>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<People>()
            {
                Total = 1,
                Data = new List<People>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("people/{id:int}/links")]
        [SwaggerOperation(Tags = new[] { "Context - People" })]
        public async Task<IActionResult> GetPersonLinks(int id)
        {
            var data = await _ctxRepository.GetPersonLinks(id);
            if (data == null) return Ok(new ApiResponse<PeopleLink>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<PeopleLink>()
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("people/{id:int}/roles")]
        [SwaggerOperation(Tags = new[] { "Context - People" })]
        public async Task<IActionResult> GetPersonRoles(int id)
        {
            var data = await _ctxRepository.GetPersonRoles(id);
            if (data == null) return Ok(new ApiResponse<PeopleRole>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<PeopleRole>()
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        
        [HttpGet("geographical-entities")]
        [SwaggerOperation(Tags = new[] { "Context - Geographical entities" })]
        public async Task<IActionResult> GetGeogEntities()
        {
            var data = await _ctxRepository.GetGeogEntities();
            if (data == null) return Ok(new ApiResponse<GeogEntity>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<GeogEntity>()
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }


        [HttpGet("geographical-entities/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Geographical entities" })]
        public async Task<IActionResult> GetGeogEntity(int id)
        {
            var data = await _ctxRepository.GetGeogEntity(id);
            if (data == null) return Ok(new ApiResponse<GeogEntity>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<GeogEntity>()
            {
                Total = 1,
                Data = new List<GeogEntity>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }


        [HttpGet("published-journals")]
        [SwaggerOperation(Tags = new[] { "Context - Published journals" })]
        public async Task<IActionResult> GetPublishedJournals()
        {
            var data = await _ctxRepository.GetPublishedJournals();
            if (data == null) return Ok(new ApiResponse<PublishedJournal>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<PublishedJournal>()
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }


        [HttpGet("published-journals/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Published journals" })]
        public async Task<IActionResult> GetPublishedJournal(int id)
        {
            var data = await _ctxRepository.GetPublishedJournal(id);
            if (data == null) return Ok(new ApiResponse<PublishedJournal>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<PublishedJournal>()
            {
                Total = 1,
                Data = new List<PublishedJournal>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
    }
}