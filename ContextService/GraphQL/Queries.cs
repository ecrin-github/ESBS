using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ContextService.Interfaces;
using ContextService.Models.Ctx;
using ContextService.Models.Lup;
using ContextService.Models.Rms;

namespace ContextService.GraphQL
{
    public class Queries
    {
        private readonly ICtxRepository _ctxRepository;
        private readonly ILupRepository _lupRepository;
        private readonly IRmsContextRepository _rmsContextRepository;

        public Queries(
            ICtxRepository ctxRepository, 
            ILupRepository lupRepository,
            IRmsContextRepository rmsContextRepository
        )
        {
            _lupRepository = lupRepository;
            _ctxRepository = ctxRepository;
            _rmsContextRepository = rmsContextRepository;
        }
        
        public async Task<ICollection<ContributionType>> GetContributionTypes() =>
            await _lupRepository.GetContributionTypes();

        public async Task<ContributionType> GetContributionType(int id) =>
            await _lupRepository.GetContributionType(id);
        
        public async Task<ICollection<DatasetConsentType>> GetDatasetConsentTypes() =>
            await _lupRepository.GetDatasetConsentTypes();

        public async Task<DatasetConsentType> GetDatasetConsentType(int id) =>
            await _lupRepository.GetDatasetConsentType(id);
        
        public async Task<ICollection<DatasetDeidentificationLevel>> GetDatasetDeidentLevels() =>
            await _lupRepository.GetDatasetDeidentLevels();

        public async Task<DatasetDeidentificationLevel> GetDatasetDeidentLevel(int id) =>
            await _lupRepository.GetDatasetDeidentLevel(id);
        
        public async Task<ICollection<DatasetRecordkeyType>> GetDatasetRecordkeyTypes() =>
            await _lupRepository.GetDatasetRecordkeyTypes();

        public async Task<DatasetRecordkeyType> GetDatasetRecordkeyType(int id) =>
            await _lupRepository.GetDatasetRecordkeyType(id);
        
        public async Task<ICollection<DateType>> GetDateTypes() =>
            await _lupRepository.GetDateTypes();

        public async Task<DateType> GetDateType(int id) =>
            await _lupRepository.GetDateType(id);
        
        public async Task<ICollection<DescriptionType>> GetDescriptionTypes() =>
            await _lupRepository.GetDescriptionTypes();

        public async Task<DescriptionType> GetDescriptionType(int id) =>
            await _lupRepository.GetDescriptionType(id);
        
        public async Task<ICollection<DoiStatusType>> GetDoiStatusTypes() =>
            await _lupRepository.GetDoiStatusTypes();

        public async Task<DoiStatusType> GetDoiStatusType(int id) =>
            await _lupRepository.GetDoiStatusType(id);
        
        public async Task<ICollection<GenderEligibilityType>> GetGenderEligibilityTypes() =>
            await _lupRepository.GetGenderEligTypes();

        public async Task<GenderEligibilityType> GetGenderEligibilityType(int id) =>
            await _lupRepository.GetGenderEligType(id);
        
        public async Task<ICollection<GeogEntityType>> GetGeogEntityTypes() =>
            await _lupRepository.GetGeogEntityTypes();

        public async Task<GeogEntityType> GetGeogEntityType(int id) =>
            await _lupRepository.GetGeogEntityType(id);
        
        public async Task<ICollection<IdentifierType>> GetIdentifierTypes() =>
            await _lupRepository.GetIdentifierTypes();

        public async Task<IdentifierType> GetIdentifierType(int id) =>
            await _lupRepository.GetIdentifierType(id);
        
        public async Task<ICollection<LanguageCode>> GetLanguageCodes() =>
            await _lupRepository.GetLanguageCodes();

        public async Task<LanguageCode> GetLanguageCode(string code) =>
            await _lupRepository.GetLanguageCode(code);
        
        public async Task<ICollection<LanguageUsageType>> GetLanguageUsageTypes() =>
            await _lupRepository.GetLangUsageTypes();

        public async Task<LanguageUsageType> GetLanguageUsageType(int id) =>
            await _lupRepository.GetLangUsageType(id);
        
        public async Task<ICollection<LinkType>> GetLinkTypes() =>
            await _lupRepository.GetLinkTypes();

        public async Task<LinkType> GetLinkType(int id) =>
            await _lupRepository.GetLinkType(id);
        
        public async Task<ICollection<ObjectAccessType>> GetObjectAccessTypes() =>
            await _lupRepository.GetObjectAccessTypes();

        public async Task<ObjectAccessType> GetObjectAccessType(int id) =>
            await _lupRepository.GetObjectAccessType(id);
        
        public async Task<ICollection<ObjectClass>> GetObjectClasses() =>
            await _lupRepository.GetObjectClasses();

        public async Task<ObjectClass> GetObjectClass(int id) =>
            await _lupRepository.GetObjectClass(id);
        
        public async Task<ICollection<ObjectFilterType>> GetObjectFilterTypes() =>
            await _lupRepository.GetObjectFilterTypes();

        public async Task<ObjectFilterType> GetObjectFilterType(int id) =>
            await _lupRepository.GetObjectFilterType(id);
        
        public async Task<ICollection<ObjectInstanceType>> GetObjectInstanceTypes() =>
            await _lupRepository.GetObjectInstanceTypes();

        public async Task<ObjectInstanceType> GetObjectInstanceType(int id) =>
            await _lupRepository.GetObjectInstanceType(id);
        
        public async Task<ICollection<ObjectRelationshipType>> GetObjectRelationshipTypes() =>
            await _lupRepository.GetObjectRelationshipTypes();

        public async Task<ObjectRelationshipType> GetObjectRelationshipType(int id) =>
            await _lupRepository.GetObjectRelationshipType(id);
        
        public async Task<ICollection<ObjectType>> GetObjectTypes() =>
            await _lupRepository.GetObjectTypes();

        public async Task<ObjectType> GetObjectType(int id) =>
            await _lupRepository.GetObjectType(id);
        
        public async Task<ICollection<ResourceType>> GetResourceTypes() =>
            await _lupRepository.GetResourceTypes();

        public async Task<ResourceType> GetResourceType(int id) =>
            await _lupRepository.GetResourceType(id);
        
        public async Task<ICollection<RmsUserType>> GetRmsUserTypes() =>
            await _lupRepository.GetRmsUserTypes();

        public async Task<RmsUserType> GetRmsUserType(int id) =>
            await _lupRepository.GetRmsUserType(id);
        
        public async Task<ICollection<RoleClass>> GetRoleClasses() =>
            await _lupRepository.GetRoleClasses();

        public async Task<RoleClass> GetRoleClass(int id) =>
            await _lupRepository.GetRoleClass(id);
        
        public async Task<ICollection<RoleType>> GetRoleTypes() =>
            await _lupRepository.GetRoleTypes();

        public async Task<RoleType> GetRoleType(int id) =>
            await _lupRepository.GetRoleType(id);
        
        public async Task<ICollection<SizeUnit>> GetSizeUnits() =>
            await _lupRepository.GetSizeUnits();

        public async Task<SizeUnit> GetSizeUnit(int id) =>
            await _lupRepository.GetSizeUnit(id);
        
        public async Task<ICollection<StudyFeatureCategory>> GetStudyFeatureCategories() =>
            await _lupRepository.GetStudyFeatureCategories();

        public async Task<StudyFeatureCategory> GetStudyFeatureCategory(int id) =>
            await _lupRepository.GetStudyFeatureCategory(id);
        
        public async Task<ICollection<StudyFeatureType>> GetStudyFeatureTypes() =>
            await _lupRepository.GetStudyFeatureTypes();

        public async Task<StudyFeatureType> GetStudyFeatureType(int id) =>
            await _lupRepository.GetStudyFeatureType(id);
        
        public async Task<ICollection<StudyRelationshipType>> GetStudyRelationshipTypes() =>
            await _lupRepository.GetStudyRelationshipTypes();

        public async Task<StudyRelationshipType> GetStudyRelationshipType(int id) =>
            await _lupRepository.GetStudyRelationshipType(id);
        
        public async Task<ICollection<StudyStatus>> GetStudyStatuses() =>
            await _lupRepository.GetStudyStatuses();

        public async Task<StudyStatus> GetStudyStatus(int id) =>
            await _lupRepository.GetStudyStatus(id);
        
        public async Task<ICollection<StudyType>> GetStudyTypes() =>
            await _lupRepository.GetStudyTypes();

        public async Task<StudyType> GetStudyType(int id) =>
            await _lupRepository.GetStudyType(id);
        
        public async Task<ICollection<TimeUnit>> GetTimeUnits() =>
            await _lupRepository.GetTimeUnits();

        public async Task<TimeUnit> GetTimeUnit(int id) =>
            await _lupRepository.GetTimeUnit(id);
        
        public async Task<ICollection<TitleType>> GetTitleTypes() =>
            await _lupRepository.GetTitlesTypes();

        public async Task<TitleType> GetTitleType(int id) =>
            await _lupRepository.GetTitleType(id);
        
        public async Task<ICollection<TopicType>> GetTopicTypes() =>
            await _lupRepository.GetTopicTypes();

        public async Task<TopicType> GetTopicType(int id) =>
            await _lupRepository.GetTopicType(id);
        
        public async Task<ICollection<AccessPrereqType>> GetAccessPrereqTypes() =>
            await _rmsContextRepository.GetAccessPrereqTypes();

        public async Task<AccessPrereqType> GetAccessPrereqType(int id) =>
            await _rmsContextRepository.GetAccessPrereqType(id);
        
        public async Task<ICollection<CheckStatusType>> GetCheckStatusTypes() =>
            await _rmsContextRepository.GetCheckStatusTypes();

        public async Task<CheckStatusType> GetCheckStatusType(int id) =>
            await _rmsContextRepository.GetCheckStatusType(id);
        
        public async Task<ICollection<DtpStatusType>> GetDtpStatusTypes() =>
            await _rmsContextRepository.GetDtpStatusTypes();

        public async Task<DtpStatusType> GetDtpStatusType(int id) =>
            await _rmsContextRepository.GetDtpStatusType(id);
        
        public async Task<ICollection<DupStatusType>> GetDupStatusTypes() =>
            await _rmsContextRepository.GetDupStatusTypes();

        public async Task<DupStatusType> GetDupStatusType(int id) =>
            await _rmsContextRepository.GetDupStatusType(id);
        
        public async Task<ICollection<LegalStatusType>> GetLegalStatusTypes() =>
            await _rmsContextRepository.GetLegalStatusTypes();

        public async Task<LegalStatusType> GetLegalStatusType(int id) =>
            await _rmsContextRepository.GetLegalStatusType(id);
        
        public async Task<ICollection<RepoAccessType>> GetRepoAccessTypes() =>
            await _rmsContextRepository.GetRepoAccessTypes();

        public async Task<RepoAccessType> GetRepoAccessType(int id) =>
            await _rmsContextRepository.GetRepoAccessType(id);
        
        public async Task<ICollection<Organisation>> GetOrganisations() => await _ctxRepository.GetOrganisations();
        public async Task<Organisation> GetOrganisation(int id) => await _ctxRepository.GetOrganisation(id);
        
        public async Task<ICollection<OrgAttribute>> GetOrgAttributes(int orgId) => await _ctxRepository.GetOrgAttributes(orgId);
        public async Task<ICollection<OrgLink>> GetOrgLinks(int orgId) => await _ctxRepository.GetOrgLinks(orgId);
        public async Task<ICollection<OrgLocation>> GetOrgLocations(int orgId) => await _ctxRepository.GetOrgLocations(orgId);
        public async Task<ICollection<OrgName>> GetOrgNames(int orgId) => await _ctxRepository.GetOrgNames(orgId);
        public async Task<ICollection<OrgRelationship>> GetOrgRelationships(int orgId) => await _ctxRepository.GetOrgRelationships(orgId);

        public async Task<ICollection<People>> GetPeople() => await _ctxRepository.GetPeople();
        public async Task<People> GetPerson(int id) => await _ctxRepository.GetPerson(id);
        public async Task<ICollection<PeopleLink>> GetPersonLinks(int personId) => await _ctxRepository.GetPersonLinks(personId);
        public async Task<ICollection<PeopleRole>> GetPersonRoles(int personId) => await _ctxRepository.GetPersonRoles(personId);

        public async Task<ICollection<Publisher>> GetPublishers() => await _ctxRepository.GetPublishers();
        public async Task<Publisher> GetPublisher(int id) => await _ctxRepository.GetPublisher(id);
        public async Task<ICollection<PubEissn>> GetPubEissns(int pubId) => await _ctxRepository.GetPubEissns(pubId);
        public async Task<ICollection<PubJournal>> GetPubJournals(int pubId) => await _ctxRepository.GetPubJournals(pubId);
        public async Task<ICollection<PubPissn>> GetPubPissns(int pubId) => await _ctxRepository.GetPubPissns(pubId); 
    }
}