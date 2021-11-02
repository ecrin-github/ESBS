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
            _dbConnection = dbConnection;
        }
        
        public async Task<ICollection<ContributionType>> GetContributionTypes()
        {
            if (!_dbConnection.ContributionTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ContributionTypes.ToArrayAsync();
        }

        public async Task<ContributionType> GetContributionType(int id)
        {
            if (!_dbConnection.ContributionTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ContributionTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<DatasetConsentType>> GetDatasetConsentTypes()
        {
            if (!_dbConnection.DatasetConsentTypes.Any())
            {
                return null;
            }
            return await _dbConnection.DatasetConsentTypes.ToArrayAsync();
        }

        public async Task<DatasetConsentType> GetDatasetConsentType(int id)
        {
            if (!_dbConnection.DatasetConsentTypes.Any())
            {
                return null;
            }

            return await _dbConnection.DatasetConsentTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<DatasetDeidentificationLevel>> GetDatasetDeidentLevels()
        {
            if (!_dbConnection.DatasetDeidentificationLevels.Any())
            {
                return null;
            }
            return await _dbConnection.DatasetDeidentificationLevels.ToArrayAsync();
        }

        public async Task<DatasetDeidentificationLevel> GetDatasetDeidentLevel(int id)
        {
            if (!_dbConnection.DatasetDeidentificationLevels.Any())
            {
                return null;
            }
            return await _dbConnection.DatasetDeidentificationLevels.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<DatasetRecordkeyType>> GetDatasetRecordkeyTypes()
        {
            if (!_dbConnection.DatasetRecordkeyTypes.Any())
            {
                return null;
            }
            return await _dbConnection.DatasetRecordkeyTypes.ToArrayAsync();
        }

        public async Task<DatasetRecordkeyType> GetDatasetRecordkeyType(int id)
        {
            if (!_dbConnection.DatasetRecordkeyTypes.Any())
            {
                return null;
            }
            return await _dbConnection.DatasetRecordkeyTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<DateType>> GetDateTypes()
        {
            if (!_dbConnection.DateTypes.Any())
            {
                return null;
            }
            return await _dbConnection.DateTypes.ToArrayAsync();
        }

        public async Task<DateType> GetDateType(int id)
        {
            if (!_dbConnection.DateTypes.Any())
            {
                return null;
            }
            return await _dbConnection.DateTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<DescriptionType>> GetDescriptionTypes()
        {
            if (!_dbConnection.DescriptionTypes.Any())
            {
                return null;
            }
            return await _dbConnection.DescriptionTypes.ToArrayAsync();
        }

        public async Task<DescriptionType> GetDescriptionType(int id)
        {
            if (!_dbConnection.DescriptionTypes.Any())
            {
                return null;
            }
            return await _dbConnection.DescriptionTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<DoiStatusType>> GetDoiStatusTypes()
        {
            if (!_dbConnection.DoiStatusTypes.Any())
            {
                return null;
            }
            return await _dbConnection.DoiStatusTypes.ToArrayAsync();
        }

        public async Task<DoiStatusType> GetDoiStatusType(int id)
        {
            if (!_dbConnection.DoiStatusTypes.Any())
            {
                return null;
            }
            return await _dbConnection.DoiStatusTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<GenderEligibilityType>> GetGenderEligTypes()
        {
            if (!_dbConnection.GenderEligibilityTypes.Any())
            {
                return null;
            }
            return await _dbConnection.GenderEligibilityTypes.ToArrayAsync();
        }

        public async Task<GenderEligibilityType> GetGenderEligType(int id)
        {
            if (!_dbConnection.GenderEligibilityTypes.Any())
            {
                return null;
            }
            return await _dbConnection.GenderEligibilityTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<GeogEntityType>> GetGeogEntityTypes()
        {
            if (!_dbConnection.GeogEntityTypes.Any())
            {
                return null;
            }
            return await _dbConnection.GeogEntityTypes.ToArrayAsync();
        }

        public async Task<GeogEntityType> GetGeogEntityType(int id)
        {
            if (!_dbConnection.GeogEntityTypes.Any())
            {
                return null;
            }
            return await _dbConnection.GeogEntityTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<IdentifierType>> GetIdentifierTypes()
        {
            if (!_dbConnection.IdentifierTypes.Any())
            {
                return null;
            }
            return await _dbConnection.IdentifierTypes.ToArrayAsync();
        }

        public async Task<IdentifierType> GetIdentifierType(int id)
        {
            if (!_dbConnection.IdentifierTypes.Any())
            {
                return null;
            }
            return await _dbConnection.IdentifierTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<LanguageCode>> GetLanguageCodes()
        {
            if (!_dbConnection.LanguageCodes.Any())
            {
                return null;
            }
            return await _dbConnection.LanguageCodes.ToArrayAsync();
        }

        public async Task<LanguageCode> GetLanguageCode(string code)
        {
            if (!_dbConnection.LanguageCodes.Any())
            {
                return null;
            }
            return await _dbConnection.LanguageCodes.FirstOrDefaultAsync(p => p.Code == code);
        }

        public async Task<ICollection<LanguageUsageType>> GetLangUsageTypes()
        {
            if (!_dbConnection.LanguageUsageTypes.Any())
            {
                return null;
            }
            return await _dbConnection.LanguageUsageTypes.ToArrayAsync();
        }

        public async Task<LanguageUsageType> GetLangUsageType(int id)
        {
            if (!_dbConnection.LanguageUsageTypes.Any())
            {
                return null;
            }
            return await _dbConnection.LanguageUsageTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<LinkType>> GetLinkTypes()
        {
            if (!_dbConnection.LinkTypes.Any())
            {
                return null;
            }
            return await _dbConnection.LinkTypes.ToArrayAsync();
        }

        public async Task<LinkType> GetLinkType(int id)
        {
            if (!_dbConnection.LinkTypes.Any())
            {
                return null;
            }
            return await _dbConnection.LinkTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<ObjectAccessType>> GetObjectAccessTypes()
        {
            if (!_dbConnection.ObjectAccessTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectAccessTypes.ToArrayAsync();
        }

        public async Task<ObjectAccessType> GetObjectAccessType(int id)
        {
            if (!_dbConnection.ObjectAccessTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectAccessTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<ObjectClass>> GetObjectClasses()
        {
            if (!_dbConnection.ObjectClasses.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectClasses.ToArrayAsync();
        }

        public async Task<ObjectClass> GetObjectClass(int id)
        {
            if (!_dbConnection.ObjectClasses.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectClasses.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<ObjectFilterType>> GetObjectFilterTypes()
        {
            if (!_dbConnection.ObjectFilterTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectFilterTypes.ToArrayAsync();
        }

        public async Task<ObjectFilterType> GetObjectFilterType(int id)
        {
            if (!_dbConnection.ObjectFilterTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectFilterTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<ObjectInstanceType>> GetObjectInstanceTypes()
        {
            if (!_dbConnection.ObjectInstanceTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectInstanceTypes.ToArrayAsync();
        }

        public async Task<ObjectInstanceType> GetObjectInstanceType(int id)
        {
            if (!_dbConnection.ObjectInstanceTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectInstanceTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<ObjectRelationshipType>> GetObjectRelationshipTypes()
        {
            if (!_dbConnection.ObjectRelationshipTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectRelationshipTypes.ToArrayAsync();
        }

        public async Task<ObjectRelationshipType> GetObjectRelationshipType(int id)
        {
            if (!_dbConnection.ObjectRelationshipTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectRelationshipTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<ObjectType>> GetObjectTypes()
        {
            if (!_dbConnection.ObjectTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectTypes.ToArrayAsync();
        }

        public async Task<ObjectType> GetObjectType(int id)
        {
            if (!_dbConnection.ObjectTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ObjectTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<ResourceType>> GetResourceTypes()
        {
            if (!_dbConnection.ResourceTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ResourceTypes.ToArrayAsync();
        }

        public async Task<ResourceType> GetResourceType(int id)
        {
            if (!_dbConnection.ResourceTypes.Any())
            {
                return null;
            }
            return await _dbConnection.ResourceTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<RmsUserType>> GetRmsUserTypes()
        {
            if (!_dbConnection.RmsUserTypes.Any())
            {
                return null;
            }
            return await _dbConnection.RmsUserTypes.ToArrayAsync();
        }

        public async Task<RmsUserType> GetRmsUserType(int id)
        {
            if (!_dbConnection.RmsUserTypes.Any())
            {
                return null;
            }
            return await _dbConnection.RmsUserTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<RoleClass>> GetRoleClasses()
        {
            if (!_dbConnection.RoleClasses.Any())
            {
                return null;
            }
            return await _dbConnection.RoleClasses.ToArrayAsync();
        }

        public async Task<RoleClass> GetRoleClass(int id)
        {
            if (!_dbConnection.RoleClasses.Any())
            {
                return null;
            }
            return await _dbConnection.RoleClasses.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<RoleType>> GetRoleTypes()
        {
            if (!_dbConnection.RoleTypes.Any())
            {
                return null;
            }
            return await _dbConnection.RoleTypes.ToArrayAsync();
        }

        public async Task<RoleType> GetRoleType(int id)
        {
            if (!_dbConnection.RoleTypes.Any())
            {
                return null;
            }
            return await _dbConnection.RoleTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<SizeUnit>> GetSizeUnits()
        {
            if (!_dbConnection.SizeUnits.Any())
            {
                return null;
            }
            return await _dbConnection.SizeUnits.ToArrayAsync();
        }

        public async Task<SizeUnit> GetSizeUnit(int id)
        {
            if (!_dbConnection.SizeUnits.Any())
            {
                return null;
            }
            return await _dbConnection.SizeUnits.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<StudyFeatureCategory>> GetStudyFeatureCategories()
        {
            if (!_dbConnection.StudyFeatureCategories.Any())
            {
                return null;
            }
            return await _dbConnection.StudyFeatureCategories.ToArrayAsync();
        }

        public async Task<StudyFeatureCategory> GetStudyFeatureCategory(int id)
        {
            if (!_dbConnection.StudyFeatureCategories.Any())
            {
                return null;
            }
            return await _dbConnection.StudyFeatureCategories.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<StudyFeatureType>> GetStudyFeatureTypes()
        {
            if (!_dbConnection.StudyFeatureTypes.Any())
            {
                return null;
            }
            return await _dbConnection.StudyFeatureTypes.ToArrayAsync();
        }

        public async Task<StudyFeatureType> GetStudyFeatureType(int id)
        {
            if (!_dbConnection.StudyFeatureTypes.Any())
            {
                return null;
            }
            return await _dbConnection.StudyFeatureTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<StudyRelationshipType>> GetStudyRelationshipTypes()
        {
            if (!_dbConnection.StudyRelationshipTypes.Any())
            {
                return null;
            }
            return await _dbConnection.StudyRelationshipTypes.ToArrayAsync();
        }

        public async Task<StudyRelationshipType> GetStudyRelationshipType(int id)
        {
            if (!_dbConnection.StudyRelationshipTypes.Any())
            {
                return null;
            }
            return await _dbConnection.StudyRelationshipTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<StudyStatus>> GetStudyStatuses()
        {
            if (!_dbConnection.StudyStatuses.Any())
            {
                return null;
            }
            return await _dbConnection.StudyStatuses.ToArrayAsync();
        }

        public async Task<StudyStatus> GetStudyStatus(int id)
        {
            if (!_dbConnection.StudyStatuses.Any())
            {
                return null;
            }
            return await _dbConnection.StudyStatuses.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<StudyType>> GetStudyTypes()
        {
            if (!_dbConnection.StudyTypes.Any())
            {
                return null;
            }
            return await _dbConnection.StudyTypes.ToArrayAsync();
        }

        public async Task<StudyType> GetStudyType(int id)
        {
            if (!_dbConnection.StudyTypes.Any())
            {
                return null;
            }
            return await _dbConnection.StudyTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<TimeUnit>> GetTimeUnits()
        {
            if (!_dbConnection.TimeUnits.Any())
            {
                return null;
            }
            return await _dbConnection.TimeUnits.ToArrayAsync();
        }

        public async Task<TimeUnit> GetTimeUnit(int id)
        {
            if (!_dbConnection.TimeUnits.Any())
            {
                return null;
            }
            return await _dbConnection.TimeUnits.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<TitleType>> GetTitlesTypes()
        {
            if (!_dbConnection.TitleTypes.Any())
            {
                return null;
            }
            return await _dbConnection.TitleTypes.ToArrayAsync();
        }

        public async Task<TitleType> GetTitleType(int id)
        {
            if (!_dbConnection.TitleTypes.Any())
            {
                return null;
            }
            return await _dbConnection.TitleTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<TopicType>> GetTopicTypes()
        {
            if (!_dbConnection.TopicTypes.Any())
            {
                return null;
            }
            return await _dbConnection.TopicTypes.ToArrayAsync();
        }

        public async Task<TopicType> GetTopicType(int id)
        {
            if (!_dbConnection.TopicTypes.Any())
            {
                return null;
            }
            return await _dbConnection.TopicTypes.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}