using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContextService.Interfaces;
using ContextService.Models.DbConnection;
using ContextService.Models.Lup;
using Microsoft.EntityFrameworkCore;

namespace ContextService.Repositories
{
    public class LupRepository : ILupRepository
    {
        private readonly ContextDbConnection _dbConnection;

        public LupRepository(ContextDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }
        
        public async Task<ICollection<ContributionType>> GetContributionTypes()
        {
            if (!_dbConnection.ContributionTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ContributionTypes
                .AsNoTracking()
                .Where(p => p.UseInDataEntry == true)
                .OrderBy(p => p.ListOrder).ToArrayAsync();
        }

        public async Task<ContributionType> GetContributionType(int id)
        {
            if (!_dbConnection.ContributionTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ContributionTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<DatasetConsentType>> GetDatasetConsentTypes()
        {
            if (!_dbConnection.DatasetConsentTypes.Any())
            {
                return null;
            }
            return await _dbConnection.DatasetConsentTypes
                .AsNoTracking()
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<DatasetConsentType> GetDatasetConsentType(int id)
        {
            if (!_dbConnection.DatasetConsentTypes.Any())
            {
                return null;
            }

            return await _dbConnection.DatasetConsentTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<DatasetDeidentificationLevel>> GetDatasetDeidentLevels()
        {
            if (!_dbConnection.DatasetDeidentificationLevels.Any())
            {
                return null;
            }
            return await _dbConnection.DatasetDeidentificationLevels
                .AsNoTracking()
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<DatasetDeidentificationLevel> GetDatasetDeidentLevel(int id)
        {
            if (!_dbConnection.DatasetDeidentificationLevels.Any())
            {
                return null;
            }
            return await _dbConnection.DatasetDeidentificationLevels
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<DatasetRecordkeyType>> GetDatasetRecordkeyTypes()
        {
            if (!_dbConnection.DatasetRecordkeyTypes.Any())
            {
                return null;
            }
            return await _dbConnection.DatasetRecordkeyTypes
                .AsNoTracking()
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<DatasetRecordkeyType> GetDatasetRecordkeyType(int id)
        {
            if (!_dbConnection.DatasetRecordkeyTypes.Any())
            {
                return null;
            }
            return await _dbConnection.DatasetRecordkeyTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<DateType>> GetDateTypes()
        {
            if (!_dbConnection.DateTypes.Any())
            {
                return null;
            }
            return await _dbConnection.DateTypes
                .AsNoTracking()
                .Where(p => p.UseInDataEntry == true)
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<DateType> GetDateType(int id)
        {
            if (!_dbConnection.DateTypes.Any())
            {
                return null;
            }
            return await _dbConnection.DateTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<DescriptionType>> GetDescriptionTypes()
        {
            if (!_dbConnection.DescriptionTypes.Any())
            {
                return null;
            }
            return await _dbConnection.DescriptionTypes
                .AsNoTracking()
                .Where(p => p.UseInDataEntry == true)
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<DescriptionType> GetDescriptionType(int id)
        {
            if (!_dbConnection.DescriptionTypes.Any())
            {
                return null;
            }
            return await _dbConnection.DescriptionTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<DoiStatusType>> GetDoiStatusTypes()
        {
            if (!_dbConnection.DoiStatusTypes.Any())
            {
                return null;
            }
            return await _dbConnection.DoiStatusTypes
                .AsNoTracking()
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<DoiStatusType> GetDoiStatusType(int id)
        {
            if (!_dbConnection.DoiStatusTypes.Any())
            {
                return null;
            }
            return await _dbConnection.DoiStatusTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<GenderEligibilityType>> GetGenderEligTypes()
        {
            if (!_dbConnection.GenderEligibilityTypes.Any())
            {
                return null;
            }
            return await _dbConnection.GenderEligibilityTypes
                .AsNoTracking()
                .Where(p => p.UseInDataEntry == true)
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<GenderEligibilityType> GetGenderEligType(int id)
        {
            if (!_dbConnection.GenderEligibilityTypes.Any())
            {
                return null;
            }
            return await _dbConnection.GenderEligibilityTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<GeogEntityType>> GetGeogEntityTypes()
        {
            if (!_dbConnection.GeogEntityTypes.Any())
            {
                return null;
            }
            return await _dbConnection.GeogEntityTypes
                .AsNoTracking()
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<GeogEntityType> GetGeogEntityType(int id)
        {
            if (!_dbConnection.GeogEntityTypes.Any())
            {
                return null;
            }
            return await _dbConnection.GeogEntityTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<IdentifierType>> GetIdentifierTypes()
        {
            if (!_dbConnection.IdentifierTypes.Any())
            {
                return null;
            }
            return await _dbConnection.IdentifierTypes
                .AsNoTracking()
                .Where(p => p.UseInDataEntry == true)
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<IdentifierType> GetIdentifierType(int id)
        {
            if (!_dbConnection.IdentifierTypes.Any())
            {
                return null;
            }
            return await _dbConnection.IdentifierTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<LanguageCode>> GetLanguageCodes()
        {
            if (!_dbConnection.LanguageCodes.Any())
            {
                return null;
            }
            return await _dbConnection.LanguageCodes
                .AsNoTracking()
                .OrderBy(p => p.Code)
                .ToArrayAsync();
        }

        public async Task<LanguageCode> GetLanguageCode(string code)
        {
            if (!_dbConnection.LanguageCodes.Any())
            {
                return null;
            }
            return await _dbConnection.LanguageCodes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Code == code);
        }

        public async Task<ICollection<LanguageUsageType>> GetLangUsageTypes()
        {
            if (!_dbConnection.LanguageUsageTypes.Any())
            {
                return null;
            }
            return await _dbConnection.LanguageUsageTypes
                .AsNoTracking()
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<LanguageUsageType> GetLangUsageType(int id)
        {
            if (!_dbConnection.LanguageUsageTypes.Any())
            {
                return null;
            }
            return await _dbConnection.LanguageUsageTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<LinkType>> GetLinkTypes()
        {
            if (!_dbConnection.LinkTypes.Any())
            {
                return null;
            }
            return await _dbConnection.LinkTypes
                .AsNoTracking()
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<LinkType> GetLinkType(int id)
        {
            if (!_dbConnection.LinkTypes.Any())
            {
                return null;
            }
            return await _dbConnection.LinkTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<ObjectAccessType>> GetObjectAccessTypes()
        {
            if (!_dbConnection.ObjectAccessTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectAccessTypes
                .AsNoTracking()
                .Where(p => p.UseInDataEntry == true)
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<ObjectAccessType> GetObjectAccessType(int id)
        {
            if (!_dbConnection.ObjectAccessTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectAccessTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<ObjectClass>> GetObjectClasses()
        {
            if (!_dbConnection.ObjectClasses.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectClasses
                .AsNoTracking()
                .Where(p => p.UseInDataEntry == true)
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<ObjectClass> GetObjectClass(int id)
        {
            if (!_dbConnection.ObjectClasses.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectClasses
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<ObjectFilterType>> GetObjectFilterTypes()
        {
            if (!_dbConnection.ObjectFilterTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectFilterTypes
                .AsNoTracking()
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<ObjectFilterType> GetObjectFilterType(int id)
        {
            if (!_dbConnection.ObjectFilterTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectFilterTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<ObjectInstanceType>> GetObjectInstanceTypes()
        {
            if (!_dbConnection.ObjectInstanceTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectInstanceTypes
                .AsNoTracking()
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<ObjectInstanceType> GetObjectInstanceType(int id)
        {
            if (!_dbConnection.ObjectInstanceTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectInstanceTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<ObjectRelationshipType>> GetObjectRelationshipTypes()
        {
            if (!_dbConnection.ObjectRelationshipTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectRelationshipTypes
                .AsNoTracking()
                .Where(p => p.UseInDataEntry == true)
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<ObjectRelationshipType> GetObjectRelationshipType(int id)
        {
            if (!_dbConnection.ObjectRelationshipTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectRelationshipTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<ObjectType>> GetObjectTypes()
        {
            if (!_dbConnection.ObjectTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectTypes
                .AsNoTracking()
                .Where(p => p.UseInDataEntry == true)
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<ObjectType> GetObjectType(int id)
        {
            if (!_dbConnection.ObjectTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<ResourceType>> GetResourceTypes()
        {
            if (!_dbConnection.ResourceTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ResourceTypes
                .AsNoTracking()
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<ResourceType> GetResourceType(int id)
        {
            if (!_dbConnection.ResourceTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ResourceTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<RmsUserType>> GetRmsUserTypes()
        {
            if (!_dbConnection.RmsUserTypes.Any())
            {
                return null;
            }
            return await _dbConnection.RmsUserTypes
                .AsNoTracking()
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<RmsUserType> GetRmsUserType(int id)
        {
            if (!_dbConnection.RmsUserTypes.Any())
            {
                return null;
            }
            return await _dbConnection.RmsUserTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<RoleClass>> GetRoleClasses()
        {
            if (!_dbConnection.RoleClasses.Any())
            {
                return null;
            }
            return await _dbConnection.RoleClasses
                .AsNoTracking()
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<RoleClass> GetRoleClass(int id)
        {
            if (!_dbConnection.RoleClasses.Any())
            {
                return null;
            }
            return await _dbConnection.RoleClasses
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<RoleType>> GetRoleTypes()
        {
            if (!_dbConnection.RoleTypes.Any())
            {
                return null;
            }
            return await _dbConnection.RoleTypes
                .AsNoTracking()
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<RoleType> GetRoleType(int id)
        {
            if (!_dbConnection.RoleTypes.Any())
            {
                return null;
            }
            return await _dbConnection.RoleTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<SizeUnit>> GetSizeUnits()
        {
            if (!_dbConnection.SizeUnits.Any())
            {
                return null;
            }
            return await _dbConnection.SizeUnits
                .AsNoTracking()
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<SizeUnit> GetSizeUnit(int id)
        {
            if (!_dbConnection.SizeUnits.Any())
            {
                return null;
            }
            return await _dbConnection.SizeUnits
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<StudyFeatureCategory>> GetStudyFeatureCategories()
        {
            if (!_dbConnection.StudyFeatureCategories.Any())
            {
                return null;
            }
            return await _dbConnection.StudyFeatureCategories
                .AsNoTracking()
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<StudyFeatureCategory> GetStudyFeatureCategory(int id)
        {
            if (!_dbConnection.StudyFeatureCategories.Any())
            {
                return null;
            }
            return await _dbConnection.StudyFeatureCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<StudyFeatureType>> GetStudyFeatureTypes()
        {
            if (!_dbConnection.StudyFeatureTypes.Any())
            {
                return null;
            }
            return await _dbConnection.StudyFeatureTypes
                .AsNoTracking()
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<StudyFeatureType> GetStudyFeatureType(int id)
        {
            if (!_dbConnection.StudyFeatureTypes.Any())
            {
                return null;
            }
            return await _dbConnection.StudyFeatureTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<StudyRelationshipType>> GetStudyRelationshipTypes()
        {
            if (!_dbConnection.StudyRelationshipTypes.Any())
            {
                return null;
            }
            return await _dbConnection.StudyRelationshipTypes
                .AsNoTracking()
                .Where(p => p.UseInDataEntry == true)
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<StudyRelationshipType> GetStudyRelationshipType(int id)
        {
            if (!_dbConnection.StudyRelationshipTypes.Any())
            {
                return null;
            }
            return await _dbConnection.StudyRelationshipTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<StudyStatus>> GetStudyStatuses()
        {
            if (!_dbConnection.StudyStatuses.Any())
            {
                return null;
            }
            return await _dbConnection.StudyStatuses
                .AsNoTracking()
                .Where(p => p.UseInDataEntry == true)
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<StudyStatus> GetStudyStatus(int id)
        {
            if (!_dbConnection.StudyStatuses.Any())
            {
                return null;
            }
            return await _dbConnection.StudyStatuses
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<StudyType>> GetStudyTypes()
        {
            if (!_dbConnection.StudyTypes.Any())
            {
                return null;
            }
            return await _dbConnection.StudyTypes
                .AsNoTracking()
                .Where(p => p.UseInDataEntry == true)
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<StudyType> GetStudyType(int id)
        {
            if (!_dbConnection.StudyTypes.Any())
            {
                return null;
            }
            return await _dbConnection.StudyTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<TimeUnit>> GetTimeUnits()
        {
            if (!_dbConnection.TimeUnits.Any())
            {
                return null;
            }
            return await _dbConnection.TimeUnits
                .AsNoTracking()
                .Where(p => p.UseInDataEntry == true)
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<TimeUnit> GetTimeUnit(int id)
        {
            if (!_dbConnection.TimeUnits.Any())
            {
                return null;
            }
            return await _dbConnection.TimeUnits
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<TitleType>> GetTitlesTypes()
        {
            if (!_dbConnection.TitleTypes.Any())
            {
                return null;
            }
            return await _dbConnection.TitleTypes
                .AsNoTracking()
                .Where(p => p.UseInDataEntry == true)
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<TitleType> GetTitleType(int id)
        {
            if (!_dbConnection.TitleTypes.Any())
            {
                return null;
            }
            return await _dbConnection.TitleTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<TopicType>> GetTopicTypes()
        {
            if (!_dbConnection.TopicTypes.Any())
            {
                return null;
            }
            return await _dbConnection.TopicTypes
                .AsNoTracking()
                .Where(p => p.UseInDataEntry == true)
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<TopicType> GetTopicType(int id)
        {
            if (!_dbConnection.TopicTypes.Any())
            {
                return null;
            }
            return await _dbConnection.TopicTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<CompositeHashType>> GetCompositeHashTypes()
        {
            if (!_dbConnection.CompositeHashTypes.Any()) return null;
            return await _dbConnection.CompositeHashTypes
                .AsNoTracking()
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<CompositeHashType> GetCompositeHashType(int id)
        {
            if (!_dbConnection.CompositeHashTypes.Any()) return null;
            return await _dbConnection.CompositeHashTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<OrgAttributeDatatype>> GetOrgAttributeDatatypes()
        {
            if (!_dbConnection.OrgAttributeDatatypes.Any()) return null;
            return await _dbConnection.OrgAttributeDatatypes
                .AsNoTracking()
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<OrgAttributeDatatype> GetOrgAttributeDatatype(int id)
        {
            if (!_dbConnection.OrgAttributeDatatypes.Any()) return null;
            return await _dbConnection.OrgAttributeDatatypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<OrgAttributeType>> GetOrgAttributeTypes()
        {
            if (!_dbConnection.OrgAttributeTypes.Any()) return null;
            return await _dbConnection.OrgAttributeTypes
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<OrgAttributeType> GetOrgAttributeType(int id)
        {
            if (!_dbConnection.OrgAttributeTypes.Any()) return null;
            return await _dbConnection.OrgAttributeTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<OrgClass>> GetOrgClasses()
        {
            if (!_dbConnection.OrgClasses.Any()) return null;
            return await _dbConnection.OrgClasses
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<OrgClass> GetOrgClass(int id)
        {
            if (!_dbConnection.OrgClasses.Any()) return null;
            return await _dbConnection.OrgClasses
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<OrgLinkType>> GetOrgLinkTypes()
        {
            if (!_dbConnection.OrgLinkTypes.Any()) return null;
            return await _dbConnection.OrgLinkTypes
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<OrgLinkType> GetOrgLinkType(int id)
        {
            if (!_dbConnection.OrgLinkTypes.Any()) return null;
            return await _dbConnection.OrgLinkTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<OrgNameQualifierType>> GetOrgNameQualifierTypes()
        {
            if (!_dbConnection.OrgNameQualifierTypes.Any()) return null;
            return await _dbConnection.OrgNameQualifierTypes
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<OrgNameQualifierType> GetOrgNameQualifierType(int id)
        {
            if (!_dbConnection.OrgNameQualifierTypes.Any()) return null;
            return await _dbConnection.OrgNameQualifierTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<OrgRelationshipType>> GetOrgRelationshipTypes()
        {
            if (!_dbConnection.OrgRelationshipTypes.Any()) return null;
            return await _dbConnection.OrgRelationshipTypes
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<OrgRelationshipType> GetOrgRelationshipType(int id)
        {
            if (!_dbConnection.OrgRelationshipTypes.Any()) return null;
            return await _dbConnection.OrgRelationshipTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<OrgType>> GetOrgTypes()
        {
            if (!_dbConnection.OrgTypes.Any()) return null;
            return await _dbConnection.OrgTypes
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<OrgType> GetOrgType(int id)
        {
            if (!_dbConnection.OrgTypes.Any()) return null;
            return await _dbConnection.OrgTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<TopicVocabulary>> GetTopicVocabularies()
        {
            if (!_dbConnection.TopicVocabularies.Any()) return null;
            return await _dbConnection.TopicVocabularies
                .AsNoTracking()
                .Where(p => p.UseInDataEntry == true)
                .OrderBy(p => p.ListOrder)
                .ToArrayAsync();
        }

        public async Task<TopicVocabulary> GetTopicVocabulary(int id)
        {
            if (!_dbConnection.TopicVocabularies.Any()) return null;
            return await _dbConnection.TopicVocabularies
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}