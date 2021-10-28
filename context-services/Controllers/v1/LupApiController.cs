using System.Collections.Generic;
using System.Threading.Tasks;
using context_services.Contracts.Responses;
using context_services.Interfaces;
using context_services.Models.Lup;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace context_services.Controllers.v1
{
    public class LupApiController : BaseApiController
    {
        private readonly ILupRepository _lupRepository;

        public LupApiController(ILupRepository lupRepository)
        {
            _lupRepository = lupRepository;
        }
        
        [HttpGet("contribution-types")]
        [SwaggerOperation(Tags = new[] { "Context - Contribution types" })]
        public async Task<IActionResult> GetContributionTypes()
        {
            var data = await _lupRepository.GetContributionTypes();
            if (data == null) return NotFound(new ApiResponse<ContributionType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<ContributionType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("contribution-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Contribution types" })]
        public async Task<IActionResult> GetContributionType(int id)
        {
            var data = await _lupRepository.GetContributionType(id);
            if (data == null) return NotFound(new ApiResponse<ContributionType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<ContributionType>()
            {
                Total = 1,
                Data = new List<ContributionType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("dataset-consent-types")]
        [SwaggerOperation(Tags = new[] { "Context - Dataset consent types" })]
        public async Task<IActionResult> GetDatasetConsentTypes()
        {
            var data = await _lupRepository.GetDatasetConsentTypes();
            if (data == null) return NotFound(new ApiResponse<DatasetConsentType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<DatasetConsentType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("dataset-consent-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Dataset consent types" })]
        public async Task<IActionResult> GetDatasetConsentType(int id)
        {
            var data = await _lupRepository.GetDatasetConsentType(id);
            if (data == null) return NotFound(new ApiResponse<DatasetConsentType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<DatasetConsentType>()
            {
                Total = 1,
                Data = new List<DatasetConsentType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("dataset-deidentification-types")]
        [SwaggerOperation(Tags = new[] { "Context - Dataset deidentification types" })]
        public async Task<IActionResult> GetDatasetDeidentTypes()
        {
            var data = await _lupRepository.GetDatasetDeidentLevels();
            if (data == null) return NotFound(new ApiResponse<DatasetDeidentificationLevel>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<DatasetDeidentificationLevel>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("dataset-deidentification-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Dataset deidentification types" })]
        public async Task<IActionResult> GetDatasetDeidentType(int id)
        {
            var data = await _lupRepository.GetDatasetDeidentLevel(id);
            if (data == null) return NotFound(new ApiResponse<DatasetDeidentificationLevel>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<DatasetDeidentificationLevel>()
            {
                Total = 1,
                Data = new List<DatasetDeidentificationLevel>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("dataset-recordkey-types")]
        [SwaggerOperation(Tags = new[] { "Context - Dataset recordkey types" })]
        public async Task<IActionResult> GetDatasetRecordkeyTypes()
        {
            var data = await _lupRepository.GetDatasetRecordkeyTypes();
            if (data == null) return NotFound(new ApiResponse<DatasetRecordkeyType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<DatasetRecordkeyType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("dataset-recordkey-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Dataset recordkey types" })]
        public async Task<IActionResult> GetDatasetRecordkeyType(int id)
        {
            var data = await _lupRepository.GetDatasetRecordkeyType(id);
            if (data == null) return NotFound(new ApiResponse<DatasetRecordkeyType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<DatasetRecordkeyType>()
            {
                Total = 1,
                Data = new List<DatasetRecordkeyType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("date-types")]
        [SwaggerOperation(Tags = new[] { "Context - Date types" })]
        public async Task<IActionResult> GetDateTypes()
        {
            var data = await _lupRepository.GetDateTypes();
            if (data == null) return NotFound(new ApiResponse<DateType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<DateType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("date-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Date types" })]
        public async Task<IActionResult> GetDateType(int id)
        {
            var data = await _lupRepository.GetDateType(id);
            if (data == null) return NotFound(new ApiResponse<DateType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<DateType>()
            {
                Total = 1,
                Data = new List<DateType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("description-types")]
        [SwaggerOperation(Tags = new[] { "Context - Description types" })]
        public async Task<IActionResult> GetDescriptionTypes()
        {
            var data = await _lupRepository.GetDescriptionTypes();
            if (data == null) return NotFound(new ApiResponse<DescriptionType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<DescriptionType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("description-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Description types" })]
        public async Task<IActionResult> GetDescriptionType(int id)
        {
            var data = await _lupRepository.GetDescriptionType(id);
            if (data == null) return NotFound(new ApiResponse<DescriptionType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<DescriptionType>()
            {
                Total = 1,
                Data = new List<DescriptionType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("doi-status-types")]
        [SwaggerOperation(Tags = new[] { "Context - DOI status types" })]
        public async Task<IActionResult> GetDoiStatusTypes()
        {
            var data = await _lupRepository.GetDoiStatusTypes();
            if (data == null) return NotFound(new ApiResponse<DoiStatusType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<DoiStatusType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("doi-status-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - DOI status types" })]
        public async Task<IActionResult> GetDoiStatusType(int id)
        {
            var data = await _lupRepository.GetDoiStatusType(id);
            if (data == null) return NotFound(new ApiResponse<DoiStatusType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<DoiStatusType>()
            {
                Total = 1,
                Data = new List<DoiStatusType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("gender-eligibility-types")]
        [SwaggerOperation(Tags = new[] { "Context - Gender eligibility types" })]
        public async Task<IActionResult> GetGenderEligTypes()
        {
            var data = await _lupRepository.GetGenderEligTypes();
            if (data == null) return NotFound(new ApiResponse<GenderEligibilityType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<GenderEligibilityType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("gender-eligibility-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Gender eligibility types" })]
        public async Task<IActionResult> GetGenderEligType(int id)
        {
            var data = await _lupRepository.GetGenderEligType(id);
            if (data == null) return NotFound(new ApiResponse<GenderEligibilityType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<GenderEligibilityType>()
            {
                Total = 1,
                Data = new List<GenderEligibilityType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("geog-entity-types")]
        [SwaggerOperation(Tags = new[] { "Context - Geographical entity types" })]
        public async Task<IActionResult> GetGeogEntityTypes()
        {
            var data = await _lupRepository.GetGeogEntityTypes();
            if (data == null) return NotFound(new ApiResponse<GeogEntityType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<GeogEntityType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("geog-entity-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Geographical entity types" })]
        public async Task<IActionResult> GetGeogEntityType(int id)
        {
            var data = await _lupRepository.GetGeogEntityType(id);
            if (data == null) return NotFound(new ApiResponse<GeogEntityType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<GeogEntityType>()
            {
                Total = 1,
                Data = new List<GeogEntityType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("identifier-types")]
        [SwaggerOperation(Tags = new[] { "Context - Identifier types" })]
        public async Task<IActionResult> GetIdentifierTypes()
        {
            var data = await _lupRepository.GetIdentifierTypes();
            if (data == null) return NotFound(new ApiResponse<IdentifierType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<IdentifierType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("identifier-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Identifier types" })]
        public async Task<IActionResult> GetIdentifierType(int id)
        {
            var data = await _lupRepository.GetIdentifierType(id);
            if (data == null) return NotFound(new ApiResponse<IdentifierType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<IdentifierType>()
            {
                Total = 1,
                Data = new List<IdentifierType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("language-usage-types")]
        [SwaggerOperation(Tags = new[] { "Context - Language usage types" })]
        public async Task<IActionResult> GetLangUsageTypes()
        {
            var data = await _lupRepository.GetLangUsageTypes();
            if (data == null) return NotFound(new ApiResponse<LanguageUsageType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<LanguageUsageType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("language-usage-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Language usage types" })]
        public async Task<IActionResult> GetLangUsageType(int id)
        {
            var data = await _lupRepository.GetLangUsageType(id);
            if (data == null) return NotFound(new ApiResponse<LanguageUsageType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<LanguageUsageType>()
            {
                Total = 1,
                Data = new List<LanguageUsageType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("link-types")]
        [SwaggerOperation(Tags = new[] { "Context - Link types" })]
        public async Task<IActionResult> GeLinkTypes()
        {
            var data = await _lupRepository.GetLinkTypes();
            if (data == null) return NotFound(new ApiResponse<LinkType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<LinkType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("link-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Link types" })]
        public async Task<IActionResult> GetLinkType(int id)
        {
            var data = await _lupRepository.GetLinkType(id);
            if (data == null) return NotFound(new ApiResponse<LinkType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<LinkType>()
            {
                Total = 1,
                Data = new List<LinkType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("object-access-types")]
        [SwaggerOperation(Tags = new[] { "Context - Object access types" })]
        public async Task<IActionResult> GetObjectAccessTypes()
        {
            var data = await _lupRepository.GetObjectAccessTypes();
            if (data == null) return NotFound(new ApiResponse<ObjectAccessType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<ObjectAccessType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("object-access-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Object access types" })]
        public async Task<IActionResult> GetObjectAccessType(int id)
        {
            var data = await _lupRepository.GetObjectAccessType(id);
            if (data == null) return NotFound(new ApiResponse<ObjectAccessType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<ObjectAccessType>()
            {
                Total = 1,
                Data = new List<ObjectAccessType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("object-classes")]
        [SwaggerOperation(Tags = new[] { "Context - Object classes" })]
        public async Task<IActionResult> GetObjectClasses()
        {
            var data = await _lupRepository.GetObjectClasses();
            if (data == null) return NotFound(new ApiResponse<ObjectClass>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<ObjectClass>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("object-classes/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Object classes" })]
        public async Task<IActionResult> GetObjectClass(int id)
        {
            var data = await _lupRepository.GetObjectClass(id);
            if (data == null) return NotFound(new ApiResponse<ObjectClass>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<ObjectClass>()
            {
                Total = 1,
                Data = new List<ObjectClass>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("object-filter-types")]
        [SwaggerOperation(Tags = new[] { "Context - Object filter types" })]
        public async Task<IActionResult> GetObjectFilterTypes()
        {
            var data = await _lupRepository.GetObjectFilterTypes();
            if (data == null) return NotFound(new ApiResponse<ObjectFilterType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<ObjectFilterType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("object-filter-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Object filter types" })]
        public async Task<IActionResult> GetObjectFilterType(int id)
        {
            var data = await _lupRepository.GetObjectFilterType(id);
            if (data == null) return NotFound(new ApiResponse<ObjectFilterType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<ObjectFilterType>()
            {
                Total = 1,
                Data = new List<ObjectFilterType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("object-instance-types")]
        [SwaggerOperation(Tags = new[] { "Context - Object instance types" })]
        public async Task<IActionResult> GetObjectInstanceTypes()
        {
            var data = await _lupRepository.GetObjectInstanceTypes();
            if (data == null) return NotFound(new ApiResponse<ObjectInstanceType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<ObjectInstanceType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("object-instance-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Object instance types" })]
        public async Task<IActionResult> GetObjectInstanceType(int id)
        {
            var data = await _lupRepository.GetObjectInstanceType(id);
            if (data == null) return NotFound(new ApiResponse<ObjectInstanceType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<ObjectInstanceType>()
            {
                Total = 1,
                Data = new List<ObjectInstanceType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("object-relationship-types")]
        [SwaggerOperation(Tags = new[] { "Context - Object relationship types" })]
        public async Task<IActionResult> GetObjectRelationTypes()
        {
            var data = await _lupRepository.GetObjectRelationshipTypes();
            if (data == null) return NotFound(new ApiResponse<ObjectRelationshipType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<ObjectRelationshipType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("object-relationship-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Object relationship types" })]
        public async Task<IActionResult> GetObjectRelationType(int id)
        {
            var data = await _lupRepository.GetObjectRelationshipType(id);
            if (data == null) return NotFound(new ApiResponse<ObjectRelationshipType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<ObjectRelationshipType>()
            {
                Total = 1,
                Data = new List<ObjectRelationshipType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("object-types")]
        [SwaggerOperation(Tags = new[] { "Context - Object types" })]
        public async Task<IActionResult> GetObjectTypes()
        {
            var data = await _lupRepository.GetObjectTypes();
            if (data == null) return NotFound(new ApiResponse<ObjectType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<ObjectType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("object-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Object types" })]
        public async Task<IActionResult> GetObjectType(int id)
        {
            var data = await _lupRepository.GetObjectType(id);
            if (data == null) return NotFound(new ApiResponse<ObjectType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<ObjectType>()
            {
                Total = 1,
                Data = new List<ObjectType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("resource-types")]
        [SwaggerOperation(Tags = new[] { "Context - Resource types" })]
        public async Task<IActionResult> GetResourceTypes()
        {
            var data = await _lupRepository.GetResourceTypes();
            if (data == null) return NotFound(new ApiResponse<ResourceType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<ResourceType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("resource-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Resource types" })]
        public async Task<IActionResult> GetResourceType(int id)
        {
            var data = await _lupRepository.GetResourceType(id);
            if (data == null) return NotFound(new ApiResponse<ResourceType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<ResourceType>()
            {
                Total = 1,
                Data = new List<ResourceType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("rms-user-types")]
        [SwaggerOperation(Tags = new[] { "Context - RMS user types" })]
        public async Task<IActionResult> GetRmsUserTypes()
        {
            var data = await _lupRepository.GetRmsUserTypes();
            if (data == null) return NotFound(new ApiResponse<RmsUserType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<RmsUserType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("rms-user-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - RMS user types" })]
        public async Task<IActionResult> GetRmsUserType(int id)
        {
            var data = await _lupRepository.GetRmsUserType(id);
            if (data == null) return NotFound(new ApiResponse<RmsUserType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<RmsUserType>()
            {
                Total = 1,
                Data = new List<RmsUserType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("role-types")]
        [SwaggerOperation(Tags = new[] { "Context - Role types" })]
        public async Task<IActionResult> GetRoleTypes()
        {
            var data = await _lupRepository.GetRoleTypes();
            if (data == null) return NotFound(new ApiResponse<RoleType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<RoleType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("role-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Role types" })]
        public async Task<IActionResult> GetRoleType(int id)
        {
            var data = await _lupRepository.GetRoleType(id);
            if (data == null) return NotFound(new ApiResponse<RoleType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<RoleType>()
            {
                Total = 1,
                Data = new List<RoleType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("size-units")]
        [SwaggerOperation(Tags = new[] { "Context - Size units" })]
        public async Task<IActionResult> GetSizeUnits()
        {
            var data = await _lupRepository.GetSizeUnits();
            if (data == null) return NotFound(new ApiResponse<SizeUnit>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<SizeUnit>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("size-units/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Size units" })]
        public async Task<IActionResult> GetSizeUnit(int id)
        {
            var data = await _lupRepository.GetSizeUnit(id);
            if (data == null) return NotFound(new ApiResponse<SizeUnit>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<SizeUnit>()
            {
                Total = 1,
                Data = new List<SizeUnit>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("study-feature-categories")]
        [SwaggerOperation(Tags = new[] { "Context - Study feature categories" })]
        public async Task<IActionResult> GetStudyFeatureCategories()
        {
            var data = await _lupRepository.GetStudyFeatureCategories();
            if (data == null) return NotFound(new ApiResponse<StudyFeatureCategory>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<StudyFeatureCategory>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("study-feature-categories/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Study feature categories" })]
        public async Task<IActionResult> GetStudyFeatureCategory(int id)
        {
            var data = await _lupRepository.GetStudyFeatureCategory(id);
            if (data == null) return NotFound(new ApiResponse<StudyFeatureCategory>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<StudyFeatureCategory>()
            {
                Total = 1,
                Data = new List<StudyFeatureCategory>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("study-feature-types")]
        [SwaggerOperation(Tags = new[] { "Context - Study feature types" })]
        public async Task<IActionResult> GetStudyFeatureTypes()
        {
            var data = await _lupRepository.GetStudyFeatureTypes();
            if (data == null) return NotFound(new ApiResponse<StudyFeatureType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<StudyFeatureType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("study-feature-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Study feature types" })]
        public async Task<IActionResult> GetStudyFeatureType(int id)
        {
            var data = await _lupRepository.GetStudyFeatureType(id);
            if (data == null) return NotFound(new ApiResponse<StudyFeatureType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<StudyFeatureType>()
            {
                Total = 1,
                Data = new List<StudyFeatureType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("study-relationship-types")]
        [SwaggerOperation(Tags = new[] { "Context - Study relationship types" })]
        public async Task<IActionResult> GetStudyRelationTypes()
        {
            var data = await _lupRepository.GetStudyRelationshipTypes();
            if (data == null) return NotFound(new ApiResponse<StudyRelationshipType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<StudyRelationshipType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("study-relationship-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Study relationship types" })]
        public async Task<IActionResult> GetStudyRelationType(int id)
        {
            var data = await _lupRepository.GetStudyRelationshipType(id);
            if (data == null) return NotFound(new ApiResponse<StudyRelationshipType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<StudyRelationshipType>()
            {
                Total = 1,
                Data = new List<StudyRelationshipType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("study-statuses")]
        [SwaggerOperation(Tags = new[] { "Context - Study statuses" })]
        public async Task<IActionResult> GetStudyStatuses()
        {
            var data = await _lupRepository.GetStudyStatuses();
            if (data == null) return NotFound(new ApiResponse<StudyStatus>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<StudyStatus>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("study-statuses/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Study statuses" })]
        public async Task<IActionResult> GetStudyStatus(int id)
        {
            var data = await _lupRepository.GetStudyStatus(id);
            if (data == null) return NotFound(new ApiResponse<StudyStatus>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<StudyStatus>()
            {
                Total = 1,
                Data = new List<StudyStatus>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }

        [HttpGet("study-types")]
        [SwaggerOperation(Tags = new[] { "Context - Study types" })]
        public async Task<IActionResult> GetStudyTypes()
        {
            var data = await _lupRepository.GetStudyTypes();
            if (data == null) return NotFound(new ApiResponse<StudyType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<StudyType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("study-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Study types" })]
        public async Task<IActionResult> GetStudyType(int id)
        {
            var data = await _lupRepository.GetStudyType(id);
            if (data == null) return NotFound(new ApiResponse<StudyType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<StudyType>()
            {
                Total = 1,
                Data = new List<StudyType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("time-units")]
        [SwaggerOperation(Tags = new[] { "Context - Time units" })]
        public async Task<IActionResult> GetTimeUnits()
        {
            var data = await _lupRepository.GetTimeUnits();
            if (data == null) return NotFound(new ApiResponse<TimeUnit>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<TimeUnit>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("time-units/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Time units" })]
        public async Task<IActionResult> GetTimeUnit(int id)
        {
            var data = await _lupRepository.GetTimeUnit(id);
            if (data == null) return NotFound(new ApiResponse<TimeUnit>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<TimeUnit>()
            {
                Total = 1,
                Data = new List<TimeUnit>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("title-types")]
        [SwaggerOperation(Tags = new[] { "Context - Title types" })]
        public async Task<IActionResult> GetTitleTypes()
        {
            var data = await _lupRepository.GetTitlesTypes();
            if (data == null) return NotFound(new ApiResponse<TitleType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<TitleType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("title-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Title types" })]
        public async Task<IActionResult> GetTitleType(int id)
        {
            var data = await _lupRepository.GetTitleType(id);
            if (data == null) return NotFound(new ApiResponse<TitleType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<TitleType>()
            {
                Total = 1,
                Data = new List<TitleType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("topic-types")]
        [SwaggerOperation(Tags = new[] { "Context - Topic types" })]
        public async Task<IActionResult> GetTopicTypes()
        {
            var data = await _lupRepository.GetTopicTypes();
            if (data == null) return NotFound(new ApiResponse<TopicType>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<TopicType>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("topic-types/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Context - Topic types" })]
        public async Task<IActionResult> GetTopicType(int id)
        {
            var data = await _lupRepository.GetTopicType(id);
            if (data == null) return NotFound(new ApiResponse<TopicType>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<TopicType>()
            {
                Total = 1,
                Data = new List<TopicType>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("lang-codes")]
        [SwaggerOperation(Tags = new[] { "Context - Language codes" })]
        public async Task<IActionResult> GetLangCodes()
        {
            var data = await _lupRepository.GetLanguageCodes();
            if (data == null) return NotFound(new ApiResponse<LanguageCode>()
            {
                Total = 0,
                Data = null,
                StatusCode = NotFound().StatusCode,
                Messages = new List<string>(){"There are no records."}
            });
            return Ok(new ApiResponse<LanguageCode>
            {
                Total = data.Count,
                Data = data,
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
        
        [HttpGet("lang-codes/{code}")]
        [SwaggerOperation(Tags = new[] { "Context - Language codes" })]
        public async Task<IActionResult> GetLangCode(string code)
        {
            var data = await _lupRepository.GetLanguageCode(code);
            if (data == null) return NotFound(new ApiResponse<LanguageCode>()
            {
                Total = 0,
                Data = null,
                Messages = new List<string>(){"Not found."},
                StatusCode = NotFound().StatusCode
            });
            return Ok(new ApiResponse<LanguageCode>()
            {
                Total = 1,
                Data = new List<LanguageCode>(){data},
                StatusCode = Ok().StatusCode,
                Messages = null
            });
        }
    }
}