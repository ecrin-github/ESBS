using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MdrService.Configs;
using MdrService.Contracts.Requests.v1.DbSearch;
using MdrService.Contracts.Responses.v1.SearchResponse;
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

        private static StringBuilder FiltersListBuilder(IList<int> filterIds)
        {
            var filters = new StringBuilder("(");
            for (var index = 0; index < filterIds.Count; index++)
            {
                var idx = index + 1;
                if (idx == filterIds.Count)
                {
                    filters.Append(filterIds[index]);
                }
                else
                {
                    filters.Append(filterIds[index] + ", ");
                }
            }
            filters.Append(')');
            return filters;
        }


        private static StringBuilder FiltersBuilder(FiltersDbRequest filtersRequest)
        {
            if (filtersRequest == null) return null;

            var queryFilterString = new StringBuilder();
            
            if (filtersRequest.StudyTypes.Count > 0)
            {
                queryFilterString.Append($" and study_id in (select studies.id from core.studies studies where studies.study_type_id in {FiltersListBuilder(filtersRequest.StudyTypes)})");
            }
            if (filtersRequest.StudyStatuses.Count > 0)
            {
                queryFilterString.Append($" and study_id in (select studies.id from core.studies studies where studies.study_status_id in {FiltersListBuilder(filtersRequest.StudyStatuses)})");
            }
            if (filtersRequest.StudyGenderEligibility.Count > 0)
            {
                queryFilterString.Append($" and study_id in (select studies.id from core.studies studies where studies.study_gender_elig_id in {FiltersListBuilder(filtersRequest.StudyGenderEligibility)})");
            }
            if (filtersRequest.StudyFeatureValues.Count > 0)
            {
                queryFilterString.Append($" and study_id in (select sf.id from core.study_features sf where sf.feature_value_id in {FiltersListBuilder(filtersRequest.StudyFeatureValues)})");
            }
            if (filtersRequest.ObjectTypes.Count > 0)
            {
                queryFilterString.Append($" and object_id in (select d_o.id from core.data_objects d_o where d_o.object_type_id in {FiltersListBuilder(filtersRequest.ObjectTypes)})");
            }
            if (filtersRequest.ObjectAccessTypes.Count > 0)
            {
                queryFilterString.Append($" and object_id in (select d_o.id from core.data_objects d_o where d_o.access_type_id in {FiltersListBuilder(filtersRequest.ObjectAccessTypes)})");
            }

            return queryFilterString;
        }
        
        
        
        public async Task<SearchServiceResponse> GetSpecificStudy(SpecificStudyDbRequest specificStudyRequest)
        {
            var skip = CalculateSkip(page: specificStudyRequest.Page, size: specificStudyRequest.Size);

            await using var connection = new NpgsqlConnection(DbConfig.MdrDbConnectionString);

            var queryString = new StringBuilder();
            var totalQueryString = new StringBuilder();

            queryString.Append("with search_query as (");
            totalQueryString.Append("with total_query as (");
            
            queryString.Append("select distinct study_id ");
            queryString.Append("from core.study_object_links ");
            queryString.Append("where study_id in ");
            queryString.Append("(select si.study_id ");
            queryString.Append("from core.study_identifiers si ");
            queryString.Append($"where si.identifier_type_id = {specificStudyRequest.SearchType} ");
            queryString.Append($"and upper(si.identifier_value) = upper('{specificStudyRequest.SearchValue}')) ");

            totalQueryString.Append("select count(distinct study_id) ");
            totalQueryString.Append("from core.study_object_links ");
            totalQueryString.Append("where study_id in ");
            totalQueryString.Append("(select si.study_id ");
            totalQueryString.Append("from core.study_identifiers si ");
            totalQueryString.Append($"where si.identifier_type_id = {specificStudyRequest.SearchType} ");
            totalQueryString.Append($"and upper(si.identifier_value) = upper('{specificStudyRequest.SearchValue}'))");

            var filters = FiltersBuilder(specificStudyRequest.Filters);
            if (filters != null)
            {
                queryString.Append(filters);
                totalQueryString.Append(filters);
            }
            
            queryString.Append(") ");
            totalQueryString.Append(") ");

            queryString.Append("select * from search_query");
            queryString.Append($" order by study_id asc limit {specificStudyRequest.Size} offset {skip}");
            
            totalQueryString.Append("select * from total_query");
            
            var result = await connection.QueryAsync(queryString.ToString());

            var ids = new List<int>();
            if (result != null)
            {
                ids.AddRange(result.Select(studyId => studyId.study_id).Cast<int>());
            }

            var totalRecords = await connection.QueryFirstAsync(totalQueryString.ToString());
            
            return new SearchServiceResponse()
            {
                Total = totalRecords.count,
                StudyIds = ids
            };
        }

        public async Task<SearchServiceResponse> GetByStudyCharacteristics(StudyCharacteristicsDbRequest studyCharacteristicsRequest)
        {
            var skip = CalculateSkip(page: studyCharacteristicsRequest.Page, size: studyCharacteristicsRequest.Size);

            await using var connection = new NpgsqlConnection(DbConfig.MdrDbConnectionString);

            var queryString = new StringBuilder();
            var totalQueryString = new StringBuilder();
            
            queryString.Append("with search_query as (");
            totalQueryString.Append("with total_query as (");

            queryString.Append("select distinct study_id ");
            queryString.Append("from core.study_object_links ");
            queryString.Append("where study_id in ");
            queryString.Append("(select st1.study_id from core.study_titles st1 ");
            queryString.Append("inner join core.study_topics st2 on st1.study_id = st2.study_id ");
            queryString.Append($"where lower(st1.title_text) like lower('%{studyCharacteristicsRequest.TitleContains}%') ");
            
            totalQueryString.Append("select count(distinct study_id) ");
            totalQueryString.Append("from core.study_object_links ");
            totalQueryString.Append("where study_id in ");
            totalQueryString.Append("(select st1.study_id from core.study_titles st1 ");
            totalQueryString.Append("inner join core.study_topics st2 on st1.study_id = st2.study_id ");
            totalQueryString.Append($"where lower(st1.title_text) like lower('%{studyCharacteristicsRequest.TitleContains}%') ");
            
            if (studyCharacteristicsRequest.LogicalOperator?.ToLower() == "and" ||
                studyCharacteristicsRequest.LogicalOperator?.ToLower() == "&&")
            {
                queryString.Append($"and lower(st2.original_value) like lower('%{studyCharacteristicsRequest.TopicsInclude}%'))");
                totalQueryString.Append($"and lower(st2.original_value) like lower('%{studyCharacteristicsRequest.TopicsInclude}%'))");
            }
            else
            {
                queryString.Append($"or lower(st2.original_value) like lower('%{studyCharacteristicsRequest.TopicsInclude}%'))");
                totalQueryString.Append($"or lower(st2.original_value) like lower('%{studyCharacteristicsRequest.TopicsInclude}%'))");
            }
            
            var filters = FiltersBuilder(studyCharacteristicsRequest.Filters);
            if (filters != null)
            {
                queryString.Append(filters);
                totalQueryString.Append(filters);
            }
            
            queryString.Append(") ");
            totalQueryString.Append(") ");

            queryString.Append("select * from search_query");
            queryString.Append($" order by study_id asc limit {studyCharacteristicsRequest.Size} offset {skip}");
            
            totalQueryString.Append("select * from total_query");

            var result = await connection.QueryAsync(queryString.ToString());
            
            var ids = new List<int>();
            if (result != null)
            {
                ids.AddRange(result.Select(studyId => studyId.study_id).Cast<int>());
            }
            
            var totalRecords = await connection.QueryFirstAsync(totalQueryString.ToString());

            return new SearchServiceResponse()
            {
                Total = totalRecords.count,
                StudyIds = ids
            };
        }

        public async Task<SearchServiceResponse> GetViaPublishedPaper(ViaPublishedPaperDbRequest viaPublishedPaperRequest)
        {
            var skip = CalculateSkip(page: viaPublishedPaperRequest.Page, size: viaPublishedPaperRequest.Size);

            await using var connection = new NpgsqlConnection(DbConfig.MdrDbConnectionString);

            var queryString = new StringBuilder();
            var totalQueryString = new StringBuilder();
            
            queryString.Append("with search_query as (");
            totalQueryString.Append("with total_query as (");

            queryString.Append("select distinct study_id ");
            queryString.Append("from core.study_object_links ");
            queryString.Append("where object_id in ");

            totalQueryString.Append("select count(distinct study_id) ");
            totalQueryString.Append("from core.study_object_links ");
            totalQueryString.Append("where object_id in ");

            if (viaPublishedPaperRequest.SearchType.ToLower() == "doi")
            {
                queryString.Append("(select d_o.id ");
                queryString.Append("from core.data_objects d_o ");
                queryString.Append($"where lower(d_o.doi) = lower({viaPublishedPaperRequest.SearchValue}))");
                
                totalQueryString.Append("(select d_o.id ");
                totalQueryString.Append("from core.data_objects d_o ");
                totalQueryString.Append($"where lower(d_o.doi) = lower({viaPublishedPaperRequest.SearchValue}))");
            }
            else
            {

                queryString.Append("(select ot.object_id ");
                queryString.Append("from core.object_titles ot ");
                queryString.Append($"where lower(ot.title_text) like lower('%{viaPublishedPaperRequest.SearchValue}%'))");
                
                totalQueryString.Append("(select ot.object_id ");
                totalQueryString.Append("from core.object_titles ot ");
                totalQueryString.Append($"where lower(ot.title_text) like lower('%{viaPublishedPaperRequest.SearchValue}%'))");
            }
            
            var filters = FiltersBuilder(viaPublishedPaperRequest.Filters);
            if (filters != null)
            {
                queryString.Append(filters);
                totalQueryString.Append(filters);
            }
            
            queryString.Append(") ");
            totalQueryString.Append(") ");

            queryString.Append("select * from search_query");
            queryString.Append($" order by study_id asc limit {viaPublishedPaperRequest.Size} offset {skip}");
            
            totalQueryString.Append("select * from total_query");
            
            var result = await connection.QueryAsync(queryString.ToString());

            var ids = new List<int>();
            if (result != null)
            {
                ids.AddRange(result.Select(studyId => studyId.study_id).Cast<int>());
            }

            var totalRecords = await connection.QueryFirstAsync(totalQueryString.ToString());
            
            return new SearchServiceResponse()
            {
                Total = totalRecords.count,
                StudyIds = ids
            };
        }
    }
}