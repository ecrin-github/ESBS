using System.Collections.Generic;
using System.Threading.Tasks;
using MdrService.Contracts.Responses.v1.Common;
using MdrService.Contracts.Responses.v1.ObjectListResponse;
using MdrService.Contracts.Responses.v1.StudyListResponse;
using MdrService.Models.Object;
using MdrService.Models.Study;

namespace MdrService.Interfaces
{
    public interface IDataMapper
    {
        // Study mappers
        Task<ICollection<StudyFeatureListResponse>> MapStudyFeatures(ICollection<StudyFeature> studyFeatures);
        
        Task<ICollection<StudyIdentifierListResponse>> MapStudyIdentifiers(
            ICollection<StudyIdentifier> studyIdentifiers);
        
        Task<ICollection<StudyRelationListResponse>> MapStudyRelationships(
            ICollection<StudyRelationship> studyRelationships);

        Task<ICollection<StudyTitleListResponse>> MapStudyTitles(ICollection<StudyTitle> studyTitles);

        Task<ICollection<StudyTopicListResponse>> MapStudyTopics(ICollection<StudyTopic> studyTopics);
        
        
        // Object mappers
        Task<ICollection<ObjectContributorListResponse>> MapObjectContributors(
            ICollection<ObjectContributor> objectContributors);

        Task<DatasetRecordKeys> MapDatasetRecordKeys(ObjectDataset objectDataset);
        
        Task<DatasetDeidentLevel> MapDatasetDeidentLevel(ObjectDataset objectDataset);
        
        Task<DatasetConsent> MapDatasetConsent(ObjectDataset objectDataset);
        
        Task<ICollection<ObjectDateListResponse>> MapObjectDates(ICollection<ObjectDate> objectDates);

        Task<ICollection<ObjectDescriptionListResponse>> MapObjectDescriptions(
            ICollection<ObjectDescription> objectDescriptions);

        Task<ICollection<ObjectIdentifierListResponse>> MapObjectIdentifiers(
            ICollection<ObjectIdentifier> objectIdentifiers);

        Task<ICollection<ObjectInstanceListResponse>> MapObjectInstances(ICollection<ObjectInstance> objectInstances);

        Task<ICollection<ObjectRelationshipListResponse>> MapObjectRelationships(
            ICollection<ObjectRelationship> objectRelationships);

        ICollection<ObjectRightListResponse> MapObjectRights(ICollection<ObjectRight> objectRights);

        Task<ICollection<ObjectTitleListResponse>> MapObjectTitles(ICollection<ObjectTitle> objectTitles);

        Task<ICollection<ObjectTopicListResponse>> MapObjectTopics(ICollection<ObjectTopic> objectTopics);
    }
}