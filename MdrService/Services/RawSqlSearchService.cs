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

        private static string FiltersListBuilder(IReadOnlyList<int> filterIds)
        {
            var filters = "(";
            for (var index = 0; index < filterIds.Count; index++)
            {
                var idx = index + 1;
                if (idx == filterIds.Count)
                {
                    filters += filterIds[index];
                }

                filters += filterIds[index] + ", ";
            }
            filters += ")";
            return filters;
        }
        
        public async Task<RawSqlSearchServiceResponse> GetSpecificStudy(SpecificStudyRequest specificStudyRequest)
        {
            var skip = CalculateSkip(page: specificStudyRequest.Page, size: specificStudyRequest.Size);

            await using var connection = new NpgsqlConnection(DbConfig.MdrDbConnectionString);

            var queryString = "select distinct study_id " +
                              "from core.study_object_links " +
                              "where study_id in " +
                              "(select si.study_id " +
                              "from core.study_identifiers si " +
                              $"where si.identifier_type_id = {specificStudyRequest.SearchType} " +
                              $"and upper(si.identifier_value) = upper({specificStudyRequest.SearchValue})) ";
            
            var totalQueryString = "select count(distinct study_id) " +
                                   "from core.study_object_links " +
                                   "where study_id in " +
                                   "(select si.study_id " +
                                   "from core.study_identifiers si " +
                                   $"where si.identifier_type_id = {specificStudyRequest.SearchType} " +
                                   $"and upper(si.identifier_value) = upper({specificStudyRequest.SearchValue})) ";

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

            queryString += $"order by study_id asc " +
                           $"limit {specificStudyRequest.Size} " +
                           $"offset {skip}";
            

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

            var queryString = "select distinct study_id " +
                              "from core.study_object_links " +
                              "where study_id in " +
                              "(select st1.study_id from core.study_titles st1 " +
                              "inner join core.study_topics st2 on st1.study_id = st2.study_id " +
                              $"where lower(st1.title_text) like lower('%{studyCharacteristicsRequest.TitleContains}%') ";
            
            var totalQueryString = "select count(distinct study_id) " +
                                   "from core.study_object_links " +
                                   "where study_id in " +
                                   "(select st1.study_id from core.study_titles st1 " +
                                   "inner join core.study_topics st2 on st1.study_id = st2.study_id " +
                                   $"where lower(st1.title_text) like lower('%{studyCharacteristicsRequest.TitleContains}%') ";

            if (studyCharacteristicsRequest.LogicalOperator?.ToLower() == "and" ||
                studyCharacteristicsRequest.LogicalOperator?.ToLower() == "&&")
            {
                queryString += $"and lower(st2.original_value) like lower('%{studyCharacteristicsRequest.TopicsInclude}%')";
                totalQueryString += $"and lower(st2.original_value) like lower('%{studyCharacteristicsRequest.TopicsInclude}%')";
            }
            else
            {
                queryString += $"or lower(st2.original_value) like lower('%{studyCharacteristicsRequest.TopicsInclude}%')";
                totalQueryString += $"or lower(st2.original_value) like lower('%{studyCharacteristicsRequest.TopicsInclude}%')";
            }
            
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
            
            queryString += ")";
            totalQueryString += ")";
            
            queryString += $"order by study_id asc " +
                           $"limit {studyCharacteristicsRequest.Size} " +
                           $"offset {skip}";

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

            var queryString = "select distinct study_id " +
                              "from core.study_object_links " +
                              "where object_id in ";

            var totalQueryString = "select count(distinct study_id) " +
                                   "from core.study_object_links " +
                                   "where object_id in ";

            if (viaPublishedPaperRequest.SearchType.ToLower() == "doi")
            {
                queryString += "(select d_o.id " +
                               "from core.data_objects d_o " +
                               $"where lower(d_o.doi) = lower({viaPublishedPaperRequest.SearchValue}))";
                
                totalQueryString += "(select d_o.id " +
                                    "from core.data_objects d_o " +
                                    $"where lower(d_o.doi) = lower({viaPublishedPaperRequest.SearchValue}))";
            }
            else
            {
                queryString += "(select ot.object_id " +
                               "from core.object_titles ot " +
                               $"where lower(ot.title_text) like lower('%{viaPublishedPaperRequest.SearchValue}%'))";
                
                totalQueryString += "(select ot.object_id " +
                                    "from core.object_titles ot " +
                                    $"where lower(ot.title_text) like lower('%{viaPublishedPaperRequest.SearchValue}%'))";
            }
            
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

            queryString += " order by study_id asc " +
                           $"limit {viaPublishedPaperRequest.Size} " +
                           $"offset {skip}";
            
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