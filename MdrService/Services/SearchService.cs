using System;
using System.Linq;
using System.Threading.Tasks;
using MdrService.Contracts.Requests.v1;
using MdrService.Contracts.Responses.v1.SearchServiceResponse;
using MdrService.Interfaces;
using MdrService.Models.DbConnection;
using Microsoft.EntityFrameworkCore;


namespace MdrService.Services
{
    public class SearchService : ISearchService
    {
        private readonly MdrDbConnection _dbConnection;

        public SearchService(MdrDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
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


        public async Task<SearchServiceResponse> GetSpecificStudy(SpecificStudyRequest specificStudyRequest)
        {
            var skip = CalculateSkip(page:specificStudyRequest.Page, size:specificStudyRequest.Size);

            var searchQuery = _dbConnection.StudyIdentifiers.Where(
                    studyIdentifier => studyIdentifier.IdentifierTypeId.Equals(specificStudyRequest.SearchType) &&
                                       studyIdentifier.IdentifierValue.ToUpper().Equals(specificStudyRequest.SearchValue.ToUpper()))
                .Select(identifier => identifier.StudyId);
            
            
            var filtersRequest = specificStudyRequest.Filters;

            var studyFilterQuery = _dbConnection.Studies
                .Where(study => filtersRequest.StudyTypes.Contains(study.StudyTypeId)
                                && filtersRequest.StudyStatuses.Contains(study.StudyStatusId)
                                && filtersRequest.StudyGenderEligibility.Contains(study.StudyGenderEligId)).Select(study => study.Id);

            var studyFeatureFilterQuery = _dbConnection.StudyFeatures
                .Where(sf => filtersRequest.StudyFeatureValues.Contains(sf.FeatureValueId)).Select(sf => sf.StudyId);

            var dataObjectFilterQuery = _dbConnection.DataObjects
                .Where(dataObject => filtersRequest.ObjectTypes.Contains(dataObject.ObjectTypeId)
                                     && filtersRequest.ObjectAccessTypes.Contains(dataObject.AccessTypeId)).Select(o => o.Id);
            
            
            var query = _dbConnection.StudyObjectLinks
                .Where(link => searchQuery.Contains(link.StudyId)
                               && studyFilterQuery.Contains(link.StudyId)
                               && studyFeatureFilterQuery.Contains(link.StudyId) 
                               && dataObjectFilterQuery.Contains(link.ObjectId))
                .OrderBy(arg => arg.StudyId)
                .Select(t => t.StudyId)
                .Distinct();

            var totalRes = query.Count();
                    
            var slice = await query
                .Skip(skip).Take(specificStudyRequest.Size).ToArrayAsync();
            
            return new SearchServiceResponse()
            {
                Total = totalRes,
                StudyIds = slice
            };
        }

        public async Task<SearchServiceResponse> GetByStudyCharacteristics(StudyCharacteristicsRequest studyCharacteristicsRequest)
        {
            // Get skip
            var skip = CalculateSkip(page:studyCharacteristicsRequest.Page, size:studyCharacteristicsRequest.Size);

            /*
            var joinQuery = _dbConnection.StudyTitles.Join(
                _dbConnection.StudyTopics,
                title => title.StudyId,
                topic => topic.StudyId,
                (title, topic) => new
                {
                    title.StudyId,
                    title.TitleText,
                    topic.OriginalValue
                });

            if (!string.IsNullOrEmpty(studyCharacteristicsRequest.TitleContains))
            {
                joinQuery = joinQuery.Where(arg => arg.TitleText.ToLower().Contains(studyCharacteristicsRequest.TitleContains.ToLower()));
            }
            
            if (!string.IsNullOrEmpty(studyCharacteristicsRequest.TopicsInclude))
            {
                joinQuery = joinQuery.Where(arg => arg.OriginalValue.ToLower().Contains(studyCharacteristicsRequest.TopicsInclude.ToLower()));
            }

            var joinQueryStudyIds = joinQuery.Select(args => args.StudyId);
            */
            
            // Search queries
            var studyTitleQuery = _dbConnection.StudyTitles.Where(title =>
                    title.TitleText.ToLower().Contains(studyCharacteristicsRequest.TitleContains.ToLower()))
                .Select(title => title.StudyId);

            var studyTopicsQuery = _dbConnection.StudyTopics.Where(topic =>
                    topic.OriginalValue.ToLower().Contains(studyCharacteristicsRequest.TopicsInclude.ToLower()))
                .Select(topic => topic.StudyId);
            

            // Get filters
            
            var filtersRequest = studyCharacteristicsRequest.Filters;
            
            var studyFilterQuery = _dbConnection.Studies
                .Where(study => !filtersRequest.StudyTypes.Contains(study.StudyTypeId)
                                && !filtersRequest.StudyStatuses.Contains(study.StudyStatusId)
                                && !filtersRequest.StudyGenderEligibility.Contains(study.StudyGenderEligId)).Select(study => study.Id);

            var studyFeatureFilterQuery = _dbConnection.StudyFeatures
                .Where(sf => !filtersRequest.StudyFeatureValues.Contains(sf.FeatureValueId)).Select(sf => sf.StudyId);

            var dataObjectFilterQuery = _dbConnection.DataObjects
                .Where(dataObject => !filtersRequest.ObjectTypes.Contains(dataObject.ObjectTypeId)
                && !filtersRequest.ObjectAccessTypes.Contains(dataObject.AccessTypeId)).Select(o => o.Id);
            

            var query = _dbConnection.StudyObjectLinks;

            if (studyCharacteristicsRequest.LogicalOperator != null && 
                (studyCharacteristicsRequest.LogicalOperator.ToLower() == "and" ||
                 studyCharacteristicsRequest.LogicalOperator == "&&"))
            {
                var resQuery = query.Where(link => 
                        studyTitleQuery.Contains(link.StudyId)
                        && studyTopicsQuery.Contains(link.StudyId)
                        && studyFilterQuery.Contains(link.StudyId)
                        && studyFeatureFilterQuery.Contains(link.StudyId) 
                        && dataObjectFilterQuery.Contains(link.ObjectId))
                    .OrderBy(arg => arg.StudyId)
                    .Select(t => t.StudyId)
                    .Distinct();
                
                var totalRes = resQuery.Count();
                
                var slice = await resQuery
                    .Skip(skip).Take(studyCharacteristicsRequest.Size).ToArrayAsync();
                return new SearchServiceResponse()
                {
                    Total = totalRes,
                    StudyIds = slice
                };
            }
            else
            {
                var resQuery = query.Where(link => 
                        studyTitleQuery.Contains(link.StudyId)
                        || studyTopicsQuery.Contains(link.StudyId)
                        && studyFilterQuery.Contains(link.StudyId)
                        && studyFeatureFilterQuery.Contains(link.StudyId) 
                        && dataObjectFilterQuery.Contains(link.ObjectId))
                    .OrderBy(arg => arg.StudyId)
                    .Select(t => t.StudyId)
                    .Distinct();
                
                var totalRes = resQuery.Count();
                    
                var slice = await resQuery
                    .Skip(skip).Take(studyCharacteristicsRequest.Size).ToArrayAsync();
                return new SearchServiceResponse()
                {
                    Total = totalRes,
                    StudyIds = slice
                };
            }
        }

        public async Task<SearchServiceResponse> GetViaPublishedPaper(ViaPublishedPaperRequest viaPublishedPaperRequest)
        {

            var skip = CalculateSkip(page:viaPublishedPaperRequest.Page, size:viaPublishedPaperRequest.Size);

            // Get filters
            var filtersRequest = viaPublishedPaperRequest.Filters;
            
            var studyFilterQuery = _dbConnection.Studies
                .Where(study => filtersRequest.StudyTypes.Contains(study.StudyTypeId)
                                && filtersRequest.StudyStatuses.Contains(study.StudyStatusId)
                                && filtersRequest.StudyGenderEligibility.Contains(study.StudyGenderEligId)).Select(study => study.Id);

            var studyFeatureFilterQuery = _dbConnection.StudyFeatures
                .Where(sf => filtersRequest.StudyFeatureValues.Contains(sf.FeatureValueId)).Select(sf => sf.StudyId);

            var dataObjectFilterQuery = _dbConnection.DataObjects
                .Where(dataObject => filtersRequest.ObjectTypes.Contains(dataObject.ObjectTypeId)
                                     && filtersRequest.ObjectAccessTypes.Contains(dataObject.AccessTypeId)).Select(o => o.Id);

            if (viaPublishedPaperRequest.SearchType == "doi")
            {
                var query = _dbConnection.StudyObjectLinks.Where(p =>
                    _dbConnection.DataObjects
                        .Where(dataObject => dataObject.Doi.Contains(viaPublishedPaperRequest.SearchValue))
                        .Select(o => o.Id).Contains(p.ObjectId)
                    && studyFilterQuery.Contains(p.StudyId)
                    && studyFeatureFilterQuery.Contains(p.StudyId) 
                    && dataObjectFilterQuery.Contains(p.ObjectId))
                    .OrderBy(p => p.Id)
                    .Select(t => t.StudyId)
                    .Distinct();
                
                var totalRes = query.Count();
                    
                var slice = await query
                    .Skip(skip).Take(viaPublishedPaperRequest.Size).ToArrayAsync();
                
                return new SearchServiceResponse()
                {
                    Total = totalRes,
                    StudyIds = slice
                };
            }
            else
            {
                var query = _dbConnection.StudyObjectLinks.Where(
                    link => _dbConnection.ObjectTitles.Where(ot => ot.TitleText.ToLower()
                                .Contains(viaPublishedPaperRequest.SearchValue.ToLower()))
                        .Select(title => title.ObjectId).Contains(link.ObjectId)
                            && studyFilterQuery.Contains(link.StudyId)
                            && studyFeatureFilterQuery.Contains(link.StudyId) 
                            && dataObjectFilterQuery.Contains(link.ObjectId))
                    .OrderBy(p => p.StudyId)
                    .Select(t => t.StudyId)
                    .Distinct();
                
                var totalRes = query.Count();
                    
                var slice = await query
                    .Skip(skip).Take(viaPublishedPaperRequest.Size).ToArrayAsync();
                
                return new SearchServiceResponse()
                {
                    Total = totalRes,
                    StudyIds = slice
                };
            }
        }

        public async Task<int?> GetByStudyId(StudyIdRequest studyIdRequest)
        {
            var res = await _dbConnection.Studies.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id.Equals(studyIdRequest.StudyId));
            return res?.Id;
        }
    }
}