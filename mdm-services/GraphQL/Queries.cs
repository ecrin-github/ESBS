using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate.Data;
using HotChocolate.Types;
using mdm_services.DTO.Object;
using mdm_services.DTO.Study;
using mdm_services.Interfaces;

namespace mdm_services.GraphQL
{
    public class Queries
    {

        private readonly IStudyRepository _studyRepository;
        private readonly IObjectRepository _objectRepository;

        public Queries(IStudyRepository studyRepository, IObjectRepository objectRepository)
        {
            _studyRepository = studyRepository;
            _objectRepository = objectRepository;
        }
        
        // Studies
        [UsePaging(ConnectionName = "StudyList", MaxPageSize = 20, IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<StudyDto>> GetStudies() => await _studyRepository.GetAllStudies();
        
        [UseFiltering]
        [UseSorting]
        public async Task<StudyDto> GetStudyById(string sdSid) => await _studyRepository.GetStudyById(sdSid);

        [UsePaging(ConnectionName = "StudyDataList", MaxPageSize = 20, IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<StudyDataDto>> GetStudiesData() => await _studyRepository.GetStudiesData();

        [UseFiltering]
        [UseSorting]
        public async Task<StudyDataDto> GetStudyData(string sdSid) => await _studyRepository.GetStudyData(sdSid);

        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<StudyContributorDto>> GetStudyContributors(string sdSid) =>
            await _studyRepository.GetStudyContributors(sdSid);
        
        [UseFiltering]
        [UseSorting]
        public async Task<StudyContributorDto> GetStudyContributor(int id) =>
            await _studyRepository.GetStudyContributor(id);

        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<StudyFeatureDto>> GetStudyFeatures(string sdSid) =>
            await _studyRepository.GetStudyFeatures(sdSid);
        
        [UseFiltering]
        [UseSorting]
        public async Task<StudyFeatureDto> GetStudyFeature(int id) =>
            await _studyRepository.GetStudyFeature(id);

        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<StudyIdentifierDto>> GetStudyIdentifiers(string sdSid) =>
            await _studyRepository.GetStudyIdentifiers(sdSid);
        
        [UseFiltering]
        [UseSorting]
        public async Task<StudyIdentifierDto> GetStudyIdentifier(int id) =>
            await _studyRepository.GetStudyIdentifier(id);

        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<StudyReferenceDto>> GetStudyReferences(string sdSid) =>
            await _studyRepository.GetStudyReferences(sdSid);
        
        [UseFiltering]
        [UseSorting]
        public async Task<StudyReferenceDto> GetStudyReference(int id) =>
            await _studyRepository.GetStudyReference(id);

        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<StudyRelationshipDto>> GetStudyRelationships(string sdSid) =>
            await _studyRepository.GetStudyRelationships(sdSid);
        
        [UseFiltering]
        [UseSorting]
        public async Task<StudyRelationshipDto> GetStudyRelationship(int id) =>
            await _studyRepository.GetStudyRelationship(id);

        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<StudyTitleDto>> GetStudyTitles(string sdSid) =>
            await _studyRepository.GetStudyTitles(sdSid);
        
        [UseFiltering]
        [UseSorting]
        public async Task<StudyTitleDto> GetStudyTitle(int id) =>
            await _studyRepository.GetStudyTitle(id);

        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<StudyTopicDto>> GetStudyTopics(string sdSid) =>
            await _studyRepository.GetStudyTopics(sdSid);
        
        [UseFiltering]
        [UseSorting]
        public async Task<StudyTopicDto> GetStudyTopic(int id) =>
            await _studyRepository.GetStudyTopic(id);



        // Data object
        [UsePaging(ConnectionName = "ObjectList", MaxPageSize = 20, IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<DataObjectDto>> GetDataObjects() => await _objectRepository.GetAllDataObjects();

        [UseFiltering]
        [UseSorting]
        public async Task<DataObjectDto> GetDataObjectById(string sdOid) =>
            await _objectRepository.GetObjectById(sdOid);
        
        [UsePaging(ConnectionName = "ObjectDataList", MaxPageSize = 20, IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<DataObjectDataDto>> GetDataObjectsData() => await _objectRepository.GetDataObjectsData();

        [UseFiltering]
        [UseSorting]
        public async Task<DataObjectDataDto> GetDataObjectDataById(string sdOid) =>
            await _objectRepository.GetDataObjectData(sdOid);

        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<ObjectContributorDto>> GetObjectContributors(string sdOid) =>
            await _objectRepository.GetObjectContributors(sdOid);
        
        [UseFiltering]
        [UseSorting]
        public async Task<ObjectContributorDto> GetObjectContributor(int id) =>
            await _objectRepository.GetObjectContributor(id);
        
        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<ObjectDatasetDto>> GetObjectDatasets(string sdOid) =>
            await _objectRepository.GetObjectDatasets(sdOid);
        
        [UseFiltering]
        [UseSorting]
        public async Task<ObjectDatasetDto> GetObjectDataset(int id) =>
            await _objectRepository.GetObjectDataset(id);

        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<ObjectDateDto>> GetObjectDates(string sdOid) =>
            await _objectRepository.GetObjectDates(sdOid);
        
        [UseFiltering]
        [UseSorting]
        public async Task<ObjectDateDto> GetObjectDate(int id) =>
            await _objectRepository.GetObjectDate(id);

        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<ObjectDescriptionDto>> GetObjectDescriptions(string sdOid) =>
            await _objectRepository.GetObjectDescriptions(sdOid);
        
        [UseFiltering]
        [UseSorting]
        public async Task<ObjectDescriptionDto> GetObjectDescription(int id) =>
            await _objectRepository.GetObjectDescription(id);

        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<ObjectIdentifierDto>> GetObjectIdentifiers(string sdOid) =>
            await _objectRepository.GetObjectIdentifiers(sdOid);
        
        [UseFiltering]
        [UseSorting]
        public async Task<ObjectIdentifierDto> GetObjectIdentifier(int id) =>
            await _objectRepository.GetObjectIdentifier(id);

        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<ObjectInstanceDto>> GetObjectInstances(string sdOid) =>
            await _objectRepository.GetObjectInstances(sdOid);
        
        [UseFiltering]
        [UseSorting]
        public async Task<ObjectInstanceDto> GetObjectInstance(int id) =>
            await _objectRepository.GetObjectInstance(id);

        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<ObjectRelationshipDto>> GetObjectRelationships(string sdOid) =>
            await _objectRepository.GetObjectRelationships(sdOid);
        
        [UseFiltering]
        [UseSorting]
        public async Task<ObjectRelationshipDto> GetObjectRelationship(int id) =>
            await _objectRepository.GetObjectRelationship(id);

        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<ObjectRightDto>> GetObjectRights(string sdOid) =>
            await _objectRepository.GetObjectRights(sdOid);
        
        [UseFiltering]
        [UseSorting]
        public async Task<ObjectRightDto> GetObjectRight(int id) =>
            await _objectRepository.GetObjectRight(id);

        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<ObjectTitleDto>> GetObjectTitles(string sdOid) =>
            await _objectRepository.GetObjectTitles(sdOid);
        
        [UseFiltering]
        [UseSorting]
        public async Task<ObjectTitleDto> GetObjectTitle(int id) =>
            await _objectRepository.GetObjectTitle(id);

        [UseFiltering]
        [UseSorting]
        public async Task<ICollection<ObjectTopicDto>> GetObjectTopics(string sdOid) =>
            await _objectRepository.GetObjectTopics(sdOid);
        
        [UseFiltering]
        [UseSorting]
        public async Task<ObjectTopicDto> GetObjectTopic(int id) =>
            await _objectRepository.GetObjectTopic(id);
    }
}