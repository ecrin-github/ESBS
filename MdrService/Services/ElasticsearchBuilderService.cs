using System;
using System.Collections.Generic;
using System.Linq;
using MdrService.Contracts.Responses.v1.ApiResponse.ObjectListResponse;
using MdrService.Contracts.Responses.v1.ApiResponse.StudyListResponse;
using MdrService.Interfaces;
using MdrService.Models.Elasticsearch.Object;
using MdrService.Models.Elasticsearch.Study;

namespace MdrService.Services
{
    public class ElasticsearchBuilderService : IElasticsearchBuilderService
    {
        private static IElasticsearchDataMapper _elasticsearchDataMapper;

        public ElasticsearchBuilderService(IElasticsearchDataMapper elasticsearchDataMapper)
        {
            _elasticsearchDataMapper = elasticsearchDataMapper ??
                                       throw new ArgumentNullException(nameof(elasticsearchDataMapper));
        }
        
        private static string ObjectUrlExtraction(ICollection<ObjectInstance> objectInstances)
        {
            string objectUrlString = null;
            if (objectInstances is not { Count: > 0 }) return null;
            if (!string.IsNullOrEmpty(objectInstances.First().AccessDetails?.Url))
            {
                objectUrlString = objectInstances.First().AccessDetails?.Url;
            }

            return objectUrlString;
        }
        
        public ObjectListResponse BuildElasticsearchObjectResponse(DataObject dataObject)
        {
            if (dataObject == null) return null;
            return new ObjectListResponse()
            {
                Id = dataObject.Id,
                Doi = dataObject.Doi,
                DisplayTitle = dataObject.DisplayTitle,
                Version = dataObject.Version,
                ObjectClass = dataObject.ObjectClass?.Name,
                ObjectType = dataObject.ObjectType?.Name,
                ObjectUrl = ObjectUrlExtraction(dataObject.ObjectInstances),
                PublicationYear = dataObject.PublicationYear,
                LangCode = dataObject.LangCode,
                ManagingOrganisation = new MdrService.Contracts.Responses.v1.Common.ManagingOrg()
                {
                    Id = dataObject.ManagingOrganisation?.Id,
                    Name = dataObject.ManagingOrganisation?.Name,
                    RorId = dataObject.ManagingOrganisation?.RorId
                },
                AccessType = dataObject.AccessType?.Name,
                AccessDetails = new MdrService.Contracts.Responses.v1.Common.AccessDetails()
                {
                    Description = dataObject.AccessDetails?.Description,
                    Url = dataObject.AccessDetails?.Url,
                    UrlLastChecked = dataObject.AccessDetails?.UrlLastChecked
                },
                EoscCategory = dataObject.EoscCategory,
                DatasetRecordKeys = _elasticsearchDataMapper.MapDatasetRecordKeys(dataObject.DatasetRecordKeys),
                DatasetDeidentLevel = _elasticsearchDataMapper.MapDatasetDeidentLevel(dataObject.DatasetDeidentLevel),
                DatasetConsent = _elasticsearchDataMapper.MapDatasetConsent(dataObject.DatasetConsent),
                ObjectContributors = _elasticsearchDataMapper.MapObjectContributors(dataObject.ObjectContributors),
                ObjectDates = _elasticsearchDataMapper.MapObjectDates(dataObject.ObjectDates),
                ObjectDescriptions = _elasticsearchDataMapper.MapObjectDescriptions(dataObject.ObjectDescriptions),
                ObjectIdentifiers = _elasticsearchDataMapper.MapObjectIdentifiers(dataObject.ObjectIdentifiers),
                ObjectInstances = _elasticsearchDataMapper.MapObjectInstances(dataObject.ObjectInstances),
                ObjectRelationships = _elasticsearchDataMapper.MapObjectRelationships(dataObject.ObjectRelationships),
                ObjectRights = _elasticsearchDataMapper.MapObjectRights(dataObject.ObjectRights),
                ObjectTitles = _elasticsearchDataMapper.MapObjectTitles(dataObject.ObjectTitles),
                ObjectTopics = _elasticsearchDataMapper.MapObjectTopics(dataObject.ObjectTopics),
                LinkedStudies = dataObject.LinkedStudies,
                ProvenanceString = dataObject.ProvenanceString
            };
        }
        
        public IEnumerable<ObjectListResponse> BuildElasticsearchObjectListResponse(IEnumerable<DataObject> dataObjects)
        {
            if (dataObjects == null) return null;
            var enumerable = dataObjects as DataObject[] ?? dataObjects.ToArray();
            return enumerable.Any() ? null : enumerable.Select(BuildElasticsearchObjectResponse).ToList();
        }

        public StudyListResponse BuildElasticsearchStudyResponse(Study study)
        {
            if (study == null) return null;
            return new StudyListResponse()
            {
                Id = study.Id,
                DisplayTitle = study.DisplayTitle,
                BriefDescription = study.BriefDescription,
                StudyType = study.StudyType?.Name,
                StudyStatus = study.StudyStatus?.Name,
                StudyGenderElig = study.StudyGenderElig?.Name,
                StudyEnrolment = study.StudyEnrolment,
                MinAge = new MinAgeResponse()
                {
                    UnitName = study.MinAge?.UnitName,
                    Value = study.MinAge?.Value
                },
                MaxAge = new MaxAgeResponse()
                {
                    UnitName = study.MaxAge?.UnitName,
                    Value = study.MaxAge?.Value
                },
                StudyIdentifiers = _elasticsearchDataMapper.MapStudyIdentifiers(study.StudyIdentifiers),
                StudyFeatures = _elasticsearchDataMapper.MapStudyFeatures(study.StudyFeatures),
                StudyRelationships = _elasticsearchDataMapper.MapStudyRelationships(study.StudyRelationships),
                StudyTitles = _elasticsearchDataMapper.MapStudyTitles(study.StudyTitles),
                StudyTopics = _elasticsearchDataMapper.MapStudyTopics(study.StudyTopics),
                ProvenanceString = study.ProvenanceString
            };
        }

        public ICollection<StudyListResponse> BuildElasticsearchStudyListResponse(ICollection<Study> studies)
        {
            return studies is { Count: <= 0 } ? null : studies.Select(BuildElasticsearchStudyResponse).ToList();
        }
    }
}