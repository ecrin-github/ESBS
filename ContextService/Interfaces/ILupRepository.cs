using System.Collections.Generic;
using System.Threading.Tasks;
using ContextService.Models.Lup;

namespace ContextService.Interfaces
{
    public interface ILupRepository
    {
        Task<ICollection<CompositeHashType>> GetCompositeHashTypes();
        Task<CompositeHashType> GetCompositeHashType(int id);

        Task<ICollection<ContributionType>> GetContributionTypes();
        Task<ContributionType> GetContributionType(int id);
        
        Task<ICollection<DatasetConsentType>> GetDatasetConsentTypes();
        Task<DatasetConsentType> GetDatasetConsentType(int id);
        
        Task<ICollection<DatasetDeidentificationLevel>> GetDatasetDeidentLevels();
        Task<DatasetDeidentificationLevel> GetDatasetDeidentLevel(int id);
        
        Task<ICollection<DatasetRecordkeyType>> GetDatasetRecordkeyTypes();
        Task<DatasetRecordkeyType> GetDatasetRecordkeyType(int id);
        
        Task<ICollection<DateType>> GetDateTypes();
        Task<DateType> GetDateType(int id);
        
        Task<ICollection<DescriptionType>> GetDescriptionTypes();
        Task<DescriptionType> GetDescriptionType(int id);
        
        Task<ICollection<DoiStatusType>> GetDoiStatusTypes();
        Task<DoiStatusType> GetDoiStatusType(int id);
        
        Task<ICollection<GenderEligibilityType>> GetGenderEligTypes();
        Task<GenderEligibilityType> GetGenderEligType(int id);
        
        Task<ICollection<GeogEntityType>> GetGeogEntityTypes();
        Task<GeogEntityType> GetGeogEntityType(int id);
        
        Task<ICollection<IdentifierType>> GetIdentifierTypes();
        Task<IdentifierType> GetIdentifierType(int id);
        
        Task<ICollection<LanguageCode>> GetLanguageCodes();
        Task<LanguageCode> GetLanguageCode(string code);
        
        Task<ICollection<LanguageUsageType>> GetLangUsageTypes();
        Task<LanguageUsageType> GetLangUsageType(int id);
        
        Task<ICollection<LinkType>> GetLinkTypes();
        Task<LinkType> GetLinkType(int id);
        
        Task<ICollection<ObjectAccessType>> GetObjectAccessTypes();
        Task<ObjectAccessType> GetObjectAccessType(int id);
        
        Task<ICollection<ObjectClass>> GetObjectClasses();
        Task<ObjectClass> GetObjectClass(int id);
        
        Task<ICollection<ObjectFilterType>> GetObjectFilterTypes();
        Task<ObjectFilterType> GetObjectFilterType(int id);
        
        Task<ICollection<ObjectInstanceType>> GetObjectInstanceTypes();
        Task<ObjectInstanceType> GetObjectInstanceType(int id);
        
        Task<ICollection<ObjectRelationshipType>> GetObjectRelationshipTypes();
        Task<ObjectRelationshipType> GetObjectRelationshipType(int id);
        
        Task<ICollection<ObjectType>> GetObjectTypes();
        Task<ObjectType> GetObjectType(int id);

        Task<ICollection<OrgAttributeDatatype>> GetOrgAttributeDatatypes();
        Task<OrgAttributeDatatype> GetOrgAttributeDatatype(int id);

        Task<ICollection<OrgAttributeType>> GetOrgAttributeTypes();
        Task<OrgAttributeType> GetOrgAttributeType(int id);

        Task<ICollection<OrgClass>> GetOrgClasses();
        Task<OrgClass> GetOrgClass(int id);

        Task<ICollection<OrgLinkType>> GetOrgLinkTypes();
        Task<OrgLinkType> GetOrgLinkType(int id);

        Task<ICollection<OrgNameQualifierType>> GetOrgNameQualifierTypes();
        Task<OrgNameQualifierType> GetOrgNameQualifierType(int id);

        Task<ICollection<OrgRelationshipType>> GetOrgRelationshipTypes();
        Task<OrgRelationshipType> GetOrgRelationshipType(int id);

        Task<ICollection<OrgType>> GetOrgTypes();
        Task<OrgType> GetOrgType(int id);
        
        Task<ICollection<ResourceType>> GetResourceTypes();
        Task<ResourceType> GetResourceType(int id);
        
        Task<ICollection<RmsUserType>> GetRmsUserTypes();
        Task<RmsUserType> GetRmsUserType(int id);
        
        Task<ICollection<RoleClass>> GetRoleClasses();
        Task<RoleClass> GetRoleClass(int id);
        
        Task<ICollection<RoleType>> GetRoleTypes();
        Task<RoleType> GetRoleType(int id);
        
        Task<ICollection<SizeUnit>> GetSizeUnits();
        Task<SizeUnit> GetSizeUnit(int id);
        
        Task<ICollection<StudyFeatureCategory>> GetStudyFeatureCategories();
        Task<StudyFeatureCategory> GetStudyFeatureCategory(int id);
        
        Task<ICollection<StudyFeatureType>> GetStudyFeatureTypes();
        Task<StudyFeatureType> GetStudyFeatureType(int id);
        
        Task<ICollection<StudyRelationshipType>> GetStudyRelationshipTypes();
        Task<StudyRelationshipType> GetStudyRelationshipType(int id);
        
        Task<ICollection<StudyStatus>> GetStudyStatuses();
        Task<StudyStatus> GetStudyStatus(int id);
        
        Task<ICollection<StudyType>> GetStudyTypes();
        Task<StudyType> GetStudyType(int id);
        
        Task<ICollection<TimeUnit>> GetTimeUnits();
        Task<TimeUnit> GetTimeUnit(int id);
        
        Task<ICollection<TitleType>> GetTitlesTypes();
        Task<TitleType> GetTitleType(int id);
        
        Task<ICollection<TopicType>> GetTopicTypes();
        Task<TopicType> GetTopicType(int id);

        Task<ICollection<TopicVocabulary>> GetTopicVocabularies();
        Task<TopicVocabulary> GetTopicVocabulary(int id);
    }
}