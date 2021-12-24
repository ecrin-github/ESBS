using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MdmService.Contracts.Requests.Filtering;
using MdmService.Contracts.Responses;
using MdmService.DTO.Object;
using MdmService.Interfaces;
using MdmService.Models.DbConnection;
using MdmService.Models.Object;
using Microsoft.EntityFrameworkCore;

namespace MdmService.Repositories
{
    public class ObjectRepository : IObjectRepository
    {
        private readonly MdmDbConnection _dbConnection;
        private readonly IDataMapper _dataMapper;

        public ObjectRepository(MdmDbConnection dbConnection, IDataMapper dataMapper)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
            _dataMapper = dataMapper ?? throw new ArgumentNullException(nameof(dataMapper));
        }
        

        public async Task<ICollection<ObjectContributorDto>> GetObjectContributors(string sdOid)
        {
            var data = _dbConnection.ObjectContributors.Where(p => p.SdOid == sdOid);
            return data.Any() ? _dataMapper.ObjectContributorDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<ObjectContributorDto> GetObjectContributor(int? id)
        {
            var objectContributor = await _dbConnection.ObjectContributors.FirstOrDefaultAsync(p => p.Id == id);
            return objectContributor != null ? _dataMapper.ObjectContributorDtoMapper(objectContributor) : null;
        }

        public async Task<ObjectContributorDto> CreateObjectContributor(ObjectContributorDto objectContributorDto)
        {
            var objectContributor = new ObjectContributor
            {
                SdOid = objectContributorDto.SdOid,
                CreatedOn = DateTime.Now,
                ContribTypeId = objectContributorDto.ContribTypeId,
                IsIndividual = objectContributorDto.IsIndividual,
                OrganisationId = objectContributorDto.OrganisationId,
                OrganisationName = objectContributorDto.OrganisationName,
                PersonId = objectContributorDto.PersonId,
                PersonFamilyName = objectContributorDto.PersonFamilyName,
                PersonGivenName = objectContributorDto.PersonGivenName,
                PersonFullName = objectContributorDto.PersonFullName,
                PersonAffiliation = objectContributorDto.PersonAffiliation,
                OrcidId = objectContributorDto.OrcidId
            };

            await _dbConnection.ObjectContributors.AddAsync(objectContributor);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.ObjectContributorDtoMapper(objectContributor);
        }

        public async Task<ObjectContributorDto> UpdateObjectContributor(ObjectContributorDto objectContributorDto)
        {
            var dbObjectContributor =
                await _dbConnection.ObjectContributors.FirstOrDefaultAsync(p => p.SdOid == objectContributorDto.SdOid);
            if (dbObjectContributor == null) return null;
            
            dbObjectContributor.ContribTypeId = objectContributorDto.ContribTypeId;
            dbObjectContributor.IsIndividual = objectContributorDto.IsIndividual;
            dbObjectContributor.OrganisationId = objectContributorDto.OrganisationId;
            dbObjectContributor.OrganisationName = objectContributorDto.OrganisationName;
            dbObjectContributor.PersonId = objectContributorDto.PersonId;
            dbObjectContributor.PersonFamilyName = objectContributorDto.PersonFamilyName;
            dbObjectContributor.PersonGivenName = objectContributorDto.PersonGivenName;
            dbObjectContributor.PersonFullName = objectContributorDto.PersonFullName;
            dbObjectContributor.PersonAffiliation = objectContributorDto.PersonAffiliation;
            dbObjectContributor.OrcidId = objectContributorDto.OrcidId;
                
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.ObjectContributorDtoMapper(dbObjectContributor);
        }

        public async Task<int> DeleteObjectContributor(int id)
        {
            var data = await _dbConnection.ObjectContributors.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.ObjectContributors.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllObjectContributors(string sdOid)
        {
            var data = _dbConnection.ObjectContributors.Where(p => p.SdOid == sdOid);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.ObjectContributors.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }
        
        public async Task<ObjectDatasetDto> GetObjectDatasets(string sdOid)
        {
            var data = _dbConnection.ObjectDatasets.FirstOrDefaultAsync(p => p.SdOid == sdOid);
            return data != null ? _dataMapper.ObjectDatasetDtoMapper(await data) : null;
        }

        public async Task<ObjectDatasetDto> GetObjectDataset(int? id)
        {
            var objectDataset = await _dbConnection.ObjectDatasets.FirstOrDefaultAsync(p => p.Id == id);
            return objectDataset != null ? _dataMapper.ObjectDatasetDtoMapper(objectDataset) : null;
        }

        public async Task<ObjectDatasetDto> CreateObjectDataset(ObjectDatasetDto objectDatasetDto)
        {
            var objectDataset = new ObjectDataset
            {
                SdOid = objectDatasetDto.SdOid,
                CreatedOn = DateTime.Now,
                RecordKeysTypeId = objectDatasetDto.RecordKeysTypeId,
                RecordKeysDetails = objectDatasetDto.RecordKeysDetails,
                DeidentTypeId = objectDatasetDto.DeidentTypeId,
                DeidentHipaa = objectDatasetDto.DeidentHipaa,
                DeidentDirect = objectDatasetDto.DeidentDirect,
                DeidentDates = objectDatasetDto.DeidentDates,
                DeidentNonarr = objectDatasetDto.DeidentNonarr,
                DeidentKanon = objectDatasetDto.DeidentKanon,
                DeidentDetails = objectDatasetDto.DeidentDetails,
                ConsentTypeId = objectDatasetDto.ConsentTypeId,
                ConsentNoncommercial = objectDatasetDto.ConsentNoncommercial,
                ConsentGeogRestrict = objectDatasetDto.ConsentGeogRestrict,
                ConsentGeneticOnly = objectDatasetDto.ConsentGeneticOnly,
                ConsentResearchType = objectDatasetDto.ConsentResearchType,
                ConsentNoMethods = objectDatasetDto.ConsentNoMethods,
                ConsentDetails = objectDatasetDto.ConsentDetails
            };

            await _dbConnection.ObjectDatasets.AddAsync(objectDataset);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.ObjectDatasetDtoMapper(objectDataset);
        }

        public async Task<ObjectDatasetDto> UpdateObjectDataset(ObjectDatasetDto objectDatasetDto)
        {
            var dbObjectDataset =
                await _dbConnection.ObjectDatasets.FirstOrDefaultAsync(p => p.Id == objectDatasetDto.Id);
            if (dbObjectDataset == null) return null;
            
            dbObjectDataset.RecordKeysTypeId = objectDatasetDto.RecordKeysTypeId;
            dbObjectDataset.RecordKeysDetails = objectDatasetDto.RecordKeysDetails;
            
            dbObjectDataset.DeidentTypeId = objectDatasetDto.DeidentTypeId;
            dbObjectDataset.DeidentHipaa = objectDatasetDto.DeidentHipaa;
            dbObjectDataset.DeidentDirect = objectDatasetDto.DeidentDirect;
            dbObjectDataset.DeidentDates = objectDatasetDto.DeidentDates;
            dbObjectDataset.DeidentNonarr = objectDatasetDto.DeidentNonarr;
            dbObjectDataset.DeidentKanon = objectDatasetDto.DeidentKanon;
            dbObjectDataset.DeidentDetails = objectDatasetDto.DeidentDetails;
            
            dbObjectDataset.ConsentTypeId = objectDatasetDto.ConsentTypeId;
            dbObjectDataset.ConsentNoncommercial = objectDatasetDto.ConsentNoncommercial;
            dbObjectDataset.ConsentGeogRestrict = objectDatasetDto.ConsentGeogRestrict;
            dbObjectDataset.ConsentGeneticOnly = objectDatasetDto.ConsentGeneticOnly;
            dbObjectDataset.ConsentResearchType = objectDatasetDto.ConsentResearchType;
            dbObjectDataset.ConsentNoMethods = objectDatasetDto.ConsentNoMethods;
            dbObjectDataset.ConsentDetails = objectDatasetDto.ConsentDetails;

            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.ObjectDatasetDtoMapper(dbObjectDataset);
        }

        public async Task<int> DeleteObjectDataset(int id)
        {
            var data = await _dbConnection.ObjectDatasets.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.ObjectDatasets.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllObjectDatasets(string sdOid)
        {
            var data = _dbConnection.ObjectDatasets.Where(p => p.SdOid == sdOid);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.ObjectDatasets.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }
        
        public async Task<ICollection<ObjectDateDto>> GetObjectDates(string sdOid)
        {
            var data = _dbConnection.ObjectDates.Where(p => p.SdOid == sdOid);
            return data.Any() ? _dataMapper.ObjectDateDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<ObjectDateDto> GetObjectDate(int? id)
        {
            var objectDate = await _dbConnection.ObjectDates.FirstOrDefaultAsync(p => p.Id == id);
            return objectDate != null ? _dataMapper.ObjectDateDtoMapper(objectDate) : null;
        }

        public async Task<ObjectDateDto> CreateObjectDate(ObjectDateDto objectDateDto)
        {
            var objectDate = new ObjectDate
            {
                SdOid = objectDateDto.SdOid,
                CreatedOn = DateTime.Now,
                DateTypeId = objectDateDto.DateTypeId,
                IsDateRange = objectDateDto.IsDateRange,
                DateAsString = objectDateDto.DateAsString,
                StartYear = objectDateDto.StartYear,
                StartMonth = objectDateDto.StartMonth,
                StartDay = objectDateDto.StartDay,
                EndYear = objectDateDto.EndYear,
                EndMonth = objectDateDto.EndMonth,
                EndDay = objectDateDto.EndDay,
                Details = objectDateDto.Details
            };

            await _dbConnection.ObjectDates.AddAsync(objectDate);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.ObjectDateDtoMapper(objectDate);
        }

        public async Task<ObjectDateDto> UpdateObjectDate(ObjectDateDto objectDateDto)
        {
            var dbObjectDate = await _dbConnection.ObjectDates.FirstOrDefaultAsync(p => p.Id == objectDateDto.Id);
            if (dbObjectDate == null) return null;
            
            dbObjectDate.DateTypeId = objectDateDto.DateTypeId;
            dbObjectDate.IsDateRange = objectDateDto.IsDateRange;
            dbObjectDate.DateAsString = objectDateDto.DateAsString;
            dbObjectDate.StartYear = objectDateDto.StartYear;
            dbObjectDate.StartMonth = objectDateDto.StartMonth;
            dbObjectDate.StartDay = objectDateDto.StartDay;
            dbObjectDate.EndYear = objectDateDto.EndYear;
            dbObjectDate.EndMonth = objectDateDto.EndMonth;
            dbObjectDate.EndDay = objectDateDto.EndDay;
            dbObjectDate.Details = objectDateDto.Details;

            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.ObjectDateDtoMapper(dbObjectDate);
        }

        public async Task<int> DeleteObjectDate(int id)
        {
            var data = await _dbConnection.ObjectDates.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.ObjectDates.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllObjectDates(string sdOid)
        {
            var data = _dbConnection.ObjectDates.Where(p => p.SdOid == sdOid);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.ObjectDates.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }
        
        public async Task<ICollection<ObjectDescriptionDto>> GetObjectDescriptions(string sdOid)
        {
            var data = _dbConnection.ObjectDescriptions.Where(p => p.SdOid == sdOid);
            return data.Any() ? _dataMapper.ObjectDescriptionDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<ObjectDescriptionDto> GetObjectDescription(int? id)
        {
            var objectDescription = await _dbConnection.ObjectDescriptions.FirstOrDefaultAsync(p => p.Id == id);
            return objectDescription != null ? _dataMapper.ObjectDescriptionDtoMapper(objectDescription) : null;
        }

        public async Task<ObjectDescriptionDto> CreateObjectDescription(ObjectDescriptionDto objectDescriptionDto)
        {
            var objectDescription = new ObjectDescription
            {
                SdOid = objectDescriptionDto.SdOid,
                CreatedOn = DateTime.Now,
                DescriptionTypeId = objectDescriptionDto.DescriptionTypeId,
                DescriptionText = objectDescriptionDto.DescriptionText,
                LangCode = objectDescriptionDto.LangCode,
                Label = objectDescriptionDto.Label
            };

            await _dbConnection.ObjectDescriptions.AddAsync(objectDescription);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.ObjectDescriptionDtoMapper(objectDescription);
        }

        public async Task<ObjectDescriptionDto> UpdateObjectDescription(ObjectDescriptionDto objectDescriptionDto)
        {
            var dbObjectDescription =
                await _dbConnection.ObjectDescriptions.FirstOrDefaultAsync(p => p.Id == objectDescriptionDto.Id);
            if (dbObjectDescription == null) return null;
            
            dbObjectDescription.DescriptionTypeId = objectDescriptionDto.DescriptionTypeId;
            dbObjectDescription.DescriptionText = objectDescriptionDto.DescriptionText;
            dbObjectDescription.LangCode = objectDescriptionDto.LangCode;
            dbObjectDescription.Label = objectDescriptionDto.Label;
                
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.ObjectDescriptionDtoMapper(dbObjectDescription);
        }

        public async Task<int> DeleteObjectDescription(int id)
        {
            var data = await _dbConnection.ObjectDescriptions.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.ObjectDescriptions.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllObjectDescriptions(string sdOid)
        {
            var data = _dbConnection.ObjectDescriptions.Where(p => p.SdOid == sdOid);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.ObjectDescriptions.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }
        
        public async Task<ICollection<ObjectIdentifierDto>> GetObjectIdentifiers(string sdOid)
        {
            var data = _dbConnection.ObjectIdentifiers.Where(p => p.SdOid == sdOid);
            return data.Any() ? _dataMapper.ObjectIdentifierDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<ObjectIdentifierDto> GetObjectIdentifier(int? id)
        {
            var objectIdentifier = await _dbConnection.ObjectIdentifiers.FirstOrDefaultAsync(p => p.Id == id);
            return objectIdentifier != null ? _dataMapper.ObjectIdentifierDtoMapper(objectIdentifier) : null;
        }

        public async Task<ObjectIdentifierDto> CreateObjectIdentifier(ObjectIdentifierDto objectIdentifierDto)
        {
            var objectIdentifier = new ObjectIdentifier
            {
                SdOid = objectIdentifierDto.SdOid,
                CreatedOn = DateTime.Now,
                IdentifierValue = objectIdentifierDto.IdentifierValue,
                IdentifierTypeId = objectIdentifierDto.IdentifierTypeId,
                IdentifierOrg = objectIdentifierDto.IdentifierOrg,
                IdentifierOrgId = objectIdentifierDto.IdentifierOrgId,
                IdentifierDate = objectIdentifierDto.IdentifierDate,
                IdentifierOrgRorId = objectIdentifierDto.IdentifierOrgRorId
            };

            await _dbConnection.ObjectIdentifiers.AddAsync(objectIdentifier);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.ObjectIdentifierDtoMapper(objectIdentifier);
        }

        public async Task<ObjectIdentifierDto> UpdateObjectIdentifier(ObjectIdentifierDto objectIdentifierDto)
        {
            var dbObjectIdentifier =
                await _dbConnection.ObjectIdentifiers.FirstOrDefaultAsync(p => p.Id == objectIdentifierDto.Id);
            if (dbObjectIdentifier == null) return null;
            
            dbObjectIdentifier.IdentifierValue = objectIdentifierDto.IdentifierValue;
            dbObjectIdentifier.IdentifierTypeId = objectIdentifierDto.IdentifierTypeId;
            dbObjectIdentifier.IdentifierOrg = objectIdentifierDto.IdentifierOrg;
            dbObjectIdentifier.IdentifierOrgId = objectIdentifierDto.IdentifierOrgId;
            dbObjectIdentifier.IdentifierDate = objectIdentifierDto.IdentifierDate;
            dbObjectIdentifier.IdentifierOrgRorId = objectIdentifierDto.IdentifierOrgRorId;

            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.ObjectIdentifierDtoMapper(dbObjectIdentifier);
        }

        public async Task<int> DeleteObjectIdentifier(int id)
        {
            var data = await _dbConnection.ObjectIdentifiers.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.ObjectIdentifiers.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllObjectIdentifiers(string sdOid)
        {
            var data = _dbConnection.ObjectIdentifiers.Where(p => p.SdOid == sdOid);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.ObjectIdentifiers.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }
        
        public async Task<ICollection<ObjectInstanceDto>> GetObjectInstances(string sdOid)
        {
            var data = _dbConnection.ObjectInstances.Where(p => p.SdOid == sdOid);
            return data.Any() ? _dataMapper.ObjectInstanceDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<ObjectInstanceDto> GetObjectInstance(int? id)
        {
            var objectInstance = await _dbConnection.ObjectInstances.FirstOrDefaultAsync(p => p.Id == id);
            return objectInstance != null ? _dataMapper.ObjectInstanceDtoMapper(objectInstance) : null;
        }

        public async Task<ObjectInstanceDto> CreateObjectInstance(ObjectInstanceDto objectInstanceDto)
        {
            var objectInstance = new ObjectInstance
            {
                SdOid = objectInstanceDto.SdOid,
                CreatedOn = DateTime.Now,
                InstanceTypeId = objectInstanceDto.InstanceTypeId,
                RepositoryOrgId = objectInstanceDto.RepositoryOrgId,
                RepositoryOrg = objectInstanceDto.RepositoryOrg,
                Url = objectInstanceDto.Url,
                UrlAccessible = objectInstanceDto.UrlAccessible,
                UrlLastChecked = objectInstanceDto.UrlLastChecked,
                ResourceTypeId = objectInstanceDto.ResourceTypeId,
                ResourceSize = objectInstanceDto.ResourceSize,
                ResourceSizeUnits = objectInstanceDto.ResourceSizeUnits,
                ResourceComments = objectInstanceDto.ResourceComments
            };

            await _dbConnection.ObjectInstances.AddAsync(objectInstance);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.ObjectInstanceDtoMapper(objectInstance);
        }

        public async Task<ObjectInstanceDto> UpdateObjectInstance(ObjectInstanceDto objectInstanceDto)
        {
            var dbObjectInstance =
                await _dbConnection.ObjectInstances.FirstOrDefaultAsync(p => p.Id == objectInstanceDto.Id);
            if (dbObjectInstance == null) return null;
            
            dbObjectInstance.InstanceTypeId = objectInstanceDto.InstanceTypeId;
            dbObjectInstance.RepositoryOrgId = objectInstanceDto.RepositoryOrgId;
            dbObjectInstance.RepositoryOrg = objectInstanceDto.RepositoryOrg;
            dbObjectInstance.Url = objectInstanceDto.Url;
            dbObjectInstance.UrlAccessible = objectInstanceDto.UrlAccessible;
            dbObjectInstance.UrlLastChecked = objectInstanceDto.UrlLastChecked;
            dbObjectInstance.ResourceTypeId = objectInstanceDto.ResourceTypeId;
            dbObjectInstance.ResourceSize = objectInstanceDto.ResourceSize;
            dbObjectInstance.ResourceSizeUnits = objectInstanceDto.ResourceSizeUnits;
            dbObjectInstance.ResourceComments = objectInstanceDto.ResourceComments;
            
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.ObjectInstanceDtoMapper(dbObjectInstance);
        }

        public async Task<int> DeleteObjectInstance(int id)
        {
            var data = await _dbConnection.ObjectInstances.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.ObjectInstances.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllObjectInstances(string sdOid)
        {
            var data = _dbConnection.ObjectInstances.Where(p => p.SdOid == sdOid);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.ObjectInstances.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }

        public async Task<ICollection<ObjectRelationshipDto>> GetObjectRelationships(string sdOid)
        {
            var data = _dbConnection.ObjectRelationships.Where(p => p.SdOid == sdOid);
            return data.Any() ? _dataMapper.ObjectRelationshipDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<ObjectRelationshipDto> GetObjectRelationship(int? id)
        {
            var objectRelation = await _dbConnection.ObjectRelationships.FirstOrDefaultAsync(p => p.Id == id);
            return objectRelation != null ? _dataMapper.ObjectRelationshipDtoMapper(objectRelation) : null;
        }

        public async Task<ObjectRelationshipDto> CreateObjectRelationship(ObjectRelationshipDto objectRelationshipDto)
        {
            var objectRelationship = new ObjectRelationship
            {
                SdOid = objectRelationshipDto.SdOid,
                CreatedOn = DateTime.Now,
                RelationshipTypeId = objectRelationshipDto.RelationshipTypeId,
                TargetSdOid = objectRelationshipDto.TargetSdOid
            };

            await _dbConnection.ObjectRelationships.AddAsync(objectRelationship);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.ObjectRelationshipDtoMapper(objectRelationship);
        }

        public async Task<ObjectRelationshipDto> UpdateObjectRelationship(ObjectRelationshipDto objectRelationshipDto)
        {
            var dbObjectRelation =
                await _dbConnection.ObjectRelationships.FirstOrDefaultAsync(p => p.Id == objectRelationshipDto.Id);
            if (dbObjectRelation == null) return null;
            
            dbObjectRelation.RelationshipTypeId = objectRelationshipDto.RelationshipTypeId;
            dbObjectRelation.TargetSdOid = objectRelationshipDto.TargetSdOid;

            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.ObjectRelationshipDtoMapper(dbObjectRelation);
        }

        public async Task<int> DeleteObjectRelationship(int id)
        {
            var data = await _dbConnection.ObjectRelationships.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.ObjectRelationships.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllObjectRelationships(string sdOid)
        {
            var data = _dbConnection.ObjectRelationships.Where(p => p.SdOid == sdOid);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.ObjectRelationships.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }
        
        public async Task<ICollection<ObjectRightDto>> GetObjectRights(string sdOid)
        {
            var data = _dbConnection.ObjectRights.Where(p => p.SdOid == sdOid);
            return data.Any() ? _dataMapper.ObjectRightDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<ObjectRightDto> GetObjectRight(int? id)
        {
            var objectRight = await _dbConnection.ObjectRights.FirstOrDefaultAsync(p => p.Id == id);
            return objectRight != null ? _dataMapper.ObjectRightDtoMapper(objectRight) : null;
        }

        public async Task<ObjectRightDto> CreateObjectRight(ObjectRightDto objectRightDto)
        {
            var objectRight = new ObjectRight
            {
                SdOid = objectRightDto.SdOid,
                CreatedOn = DateTime.Now,
                RightsName = objectRightDto.RightsName,
                RightsUri = objectRightDto.RightsUri,
                Comments = objectRightDto.Comments
            };

            await _dbConnection.ObjectRights.AddAsync(objectRight);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.ObjectRightDtoMapper(objectRight);
        }

        public async Task<ObjectRightDto> UpdateObjectRight(ObjectRightDto objectRightDto)
        {
            var dbObjectRight = await _dbConnection.ObjectRights.FirstOrDefaultAsync(p => p.Id == objectRightDto.Id);
            if (dbObjectRight == null) return null;
            
            dbObjectRight.RightsName = objectRightDto.RightsName;
            dbObjectRight.RightsUri = objectRightDto.RightsUri;
            dbObjectRight.Comments = objectRightDto.Comments;

            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.ObjectRightDtoMapper(dbObjectRight);
        }

        public async Task<int> DeleteObjectRight(int id)
        {
            var data = await _dbConnection.ObjectRights.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.ObjectRights.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllObjectRights(string sdOid)
        {
            var data = _dbConnection.ObjectRights.Where(p => p.SdOid == sdOid);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.ObjectRights.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }
        
        public async Task<ICollection<ObjectTitleDto>> GetObjectTitles(string sdOid)
        {
            var data = _dbConnection.ObjectTitles.Where(p => p.SdOid == sdOid);
            return data.Any() ? _dataMapper.ObjectTitleDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<ObjectTitleDto> GetObjectTitle(int? id)
        {
            var objectTitle = await _dbConnection.ObjectTitles.FirstOrDefaultAsync(p => p.Id == id);
            return objectTitle != null ? _dataMapper.ObjectTitleDtoMapper(objectTitle) : null;
        }

        public async Task<ObjectTitleDto> CreateObjectTitle(ObjectTitleDto objectTitleDto)
        {
            var objectTitle = new ObjectTitle
            {
                SdOid = objectTitleDto.SdOid,
                CreatedOn = DateTime.Now,
                TitleTypeId = objectTitleDto.TitleTypeId,
                IsDefault = objectTitleDto.IsDefault,
                TitleText = objectTitleDto.TitleText,
                LangCode = objectTitleDto.LangCode,
                LangUsageId = objectTitleDto.LangUsageId,
                Comments = objectTitleDto.Comments
            };

            await _dbConnection.ObjectTitles.AddAsync(objectTitle);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.ObjectTitleDtoMapper(objectTitle);
        }

        public async Task<ObjectTitleDto> UpdateObjectTitle(ObjectTitleDto objectTitleDto)
        {
            var dbObjectTitle = await _dbConnection.ObjectTitles.FirstOrDefaultAsync(p => p.Id == objectTitleDto.Id);
            if (dbObjectTitle == null) return null;
            
            dbObjectTitle.TitleTypeId = objectTitleDto.TitleTypeId;
            dbObjectTitle.IsDefault = objectTitleDto.IsDefault;
            dbObjectTitle.TitleText = objectTitleDto.TitleText;
            dbObjectTitle.LangCode = objectTitleDto.LangCode;
            dbObjectTitle.LangUsageId = objectTitleDto.LangUsageId;
            dbObjectTitle.Comments = objectTitleDto.Comments;
                
            await _dbConnection.SaveChangesAsync();
            return _dataMapper.ObjectTitleDtoMapper(dbObjectTitle);
        }

        public async Task<int> DeleteObjectTitle(int id)
        {
            var data = await _dbConnection.ObjectTitles.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.ObjectTitles.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllObjectTitles(string sdOid)
        {
            var data = _dbConnection.ObjectTitles.Where(p => p.SdOid == sdOid);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.ObjectTitles.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }
        
        public async Task<ICollection<ObjectTopicDto>> GetObjectTopics(string sdOid)
        {
            var data = _dbConnection.ObjectTopics.Where(p => p.SdOid == sdOid);
            return data.Any() ? _dataMapper.ObjectTopicDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<ObjectTopicDto> GetObjectTopic(int? id)
        {
            var objectTopic = await _dbConnection.ObjectTopics.FirstOrDefaultAsync(p => p.Id == id);
            return objectTopic != null ? _dataMapper.ObjectTopicDtoMapper(objectTopic) : null;
        }

        public async Task<ObjectTopicDto> CreateObjectTopic(ObjectTopicDto objectTopicDto)
        {
            var objectTopic = new ObjectTopic
            {
                SdOid = objectTopicDto.SdOid,
                CreatedOn = DateTime.Now,
                TopicTypeId = objectTopicDto.TopicTypeId,
                MeshCoded = objectTopicDto.MeshCoded,
                MeshCode = objectTopicDto.MeshCode,
                MeshValue = objectTopicDto.MeshValue,
                MeshQualcode = objectTopicDto.MeshQualcode,
                MeshQualvalue = objectTopicDto.MeshQualvalue,
                OriginalCtId = objectTopicDto.OriginalCtId,
                OriginalCtCode = objectTopicDto.OriginalCtCode,
                OriginalValue = objectTopicDto.OriginalValue,
                Comments = objectTopicDto.Comments
            };

            await _dbConnection.ObjectTopics.AddAsync(objectTopic);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.ObjectTopicDtoMapper(objectTopic);
        }

        public async Task<ObjectTopicDto> UpdateObjectTopic(ObjectTopicDto objectTopicDto)
        {
            var dbObjectTopic = await _dbConnection.ObjectTopics.FirstOrDefaultAsync(p => p.Id == objectTopicDto.Id);
            if (dbObjectTopic == null) return null;
            
            dbObjectTopic.TopicTypeId = objectTopicDto.TopicTypeId;
            dbObjectTopic.MeshCoded = objectTopicDto.MeshCoded;
            dbObjectTopic.MeshCode = objectTopicDto.MeshCode;
            dbObjectTopic.MeshValue = objectTopicDto.MeshValue;
            dbObjectTopic.MeshQualcode = objectTopicDto.MeshQualcode;
            dbObjectTopic.MeshQualvalue = objectTopicDto.MeshQualvalue;
            dbObjectTopic.OriginalCtId = objectTopicDto.OriginalCtId;
            dbObjectTopic.OriginalCtCode = objectTopicDto.OriginalCtCode;
            dbObjectTopic.OriginalValue = objectTopicDto.OriginalValue;
            dbObjectTopic.Comments = objectTopicDto.Comments;

            await _dbConnection.SaveChangesAsync();
            return _dataMapper.ObjectTopicDtoMapper(dbObjectTopic);
        }

        public async Task<int> DeleteObjectTopic(int id)
        {
            var data = await _dbConnection.ObjectTopics.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.ObjectTopics.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllObjectTopics(string sdOid)
        {
            var data = _dbConnection.ObjectTopics.Where(p => p.SdOid == sdOid);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.ObjectTopics.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }


        // DATA OBJECT
        public async Task<ICollection<DataObjectDto>> GetAllDataObjects()
        {
            var objectResponses = new List<DataObjectDto>();
            if (!_dbConnection.DataObjects.Any()) return null;
            var dataObjects = await _dbConnection.DataObjects.ToArrayAsync();
            foreach (var dataObject in dataObjects)
            {
                objectResponses.Add(await DataObjectBuilder(dataObject));
            }

            return objectResponses;
        }

        public async Task<DataObjectDto> GetObjectById(string sdOid)
        {
            var dataObject = await _dbConnection.DataObjects.FirstOrDefaultAsync(p => p.SdOid == sdOid);
            if (dataObject == null) return null;
            return await DataObjectBuilder(dataObject);
        }

        public async Task<DataObjectDto> CreateDataObject(DataObjectDto dataObjectDto)
        {
            var objId = 300001;
            var lastRecord = await _dbConnection.DataObjects.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            if (lastRecord != null)
            {
                objId = lastRecord.Id + 1;
            }

            var dataObject = new DataObject
            {
                SdOid = objId.ToString(),
                CreatedOn = DateTime.Now,
                SdSid = dataObjectDto.SdSid,
                DisplayTitle = dataObjectDto.DisplayTitle,
                Doi = dataObjectDto.Doi,
                Version = dataObjectDto.Version,
                DoiStatusId = dataObjectDto.DoiStatusId,
                PublicationYear = dataObjectDto.PublicationYear,
                ObjectClassId = dataObjectDto.ObjectClassId,
                ObjectTypeId = dataObjectDto.ObjectTypeId,
                ManagingOrgId = dataObjectDto.ManagingOrgId,
                ManagingOrg = dataObjectDto.ManagingOrg,
                ManagingOrgRorId = dataObjectDto.ManagingOrgRorId,
                LangCode = dataObjectDto.LangCode,
                AccessTypeId = dataObjectDto.AccessTypeId,
                AccessDetails = dataObjectDto.AccessDetails,
                AccessDetailsUrl = dataObjectDto.AccessDetailsUrl,
                UrlLastChecked = dataObjectDto.UrlLastChecked,
                EoscCategory = dataObjectDto.EoscCategory,
                AddStudyContribs = dataObjectDto.AddStudyContribs
            };

            await _dbConnection.DataObjects.AddAsync(dataObject);
            await _dbConnection.SaveChangesAsync();

            if (dataObjectDto.ObjectContributors is { Count: > 0 })
            {
                foreach (var oc in dataObjectDto.ObjectContributors)
                {
                    oc.SdOid ??= dataObjectDto.SdOid;
                    await CreateObjectContributor(oc);
                }
            }
            
            if (dataObjectDto.ObjectDatasets != null)
            {
                dataObjectDto.ObjectDatasets.SdOid ??= dataObjectDto.SdOid;
                await CreateObjectDataset(dataObjectDto.ObjectDatasets);
            }
            
            if (dataObjectDto.ObjectDates is { Count: > 0 })
            {
                foreach (var od in dataObjectDto.ObjectDates)
                {
                    od.SdOid ??= dataObjectDto.SdOid;
                    await CreateObjectDate(od);
                }
            }
            
            if (dataObjectDto.ObjectDescriptions is { Count: > 0 })
            {
                foreach (var od in dataObjectDto.ObjectDescriptions)
                {
                    od.SdOid ??= dataObjectDto.SdOid;
                    await CreateObjectDescription(od);
                }
            }
            
            if (dataObjectDto.ObjectIdentifiers is { Count: > 0 })
            {
                foreach (var oi in dataObjectDto.ObjectIdentifiers)
                {
                    oi.SdOid ??= dataObjectDto.SdOid;
                    await CreateObjectIdentifier(oi);
                }
            }
            
            if (dataObjectDto.ObjectInstances is { Count: > 0 })
            {
                foreach (var oi in dataObjectDto.ObjectInstances)
                {
                    oi.SdOid ??= dataObjectDto.SdOid;
                    await CreateObjectInstance(oi);
                }
            }
            
            if (dataObjectDto.ObjectRelationships is { Count: > 0 })
            {
                foreach (var or in dataObjectDto.ObjectRelationships)
                {
                    or.SdOid ??= dataObjectDto.SdOid;
                    await CreateObjectRelationship(or);
                }
            }
            
            if (dataObjectDto.ObjectRights is { Count: > 0 })
            {
                foreach (var or in dataObjectDto.ObjectRights)
                {
                    or.SdOid ??= dataObjectDto.SdOid;
                    await CreateObjectRight(or);
                }
            }
            
            if (dataObjectDto.ObjectTitles is { Count: > 0 })
            {
                foreach (var ot in dataObjectDto.ObjectTitles)
                {
                    ot.SdOid ??= dataObjectDto.SdOid;
                    await CreateObjectTitle(ot);
                }
            }
            
            if (dataObjectDto.ObjectTopics is { Count: > 0 })
            {
                foreach (var ot in dataObjectDto.ObjectTopics)
                {
                    ot.SdOid ??= dataObjectDto.SdOid;
                    await CreateObjectTopic(ot);
                }
            }
            
            return await DataObjectBuilder(dataObject);
        }

        public async Task<DataObjectDto> UpdateDataObject(DataObjectDto dataObjectDto)
        {
            var dbDataObject = await _dbConnection.DataObjects.FirstOrDefaultAsync(p => p.SdOid == dataObjectDto.SdOid);
            if (dbDataObject == null) return null;
            
            dbDataObject.DisplayTitle = dataObjectDto.DisplayTitle;
            dbDataObject.Doi = dataObjectDto.Doi;
            dbDataObject.Version = dataObjectDto.Version;
            dbDataObject.DoiStatusId = dataObjectDto.DoiStatusId;
            dbDataObject.PublicationYear = dataObjectDto.PublicationYear;
            dbDataObject.ObjectClassId = dataObjectDto.ObjectClassId;
            dbDataObject.ObjectTypeId = dataObjectDto.ObjectTypeId;
            dbDataObject.ManagingOrgId = dataObjectDto.ManagingOrgId;
            dbDataObject.ManagingOrg = dataObjectDto.ManagingOrg;
            dbDataObject.ManagingOrgRorId = dataObjectDto.ManagingOrgRorId;
            dbDataObject.LangCode = dataObjectDto.LangCode;
            dbDataObject.AccessTypeId = dataObjectDto.AccessTypeId;
            dbDataObject.AccessDetails = dataObjectDto.AccessDetails;
            dbDataObject.AccessDetailsUrl = dataObjectDto.AccessDetailsUrl;
            dbDataObject.UrlLastChecked = dataObjectDto.UrlLastChecked;
            dbDataObject.EoscCategory = dataObjectDto.EoscCategory;
            dbDataObject.AddStudyContribs = dataObjectDto.AddStudyContribs;
            
            if (dataObjectDto.ObjectContributors is { Count: > 0 })
            {
                foreach (var oc in dataObjectDto.ObjectContributors)
                {
                    if (oc.Id is null or 0)
                    {
                        oc.SdOid ??= dataObjectDto.SdOid;
                        await CreateObjectContributor(oc);
                    }
                    else
                    {
                        await UpdateObjectContributor(oc);
                    }
                }
            }
            
            if (dataObjectDto.ObjectDatasets != null)
            {
                if (dataObjectDto.ObjectDatasets.Id is null or 0)
                {
                    dataObjectDto.ObjectDatasets.SdOid ??= dataObjectDto.SdOid;
                    await CreateObjectDataset(dataObjectDto.ObjectDatasets);
                }
                else
                {
                    await UpdateObjectDataset(dataObjectDto.ObjectDatasets);
                }
            }
            
            if (dataObjectDto.ObjectDates is { Count: > 0 })
            {
                foreach (var od in dataObjectDto.ObjectDates)
                {
                    if (od.Id is null or 0)
                    {
                        od.SdOid ??= dataObjectDto.SdOid;
                        await CreateObjectDate(od);
                    }
                    else
                    {
                        await UpdateObjectDate(od);
                    }
                }
            }
            
            if (dataObjectDto.ObjectDescriptions is { Count: > 0 })
            {
                foreach (var od in dataObjectDto.ObjectDescriptions)
                {
                    if (od.Id is null or 0)
                    {
                        od.SdOid ??= dataObjectDto.SdOid;
                        await CreateObjectDescription(od);
                    }
                    else
                    {
                        await UpdateObjectDescription(od);
                    }
                }
            }
            
            if (dataObjectDto.ObjectIdentifiers is { Count: > 0 })
            {
                foreach (var oi in dataObjectDto.ObjectIdentifiers)
                {
                    if (oi.Id is null or 0)
                    {
                        oi.SdOid ??= dataObjectDto.SdOid;
                        await CreateObjectIdentifier(oi);
                    }
                    else
                    {
                        await UpdateObjectIdentifier(oi);
                    }
                }
            }
            
            if (dataObjectDto.ObjectInstances is { Count: > 0 })
            {
                foreach (var oi in dataObjectDto.ObjectInstances)
                {
                    if (oi.Id is null or 0)
                    {
                        oi.SdOid ??= dataObjectDto.SdOid;
                        await CreateObjectInstance(oi);
                    }
                    else
                    {
                        await UpdateObjectInstance(oi);
                    }
                }
            }
            
            if (dataObjectDto.ObjectRelationships is { Count: > 0 })
            {
                foreach (var or in dataObjectDto.ObjectRelationships)
                {
                    if (or.Id is null or 0)
                    {
                        or.SdOid ??= dataObjectDto.SdOid;
                        await CreateObjectRelationship(or);
                    }
                    else
                    {
                        await UpdateObjectRelationship(or);
                    }
                }
            }
            
            if (dataObjectDto.ObjectRights is { Count: > 0 })
            {
                foreach (var or in dataObjectDto.ObjectRights)
                {
                    if (or.Id is null or 0)
                    {
                        or.SdOid ??= dataObjectDto.SdOid;
                        await CreateObjectRight(or);
                    }
                    else
                    {
                        await UpdateObjectRight(or);
                    }
                }
            }
            
            if (dataObjectDto.ObjectTitles is { Count: > 0 })
            {
                foreach (var ot in dataObjectDto.ObjectTitles)
                {
                    if (ot.Id is null or 0)
                    {
                        ot.SdOid ??= dataObjectDto.SdOid;
                        await CreateObjectTitle(ot);
                    }
                    else
                    {
                        await UpdateObjectTitle(ot);
                    }
                }
            }
            
            if (dataObjectDto.ObjectTopics is { Count: > 0 })
            {
                foreach (var ot in dataObjectDto.ObjectTopics)
                {
                    if (ot.Id is null or 0)
                    {
                        ot.SdOid ??= dataObjectDto.SdOid;
                        await CreateObjectTopic(ot);
                    }
                    else
                    {
                        await UpdateObjectTopic(ot);
                    }
                }
            }
                
            await _dbConnection.SaveChangesAsync();
            return await DataObjectBuilder(dbDataObject);
        }

        public async Task<int> DeleteDataObject(string sdOid)
        {
            var dataObject = await _dbConnection.DataObjects.FirstOrDefaultAsync(p => p.SdOid == sdOid);
            if (dataObject == null) return 0;
            _dbConnection.DataObjects.Remove(dataObject);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<ICollection<DataObjectDataDto>> GetDataObjectsData()
        {
            if (!_dbConnection.DataObjects.Any()) return null;
            var dataObjects = await _dbConnection.DataObjects.ToArrayAsync();

            return dataObjects.Select(dataObject => _dataMapper.DataObjectDataDtoMapper(dataObject)).ToList();
        }

        public async Task<DataObjectDataDto> GetDataObjectData(string sdOid)
        {
            var data = await _dbConnection.DataObjects.FirstOrDefaultAsync(p => p.SdSid == sdOid);
            return data == null ? null : _dataMapper.DataObjectDataDtoMapper(data);
        }

        public async Task<ICollection<DataObjectDataDto>> GetRecentObjectData(int limit)
        {
            if (!_dbConnection.DataObjects.Any()) return null;

            var recentObjects = await _dbConnection.DataObjects.OrderByDescending(p => p.Id).Take(limit).ToArrayAsync();
            return _dataMapper.DataObjectDataDtoBuilder(recentObjects);
        }

        public async Task<DataObjectDataDto> CreateDataObjectData(DataObjectDataDto dataObjectData)
        {
            var objId = 300001;
            var lastRecord = await _dbConnection.DataObjects.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            if (lastRecord != null)
            {
                objId = lastRecord.Id + 1;
            }

            var dataObject = new DataObject
            {
                SdOid = objId.ToString(),
                CreatedOn = DateTime.Now,
                SdSid = dataObjectData.SdSid,
                DisplayTitle = dataObjectData.DisplayTitle,
                Doi = dataObjectData.Doi,
                Version = dataObjectData.Version,
                DoiStatusId = dataObjectData.DoiStatusId,
                PublicationYear = dataObjectData.PublicationYear,
                ObjectClassId = dataObjectData.ObjectClassId,
                ObjectTypeId = dataObjectData.ObjectTypeId,
                ManagingOrgId = dataObjectData.ManagingOrgId,
                ManagingOrg = dataObjectData.ManagingOrg,
                ManagingOrgRorId = dataObjectData.ManagingOrgRorId,
                LangCode = dataObjectData.LangCode,
                AccessTypeId = dataObjectData.AccessTypeId,
                AccessDetails = dataObjectData.AccessDetails,
                AccessDetailsUrl = dataObjectData.AccessDetailsUrl,
                UrlLastChecked = dataObjectData.UrlLastChecked,
                EoscCategory = dataObjectData.EoscCategory,
                AddStudyContribs = dataObjectData.AddStudyContribs
            };

            await _dbConnection.DataObjects.AddAsync(dataObject);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.DataObjectDataDtoMapper(dataObject);
        }
        
        public async Task<DataObjectDataDto> UpdateDataObjectData(DataObjectDataDto dataObjectData)
        {
            var dbDataObject = await _dbConnection.DataObjects.FirstOrDefaultAsync(p => p.SdOid == dataObjectData.SdOid);
            if (dbDataObject == null) return null;
            
            dbDataObject.DisplayTitle = dataObjectData.DisplayTitle;
            dbDataObject.Doi = dataObjectData.Doi;
            dbDataObject.Version = dataObjectData.Version;
            dbDataObject.DoiStatusId = dataObjectData.DoiStatusId;
            dbDataObject.PublicationYear = dataObjectData.PublicationYear;
            dbDataObject.ObjectClassId = dataObjectData.ObjectClassId;
            dbDataObject.ObjectTypeId = dataObjectData.ObjectTypeId;
            dbDataObject.ManagingOrgId = dataObjectData.ManagingOrgId;
            dbDataObject.ManagingOrg = dataObjectData.ManagingOrg;
            dbDataObject.ManagingOrgRorId = dataObjectData.ManagingOrgRorId;
            dbDataObject.LangCode = dataObjectData.LangCode;
            dbDataObject.AccessTypeId = dataObjectData.AccessTypeId;
            dbDataObject.AccessDetails = dataObjectData.AccessDetails;
            dbDataObject.AccessDetailsUrl = dataObjectData.AccessDetailsUrl;
            dbDataObject.UrlLastChecked = dataObjectData.UrlLastChecked;
            dbDataObject.EoscCategory = dataObjectData.EoscCategory;
            dbDataObject.AddStudyContribs = dataObjectData.AddStudyContribs;
                
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.DataObjectDataDtoMapper(dbDataObject);
        }


        private async Task<DataObjectDto> DataObjectBuilder(DataObject dataObject)
        {
            return new DataObjectDto()
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
                CreatedOn = dataObject.CreatedOn,
                ObjectContributors = await GetObjectContributors(dataObject.SdOid),
                ObjectDatasets = await GetObjectDatasets(dataObject.SdOid),
                ObjectDates = await GetObjectDates(dataObject.SdOid),
                ObjectDescriptions = await GetObjectDescriptions(dataObject.SdOid),
                ObjectIdentifiers = await GetObjectIdentifiers(dataObject.SdOid),
                ObjectInstances = await GetObjectInstances(dataObject.SdOid),
                ObjectRelationships = await GetObjectRelationships(dataObject.SdOid),
                ObjectRights = await GetObjectRights(dataObject.SdOid),
                ObjectTitles = await GetObjectTitles(dataObject.SdOid),
                ObjectTopics = await GetObjectTopics(dataObject.SdOid)
            };
        }

        private static int CalculateSkip(int page, int size)
        {
            var skip = 0;
            if (page > 1)
            {
                skip = (page - 1) * size;
            }

            return skip;
        }

        public async Task<PaginationResponse<DataObjectDto>> PaginateDataObjects(PaginationRequest paginationRequest)
        {
            var dataObjects = new List<DataObjectDto>();

            var skip = CalculateSkip(paginationRequest.Page, paginationRequest.Size);
            
            var query = _dbConnection.DataObjects
                .AsNoTracking()
                .OrderBy(arg => arg.Id);
            
            var data = await query.Skip(skip).Take(paginationRequest.Size).ToListAsync();
                        
            if (data is { Count: > 0 })
            {
                foreach (var dataObject in data)
                {
                    dataObjects.Add(await DataObjectBuilder(dataObject));
                }
            }

            var total = await query.CountAsync();

            return new PaginationResponse<DataObjectDto>
            {
                Total = total,
                Data = dataObjects
            };
        }

        public async Task<PaginationResponse<DataObjectDto>> FilterDataObjectsByTitle(FilteringByTitleRequest filteringByTitleRequest)
        {
            var dataObjects = new List<DataObjectDto>();

            var skip = CalculateSkip(filteringByTitleRequest.Page, filteringByTitleRequest.Size);
            
            var query = _dbConnection.DataObjects
                .AsNoTracking()
                .Where(p => p.DisplayTitle.ToLower().Contains(filteringByTitleRequest.Title.ToLower()))
                .OrderBy(arg => arg.Id);

            var data = await query
                .Skip(skip)
                .Take(filteringByTitleRequest.Size)
                .ToListAsync();

            var total = await query.CountAsync();
                        
            if (data is { Count: > 0 })
            {
                foreach (var dataObject in data)
                {
                    dataObjects.Add(await DataObjectBuilder(dataObject));
                }
            }

            return new PaginationResponse<DataObjectDto>
            {
                Total = total,
                Data = dataObjects
            };
        }

        public async Task<int> GetTotalDataObjects()
        {
            return await _dbConnection.DataObjects.AsNoTracking().CountAsync();
        }
    }
}