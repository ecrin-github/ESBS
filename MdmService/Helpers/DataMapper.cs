using System.Collections.Generic;
using System.Linq;
using MdmService.DTO.Object;
using MdmService.DTO.Study;
using MdmService.Interfaces;
using MdmService.Models.Object;
using MdmService.Models.Study;

namespace MdmService.Helpers
{
    public class DataMapper : IDataMapper
    {
        public ICollection<StudyDataDto> StudyDataDtoBuilder(ICollection<Study> studies)
        {
            return studies is not { Count: > 0 } ? null : studies.Select(StudyDataDtoMapper).ToList();
        }

        public StudyDataDto StudyDataDtoMapper(Study study)
        {
            var studyDataDto = new StudyDataDto()
            {
                Id = study.Id,
                SdSid = study.SdSid,
                MdrSdSid = study.MdrSdSid,
                MdrSourceId = study.MdrSourceId,
                DisplayTitle = study.DisplayTitle,
                TitleLangCode = study.TitleLangCode,
                BriefDescription = study.BriefDescription,
                DataSharingStatement = study.DataSharingStatement,
                StudyStartYear = study.StudyStartYear,
                StudyStartMonth = study.StudyStartMonth,
                StudyTypeId = study.StudyTypeId,
                StudyStatusId = study.StudyStatusId,
                StudyEnrolment = study.StudyEnrolment,
                StudyGenderEligId = study.StudyGenderEligId,
                MinAge = study.MinAge,
                MinAgeUnitsId = study.MinAgeUnitsId,
                MaxAge = study.MaxAge,
                MaxAgeUnitsId = study.MaxAgeUnitsId,
                CreatedOn = study.CreatedOn.ToString()
            };
            return studyDataDto;
        }

        public ICollection<StudyContributorDto> StudyContributorDtoBuilder(ICollection<StudyContributor> studyContributors)
        {
            return studyContributors is not { Count: > 0 } ? null : studyContributors.Select(StudyContributorDtoMapper).ToList();
        }

        public StudyContributorDto StudyContributorDtoMapper(StudyContributor studyContributor)
        {
            if (studyContributor == null) return null;
            
            var studyContributorDto = new StudyContributorDto
            {
                Id = studyContributor.Id,
                SdSid = studyContributor.SdSid,
                ContribTypeId = studyContributor.ContribTypeId,
                IsIndividual = studyContributor.IsIndividual,
                PersonId = studyContributor.PersonId,
                PersonGivenName = studyContributor.PersonGivenName,
                PersonFamilyName = studyContributor.PersonFamilyName,
                PersonFullName = studyContributor.PersonFullName,
                PersonAffiliation = studyContributor.PersonAffiliation,
                OrganisationId = studyContributor.OrganisationId,
                OrganisationName = studyContributor.OrganisationName,
                OrganisationRorId = studyContributor.OrganisationRorId,
                CreatedOn = studyContributor.CreatedOn
            };

            return studyContributorDto;
        }

        public ICollection<StudyFeatureDto> StudyFeatureDtoBuilder(ICollection<StudyFeature> studyFeatures)
        {
            return studyFeatures is not { Count: > 0 } ? null : studyFeatures.Select(StudyFeatureDtoMapper).ToList();
        }

        public StudyFeatureDto StudyFeatureDtoMapper(StudyFeature studyFeature)
        {
            if (studyFeature == null) return null;
            
            var studyFeatureDto = new StudyFeatureDto
            {
                Id = studyFeature.Id,
                SdSid = studyFeature.SdSid,
                FeatureTypeId = studyFeature.FeatureTypeId,
                FeatureValueId = studyFeature.FeatureValueId,
                CreatedOn = studyFeature.CreatedOn
            };

            return studyFeatureDto;
        }

        public ICollection<StudyIdentifierDto> StudyIdentifierDtoBuilder(ICollection<StudyIdentifier> studyIdentifiers)
        {
            return studyIdentifiers is not { Count: > 0 } ? null : studyIdentifiers.Select(StudyIdentifierDtoMapper).ToList();
        }

        public StudyIdentifierDto StudyIdentifierDtoMapper(StudyIdentifier studyIdentifier)
        {
            if (studyIdentifier == null) return null;
            
            var studyIdentifierDto = new StudyIdentifierDto
            {
                Id = studyIdentifier.Id,
                SdSid = studyIdentifier.SdSid,
                CreatedOn = studyIdentifier.CreatedOn,
                IdentifierTypeId = studyIdentifier.IdentifierTypeId,
                IdentifierValue = studyIdentifier.IdentifierValue,
                IdentifierOrgId = studyIdentifier.IdentifierOrgId,
                IdentifierOrg = studyIdentifier.IdentifierOrg,
                IdentifierOrgRorId = studyIdentifier.IdentifierOrgRorId,
                IdentifierDate = studyIdentifier.IdentifierDate,
                IdentifierLink = studyIdentifier.IdentifierLink
            };

            return studyIdentifierDto;
        }

        public ICollection<StudyReferenceDto> StudyReferenceDtoBuilder(ICollection<StudyReference> studyReferences)
        {
            return studyReferences is not { Count: > 0 } ? null : studyReferences.Select(StudyReferenceDtoMapper).ToList();
        }

        public StudyReferenceDto StudyReferenceDtoMapper(StudyReference studyReference)
        {
            if (studyReference == null) return null;
            
            var studyReferenceDto = new StudyReferenceDto
            {
                Id = studyReference.Id,
                SdSid = studyReference.SdSid,
                CreatedOn = studyReference.CreatedOn,
                Pmid = studyReference.Pmid,
                Doi = studyReference.Doi,
                Citation = studyReference.Citation,
                Comments = studyReference.Comments
            };

            return studyReferenceDto;
        }

        public ICollection<StudyRelationshipDto> StudyRelationshipDtoBuilder(ICollection<StudyRelationship> studyRelationships)
        {
            return studyRelationships is not { Count: > 0 } ? null : studyRelationships.Select(StudyRelationshipDtoMapper).ToList();
        }

        public StudyRelationshipDto StudyRelationshipDtoMapper(StudyRelationship studyRelationship)
        {
            if (studyRelationship == null) return null;
            
            var studyRelationshipDto = new StudyRelationshipDto
            {
                Id = studyRelationship.Id,
                SdSid = studyRelationship.SdSid,
                CreatedOn = studyRelationship.CreatedOn,
                RelationshipTypeId = studyRelationship.RelationshipTypeId,
                TargetSdSid = studyRelationship.TargetSdSid
            };

            return studyRelationshipDto;
        }

        public ICollection<StudyTitleDto> StudyTitleDtoBuilder(ICollection<StudyTitle> studyTitles)
        {
            return studyTitles is not { Count: > 0 } ? null : studyTitles.Select(StudyTitleDtoMapper).ToList();
        }

        public StudyTitleDto StudyTitleDtoMapper(StudyTitle studyTitle)
        {
            if (studyTitle == null) return null;
            
            var studyTitleDto = new StudyTitleDto
            {
                Id = studyTitle.Id,
                SdSid = studyTitle.SdSid,
                CreatedOn = studyTitle.CreatedOn,
                IsDefault = studyTitle.IsDefault,
                LangCode = studyTitle.LangCode,
                TitleText = studyTitle.TitleText,
                TitleTypeId = studyTitle.TitleTypeId,
                LangUsageId = studyTitle.LangUsageId,
                Comments = studyTitle.Comments
            };

            return studyTitleDto;
        }

        public ICollection<StudyTopicDto> StudyTopicDtoBuilder(ICollection<StudyTopic> studyTopics)
        {
            return studyTopics is not { Count: > 0 } ? null : studyTopics.Select(StudyTopicDtoMapper).ToList();
        }

        public StudyTopicDto StudyTopicDtoMapper(StudyTopic studyTopic)
        {
            if (studyTopic == null) return null;
            
            var studyTopicDto = new StudyTopicDto
            {
                Id = studyTopic.Id,
                SdSid = studyTopic.SdSid,
                CreatedOn = studyTopic.CreatedOn,
                TopicTypeId = studyTopic.TopicTypeId,
                MeshCoded = studyTopic.MeshCoded,
                MeshCode = studyTopic.MeshCode,
                MeshValue = studyTopic.MeshValue,
                OriginalCtId = studyTopic.OriginalCtId,
                OriginalCtCode = studyTopic.OriginalCtCode,
                OriginalValue = studyTopic.OriginalValue,
            };

            return studyTopicDto;
        }

        public ICollection<DataObjectDataDto> DataObjectDataDtoBuilder(ICollection<DataObject> dataObjects)
        {
            return dataObjects is not { Count: > 0 } ? null : dataObjects.Select(DataObjectDataDtoMapper).ToList();
        }

        public DataObjectDataDto DataObjectDataDtoMapper(DataObject dataObject)
        {
            var dataObjectDataDto = new DataObjectDataDto()
            {
                Id = dataObject.Id,
                SdOid = dataObject.SdOid,
                SdSid = dataObject.SdSid,
                DisplayTitle = dataObject.DisplayTitle,
                Version = dataObject.Version,
                Doi = dataObject.Doi,
                DoiStatusId = dataObject.DoiStatusId,
                PublicationYear = dataObject.PublicationYear,
                ObjectClassId = dataObject.ObjectClassId,
                ObjectTypeId = dataObject.ObjectTypeId,
                ManagingOrgId = dataObject.ManagingOrgId,
                ManagingOrg = dataObject.ManagingOrg,
                ManagingOrgRorId = dataObject.ManagingOrgRorId,
                LangCode = dataObject.LangCode,
                AccessTypeId = dataObject.AccessTypeId,
                AccessDetails = dataObject.AccessDetails,
                AccessDetailsUrl = dataObject.AccessDetailsUrl,
                UrlLastChecked = dataObject.UrlLastChecked,
                EoscCategory = dataObject.EoscCategory,
                AddStudyContribs = dataObject.AddStudyContribs,
                AddStudyTopics = dataObject.AddStudyTopics,
                CreatedOn = dataObject.CreatedOn
            };
            return dataObjectDataDto;
        }

        public ICollection<ObjectContributorDto> ObjectContributorDtoBuilder(ICollection<ObjectContributor> objectContributors)
        {
            return objectContributors is not { Count: > 0 } ? null : objectContributors.Select(ObjectContributorDtoMapper).ToList();
        }

        public ObjectContributorDto ObjectContributorDtoMapper(ObjectContributor objectContributor)
        {
            if (objectContributor == null) return null;
            
            var objectContributorDto = new ObjectContributorDto
            {
                Id = objectContributor.Id,
                SdOid = objectContributor.SdOid,
                CreatedOn = objectContributor.CreatedOn,
                ContribTypeId = objectContributor.ContribTypeId,
                IsIndividual = objectContributor.IsIndividual,
                OrganisationId = objectContributor.OrganisationId,
                OrganisationName = objectContributor.OrganisationName,
                PersonId = objectContributor.PersonId,
                PersonFamilyName = objectContributor.PersonFamilyName,
                PersonGivenName = objectContributor.PersonGivenName,
                PersonFullName = objectContributor.PersonFullName,
                PersonAffiliation = objectContributor.PersonAffiliation,
                OrcidId = objectContributor.OrcidId
            };

            return objectContributorDto;
        }

        public ICollection<ObjectDatasetDto> ObjectDatasetDtoBuilder(ICollection<ObjectDataset> objectDatasets)
        {
            return objectDatasets is not { Count: > 0 } ? null : objectDatasets.Select(ObjectDatasetDtoMapper).ToList();
        }

        public ObjectDatasetDto ObjectDatasetDtoMapper(ObjectDataset objectDataset)
        {
            if (objectDataset == null) return null;
            
            var objectDatasetDto = new ObjectDatasetDto
            {
                Id = objectDataset.Id,
                SdOid = objectDataset.SdOid,
                CreatedOn = objectDataset.CreatedOn,
                RecordKeysTypeId = objectDataset.RecordKeysTypeId,
                RecordKeysDetails = objectDataset.RecordKeysDetails,
                DeidentTypeId = objectDataset.DeidentTypeId,
                DeidentHipaa = objectDataset.DeidentHipaa,
                DeidentDirect = objectDataset.DeidentDirect,
                DeidentDates = objectDataset.DeidentDates,
                DeidentNonarr = objectDataset.DeidentNonarr,
                DeidentKanon = objectDataset.DeidentKanon,
                DeidentDetails = objectDataset.DeidentDetails,
                ConsentTypeId = objectDataset.ConsentTypeId,
                ConsentNoncommercial = objectDataset.ConsentNoncommercial,
                ConsentGeogRestrict = objectDataset.ConsentGeogRestrict,
                ConsentGeneticOnly = objectDataset.ConsentGeneticOnly,
                ConsentResearchType = objectDataset.ConsentResearchType,
                ConsentNoMethods = objectDataset.ConsentNoMethods,
                ConsentDetails = objectDataset.ConsentDetails
            };

            return objectDatasetDto;
        }

        public ICollection<ObjectDateDto> ObjectDateDtoBuilder(ICollection<ObjectDate> objectDates)
        {
            return objectDates is not { Count: > 0 } ? null : objectDates.Select(ObjectDateDtoMapper).ToList();
        }

        public ObjectDateDto ObjectDateDtoMapper(ObjectDate objectDate)
        {
            if (objectDate == null) return null;
            
            var objectDateDto = new ObjectDateDto
            {
                Id = objectDate.Id,
                SdOid = objectDate.SdOid,
                CreatedOn = objectDate.CreatedOn,
                DateTypeId = objectDate.DateTypeId,
                DateIsRange = objectDate.DateIsRange,
                DateAsString = objectDate.DateAsString,
                StartYear = objectDate.StartYear,
                StartMonth = objectDate.StartMonth,
                StartDay = objectDate.StartDay,
                EndYear = objectDate.EndYear,
                EndMonth = objectDate.EndMonth,
                EndDay = objectDate.EndDay,
                Details = objectDate.Details
            };

            return objectDateDto;
        }

        public ICollection<ObjectDescriptionDto> ObjectDescriptionDtoBuilder(ICollection<ObjectDescription> objectDescriptions)
        {
            return objectDescriptions is not { Count: > 0 } ? null : objectDescriptions.Select(ObjectDescriptionDtoMapper).ToList();
        }

        public ObjectDescriptionDto ObjectDescriptionDtoMapper(ObjectDescription objectDescription)
        {
            if (objectDescription == null) return null;
            
            var objectDescriptionDto = new ObjectDescriptionDto
            {
                Id = objectDescription.Id,
                SdOid = objectDescription.SdOid,
                CreatedOn = objectDescription.CreatedOn,
                DescriptionTypeId = objectDescription.DescriptionTypeId,
                DescriptionText = objectDescription.DescriptionText,
                LangCode = objectDescription.LangCode,
                Label = objectDescription.Label
            };

            return objectDescriptionDto;
        }

        public ICollection<ObjectIdentifierDto> ObjectIdentifierDtoBuilder(ICollection<ObjectIdentifier> objectIdentifiers)
        {
            return objectIdentifiers is not { Count: > 0 } ? null : objectIdentifiers.Select(ObjectIdentifierDtoMapper).ToList();
        }

        public ObjectIdentifierDto ObjectIdentifierDtoMapper(ObjectIdentifier objectIdentifier)
        {
            if (objectIdentifier == null) return null;
            
            var objectIdentifierDto = new ObjectIdentifierDto
            {
                Id = objectIdentifier.Id,
                SdOid = objectIdentifier.SdOid,
                CreatedOn = objectIdentifier.CreatedOn,
                IdentifierValue = objectIdentifier.IdentifierValue,
                IdentifierTypeId = objectIdentifier.IdentifierTypeId,
                IdentifierOrg = objectIdentifier.IdentifierOrg,
                IdentifierOrgId = objectIdentifier.IdentifierOrgId,
                IdentifierDate = objectIdentifier.IdentifierDate,
                IdentifierOrgRorId = objectIdentifier.IdentifierOrgRorId
            };

            return objectIdentifierDto;
        }

        public ICollection<ObjectInstanceDto> ObjectInstanceDtoBuilder(ICollection<ObjectInstance> objectInstances)
        {
            return objectInstances is not { Count: > 0 } ? null : objectInstances.Select(ObjectInstanceDtoMapper).ToList();
        }

        public ObjectInstanceDto ObjectInstanceDtoMapper(ObjectInstance objectInstance)
        {
            if (objectInstance == null) return null;
            
            var objectInstanceDto = new ObjectInstanceDto
            {
                Id = objectInstance.Id,
                SdOid = objectInstance.SdOid,
                CreatedOn = objectInstance.CreatedOn,
                InstanceTypeId = objectInstance.InstanceTypeId,
                RepositoryOrgId = objectInstance.RepositoryOrgId,
                RepositoryOrg = objectInstance.RepositoryOrg,
                Url = objectInstance.Url,
                UrlAccessible = objectInstance.UrlAccessible,
                UrlLastChecked = objectInstance.UrlLastChecked,
                ResourceTypeId = objectInstance.ResourceTypeId,
                ResourceSize = objectInstance.ResourceSize,
                ResourceSizeUnits = objectInstance.ResourceSizeUnits,
                ResourceComments = objectInstance.ResourceComments
            };

            return objectInstanceDto;
        }

        public ICollection<ObjectRelationshipDto> ObjectRelationshipDtoBuilder(ICollection<ObjectRelationship> objectRelationships)
        {
            return objectRelationships is not { Count: > 0 } ? null : objectRelationships.Select(ObjectRelationshipDtoMapper).ToList();
        }

        public ObjectRelationshipDto ObjectRelationshipDtoMapper(ObjectRelationship objectRelationship)
        {
            if (objectRelationship == null) return null;
            
            var objectRelationshipDto = new ObjectRelationshipDto
            {
                Id = objectRelationship.Id,
                SdOid = objectRelationship.SdOid,
                CreatedOn = objectRelationship.CreatedOn,
                RelationshipTypeId = objectRelationship.RelationshipTypeId,
                TargetSdOid = objectRelationship.TargetSdOid
            };

            return objectRelationshipDto;
        }

        public ICollection<ObjectRightDto> ObjectRightDtoBuilder(ICollection<ObjectRight> objectRights)
        {
            return objectRights is not { Count: > 0 } ? null : objectRights.Select(ObjectRightDtoMapper).ToList();
        }

        public ObjectRightDto ObjectRightDtoMapper(ObjectRight objectRight)
        {
            if (objectRight == null) return null;
            
            var objectRightDto = new ObjectRightDto
            {
                Id = objectRight.Id,
                SdOid = objectRight.SdOid,
                CreatedOn = objectRight.CreatedOn,
                RightsName = objectRight.RightsName,
                RightsUri = objectRight.RightsUri,
                Comments = objectRight.Comments
            };

            return objectRightDto;
        }

        public ICollection<ObjectTitleDto> ObjectTitleDtoBuilder(ICollection<ObjectTitle> objectTitles)
        {
            return objectTitles is not { Count: > 0 } ? null : objectTitles.Select(ObjectTitleDtoMapper).ToList();
        }

        public ObjectTitleDto ObjectTitleDtoMapper(ObjectTitle objectTitle)
        {
            if (objectTitle == null) return null;
            
            var objectTitleDto = new ObjectTitleDto
            {
                Id = objectTitle.Id,
                SdOid = objectTitle.SdOid,
                CreatedOn = objectTitle.CreatedOn,
                TitleTypeId = objectTitle.TitleTypeId,
                IsDefault = objectTitle.IsDefault,
                TitleText = objectTitle.TitleText,
                LangCode = objectTitle.LangCode,
                LangUsageId = objectTitle.LangUsageId,
                Comments = objectTitle.Comments
            };

            return objectTitleDto;
        }

        public ICollection<ObjectTopicDto> ObjectTopicDtoBuilder(ICollection<ObjectTopic> objectTopics)
        {
            return objectTopics is not { Count: > 0 } ? null : objectTopics.Select(ObjectTopicDtoMapper).ToList();
        }

        public ObjectTopicDto ObjectTopicDtoMapper(ObjectTopic objectTopic)
        {
            if (objectTopic == null) return null;
            
            var objectTopicDto = new ObjectTopicDto
            {
                Id = objectTopic.Id,
                SdOid = objectTopic.SdOid,
                CreatedOn = objectTopic.CreatedOn,
                TopicTypeId = objectTopic.TopicTypeId,
                MeshCoded = objectTopic.MeshCoded,
                MeshCode = objectTopic.MeshCode,
                MeshValue = objectTopic.MeshValue,
                OriginalCtId = objectTopic.OriginalCtId,
                OriginalCtCode = objectTopic.OriginalCtCode,
                OriginalValue = objectTopic.OriginalValue,
            };

            return objectTopicDto;
        }
    }
}