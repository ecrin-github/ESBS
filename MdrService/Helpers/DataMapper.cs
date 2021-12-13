using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MdrService.Contracts.Responses.v1.Common;
using MdrService.Contracts.Responses.v1.ApiResponse.ObjectListResponse;
using MdrService.Contracts.Responses.v1.ApiResponse.StudyListResponse;
using MdrService.Interfaces;
using MdrService.Models.Object;
using MdrService.Models.Study;


namespace MdrService.Helpers
{
    public class DataMapper : IDataMapper
    {
        private readonly IContextService _contextService;

        public DataMapper(IContextService contextService)
        {
            _contextService = contextService ?? throw new ArgumentNullException(nameof(contextService));
        }

        public async Task<ICollection<StudyFeatureListResponse>> MapStudyFeatures(ICollection<StudyFeature> studyFeatures)
        {
            var studyFeaturesDto = new List<StudyFeatureListResponse>();
            if (studyFeatures is not { Count: > 0 }) return null;
            foreach (var sf in studyFeatures)
            {
                var sfDto = new StudyFeatureListResponse()
                {
                    Id = sf.Id,
                    FeatureType = await _contextService.GetFeatureType(sf.FeatureTypeId),
                    FeatureValue = await _contextService.GetFeatureValue(sf.FeatureValueId)
                };
                studyFeaturesDto.Add(sfDto);
            }

            return studyFeaturesDto;
        }

        public async Task<ICollection<StudyIdentifierListResponse>> MapStudyIdentifiers(ICollection<StudyIdentifier> studyIdentifiers)
        {
            var studyIdentifiersDto = new List<StudyIdentifierListResponse>();
            if (studyIdentifiers is not { Count: > 0 }) return null;
            foreach (var si in studyIdentifiers)
            {
                var siDto = new StudyIdentifierListResponse()
                {
                    Id = si.Id,
                    IdentifierValue = si.IdentifierValue,
                    IdentifierType = await _contextService.GetIdentifierType(si.IdentifierTypeId),
                    IdentifierDate = si.IdentifierDate,
                    IdentifierLink = si.IdentifierLink,
                    IdentifierOrg = new IdentifierOrg()
                    {
                        Id = si.IdentifierOrgId,
                        Name = si.IdentifierOrg,
                        RorId = si.IdentifierOrgRorId
                    }
                };
                studyIdentifiersDto.Add(siDto);
            }

            return studyIdentifiersDto;
        }

        public async Task<ICollection<StudyRelationListResponse>> MapStudyRelationships(ICollection<StudyRelationship> studyRelationships)
        {
            var studyRelationsDto = new List<StudyRelationListResponse>();
            if (studyRelationships is not { Count: > 0 }) return null;
            foreach (var sr in studyRelationships)
            {
                var srDto = new StudyRelationListResponse()
                {
                    Id = sr.Id,
                    RelationshipType = await _contextService.GetStudyRelationshipType(sr.RelationshipTypeId),
                    TargetStudyId = sr.TargetStudyId
                };
                studyRelationsDto.Add(srDto);
            }

            return studyRelationsDto;
        }

        public async Task<ICollection<StudyTitleListResponse>> MapStudyTitles(ICollection<StudyTitle> studyTitles)
        {
            var studyTitlesDto = new List<StudyTitleListResponse>();
            if (studyTitles is not { Count: > 0 }) return null;
            foreach (var st in studyTitles)
            {
                var stDto = new StudyTitleListResponse()
                {
                    Id = st.Id,
                    TitleType = await _contextService.GetTitleType(st.TitleTypeId),
                    TitleText = st.TitleText,
                    LangCode = st.LangCode,
                    Comments = st.Comments
                };
                studyTitlesDto.Add(stDto);
            }
            
            return studyTitlesDto;
        }

        public async Task<ICollection<StudyTopicListResponse>> MapStudyTopics(ICollection<StudyTopic> studyTopics)
        {
            var studyTopicsDto = new List<StudyTopicListResponse>();
            if (studyTopics is not { Count: > 0 }) return null;
            foreach (var st in studyTopics)
            {
                var stDto = new StudyTopicListResponse()
                {
                    Id = st.Id,
                    TopicType = await _contextService.GetTopicType(st.TopicTypeId),
                    MeshCoded = st.MeshCoded,
                    MeshCode = st.MeshCode,
                    MeshValue = st.MeshValue,
                    OriginalCtId = st.OriginalCtId,
                    OriginalCtCode = st.OriginalCtCode,
                    OriginalValue = st.OriginalValue
                };
                studyTopicsDto.Add(stDto);
            }
            
            return studyTopicsDto;
        }
        

        public async Task<ICollection<ObjectContributorListResponse>> MapObjectContributors(ICollection<ObjectContributor> objectContributors)
        {
            var objectContributorsDto = new List<ObjectContributorListResponse>();
            if (objectContributors is not { Count: > 0 }) return null;
            foreach (var oc in objectContributors)
            {
                var ocDto = new ObjectContributorListResponse()
                {
                    Id = oc.Id,
                    ContributionType = await _contextService.GetContributionType(oc.ContribTypeId),
                    IsIndividual = oc.IsIndividual,
                    Organisation = new ContribOrg()
                    {
                        Id = oc.OrganisationId,
                        Name = oc.OrganisationName,
                        RorId = oc.OrganisationRorId
                    },
                    Person = new Person()
                    {
                        FamilyName = oc.PersonFamilyName,
                        FullName = oc.PersonFullName,
                        GivenName = oc.PersonGivenName,
                        Orcid = oc.OrcidId,
                        AffiliationString = oc.PersonAffiliation,
                        AffiliationOrgId = null,
                        AffiliationOrgName = null,
                        AffiliationOrgRorId = null
                    }
                };
                objectContributorsDto.Add(ocDto);
            }

            return objectContributorsDto;
        }

        public async Task<DatasetRecordKeys> MapDatasetRecordKeys(ObjectDataset objectDataset)
        {
            if (objectDataset == null) return null;
            return new DatasetRecordKeys()
            {
                KeysTypeId = objectDataset.RecordKeysTypeId,
                KeysType = await _contextService.GetRecordkeyType(objectDataset.RecordKeysTypeId),
                KeysDetails = objectDataset.RecordKeysDetails
            };
        }

        public async Task<DatasetDeidentLevel> MapDatasetDeidentLevel(ObjectDataset objectDataset)
        {
            if (objectDataset == null) return null;
            return new DatasetDeidentLevel()
            {
                DeidentTypeId = objectDataset.DeidentTypeId,
                DeidentType = await _contextService.GetDeidentType(objectDataset.DeidentTypeId),
                DeidentDirect = objectDataset.DeidentDirect,
                DeidentHipaa = objectDataset.DeidentHipaa,
                DeidentDates = objectDataset.DeidentDates,
                DeidentNonarr = objectDataset.DeidentNonarr,
                DeidentKanon = objectDataset.DeidentKanon,
                DeidentDetails = objectDataset.DeidentDetails
            };
        }

        public async Task<DatasetConsent> MapDatasetConsent(ObjectDataset objectDataset)
        {
            if (objectDataset == null) return null;
            return new DatasetConsent()
            {
                ConsentTypeId = objectDataset.ConsentTypeId,
                ConsentType = await _contextService.GetConsentType(objectDataset.ConsentTypeId),
                ConsentNoncommercial = objectDataset.ConsentNoncommercial,
                ConsentGeogRestrict = objectDataset.ConsentGeogRestrict,
                ConsentResearchType = objectDataset.ConsentResearchType,
                ConsentGeneticOnly = objectDataset.ConsentGeneticOnly,
                ConsentNoMethods = objectDataset.ConsentNoMethods,
                ConsentsDetails = objectDataset.ConsentDetails
            };
        }

        public async Task<ICollection<ObjectDateListResponse>> MapObjectDates(ICollection<ObjectDate> objectDates)
        {
            var objectDatesDto = new List<ObjectDateListResponse>();
            if (objectDates is not { Count: > 0 }) return null;
            foreach (var od in objectDates)
            {
                var odDto = new ObjectDateListResponse()
                {
                    Id = od.Id,
                    DateType = await _contextService.GetDateType(od.DateTypeId),
                    DateIsRange = od.DateIsRange,
                    DateAsString = od.DateAsString,
                    StartDate = new Date()
                    {
                        Year = od.StartYear,
                        Month = od.StartMonth,
                        Day = od.StartDay
                    },
                    EndDate = new Date()
                    {
                        Year = od.EndYear,
                        Month = od.EndMonth,
                        Day = od.EndDay
                    },
                    Comments = null
                };
                objectDatesDto.Add(odDto);
            }
            
            return objectDatesDto;
        }

        public async Task<ICollection<ObjectDescriptionListResponse>> MapObjectDescriptions(ICollection<ObjectDescription> objectDescriptions)
        {
            var objectDescriptionsDto = new List<ObjectDescriptionListResponse>();
            if (objectDescriptions is not { Count: > 0 }) return null;
            foreach (var od in objectDescriptions)
            {
                var odDto = new ObjectDescriptionListResponse()
                {
                    Id = od.Id,
                    DescriptionType = await _contextService.GetDescriptionType(od.DescriptionTypeId),
                    DescriptionLabel = od.Label,
                    DescriptionText = od.DescriptionText,
                    LangCode = od.LangCode
                };
                objectDescriptionsDto.Add(odDto);
            }

            return objectDescriptionsDto;
        }

        public async Task<ICollection<ObjectIdentifierListResponse>> MapObjectIdentifiers(ICollection<ObjectIdentifier> objectIdentifiers)
        {
            var objectIdentifiersDto = new List<ObjectIdentifierListResponse>();
            if (objectIdentifiers is not { Count: > 0 }) return null;
            foreach (var oi in objectIdentifiers)
            {
                var oiDto = new ObjectIdentifierListResponse()
                {
                    Id = oi.Id,
                    IdentifierValue = oi.IdentifierValue,
                    IdentifierType = await _contextService.GetIdentifierType(oi.IdentifierTypeId),
                    IdentifierDate = oi.IdentifierDate,
                    IdentifierOrg = new IdentifierOrg()
                    {
                        Id = oi.IdentifierOrgId,
                        Name = oi.IdentifierOrg,
                        RorId = oi.IdentifierOrgRorId
                    }
                };
                objectIdentifiersDto.Add(oiDto);
            }

            return objectIdentifiersDto;
        }

        public async Task<ICollection<ObjectInstanceListResponse>> MapObjectInstances(ICollection<ObjectInstance> objectInstances)
        {
            var objectInstancesDto = new List<ObjectInstanceListResponse>();
            if (objectInstances is not { Count: > 0 }) return null;
            foreach (var oi in objectInstances)
            {
                var oiDto = new ObjectInstanceListResponse()
                {
                    Id = oi.Id,
                    RepositoryOrg = oi.RepositoryOrg,
                    AccessDetails = new InstanceAccessDetails()
                    {
                        DirectAccess = oi.UrlAccessible,
                        Url = oi.Url,
                        UrlLastChecked = oi.UrlLastChecked.ToString()
                    },
                    ResourceDetails = new InstanceResourceDetails()
                    {
                        TypeId = oi.ResourceTypeId,
                        TypeName = await _contextService.GetResourceType(oi.ResourceTypeId),
                        Size = oi.ResourceSize,
                        SizeUnit = oi.ResourceSizeUnits,
                        Comments = oi.ResourceComments
                    }
                };
                objectInstancesDto.Add(oiDto);
            }

            return objectInstancesDto;
        }

        public async Task<ICollection<ObjectRelationshipListResponse>> MapObjectRelationships(ICollection<ObjectRelationship> objectRelationships)
        {
            var objectRelationsDto = new List<ObjectRelationshipListResponse>();
            if (objectRelationships is not { Count: > 0 }) return null;
            foreach (var or in objectRelationships)
            {
                var orDto = new ObjectRelationshipListResponse()
                {
                    Id = or.Id,
                    RelationshipType = await _contextService.GetObjectRelationshipType(or.RelationshipTypeId),
                    TargetObjectId = or.TargetObjectId
                };
                objectRelationsDto.Add(orDto);
            }

            return objectRelationsDto;
        }

        public ICollection<ObjectRightListResponse> MapObjectRights(ICollection<ObjectRight> objectRights)
        {
            return objectRights is not { Count: > 0 } ? null : objectRights.Select(or => new ObjectRightListResponse() { Id = or.Id, RightsName = or.RightsName, RightsUrl = or.RightsUri, Comments = or.Comments }).ToList();
        }

        public async Task<ICollection<ObjectTitleListResponse>> MapObjectTitles(ICollection<ObjectTitle> objectTitles)
        {
            var objectTitlesDto = new List<ObjectTitleListResponse>();
            if (objectTitles is not { Count: > 0 }) return null;
            foreach (var ot in objectTitles)
            {
                var otDto = new ObjectTitleListResponse()
                {
                    Id = ot.Id,
                    TitleType = await _contextService.GetTitleType(ot.TitleTypeId),
                    TitleText = ot.TitleText,
                    LangCode = ot.LangCode,
                    Comments = ot.Comments
                };
                objectTitlesDto.Add(otDto);
            }

            return objectTitlesDto;
        }

        public async Task<ICollection<ObjectTopicListResponse>> MapObjectTopics(ICollection<ObjectTopic> objectTopics)
        {
            var objectTopicsDto = new List<ObjectTopicListResponse>();
            if (objectTopics is not { Count: > 0 }) return null;
            foreach (var ot in objectTopics)
            {
                var otDto = new ObjectTopicListResponse()
                {
                    Id = ot.Id,
                    TopicType = await _contextService.GetTopicType(ot.TopicTypeId),
                    MeshCoded = ot.MeshCoded,
                    MeshCode = ot.MeshCode,
                    MeshValue = ot.MeshValue,
                    OriginalCtId = ot.OriginalCtId,
                    OriginalCtCode = ot.OriginalCtCode,
                    OriginalValue = ot.OriginalValue
                };
                objectTopicsDto.Add(otDto);
            }

            return objectTopicsDto;
        }
    }
}