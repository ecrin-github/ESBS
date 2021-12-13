using System.Collections.Generic;
using System.Linq;
using MdrService.Contracts.Responses.v1.ApiResponse.ObjectListResponse;
using MdrService.Contracts.Responses.v1.ApiResponse.StudyListResponse;
using MdrService.Contracts.Responses.v1.Common;
using MdrService.Interfaces;
using MdrService.Models.Elasticsearch.Object;
using MdrService.Models.Elasticsearch.Study;
using ContribOrg = MdrService.Contracts.Responses.v1.Common.ContribOrg;
using Person = MdrService.Contracts.Responses.v1.Common.Person;
using Date = MdrService.Contracts.Responses.v1.Common.Date; 
using InstanceAccessDetails = MdrService.Contracts.Responses.v1.Common.InstanceAccessDetails;
using InstanceResourceDetails = MdrService.Contracts.Responses.v1.Common.InstanceResourceDetails;
using DatasetConsent = MdrService.Models.Elasticsearch.Object.DatasetConsent;
using DatasetDeidentLevel = MdrService.Models.Elasticsearch.Object.DatasetDeidentLevel;
using DatasetRecordKeys = MdrService.Models.Elasticsearch.Object.DatasetRecordKeys;

namespace MdrService.Helpers
{
    public class ElasticsearchDataMapper : IElasticsearchDataMapper
    {
        public ICollection<StudyFeatureListResponse> MapStudyFeatures(ICollection<StudyFeature> studyFeatures)
        {
            return studyFeatures?.Select(sf => new StudyFeatureListResponse
            {
                Id = sf.Id, 
                FeatureType = sf.FeatureType?.Name, 
                FeatureValue = sf.FeatureValue?.Name
            }).ToList();
        }

        public ICollection<StudyIdentifierListResponse> MapStudyIdentifiers(ICollection<StudyIdentifier> studyIdentifiers)
        {
            return studyIdentifiers?.Select(si => new StudyIdentifierListResponse()
                {
                    Id = si.Id,
                    IdentifierValue = si.IdentifierValue,
                    IdentifierType = si.IdentifierType?.Name,
                    IdentifierDate = si.IdentifierDate,
                    IdentifierOrg = new IdentifierOrg() { Id = si.IdentifierOrg?.Id, Name = si.IdentifierOrg?.Name, RorId = si.IdentifierOrg?.RorId },
                    IdentifierLink = si.IdentifierLink
                })
                .ToList();
        }

        public ICollection<StudyRelationListResponse> MapStudyRelationships(ICollection<StudyRelation> studyRelationships)
        {
            return studyRelationships?.Select(sr => new StudyRelationListResponse() { Id = sr.Id, RelationshipType = sr.RelationshipType?.Name, TargetStudyId = sr.TargetStudyId.ToString() }).ToList();
        }

        public ICollection<StudyTitleListResponse> MapStudyTitles(ICollection<StudyTitle> studyTitles)
        {
            return studyTitles?.Select(st => new StudyTitleListResponse()
            {
                Id = st.Id,
                TitleText = st.TitleText,
                TitleType = st.TitleType?.Name,
                LangCode = st.LangCode,
                Comments = st.Comments
            }).ToList();
        }

        public ICollection<StudyTopicListResponse> MapStudyTopics(ICollection<StudyTopic> studyTopics)
        {
            return studyTopics?.Select(st => new StudyTopicListResponse()
            {
                Id = st.Id,
                TopicType = st.TopicType?.Name,
                MeshCode = st.MeshCode,
                MeshCoded = st.MeshCoded,
                MeshValue = st.MeshValue,
                OriginalCtId = st.OriginalCtId,
                OriginalValue = st.OriginalValue,
                OriginalCtCode = st.OriginalCtCode
            }).ToList();
        }

        public ICollection<ObjectContributorListResponse> MapObjectContributors(ICollection<ObjectContributor> objectContributors)
        {
            return objectContributors?.Select(oc => new ObjectContributorListResponse()
            {
                Id = oc.Id,
                ContributionType = oc.ContributionType?.Name,
                IsIndividual = oc.IsIndividual,
                Organisation = new ContribOrg()
                {
                    Id = oc.Organisation?.Id,
                    Name = oc.Organisation?.Name,
                    RorId = oc.Organisation?.RorId
                },
                Person = new Person()
                {
                    FamilyName = oc.Person?.FamilyName,
                    GivenName = oc.Person?.GivenName,
                    FullName = oc.Person?.FullName,
                    Orcid = oc.Person?.Orcid,
                    AffiliationString = oc.Person?.AffiliationString,
                    AffiliationOrgId = oc.Person?.AffiliationOrgId,
                    AffiliationOrgName = oc.Person?.AffiliationOrgName,
                    AffiliationOrgRorId = oc.Person?.AffiliationOrgRorId
                }
            }).ToList();
        }

        public MdrService.Contracts.Responses.v1.Common.DatasetRecordKeys MapDatasetRecordKeys(DatasetRecordKeys datasetRecordKeys)
        {
            if (datasetRecordKeys == null) return null;
            return new MdrService.Contracts.Responses.v1.Common.DatasetRecordKeys()
            {
                KeysTypeId = datasetRecordKeys.KeysTypeId,
                KeysType = datasetRecordKeys.KeysType,
                KeysDetails = datasetRecordKeys.KeysDetails
            };
        }

        public MdrService.Contracts.Responses.v1.Common.DatasetDeidentLevel MapDatasetDeidentLevel(DatasetDeidentLevel datasetDeidentLevel)
        {
            if (datasetDeidentLevel == null) return null;
            return new MdrService.Contracts.Responses.v1.Common.DatasetDeidentLevel()
            {
                DeidentTypeId = datasetDeidentLevel.DeidentTypeId,
                DeidentType = datasetDeidentLevel.DeidentType,
                DeidentDirect = datasetDeidentLevel.DeidentDirect,
                DeidentHipaa = datasetDeidentLevel.DeidentHipaa,
                DeidentDates = datasetDeidentLevel.DeidentDates,
                DeidentNonarr = datasetDeidentLevel.DeidentNonarr,
                DeidentKanon = datasetDeidentLevel.DeidentKanon,
                DeidentDetails = datasetDeidentLevel.DeidentDetails
            };
        }

        public MdrService.Contracts.Responses.v1.Common.DatasetConsent MapDatasetConsent(DatasetConsent datasetConsent)
        {
            if (datasetConsent == null) return null;
            return new MdrService.Contracts.Responses.v1.Common.DatasetConsent()
            {
                ConsentTypeId = datasetConsent.ConsentTypeId,
                ConsentType = datasetConsent.ConsentType,
                ConsentNoncommercial = datasetConsent.ConsentNoncommercial,
                ConsentGeogRestrict = datasetConsent.ConsentGeogRestrict,
                ConsentResearchType = datasetConsent.ConsentResearchType,
                ConsentGeneticOnly = datasetConsent.ConsentGeneticOnly,
                ConsentNoMethods = datasetConsent.ConsentNoMethods,
                ConsentsDetails = datasetConsent.ConsentsDetails
            };
        }

        public ICollection<ObjectDateListResponse> MapObjectDates(ICollection<ObjectDate> objectDates)
        {
            return objectDates?.Select(od => new ObjectDateListResponse()
            {
                Id = od.Id,
                DateType = od.DateType?.Name,
                DateIsRange = od.DateIsRange,
                DateAsString = od.DateAsString,
                StartDate = new Date()
                {
                    Year = od.StartDate?.Year,
                    Month = od.StartDate?.Month,
                    Day = od.StartDate?.Day
                },
                EndDate = new Date()
                {
                    Year = od.EndDate?.Year,
                    Month = od.EndDate?.Month,
                    Day = od.EndDate?.Day
                },
                Comments = od.Comments
            }).ToList();
        }

        public ICollection<ObjectDescriptionListResponse> MapObjectDescriptions(ICollection<ObjectDescription> objectDescriptions)
        {
            return objectDescriptions?.Select(od => new ObjectDescriptionListResponse()
            {
                Id = od.Id,
                DescriptionType = od.DescriptionType?.Name,
                DescriptionLabel = od.DescriptionLabel,
                DescriptionText = od.DescriptionText,
                LangCode = od.LangCode
            }).ToList();
        }

        public ICollection<ObjectIdentifierListResponse> MapObjectIdentifiers(ICollection<ObjectIdentifier> objectIdentifiers)
        {
            return objectIdentifiers?.Select(oi => new ObjectIdentifierListResponse()
            {
                Id = oi.Id,
                IdentifierValue = oi.IdentifierValue,
                IdentifierType = oi.IdentifierType?.Name,
                IdentifierDate = oi.IdentifierDate,
                IdentifierOrg = new IdentifierOrg()
                {
                    Id = oi.IdentifierOrg?.Id,
                    Name = oi.IdentifierOrg?.Name,
                    RorId = oi.IdentifierOrg?.RorId
                }
            }).ToList();
        }

        public ICollection<ObjectInstanceListResponse> MapObjectInstances(ICollection<ObjectInstance> objectInstances)
        {
            return objectInstances?.Select(oi => new ObjectInstanceListResponse()
            {
                Id = oi.Id,
                RepositoryOrg = oi.RepositoryOrg?.Name,
                AccessDetails = new InstanceAccessDetails()
                {
                    DirectAccess = oi.AccessDetails?.DirectAccess,
                    Url = oi.AccessDetails?.Url,
                    UrlLastChecked = oi.AccessDetails?.UrlLastChecked
                },
                ResourceDetails = new InstanceResourceDetails()
                {
                    TypeId = oi.ResourceDetails?.TypeId,
                    TypeName = oi.ResourceDetails?.TypeName,
                    Size = oi.ResourceDetails?.Size.ToString(),
                    SizeUnit = oi.ResourceDetails?.SizeUnit,
                    Comments = oi.ResourceDetails?.Comments
                }
            }).ToList();
        }

        public ICollection<ObjectRelationshipListResponse> MapObjectRelationships(ICollection<ObjectRelationship> objectRelationships)
        {
            return objectRelationships?.Select(or => new ObjectRelationshipListResponse()
            {
                Id = or.Id,
                RelationshipType = or.RelationshipType?.Name,
                TargetObjectId = or.TargetObjectId
            }).ToList();
        }

        public ICollection<ObjectRightListResponse> MapObjectRights(ICollection<ObjectRight> objectRights)
        {
            return objectRights?.Select(or => new ObjectRightListResponse()
            {
                Id = or.Id,
                RightsName = or.RightsName,
                RightsUrl = or.RightsUrl,
                Comments = or.Comments
            }).ToList();
        }

        public ICollection<ObjectTitleListResponse> MapObjectTitles(ICollection<ObjectTitle> objectTitles)
        {
            return objectTitles?.Select(ot => new ObjectTitleListResponse()
            {
                Id = ot.Id,
                TitleType = ot.TitleType?.Name,
                TitleText = ot.TitleText,
                LangCode = ot.LangCode,
                Comments = ot.Comments
            }).ToList();
        }

        public ICollection<ObjectTopicListResponse> MapObjectTopics(ICollection<ObjectTopic> objectTopics)
        {
            return objectTopics?.Select(ot => new ObjectTopicListResponse()
            {
                Id = ot.Id,
                TopicType = ot.TopicType?.Name,
                MeshCoded = ot.MeshCoded,
                MeshCode = ot.MeshCode,
                MeshValue = ot.MeshValue,
                OriginalCtId = ot.OriginalCtId,
                OriginalCtCode = ot.OriginalCtCode,
                OriginalValue = ot.OriginalValue
            }).ToList();
        }
    }
}