#nullable enable
using System.Collections.Generic;
using System.Threading.Tasks;
using MdrService.Models.Lup;

namespace MdrService.Interfaces
{
    public interface ILupRepository
    {
        Task<string?> GetContributionType(int? id);
        
        Task<string?> GetDatasetConsentType(int? id);
        
        Task<string?> GetDatasetDeidentLevel(int? id);
        
        Task<string?> GetDatasetRecordkeyType(int? id);
        
        Task<string?> GetDateType(int? id);
        
        Task<string?> GetDescriptionType(int? id);
        
        Task<string?> GetDoiStatusType(int? id);
        
        Task<string?> GetGenderEligType(int? id);
        
        Task<string?> GetGeogEntityType(int? id);
        
        Task<string?> GetIdentifierType(int? id);
        
        Task<string?> GetLanguageCode(string? code);
        
        Task<string?> GetLangUsageType(int? id);
        
        Task<string?> GetLinkType(int? id);
        
        Task<string?> GetObjectAccessType(int? id);
        
        Task<string?> GetObjectClass(int? id);
        
        Task<string?> GetObjectFilterType(int? id);
        
        Task<string?> GetObjectInstanceType(int? id);
        
        Task<string?> GetObjectRelationshipType(int? id);
        
        Task<string?> GetObjectType(int? id);
        
        Task<string?> GetResourceType(int? id);

        Task<string?> GetSizeUnit(int? id);
        
        Task<string?> GetStudyFeatureCategory(int? id);
        
        Task<string?> GetStudyFeatureType(int? id);
        
        Task<string?> GetStudyRelationshipType(int? id);
        
        Task<string?> GetStudyStatus(int? id);
        
        Task<string?> GetStudyType(int? id);
        
        Task<string?> GetTimeUnit(int? id);
        
        Task<string?> GetTitleType(int? id);
        
        Task<string?> GetTopicType(int? id);
    }
}