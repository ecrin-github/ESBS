using System.Collections.Generic;
using System.Linq;
using MdrService.Contracts.Responses.v1.ObjectListResponse;
using MdrService.Contracts.Responses.v1.StudyListResponse;
using MdrService.Interfaces;
using MdrService.Models.Elasticsearch.Object;
using MdrService.Models.Elasticsearch.Study;


namespace MdrService.Helpers
{
    public class DataMapper : IDataMapper
    {
        private static bool HasProperty(object obj, string propertyName)
        {
            if (obj == null) return false;
            return obj.GetType().GetProperty(propertyName) != null;
        }

        private ICollection<StudyIdentifierListResponse> StudyIdentifierListResponseMapper(ICollection<StudyIdentifier> studyIdentifiers)
        {
            if (studyIdentifiers is not { Count: > 0 }) return null;
            ICollection<StudyIdentifierListResponse> studyIdentifierListResponses =
                new List<StudyIdentifierListResponse>();
            
            foreach (var studyIdentifier in studyIdentifiers)
            {

                string identifierType = null;
                if (HasProperty(studyIdentifier, "IdentifierType"))
                {
                    if (HasProperty(studyIdentifier.IdentifierType, "Name"))
                    {
                        identifierType = studyIdentifier.IdentifierType?.Name;
                    }
                }

                var studyIdentifierObject = new StudyIdentifierListResponse
                {
                    Id = studyIdentifier.Id,
                    IdentifierValue = studyIdentifier.IdentifierValue,
                    IdentifierType = identifierType,
                    IdentifierDate = studyIdentifier.IdentifierDate,
                    IdentifierLink = studyIdentifier.IdentifierLink,
                    IdentifierOrg = studyIdentifier.IdentifierOrg
                };
                
                studyIdentifierListResponses.Add(studyIdentifierObject);
            }

            return studyIdentifierListResponses;

        }


        private ICollection<StudyTitleListResponse> StudyTitleListResponseMapper(ICollection<StudyTitle> studyTitles)
        {
            if (studyTitles is not { Count: > 0 }) return null;
            var studyTitleListResponses = new List<StudyTitleListResponse>();

            foreach (var studyTitle in studyTitles)
            {
                
                string titleType = null;
                if (HasProperty(studyTitle, "TitleType"))
                {
                    if (HasProperty(studyTitle.TitleType, "Name"))
                    {
                        titleType = studyTitle.TitleType?.Name;
                    }
                }
                
                var studyTitleObject = new StudyTitleListResponse
                {
                    Id = studyTitle.Id,
                    TitleType = titleType,
                    TitleText = studyTitle.TitleText,
                    LangCode = studyTitle.LangCode,
                    Comments = studyTitle.Comments
                };
                studyTitleListResponses.Add(studyTitleObject);
            }

            return studyTitleListResponses;
        }


        private ICollection<StudyFeatureListResponse> StudyFeatureListResponseMapper(ICollection<StudyFeature> studyFeatures)
        {
            if (studyFeatures is not { Count: > 0 }) return null;
            var studyFeatureListResponses = new List<StudyFeatureListResponse>();

            foreach (var studyFeature in studyFeatures)
            {
                string featureType = null;
                if (HasProperty(studyFeature, "FeatureType"))
                {
                    if (HasProperty(studyFeature.FeatureType, "Name"))
                    {
                        featureType = studyFeature.FeatureType?.Name;
                    }
                }
                
                string featureValue = null;
                if (HasProperty(studyFeature, "FeatureValue"))
                {
                    if (HasProperty(studyFeature.FeatureValue, "Name"))
                    {
                        featureValue = studyFeature.FeatureValue?.Name;
                    }
                }
                
                var studyFeatureObject = new StudyFeatureListResponse
                {
                    Id = studyFeature.Id,
                    FeatureType = featureType,
                    FeatureValue = featureValue
                };
                studyFeatureListResponses.Add(studyFeatureObject);
            }

            return studyFeatureListResponses;
        }

        private ICollection<StudyTopicListResponse> StudyTopicResponseMapper(ICollection<StudyTopic> studyTopics)
        {
            if (studyTopics is not { Count: > 0 }) return null;
            var studyTopicListResponses = new List<StudyTopicListResponse>();

            foreach (var studyTopic in studyTopics)
            {
                string topicType = null;
                if (HasProperty(studyTopic, "TopicType"))
                {
                    if (HasProperty(studyTopic.TopicType, "Name"))
                    {
                        topicType = studyTopic.TopicType?.Name;
                    }
                }
                
                var studyTopicObject = new StudyTopicListResponse
                {
                    Id = studyTopic.Id,
                    TopicType = topicType,
                    MeshCoded = studyTopic.MeshCoded,
                    MeshCode = studyTopic.MeshCode,
                    MeshValue = studyTopic.MeshValue,
                    OriginalCtId = studyTopic.OriginalCtId,
                    OriginalCtCode = studyTopic.OriginalCtCode,
                    OriginalValue = studyTopic.OriginalValue
                };
                studyTopicListResponses.Add(studyTopicObject);
            }
            
            return studyTopicListResponses;
        }


        private ICollection<StudyRelationListResponse> StudyRelationListResponseMapper(
            ICollection<StudyRelation> studyRelations)
        {
            if (studyRelations is not { Count: > 0 }) return null;
            var studyRelationListResponses = new List<StudyRelationListResponse>();

            foreach (var studyRelation in studyRelations)
            {
                string relationName = null;
                if (HasProperty(studyRelation, "RelationshipType"))
                {
                    if (HasProperty(studyRelation.RelationshipType, "Name"))
                    {
                        relationName = studyRelation.RelationshipType?.Name;
                    }
                }
                
                var studyRelationObject = new StudyRelationListResponse
                {
                    Id = studyRelation.Id,
                    RelationshipType = relationName,
                    TargetStudyId = studyRelation.TargetStudyId
                };
                studyRelationListResponses.Add(studyRelationObject);
            }
            
            return studyRelationListResponses;
        }


        private static string ObjectUrlExtraction(ICollection<ObjectInstance> objectInstances)
        {
            string objectUrlString = null;
            if (objectInstances is not { Count: > 0 and > 0 }) return null;
            if (!string.IsNullOrEmpty(objectInstances.First().AccessDetails!.Url))
            {
                objectUrlString = objectInstances.First().AccessDetails!.Url;
            }

            return objectUrlString;
        }


        private ICollection<ObjectContributorListResponse> ObjectContributorListResponseMapper(ICollection<ObjectContributor> objectContributors)
        {
            if (objectContributors is not { Count: > 0 }) return null;
            var objectContributorListResponses = new List<ObjectContributorListResponse>();

            foreach (var objectContributor in objectContributors)
            {
                string contributorType = null;
                if (HasProperty(objectContributor, "ContributionType"))
                {
                    if (HasProperty(objectContributor.ContributionType, "Name"))
                    {
                        contributorType = objectContributor.ContributionType?.Name;
                    }
                }
                
                var objectContributorRecord = new ObjectContributorListResponse
                {
                    Id = objectContributor.Id,
                    ContributionType = contributorType,
                    IsIndividual = objectContributor.IsIndividual,
                    Organisation = objectContributor.Organisation,
                    Person = objectContributor.Person
                };
                objectContributorListResponses.Add(objectContributorRecord);
            }

            return objectContributorListResponses;
        }
        
        
        private ICollection<ObjectDateListResponse> ObjectDateListResponseMapper(ICollection<ObjectDate> objectDates)
        {
            if (objectDates is not { Count: > 0 }) return null;
            var objectDateListResponses = new List<ObjectDateListResponse>();
            foreach (var objectDate in objectDates)
            {
                string dateType = null;
                if (HasProperty(objectDate, "DateType"))
                {
                    if (HasProperty(objectDate.DateType, "name"))
                    {
                        dateType = objectDate.DateType?.Name;
                    }
                }
                
                var objectDateRecord = new ObjectDateListResponse
                {
                    Id = objectDate.Id,
                    DateType = dateType,
                    DateIsRange = objectDate.DateIsRange,
                    DateAsString = objectDate.DateAsString,
                    StartDate = objectDate.StartDate,
                    EndDate = objectDate.EndDate,
                    Comments = objectDate.Comments
                };
                objectDateListResponses.Add(objectDateRecord);
            }

            return objectDateListResponses;
        }
        
        
        private ICollection<ObjectDescriptionListResponse> ObjectDescriptionListResponseMapper(ICollection<ObjectDescription> objectDescriptions)
        {
            if (objectDescriptions is not { Count: > 0 }) return null;
            var objectDescriptionListResponses = new List<ObjectDescriptionListResponse>();

            foreach (var objectDescription in objectDescriptions)
            {
                string descriptionType = null;
                if (HasProperty(objectDescription, "DescriptionType"))
                {
                    if (HasProperty(objectDescription.DescriptionType, "Name"))
                    {
                        descriptionType = objectDescription.DescriptionType?.Name;
                    }
                }
                
                var objectDescriptionRecord = new ObjectDescriptionListResponse
                {
                    Id = objectDescription.Id,
                    DescriptionType = descriptionType,
                    DescriptionLabel = objectDescription.DescriptionLabel,
                    DescriptionText = objectDescription.DescriptionText,
                    LangCode = objectDescription.LangCode
                };
                objectDescriptionListResponses.Add(objectDescriptionRecord);
            }
            
            return objectDescriptionListResponses;
        }
        
        
        private ICollection<ObjectIdentifierListResponse> ObjectIdentifierListResponseMapper(ICollection<ObjectIdentifier> objectIdentifiers)
        {
            if (objectIdentifiers is not { Count: > 0 }) return null;
            var objectIdentifierListResponses = new List<ObjectIdentifierListResponse>();

            foreach (var objectIdentifier in objectIdentifiers)
            {
                string identifierType = null;
                if (HasProperty(objectIdentifier, "IdentifierType"))
                {
                    if (HasProperty(objectIdentifier.IdentifierType, "Name"))
                    {
                        identifierType = objectIdentifier.IdentifierType?.Name;
                    }
                }
                
                var objectIdentifierRecord = new ObjectIdentifierListResponse
                {
                    Id = objectIdentifier.Id,
                    IdentifierValue = objectIdentifier.IdentifierValue,
                    IdentifierType = identifierType,
                    IdentifierDate = objectIdentifier.IdentifierDate,
                    IdentifierOrg = objectIdentifier.IdentifierOrg
                };
                objectIdentifierListResponses.Add(objectIdentifierRecord);
            }

            return objectIdentifierListResponses;
        }
        
        
        private ICollection<ObjectInstanceListResponse> ObjectInstanceListResponseMapper(ICollection<ObjectInstance> objectInstances)
        {
            if (objectInstances is not { Count: > 0 }) return null;

            var objectInstanceListResponses = new List<ObjectInstanceListResponse>();

            foreach (var objectInstance in objectInstances)
            {
                string repositoryOrg = null;
                if (HasProperty(objectInstance, "RepositoryOrg"))
                {
                    if (HasProperty(objectInstance.RepositoryOrg, "Name"))
                    {
                        repositoryOrg = objectInstance.RepositoryOrg?.Name;
                    }
                }
                
                var objectInstanceRecord = new ObjectInstanceListResponse
                {
                    Id = objectInstance.Id,
                    RepositoryOrg = repositoryOrg,
                    AccessDetails = objectInstance.AccessDetails,
                    ResourceDetails = objectInstance.ResourceDetails
                };
                objectInstanceListResponses.Add(objectInstanceRecord);
            }

            return objectInstanceListResponses;
        }
        
        
        private ICollection<ObjectRelationshipListResponse> ObjectRelationshipListResponseMapper(ICollection<ObjectRelationship> objectRelationships)
        {
            if (objectRelationships is not { Count: > 0 }) return null;
            var objectRelationshipListResponses = new List<ObjectRelationshipListResponse>();

            foreach (var objectRelation in objectRelationships)
            {
                string relationName = null;
                if (HasProperty(objectRelation, "RelationshipType"))
                {
                    if (HasProperty(objectRelation.RelationshipType, "Name"))
                    {
                        relationName = objectRelation.RelationshipType?.Name;
                    }
                }
                
                var objectRelationRecord = new ObjectRelationshipListResponse
                {
                    Id = objectRelation.Id,
                    RelationshipType = relationName,
                    TargetObjectId = objectRelation.TargetObjectId
                };
                objectRelationshipListResponses.Add(objectRelationRecord);
            }
            
            return objectRelationshipListResponses;
        }
        
        
        private ICollection<ObjectRightListResponse> ObjectRightListResponseMapper(ICollection<ObjectRight> objectRights)
        {
            return objectRights is not { Count: > 0 } ? null : objectRights.Select(objectRight => new ObjectRightListResponse { Id = objectRight.Id, RightsName = objectRight.RightsName, RightsUrl = objectRight.RightsUrl, Comments = objectRight.Comments }).ToList();
        }
        
        
        private ICollection<ObjectTitleListResponse> ObjectTitleListResponseMapper(ICollection<ObjectTitle> objectTitles)
        {
            if (objectTitles is not { Count: > 0 }) return null;
            var objectTitleListResponses = new List<ObjectTitleListResponse>();

            foreach (var objectTitle in objectTitles)
            {
                string titleType = null;
                if (HasProperty(objectTitle, "TitleType"))
                {
                    if (HasProperty(objectTitle.TitleType, "Name"))
                    {
                        titleType = objectTitle.TitleType?.Name;
                    }
                }
                
                var objectTitleRecord = new ObjectTitleListResponse
                {
                    Id = objectTitle.Id,
                    TitleType = titleType,
                    TitleText = objectTitle.TitleText,
                    LangCode = objectTitle.LangCode,
                    Comments = objectTitle.Comments
                };
                objectTitleListResponses.Add(objectTitleRecord);
            }

            return objectTitleListResponses;
        }
        
        
        private ICollection<ObjectTopicListResponse> ObjectTopicListResponseMapper(ICollection<ObjectTopic> objectTopics)
        {
            if (objectTopics is not { Count: > 0 }) return null;
            var objectTopicListResponses = new List<ObjectTopicListResponse>();

            foreach (var objectTopic in objectTopics)
            {
                string topicType = null;
                if (HasProperty(objectTopic, "TopicType"))
                {
                    if (HasProperty(objectTopic.TopicType, "Name"))
                    {
                        topicType = objectTopic.TopicType?.Name;
                    }
                }
                
                var objectTopicRecord = new ObjectTopicListResponse
                {
                    Id = objectTopic.Id,
                    TopicType = topicType,
                    MeshCoded = objectTopic.MeshCoded,
                    MeshCode = objectTopic.MeshCode,
                    MeshValue = objectTopic.MeshValue,
                    OriginalCtId = objectTopic.OriginalCtId,
                    OriginalCtCode = objectTopic.OriginalCtCode,
                    OriginalValue = objectTopic.OriginalValue
                };
                objectTopicListResponses.Add(objectTopicRecord);
            }

            return objectTopicListResponses;
        }


        private ICollection<ObjectListResponse> ObjectListResponseMapper(ICollection<Object> objects)
        {
            if (objects is not { Count: > 0 }) return null;
            var objectListResponses = new List<ObjectListResponse>();

            foreach (var objectRecord in objects)
            {
                
                string objectType = null;
                if (HasProperty(objectRecord, "ObjectType"))
                {
                    if (HasProperty(objectRecord.ObjectType, "Name"))
                    {
                        objectType = objectRecord.ObjectType?.Name;
                    }
                }
                
                string objectClass = null;
                if (HasProperty(objectRecord, "ObjectClass"))
                {
                    if (HasProperty(objectRecord.ObjectClass, "Name"))
                    {
                        objectClass = objectRecord.ObjectClass?.Name;
                    }
                }
                
                var objectDto = new ObjectListResponse
                {
                    Id = objectRecord.Id,
                    Doi = objectRecord.Doi,
                    DisplayTitle = objectRecord.DisplayTitle,
                    Version = objectRecord.Version,
                    ObjectClass = objectClass,
                    ObjectType = objectType,
                    ObjectUrl = ObjectUrlExtraction(objectRecord.ObjectInstances),
                    PublicationYear = objectRecord.PublicationYear,
                    LangCode = objectRecord.LangCode,
                    ManagingOrganisation = objectRecord.ManagingOrganisation,
                    AccessType = objectRecord.AccessType?.Name,
                    AccessDetails = objectRecord.AccessDetails,
                    EoscCategory = objectRecord.EoscCategory,
                    DatasetRecordKeys = objectRecord.DatasetRecordKeys,
                    DatasetConsent = objectRecord.DatasetConsent,
                    DatasetDeidentLevel = objectRecord.DatasetDeidentLevel,
                    ObjectInstances = ObjectInstanceListResponseMapper(objectRecord.ObjectInstances),
                    ObjectTitles = ObjectTitleListResponseMapper(objectRecord.ObjectTitles),
                    ObjectDates = ObjectDateListResponseMapper(objectRecord.ObjectDates),
                    ObjectContributors = ObjectContributorListResponseMapper(objectRecord.ObjectContributors),
                    ObjectTopics = ObjectTopicListResponseMapper(objectRecord.ObjectTopics),
                    ObjectIdentifiers = ObjectIdentifierListResponseMapper(objectRecord.ObjectIdentifiers),
                    ObjectDescriptions = ObjectDescriptionListResponseMapper(objectRecord.ObjectDescriptions),
                    ObjectRights = ObjectRightListResponseMapper(objectRecord.ObjectRights),
                    ObjectRelationships = ObjectRelationshipListResponseMapper(objectRecord.ObjectRelationships),
                    LinkedStudies = objectRecord.LinkedStudies,
                    ProvenanceString = objectRecord.ProvenanceString
                };
                objectListResponses.Add(objectDto);
            }

            return objectListResponses;
        }


        public List<StudyListResponse> MapStudies(IEnumerable<Study> studies)
        {
            var studiesDto = new List<StudyListResponse>();
            foreach (var study in studies)
            {
                MinAgeResponse minAgeResponse = null;
                if (study.MinAge != null)
                {
                    minAgeResponse = new MinAgeResponse
                    {
                        Value = study.MinAge.Value,
                        UnitName = study.MinAge.UnitName
                    };
                }

                MaxAgeResponse maxAgeResponse = null;
                if (study.MaxAge != null)
                {
                    maxAgeResponse = new MaxAgeResponse
                    {
                        Value = study.MaxAge.Value,
                        UnitName = study.MaxAge.UnitName
                    };
                }
            
                var studyDto = new StudyListResponse
                {
                    Id = study.Id!,
                    DisplayTitle = study.DisplayTitle,
                    BriefDescription = study.BriefDescription,
                    StudyType = study.StudyType?.Name,
                    StudyStatus = study.StudyStatus?.Name,
                    StudyGenderElig = study.StudyGenderElig?.Name,
                    StudyEnrolment = study.StudyEnrolment,
                    MinAge = minAgeResponse,
                    MaxAge = maxAgeResponse,
                    StudyIdentifiers = StudyIdentifierListResponseMapper(study.StudyIdentifiers),
                    StudyTitles = StudyTitleListResponseMapper(study.StudyTitles),
                    StudyFeatures = StudyFeatureListResponseMapper(study.StudyFeatures),
                    StudyTopics = StudyTopicResponseMapper(study.StudyTopics),
                    StudyRelationships = StudyRelationListResponseMapper(study.StudyRelationships),
                    ProvenanceString = study.ProvenanceString,
                    LinkedDataObjects = ObjectListResponseMapper(study.LinkedDataObjects),
                };
                studiesDto.Add(studyDto);
            }
            
            return studiesDto;
        }

    }
}