using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MdrService.Contracts.Requests.v1;
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
            _dbConnection = dbConnection;
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
        
        
        public async Task<ICollection<int>> GetSpecificStudy(SpecificStudyRequest specificStudyRequest)
        {
            var skip = CalculateSkip(page:specificStudyRequest.Page, size:specificStudyRequest.Size);

            var query = _dbConnection.StudyIdentifiers.Where(
                p => p.IdentifierTypeId.Equals(specificStudyRequest.SearchType) &&
                     p.IdentifierValue.ToUpper().Equals(specificStudyRequest.SearchValue.ToUpper()))
                .OrderBy(p => p.Id)
                .Select(p => p.StudyId)
                .Distinct()
                .Skip(skip)
                .Take(specificStudyRequest.Size);

            return await query.ToArrayAsync();
        }

        public async Task<ICollection<int>> GetByStudyCharacteristics(StudyCharacteristicsRequest studyCharacteristicsRequest)
        {
            var skip = CalculateSkip(page:studyCharacteristicsRequest.Page, size:studyCharacteristicsRequest.Size);
            
            var query = _dbConnection.StudyTitles.Join(
                _dbConnection.StudyTopics,
                title => title.StudyId,
                topic => topic.StudyId,
                (title, topic) => new {title, topic}
                );

            if (!string.IsNullOrEmpty(studyCharacteristicsRequest.TitleContains))
            {
                query = query.Where(arg => arg.title.TitleText.ToLower().Contains(studyCharacteristicsRequest.TitleContains.ToLower()));
            }
            
            if (!string.IsNullOrEmpty(studyCharacteristicsRequest.TopicsInclude))
            {
                query = query.Where(arg => arg.topic.OriginalValue.ToLower().Contains(studyCharacteristicsRequest.TopicsInclude.ToLower()));
            }

            var orderedQuery = query.OrderBy(arg => arg.title.Id);
            
            var selectRes = orderedQuery
                .Select(t => t.title.StudyId)
                .Distinct()
                .Skip(skip).Take(studyCharacteristicsRequest.Size);

            return await selectRes.ToArrayAsync();
        }

        public async Task<ICollection<int>> GetViaPublishedPaper(ViaPublishedPaperRequest viaPublishedPaperRequest)
        {
            var skip = CalculateSkip(page:viaPublishedPaperRequest.Page, size:viaPublishedPaperRequest.Size);

            if (viaPublishedPaperRequest.SearchType == "doi")
            {
                /*
                var query = _dbConnection.DataObjects.Where(p => p.Doi.Equals(viaPublishedPaperRequest.SearchValue));
                var orderedQuery = query.OrderBy(p => p.Id);
                var selectRes = orderedQuery.Select(p => p.Id)
                    .Distinct()
                    .Skip(skip)
                    .Take(viaPublishedPaperRequest.Size);
                
                return await selectRes.ToArrayAsync();
                */

                var query = _dbConnection.StudyObjectLinks.Where(p =>
                    p.ObjectId.Equals(
                        _dbConnection.DataObjects
                            .FirstOrDefault(
                                dataObject => 
                                    dataObject.Doi.Equals(viaPublishedPaperRequest.SearchValue)).Id));
                
                var orderedQuery = query.OrderBy(p => p.Id);
                var selectRes = orderedQuery.Select(p => p.StudyId)
                    .Distinct()
                    .Skip(skip)
                    .Take(viaPublishedPaperRequest.Size);
                
                return await selectRes.ToArrayAsync();
            }
            else
            {
                /*
                var query = _dbConnection.ObjectTitles.Where(p => p.TitleText.ToLower().Contains(viaPublishedPaperRequest.SearchValue));
                var orderedQuery = query.OrderBy(p => p.ObjectId);
                var selectRes = orderedQuery.Select(p => p.Id)
                    .Distinct()
                    .Skip(skip)
                    .Take(viaPublishedPaperRequest.Size);

                return await selectRes.ToArrayAsync();
                */
                var query = _dbConnection.StudyObjectLinks.Where(
                    link => _dbConnection.ObjectTitles
                        .Where(ot => 
                            ot.TitleText.ToLower()
                                .Contains(viaPublishedPaperRequest.SearchValue.ToLower()))
                        .Select(title => title.ObjectId).ToArray().Contains(link.ObjectId));
                
                var orderedQuery = query.OrderBy(p => p.StudyId);
                var selectRes = orderedQuery.Select(p => p.StudyId)
                    .Distinct()
                    .Skip(skip)
                    .Take(viaPublishedPaperRequest.Size);

                return await selectRes.ToArrayAsync();
            }
        }

        public async Task<int?> GetByStudyId(StudyIdRequest studyIdRequest)
        {
            var res = await _dbConnection.Studies
                .FirstOrDefaultAsync(p => p.Id.Equals(studyIdRequest.StudyId));
            return res?.Id;
        }
    }
}