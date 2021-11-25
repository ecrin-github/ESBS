using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MdrService.Contracts.Responses.v1.Common;
using MdrService.Contracts.Responses.v1.ObjectListResponse;
using MdrService.Contracts.Responses.v1.StudyListResponse;
using MdrService.Interfaces;
using MdrService.Models.Object;
using MdrService.Models.Study;

namespace MdrService.Services
{
    public class BuilderService : IBuilderService
    {
        private readonly IDataMapper _dataMapper;
        private readonly IContextService _context;

        private readonly IStudyRepository _studyRepository;
        private readonly IObjectRepository _objectRepository;

        private readonly ILinksRepository _linksRepository;

        private readonly ILupRepository _lupRepository;

        public BuilderService(
            IDataMapper dataMapper,
            IContextService context,
            IStudyRepository studyRepository,
            IObjectRepository objectRepository,
            ILinksRepository linksRepository,
            ILupRepository lupRepository)
        {
            _dataMapper = dataMapper ?? throw new ArgumentNullException(nameof(dataMapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _studyRepository = studyRepository ?? throw new ArgumentNullException(nameof(studyRepository));
            _objectRepository = objectRepository ?? throw new ArgumentNullException(nameof(objectRepository));
            _linksRepository = linksRepository ?? throw new ArgumentNullException(nameof(linksRepository));
            _lupRepository = lupRepository ?? throw new ArgumentNullException(nameof(lupRepository));
        }
        
        public async Task<StudyListResponse> BuildSingleStudyResponse(Study study)
        {
            var minAge = new MinAgeResponse();
            if (study.MinAge != null && study.MinAgeUnitsId != null)
            {
                minAge.Value = study.MinAge;
                minAge.UnitName = await _lupRepository.GetTimeUnit(study.MinAgeUnitsId);
            }

            var maxAge = new MaxAgeResponse();
            if (study.MaxAge != null && study.MaxAgeUnitsId != null)
            {
                maxAge.Value = study.MaxAge;
                maxAge.UnitName = await _lupRepository.GetTimeUnit(study.MaxAgeUnitsId);
            }
            
            
            return new StudyListResponse()
            {
                Id = study.Id,
                DisplayTitle = study.DisplayTitle,
                BriefDescription = study.BriefDescription,
                StudyType = await _lupRepository.GetStudyType(study.StudyTypeId),
                StudyStatus = await _lupRepository.GetStudyStatus(study.StudyStatusId),
                StudyGenderElig = await _lupRepository.GetGenderEligType(study.StudyGenderEligId),
                StudyEnrolment = study.StudyEnrolment,
                MinAge = minAge,
                MaxAge = maxAge,
                StudyIdentifiers = await _dataMapper.MapStudyIdentifiers(await _studyRepository.GetStudyIdentifiers(study.Id)),
                StudyTitles = await _dataMapper.MapStudyTitles(await _studyRepository.GetStudyTitles(study.Id)),
                StudyFeatures = await _dataMapper.MapStudyFeatures(await _studyRepository.GetStudyFeatures(study.Id)),
                StudyTopics = await _dataMapper.MapStudyTopics(await _studyRepository.GetStudyTopics(study.Id)),
                StudyRelationships = await _dataMapper.MapStudyRelationships(await _studyRepository.GetStudyRelationships(study.Id)),
                ProvenanceString = study.ProvenanceString,
                LinkedDataObjects = await BuildObjectResponse(
                    await _objectRepository.GetDataObjects(
                        await _linksRepository.GetStudyObjects(study.Id)))
            };
        }

        public async Task<ICollection<StudyListResponse>> BuildStudyResponse(ICollection<Study> studies)
        {
            var studyListResponse = new List<StudyListResponse>();
            foreach (var study in studies)
            {
                studyListResponse.Add(await BuildSingleStudyResponse(study));
            }

            return studyListResponse;
        }

        
        private static string ObjectUrlExtraction(ICollection<ObjectInstance> objectInstances)
        {
            string objectUrlString = null;
            if (objectInstances is not { Count: > 0 }) return null;
            if (!string.IsNullOrEmpty(objectInstances.First().Url))
            {
                objectUrlString = objectInstances.First().Url;
            }

            return objectUrlString;
        }
        
        
        public async Task<ObjectListResponse> BuildSingleObjectResponse(DataObject dataObject)
        {
            var objectInstances = await _objectRepository.GetObjectInstances(dataObject.Id);

            string objectUrl;
            if (objectInstances is not { Count: > 0 }) objectUrl = null;
            objectUrl = ObjectUrlExtraction(objectInstances);
            
            var objectDataset = await _objectRepository.GetObjectDatasets(dataObject.Id);
            return new ObjectListResponse()
            {
                Id = dataObject.Id,
                Doi = dataObject.Doi,
                DisplayTitle = dataObject.DisplayTitle,
                Version = dataObject.Version,
                ObjectClass = await _lupRepository.GetObjectClass(dataObject.ObjectClassId),
                ObjectType = await _lupRepository.GetObjectType(dataObject.ObjectTypeId),
                ObjectUrl = objectUrl,
                PublicationYear = dataObject.PublicationYear,
                LangCode = dataObject.LangCode,
                ManagingOrganisation = new ManagingOrg()
                {
                    Id = dataObject.ManagingOrgId,
                    Name = dataObject.ManagingOrg,
                    RorId = dataObject.ManagingOrgRorId
                },
                AccessType = await _lupRepository.GetObjectAccessType(dataObject.AccessTypeId),
                AccessDetails = new AccessDetails()
                {
                    Description = dataObject.AccessDetails,
                    Url = dataObject.AccessDetailsUrl,
                    UrlLastChecked = null
                },
                EoscCategory = dataObject.EoscCategory,
                DatasetRecordKeys = await _dataMapper.MapDatasetRecordKeys(objectDataset),
                DatasetConsent = await _dataMapper.MapDatasetConsent(objectDataset),
                DatasetDeidentLevel = await _dataMapper.MapDatasetDeidentLevel(objectDataset),
                ObjectInstances = await _dataMapper.MapObjectInstances(await _objectRepository.GetObjectInstances(dataObject.Id)),
                ObjectTitles = await _dataMapper.MapObjectTitles(await _objectRepository.GetObjectTitles(dataObject.Id)),
                ObjectDates = await _dataMapper.MapObjectDates(await _objectRepository.GetObjectDates(dataObject.Id)),
                ObjectContributors = await _dataMapper.MapObjectContributors(await _objectRepository.GetObjectContributors(dataObject.Id)),
                ObjectTopics = await _dataMapper.MapObjectTopics(await _objectRepository.GetObjectTopics(dataObject.Id)),
                ObjectIdentifiers = await _dataMapper.MapObjectIdentifiers(await _objectRepository.GetObjectIdentifiers(dataObject.Id)),
                ObjectDescriptions = await _dataMapper.MapObjectDescriptions(await _objectRepository.GetObjectDescriptions(dataObject.Id)),
                ObjectRights = _dataMapper.MapObjectRights(await _objectRepository.GetObjectRights(dataObject.Id)),
                ObjectRelationships = await _dataMapper.MapObjectRelationships(await _objectRepository.GetObjectRelationships(dataObject.Id)),
                LinkedStudies = await _linksRepository.GetObjectStudies(dataObject.Id),
                ProvenanceString = dataObject.ProvenanceString
            };
        }

        public async Task<ICollection<ObjectListResponse>> BuildObjectResponse(ICollection<DataObject> dataObjects)
        {
            var objectListResponse = new List<ObjectListResponse>();
            foreach (var obj in dataObjects)
            {
                objectListResponse.Add(await BuildSingleObjectResponse(obj));
            }

            return objectListResponse;
        }
    }
}