using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MdrService.Configs;
using MdrService.Contracts.Responses.v1.Common;
using MdrService.Contracts.Responses.v1.ObjectListResponse;
using MdrService.Contracts.Responses.v1.SearchServiceResponse;
using MdrService.Contracts.Responses.v1.StudyListResponse;
using MdrService.Interfaces;
using MdrService.Models.Object;
using MdrService.Models.Study;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace MdrService.Services
{
    public class BuilderService : IBuilderService
    {
        private readonly IDataMapper _dataMapper;
        private readonly IContextService _context;

        private readonly IStudyRepository _studyRepository;
        private readonly IObjectRepository _objectRepository;

        private readonly ILinksRepository _linksRepository;

        private readonly IDistributedCache _distributedCache;
        
        public BuilderService(
            IDataMapper dataMapper,
            IContextService context,
            IStudyRepository studyRepository,
            IObjectRepository objectRepository,
            ILinksRepository linksRepository, 
            IDistributedCache distributedCache)
        {
            _dataMapper = dataMapper ?? throw new ArgumentNullException(nameof(dataMapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _studyRepository = studyRepository ?? throw new ArgumentNullException(nameof(studyRepository));
            _objectRepository = objectRepository ?? throw new ArgumentNullException(nameof(objectRepository));
            _linksRepository = linksRepository ?? throw new ArgumentNullException(nameof(linksRepository));
            _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
        }
        
        public async Task<StudyListResponse> BuildSingleStudyResponse(Study study)
        {
            var cacheKey = "mappedStudy_" + study.Id;

            StudyListResponse studyListResponse;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                studyListResponse = JsonConvert.DeserializeObject<StudyListResponse>(serializedValue);
            }
            else
            {
                var minAge = new MinAgeResponse();
                if (study.MinAge != null && study.MinAgeUnitsId != null)
                {
                    minAge.Value = study.MinAge;
                    minAge.UnitName = await _context.GetTimeUnitType(study.MinAgeUnitsId);
                }

                var maxAge = new MaxAgeResponse();
                if (study.MaxAge != null && study.MaxAgeUnitsId != null)
                {
                    maxAge.Value = study.MaxAge;
                    maxAge.UnitName = await _context.GetTimeUnitType(study.MaxAgeUnitsId);
                }
                
                
                studyListResponse = new StudyListResponse()
                {
                    Id = study.Id,
                    DisplayTitle = study.DisplayTitle,
                    BriefDescription = study.BriefDescription,
                    StudyType = await _context.GetStudyType(study.StudyTypeId),
                    StudyStatus = await _context.GetStudyStatus(study.StudyStatusId),
                    StudyGenderElig = await _context.GetGenderElig(study.StudyGenderEligId),
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
                
                serializedValue = JsonConvert.SerializeObject(studyListResponse);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);

            }

            return studyListResponse;

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
            var cacheKey = "mappedObject_" + dataObject.Id;

            ObjectListResponse objectListResponse;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                objectListResponse = JsonConvert.DeserializeObject<ObjectListResponse>(serializedValue);
            }
            else
            {
                var objectInstances = await _objectRepository.GetObjectInstances(dataObject.Id);

                string objectUrl;
                if (objectInstances is not { Count: > 0 }) objectUrl = null;
                objectUrl = ObjectUrlExtraction(objectInstances);
                
                var objectDataset = await _objectRepository.GetObjectDatasets(dataObject.Id);
                objectListResponse = new ObjectListResponse()
                {
                    Id = dataObject.Id,
                    Doi = dataObject.Doi,
                    DisplayTitle = dataObject.DisplayTitle,
                    Version = dataObject.Version,
                    ObjectClass = await _context.GetObjectClass(dataObject.ObjectClassId),
                    ObjectType = await _context.GetObjectType(dataObject.ObjectTypeId),
                    ObjectUrl = objectUrl,
                    PublicationYear = dataObject.PublicationYear,
                    LangCode = dataObject.LangCode,
                    ManagingOrganisation = new ManagingOrg()
                    {
                        Id = dataObject.ManagingOrgId,
                        Name = dataObject.ManagingOrg,
                        RorId = dataObject.ManagingOrgRorId
                    },
                    AccessType = await _context.GetAccessType(dataObject.AccessTypeId),
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
                serializedValue = JsonConvert.SerializeObject(objectListResponse);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }

            return objectListResponse;
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

        public async Task<SearchStudyListResponse> BuildSingleSearchStudyResponse(Study study)
        {
            var cacheKey = "mappedSearchStudy_" + study.Id;

            SearchStudyListResponse studyListResponse;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                studyListResponse = JsonConvert.DeserializeObject<SearchStudyListResponse>(serializedValue);
            }
            else
            {
                studyListResponse = new SearchStudyListResponse()
                {
                    Id = study.Id,
                    DisplayTitle = study.DisplayTitle,
                    BriefDescription = study.BriefDescription,
                    StudyType = await _context.GetStudyType(study.StudyTypeId),
                    StudyStatus = await _context.GetStudyStatus(study.StudyStatusId),
                    StudyGenderElig = await _context.GetGenderElig(study.StudyGenderEligId),
                    StudyEnrolment = study.StudyEnrolment,
                    ProvenanceString = study.ProvenanceString,
                    LinkedDataObjects = await BuildSearchObjectResponse(
                        await _objectRepository.GetDataObjects(
                            await _linksRepository.GetStudyObjects(study.Id)))
                };
                
                serializedValue = JsonConvert.SerializeObject(studyListResponse);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);

            }

            return studyListResponse;
        }

        public async Task<ICollection<SearchStudyListResponse>> BuildSearchStudyResponse(ICollection<Study> studies)
        {
            var studyListResponse = new List<SearchStudyListResponse>();
            foreach (var study in studies)
            {
                studyListResponse.Add(await BuildSingleSearchStudyResponse(study));
            }

            return studyListResponse;
        }

        public async Task<SearchDataObjectListResponse> BuildSingleSearchObjectResponse(DataObject dataObject)
        {
            var cacheKey = "mappedSearchObject_" + dataObject.Id;

            SearchDataObjectListResponse objectListResponse;
            string serializedValue;
            
            var encodedValue = await _distributedCache.GetAsync(cacheKey);
            if (encodedValue != null)
            {
                serializedValue = Encoding.UTF8.GetString(encodedValue);
                objectListResponse = JsonConvert.DeserializeObject<SearchDataObjectListResponse>(serializedValue);
            }
            else
            {
                var objectInstances = await _objectRepository.GetObjectInstances(dataObject.Id);

                string objectUrl;
                if (objectInstances is not { Count: > 0 }) objectUrl = null;
                objectUrl = ObjectUrlExtraction(objectInstances);
                
                objectListResponse = new SearchDataObjectListResponse()
                {
                    Id = dataObject.Id,
                    Doi = dataObject.Doi,
                    DisplayTitle = dataObject.DisplayTitle,
                    ObjectClass = await _context.GetObjectClass(dataObject.ObjectClassId),
                    ObjectType = await _context.GetObjectType(dataObject.ObjectTypeId),
                    ObjectUrl = objectUrl,
                    PublicationYear = dataObject.PublicationYear,
                    LangCode = dataObject.LangCode,
                    AccessType = await _context.GetAccessType(dataObject.AccessTypeId),
                    EoscCategory = dataObject.EoscCategory,
                    ObjectInstances = await _dataMapper.MapObjectInstances(await _objectRepository.GetObjectInstances(dataObject.Id)),
                    ProvenanceString = dataObject.ProvenanceString
                };
                serializedValue = JsonConvert.SerializeObject(objectListResponse);
                encodedValue = Encoding.UTF8.GetBytes(serializedValue);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(RedisConfig.SlidingExpirationData))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(RedisConfig.AbsoluteExpirationData));
                await _distributedCache.SetAsync(cacheKey, encodedValue, options);
            }

            return objectListResponse;
        }

        public async Task<ICollection<SearchDataObjectListResponse>> BuildSearchObjectResponse(ICollection<DataObject> dataObjects)
        {
            var objectListResponse = new List<SearchDataObjectListResponse>();
            foreach (var obj in dataObjects)
            {
                objectListResponse.Add(await BuildSingleSearchObjectResponse(obj));
            }

            return objectListResponse;
        }
    }
}