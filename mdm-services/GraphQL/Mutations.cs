using System.Threading.Tasks;
using mdm_services.DTO.Object;
using mdm_services.DTO.Study;
using mdm_services.Interfaces;

namespace mdm_services.GraphQL
{
    public class Mutations
    {
        private readonly IStudyRepository _studyRepository;
        private readonly IObjectRepository _objectRepository;

        public Mutations(IStudyRepository studyRepository, IObjectRepository objectRepository)
        {
            _studyRepository = studyRepository;
            _objectRepository = objectRepository;
        }
        
        // Study
        public async Task<StudyDto> CreateStudy(StudyDto study) => await _studyRepository.CreateStudy(study);
        
        public async Task<StudyDto> UpdateStudy(StudyDto study) => await _studyRepository.UpdateStudy(study);
        
        public void DeleteStudy(string sdSid) => _studyRepository.DeleteStudy(sdSid);
        
        public async Task<StudyDataDto> CreateStudyData(StudyDataDto studyDataDto) =>
            await _studyRepository.CreateStudyData(studyDataDto);

        public async Task<StudyDataDto> UpdateStudyData(StudyDataDto studyDataDto) =>
            await _studyRepository.UpdateStudyData(studyDataDto);

        public async Task<StudyContributorDto> CreateStudyContributor(string sdSid, StudyContributorDto studyContributorDto) =>
            await _studyRepository.CreateStudyContributor(sdSid, studyContributorDto);

        public async Task<StudyContributorDto> UpdateStudyContributor(StudyContributorDto studyContributorDto) =>
            await _studyRepository.UpdateStudyContributor(studyContributorDto);

        public void DeleteStudyContributor(int id) => _studyRepository.DeleteStudyContributor(id);

        public void DeleteAllStudyContributors(string sdSid) => _studyRepository.DeleteAllStudyContributors(sdSid);

        public async Task<StudyFeatureDto> CreateStudyFeature(string sdSid, StudyFeatureDto studyFeatureDto) =>
            await _studyRepository.CreateStudyFeature(sdSid, studyFeatureDto);

        public async Task<StudyFeatureDto> UpdateStudyFeature(StudyFeatureDto studyFeatureDto) =>
            await _studyRepository.UpdateStudyFeature(studyFeatureDto);

        public void DeleteStudyFeature(int id) => _studyRepository.DeleteStudyFeature(id);

        public void DeleteAllStudyFeatures(string sdSid) => _studyRepository.DeleteAllStudyFeatures(sdSid);

        public async Task<StudyIdentifierDto>
            CreateStudyIdentifier(string sdSid, StudyIdentifierDto studyIdentifierDto) =>
            await _studyRepository.CreateStudyIdentifier(sdSid, studyIdentifierDto);

        public async Task<StudyIdentifierDto> UpdateStudyIdentifier(StudyIdentifierDto studyIdentifierDto) =>
            await _studyRepository.UpdateStudyIdentifier(studyIdentifierDto);

        public void DeleteStudyIdentifier(int id) => _studyRepository.DeleteStudyIdentifier(id);

        public void DeleteAllStudyIdentifiers(string sdSid) => _studyRepository.DeleteAllStudyIdentifiers(sdSid);

        public async Task<StudyReferenceDto> CreateStudyReference(string sdSid, StudyReferenceDto studyReferenceDto) =>
            await _studyRepository.CreateStudyReference(sdSid, studyReferenceDto);

        public async Task<StudyReferenceDto> UpdateStudyReference(StudyReferenceDto studyReferenceDto) =>
            await _studyRepository.UpdateStudyReference(studyReferenceDto);

        public void DeleteStudyReference(int id) => _studyRepository.DeleteStudyReference(id);

        public void DeleteAllStudyReferences(string sdSid) => _studyRepository.DeleteAllStudyReferences(sdSid);

        public async Task<StudyRelationshipDto> CreateStudyRelationship(string sdSid,
            StudyRelationshipDto studyRelationshipDto) =>
            await _studyRepository.CreateStudyRelationship(sdSid, studyRelationshipDto);

        public async Task<StudyRelationshipDto> UpdateStudyRelationship(StudyRelationshipDto studyRelationshipDto) =>
            await _studyRepository.UpdateStudyRelationship(studyRelationshipDto);

        public void DeleteStudyRelationship(int id) =>
            _studyRepository.DeleteStudyRelationship(id);

        public void DeleteAllStudyRelationships(string sdSid) => _studyRepository.DeleteAllStudyRelationships(sdSid);

        public async Task<StudyTitleDto> CreateStudyTitle(string sdSid, StudyTitleDto studyTitleDto) =>
            await _studyRepository.CreateStudyTitle(sdSid, studyTitleDto);

        public async Task<StudyTitleDto> UpdateStudyTitle(StudyTitleDto studyTitleDto) =>
            await _studyRepository.UpdateStudyTitle(studyTitleDto);

        public void DeleteStudyTitle(int id) => _studyRepository.DeleteStudyTitle(id);

        public void DeleteAllStudyTitles(string sdSid) => _studyRepository.DeleteAllStudyTitles(sdSid);

        public async Task<StudyTopicDto> CreateStudyTopic(string sdSid, StudyTopicDto studyTopicDto) =>
            await _studyRepository.CreateStudyTopic(sdSid, studyTopicDto);

        public async Task<StudyTopicDto> UpdateStudyTopic(StudyTopicDto studyTopicDto) =>
            await _studyRepository.UpdateStudyTopic(studyTopicDto);

        public void DeleteStudyTopic(int id) => _studyRepository.DeleteStudyTopic(id);

        public void DeleteAllStudyTopics(string sdSid) => _studyRepository.DeleteAllStudyTopics(sdSid);
        


        // Data object
        public async Task<DataObjectDto> CreateDataObject(DataObjectDto dataObject) =>
            await _objectRepository.CreateDataObject(dataObject);
        
        public async Task<DataObjectDto> UpdateDataObject(DataObjectDto dataObject) =>
            await _objectRepository.UpdateDataObject(dataObject);
        
        public void DeleteDataObject(string sdOid) =>
            _objectRepository.DeleteDataObject(sdOid);

        public async Task<DataObjectDataDto> CreateDataObjectData(DataObjectDataDto dataObjectDataDto) =>
            await _objectRepository.CreateDataObjectData(dataObjectDataDto);

        public async Task<DataObjectDataDto> UpdateDataObjectData(DataObjectDataDto dataObjectDataDto) =>
            await _objectRepository.UpdateDataObjectData(dataObjectDataDto);

        public async Task<ObjectContributorDto> CreateObjectContributor(string sdOid,
            ObjectContributorDto objectContributorDto) =>
            await _objectRepository.CreateObjectContributor(sdOid, objectContributorDto);

        public async Task<ObjectContributorDto> UpdateObjectContributor(ObjectContributorDto objectContributorDto) =>
            await _objectRepository.UpdateObjectContributor(objectContributorDto);

        public void DeleteObjectContributor(int id) =>
            _objectRepository.DeleteObjectContributor(id);

        public void DeleteAllObjectContributors(string sdOid) =>
            _objectRepository.DeleteAllObjectContributors(sdOid);

        public async Task<ObjectDatasetDto> CreateObjectDataset(string sdOid, ObjectDatasetDto objectDatasetDto) =>
            await _objectRepository.CreateObjectDataset(sdOid, objectDatasetDto);

        public async Task<ObjectDatasetDto> UpdateObjectDataset(ObjectDatasetDto objectDatasetDto) =>
            await _objectRepository.UpdateObjectDataset(objectDatasetDto);

        public void DeleteObjectDataset(int id) => _objectRepository.DeleteObjectDataset(id);

        public void DeleteAllObjectDatasets(string sdOid) => _objectRepository.DeleteAllObjectDatasets(sdOid);

        public async Task<ObjectDateDto> CreateObjectDate(string sdOid, ObjectDateDto objectDateDto) =>
            await _objectRepository.CreateObjectDate(sdOid, objectDateDto);

        public async Task<ObjectDateDto> UpdateObjectDate(ObjectDateDto objectDateDto) =>
            await _objectRepository.UpdateObjectDate(objectDateDto);

        public void DeleteObjectDate(int id) => _objectRepository.DeleteObjectDate(id);

        public void DeleteAllObjectDates(string sdOid) => _objectRepository.DeleteAllObjectDates(sdOid);

        public async Task<ObjectDescriptionDto> CreateObjectDescription(string sdOid,
            ObjectDescriptionDto objectDescriptionDto) =>
            await _objectRepository.CreateObjectDescription(sdOid, objectDescriptionDto);

        public async Task<ObjectDescriptionDto> UpdateObjectDescription(ObjectDescriptionDto objectDescriptionDto) =>
            await _objectRepository.UpdateObjectDescription(objectDescriptionDto);

        public void DeleteObjectDescription(int id) =>
            _objectRepository.DeleteObjectDescription(id);

        public void DeleteAllObjectDescriptions(string sdOid) =>
            _objectRepository.DeleteAllObjectDescriptions(sdOid);

        public async Task<ObjectIdentifierDto> CreateObjectIdentifier(string sdOid,
            ObjectIdentifierDto objectIdentifierDto) =>
            await _objectRepository.CreateObjectIdentifier(sdOid, objectIdentifierDto);

        public async Task<ObjectIdentifierDto> UpdateObjectIdentifier(ObjectIdentifierDto objectIdentifierDto) =>
            await _objectRepository.UpdateObjectIdentifier(objectIdentifierDto);

        public void DeleteObjectIdentifier(int id) => _objectRepository.DeleteObjectIdentifier(id);

        public void DeleteAllObjectIdentifiers(string sdOid) => _objectRepository.DeleteAllObjectIdentifiers(sdOid);

        public async Task<ObjectInstanceDto> CreateObjectInstance(string sdOid, ObjectInstanceDto objectInstanceDto) =>
            await _objectRepository.CreateObjectInstance(sdOid, objectInstanceDto);

        public async Task<ObjectInstanceDto> UpdateObjectInstance(ObjectInstanceDto objectInstanceDto) =>
            await _objectRepository.UpdateObjectInstance(objectInstanceDto);

        public void DeleteObjectInstance(int id) => _objectRepository.DeleteObjectInstance(id);

        public void DeleteAllObjectInstances(string sdOid) => _objectRepository.DeleteAllObjectInstances(sdOid);

        public async Task<ObjectRelationshipDto> CreateObjectRelationship(string sdOid,
            ObjectRelationshipDto objectRelationshipDto) =>
            await _objectRepository.CreateObjectRelationship(sdOid, objectRelationshipDto);

        public async Task<ObjectRelationshipDto>
            UpdateObjectRelationship(ObjectRelationshipDto objectRelationshipDto) =>
            await _objectRepository.UpdateObjectRelationship(objectRelationshipDto);

        public void DeleteObjectRelationship(int id) =>
            _objectRepository.DeleteObjectRelationship(id);

        public void DeleteAllObjectRelationships(string sdOid) =>
            _objectRepository.DeleteAllObjectRelationships(sdOid);

        public async Task<ObjectRightDto> CreateObjectRight(string sdOid, ObjectRightDto objectRightDto) =>
            await _objectRepository.CreateObjectRight(sdOid, objectRightDto);

        public async Task<ObjectRightDto> UpdateObjectRight(ObjectRightDto objectRightDto) =>
            await _objectRepository.UpdateObjectRight(objectRightDto);

        public void DeleteObjectRight(int id) => _objectRepository.DeleteObjectRight(id);

        public void DeleteAllObjectRights(string sdOid) => _objectRepository.DeleteAllObjectRights(sdOid);

        public async Task<ObjectTitleDto> CreateObjectTitle(string sdOid, ObjectTitleDto objectTitleDto) =>
            await _objectRepository.CreateObjectTitle(sdOid, objectTitleDto);

        public async Task<ObjectTitleDto> UpdateObjectTitle(ObjectTitleDto objectTitleDto) =>
            await _objectRepository.UpdateObjectTitle(objectTitleDto);

        public void DeleteObjectTitle(int id) => _objectRepository.DeleteObjectTitle(id);

        public void DeleteAllObjectTitles(string sdOid) => _objectRepository.DeleteAllObjectTitles(sdOid);

        public async Task<ObjectTopicDto> CreateObjectTopic(string sdOid, ObjectTopicDto objectTopicDto) =>
            await _objectRepository.CreateObjectTopic(sdOid, objectTopicDto);

        public async Task<ObjectTopicDto> UpdateObjectTopic(ObjectTopicDto objectTopicDto) =>
            await _objectRepository.UpdateObjectTopic(objectTopicDto);

        public void DeleteObjectTopic(int id) => _objectRepository.DeleteObjectTopic(id);

        public void DeleteAllObjectTopics(string sdOid) => _objectRepository.DeleteAllObjectTopics(sdOid);


    }
}