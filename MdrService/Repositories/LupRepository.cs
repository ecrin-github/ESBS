#nullable enable
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using MdrService.Interfaces;
using MdrService.Models.DbConnection;

namespace MdrService.Repositories
{
    public class LupRepository : ILupRepository
    {
        private readonly ContextDbConnection _dbConnection;

        public LupRepository(ContextDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }
        
        public async Task<string?> GetContributionType(int? id)
        {
            if (id == null) return null;
            var contribType = await _dbConnection.ContributionTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return contribType?.Name;
        }

        public async Task<string?> GetDatasetConsentType(int? id)
        {
            if (id == null) return null;
            var consentType = await _dbConnection.DatasetConsentTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return consentType?.Name;
        }
        
        public async Task<string?> GetDatasetDeidentLevel(int? id)
        {
            if (id == null) return null;
            var deidentLevel = await _dbConnection.DatasetDeidentificationLevels.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return deidentLevel?.Name;
        }
        
        public async Task<string?> GetDatasetRecordkeyType(int? id)
        {
            if (id == null) return null;
            var rkType = await _dbConnection.DatasetRecordkeyTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return rkType?.Name;
        }
        
        public async Task<string?> GetDateType(int? id)
        {
            if (id == null) return null;
            var dateType = await _dbConnection.DateTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return dateType?.Name;
        }
        
        public async Task<string?> GetDescriptionType(int? id)
        {
            if (id == null) return null;
            var descType = await _dbConnection.DescriptionTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return descType?.Name;
        }
        
        public async Task<string?> GetDoiStatusType(int? id)
        {
            if (id == null) return null;
            var doiStatusType = await _dbConnection.DoiStatusTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return doiStatusType?.Name;
        }

        public async Task<string?> GetGenderEligType(int? id)
        {
            if (id == null) return null;
            var genderEligType = await _dbConnection.GenderEligibilityTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return genderEligType?.Name;
        }

        public async Task<string?> GetGeogEntityType(int? id)
        {
            if (id == null) return null;
            var geogEntityType = await _dbConnection.GeogEntityTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return geogEntityType?.Name;
        }
        
        public async Task<string?> GetIdentifierType(int? id)
        {
            if (id == null) return null;
            var identifierType = await _dbConnection.IdentifierTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return identifierType?.Name;
        }
        
        public async Task<string?> GetLanguageCode(string? code)
        {
            if (code == null) return null;
            var langCode = await _dbConnection.LanguageCodes.FirstOrDefaultAsync(p => p.Code.Equals(code.ToLower()));
            return langCode?.LangNameEn;
        }
        
        public async Task<string?> GetLangUsageType(int? id)
        {
            if (id == null) return null;
            var langUsageType = await _dbConnection.LanguageUsageTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return langUsageType?.Name;
        }
        
        public async Task<string?> GetLinkType(int? id)
        {
            if (id == null) return null;
            var linkType = await _dbConnection.LinkTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return linkType?.Name;
        }
        
        public async Task<string?> GetObjectAccessType(int? id)
        {
            if (id == null) return null;
            var objectAccessType = await _dbConnection.ObjectAccessTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return objectAccessType?.Name;
        }
        
        public async Task<string?> GetObjectClass(int? id)
        {
            if (id == null) return null;
            var objectClass = await _dbConnection.ObjectClasses.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return objectClass?.Name;
        }
        
        public async Task<string?> GetObjectFilterType(int? id)
        {
            if (id == null) return null;
            var objectFilterType = await _dbConnection.ObjectFilterTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return objectFilterType?.Name;
        }
        
        public async Task<string?> GetObjectInstanceType(int? id)
        {
            if (id == null) return null;
            var objectInstanceType = await _dbConnection.ObjectInstanceTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return objectInstanceType?.Name;
        }

        public async Task<string?> GetObjectRelationshipType(int? id)
        {
            if (id == null) return null;
            var objectRelType = await _dbConnection.ObjectRelationshipTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return objectRelType?.Name;
        }
        
        public async Task<string?> GetObjectType(int? id)
        {
            if (id == null) return null;
            var objectType = await _dbConnection.ObjectTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return objectType?.Name;
        }

        public async Task<string?> GetResourceType(int? id)
        {
            if (id == null) return null;
            var resType = await _dbConnection.ResourceTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return resType?.Name;
        }
        
        public async Task<string?> GetSizeUnit(int? id)
        {
            if (id == null) return null;
            var sizeUnit = await _dbConnection.SizeUnits.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return sizeUnit?.Name;
        }
        
        public async Task<string?> GetStudyFeatureCategory(int? id)
        {
            if (id == null) return null;
            var studyFeatureCategory = await _dbConnection.StudyFeatureCategories.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return studyFeatureCategory?.Name;
        }

        public async Task<string?> GetStudyFeatureType(int? id)
        {
            if (id == null) return null;
            var studyFeatureType = await _dbConnection.StudyFeatureTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return studyFeatureType?.Name;
        }

        public async Task<string?> GetStudyRelationshipType(int? id)
        {
            if (id == null) return null;
            var studyRelType = await _dbConnection.StudyRelationshipTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return studyRelType?.Name;
        }

        public async Task<string?> GetStudyStatus(int? id)
        {
            if (id == null) return null;
            var studyStatus = await _dbConnection.StudyStatuses.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return studyStatus?.Name;
        }
        
        public async Task<string?> GetStudyType(int? id)
        {
            if (id == null) return null;
            var studyType = await _dbConnection.StudyTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return studyType?.Name;
        }

        public async Task<string?> GetTimeUnit(int? id)
        {
            if (id == null) return null;
            var timeUnit = await _dbConnection.TimeUnits.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return timeUnit?.Name;
        }

        public async Task<string?> GetTitleType(int? id)
        {
            if (id == null) return null;
            var titleType = await _dbConnection.TitleTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return titleType?.Name;
        }

        public async Task<string?> GetTopicType(int? id)
        {
            if (id == null) return null;
            var topicType = await _dbConnection.TopicTypes.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return topicType?.Name;
        }
    }
}