using System.Threading.Tasks;

namespace MdrService.Interfaces
{
    public interface IContextService
    {
        // Common
        Task<string> GetTitleType(int? id);
        Task<string> GetTopicType(int? id);
        Task<string> GetDescriptionType(int? id);
        Task<string> GetIdentifierType(int? id);
        Task<string> GetContributionType(int? id);
        Task<string> GetSizeUnitType(int? id);
        Task<string> GetTimeUnitType(int? id);

        // Study
        Task<string> GetStudyType(int? id);
        Task<string> GetStudyStatus(int? id);
        Task<string> GetFeatureType(int? id);
        Task<string> GetFeatureValue(int? id);
        Task<string> GetGenderElig(int? id);
        Task<string> GetStudyRelationshipType(int? id);

        

        // Object
        Task<string> GetObjectType(int? id);
        Task<string> GetObjectClass(int? id);
        Task<string> GetAccessType(int? id);
        Task<string> GetDateType(int? id);
        Task<string> GetInstanceType(int? id);
        Task<string> GetRecordkeyType(int? id);
        Task<string> GetDeidentType(int? id);
        Task<string> GetConsentType(int? id);
        Task<string> GetResourceType(int? id);
        Task<string> GetDoiStatus(int? id);
        Task<string> GetObjectRelationshipType(int? id);

        
    }
}