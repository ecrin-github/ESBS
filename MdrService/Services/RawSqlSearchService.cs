using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MdrService.Configs;
using MdrService.Contracts.Requests.v1;
using MdrService.Contracts.Responses.v1.RawSqlSearchServiceResponse;
using MdrService.Interfaces;
using Npgsql;

namespace MdrService.Services
{
    public class RawSqlSearchService : IRawSqlSearchService
    {
        private static int CalculateSkip(int page, int size)
        {
            var skip = 0;
            if (page > 1)
            {
                skip = (page - 1) * size;
            }

            return skip;
        }
        
        public async Task<RawSqlSearchServiceResponse> GetSpecificStudy(SpecificStudyRequest specificStudyRequest)
        {
            var skip = CalculateSkip(page: specificStudyRequest.Page, size: specificStudyRequest.Size);

            await using var connection = new NpgsqlConnection(DbConfig.MdrDbConnectionString);

            var queryString = "";
            var totalQueryString = "";

            if (specificStudyRequest.Filters != null)
            {
                if (specificStudyRequest.Filters.StudyTypes.Count > 0)
                {
                    queryString += "";
                    totalQueryString += "";
                }
                if (specificStudyRequest.Filters.StudyStatuses.Count > 0)
                {
                    queryString += "";
                    totalQueryString += "";
                }
                if (specificStudyRequest.Filters.StudyGenderEligibility.Count > 0)
                {
                    queryString += "";
                    totalQueryString += "";
                }
                if (specificStudyRequest.Filters.StudyFeatureValues.Count > 0)
                {
                    queryString += "";
                    totalQueryString += "";
                }
                if (specificStudyRequest.Filters.ObjectTypes.Count > 0)
                {
                    queryString += "";
                    totalQueryString += "";
                }
                if (specificStudyRequest.Filters.ObjectAccessTypes.Count > 0)
                {
                    queryString += "";
                    totalQueryString += "";
                }
            }
            

            var result = await connection.QueryAsync(queryString);

            var ids = new List<int>();
            if (result != null)
            {
                ids.AddRange(result.Select(studyId => studyId.study_id).Cast<int>());
            }

            var totalRecords = await connection.QueryFirstAsync(totalQueryString);
            
            return new RawSqlSearchServiceResponse()
            {
                Total = totalRecords.count,
                StudyIds = ids
            };
        }

        public async Task<RawSqlSearchServiceResponse> GetByStudyCharacteristics(StudyCharacteristicsRequest studyCharacteristicsRequest)
        {
            var skip = CalculateSkip(page: studyCharacteristicsRequest.Page, size: studyCharacteristicsRequest.Size);

            await using var connection = new NpgsqlConnection(DbConfig.MdrDbConnectionString);

            var queryString = "";
            var totalQueryString = "";
            
            if (studyCharacteristicsRequest.Filters != null)
            {
                if (studyCharacteristicsRequest.Filters.StudyTypes.Count > 0)
                {
                    queryString += "";
                    totalQueryString += "";
                }
                if (studyCharacteristicsRequest.Filters.StudyStatuses.Count > 0)
                {
                    queryString += "";
                    totalQueryString += "";
                }
                if (studyCharacteristicsRequest.Filters.StudyGenderEligibility.Count > 0)
                {
                    queryString += "";
                    totalQueryString += "";
                }
                if (studyCharacteristicsRequest.Filters.StudyFeatureValues.Count > 0)
                {
                    queryString += "";
                    totalQueryString += "";
                }
                if (studyCharacteristicsRequest.Filters.ObjectTypes.Count > 0)
                {
                    queryString += "";
                    totalQueryString += "";
                }
                if (studyCharacteristicsRequest.Filters.ObjectAccessTypes.Count > 0)
                {
                    queryString += "";
                    totalQueryString += "";
                }
            }

            var result = await connection.QueryAsync(queryString);

            var ids = new List<int>();
            if (result != null)
            {
                ids.AddRange(result.Select(studyId => studyId.study_id).Cast<int>());
            }

            var totalRecords = await connection.QueryFirstAsync(totalQueryString);

            return new RawSqlSearchServiceResponse()
            {
                Total = totalRecords.count,
                StudyIds = ids
            };
        }

        public async Task<RawSqlSearchServiceResponse> GetViaPublishedPaper(ViaPublishedPaperRequest viaPublishedPaperRequest)
        {
            var skip = CalculateSkip(page: viaPublishedPaperRequest.Page, size: viaPublishedPaperRequest.Size);

            await using var connection = new NpgsqlConnection(DbConfig.MdrDbConnectionString);

            var queryString = "";
            var totalQueryString = "";
            
            if (viaPublishedPaperRequest.Filters != null)
            {
                if (viaPublishedPaperRequest.Filters.StudyTypes.Count > 0)
                {
                    queryString += "";
                    totalQueryString += "";
                }
                if (viaPublishedPaperRequest.Filters.StudyStatuses.Count > 0)
                {
                    queryString += "";
                    totalQueryString += "";
                }
                if (viaPublishedPaperRequest.Filters.StudyGenderEligibility.Count > 0)
                {
                    queryString += "";
                    totalQueryString += "";
                }
                if (viaPublishedPaperRequest.Filters.StudyFeatureValues.Count > 0)
                {
                    queryString += "";
                    totalQueryString += "";
                }
                if (viaPublishedPaperRequest.Filters.ObjectTypes.Count > 0)
                {
                    queryString += "";
                    totalQueryString += "";
                }
                if (viaPublishedPaperRequest.Filters.ObjectAccessTypes.Count > 0)
                {
                    queryString += "";
                    totalQueryString += "";
                }
            }

            queryString += "";
            
            var result = await connection.QueryAsync(queryString);

            var ids = new List<int>();
            if (result != null)
            {
                ids.AddRange(result.Select(studyId => studyId.study_id).Cast<int>());
            }

            var totalRecords = await connection.QueryFirstAsync(totalQueryString);

            return new RawSqlSearchServiceResponse()
            {
                Total = totalRecords.count,
                StudyIds = ids
            };
        }
    }
}