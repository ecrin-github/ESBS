using System.Collections.Generic;
using MdrService.Contracts.Responses.v1.ApiResponse.StudyListResponse;
using MdrService.Contracts.Responses.v1.ApiResponse.ObjectListResponse;
using MdrService.Models.Elasticsearch.Object;
using MdrService.Models.Elasticsearch.Study;

namespace MdrService.Interfaces
{
    public interface IElasticsearchDataMapper
    {
        ICollection<StudyFeatureListResponse> MapStudyFeatures(ICollection<StudyFeature> studyFeatures);
        
        ICollection<StudyIdentifierListResponse> MapStudyIdentifiers(
            ICollection<StudyIdentifier> studyIdentifiers);
        
        ICollection<StudyRelationListResponse> MapStudyRelationships(
            ICollection<StudyRelation> studyRelationships);

        ICollection<StudyTitleListResponse> MapStudyTitles(ICollection<StudyTitle> studyTitles);

        ICollection<StudyTopicListResponse> MapStudyTopics(ICollection<StudyTopic> studyTopics);
        
        
        // Object mappers
        ICollection<ObjectContributorListResponse> MapObjectContributors(
            ICollection<ObjectContributor> objectContributors);

        Contracts.Responses.v1.Common.DatasetRecordKeys MapDatasetRecordKeys(DatasetRecordKeys datasetRecordKeys);
        
        Contracts.Responses.v1.Common.DatasetDeidentLevel MapDatasetDeidentLevel(DatasetDeidentLevel datasetDeidentLevel);
        
        Contracts.Responses.v1.Common.DatasetConsent MapDatasetConsent(DatasetConsent datasetConsent);
        
        ICollection<ObjectDateListResponse> MapObjectDates(ICollection<ObjectDate> objectDates);

        ICollection<ObjectDescriptionListResponse> MapObjectDescriptions(
            ICollection<ObjectDescription> objectDescriptions);

        ICollection<ObjectIdentifierListResponse> MapObjectIdentifiers(
            ICollection<ObjectIdentifier> objectIdentifiers);

        ICollection<ObjectInstanceListResponse> MapObjectInstances(ICollection<ObjectInstance> objectInstances);

        ICollection<ObjectRelationshipListResponse> MapObjectRelationships(
            ICollection<ObjectRelationship> objectRelationships);

        ICollection<ObjectRightListResponse> MapObjectRights(ICollection<ObjectRight> objectRights);

        ICollection<ObjectTitleListResponse> MapObjectTitles(ICollection<ObjectTitle> objectTitles);

        ICollection<ObjectTopicListResponse> MapObjectTopics(ICollection<ObjectTopic> objectTopics);
    }
}