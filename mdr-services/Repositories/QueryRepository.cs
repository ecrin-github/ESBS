using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using mdr_services.Contracts.Requests.v1;
using mdr_services.Contracts.Responses.v1;
using mdr_services.Contracts.Responses.v1.FetchedData;
using mdr_services.Contracts.Responses.v1.StudyListResponse;
using mdr_services.Interfaces;
using mdr_services.Models.Elasticsearch.Object;
using mdr_services.Models.Elasticsearch.Study;
using Nest;

namespace mdr_services.Repositories
{
    public class QueryRepository : IQueryRepository
    {
        private readonly IElasticSearchService _elasticSearchService;
        private readonly IDataMapper _dataMapper;

        public QueryRepository(IElasticSearchService elasticSearchService, IDataMapper dataMapper)
        {
            _elasticSearchService = elasticSearchService;
            _dataMapper = dataMapper;
        }

        private static int? CalculateStartFrom(int? page, int? pageSize)
        {
            if (page != null && pageSize == null) return null;
            var startFrom = ((page + 1) * pageSize) - pageSize;
            if (startFrom == 1 && pageSize == 1)
            {
                startFrom = 0;
            }
            return startFrom;
        }

        private static bool HasProperty(object obj, string propertyName)
        {
            if (obj == null) return false;
            return obj.GetType().GetProperty(propertyName) != null;
        }

        public async Task<BaseResponse> GetSpecificStudy(SpecificStudyRequest specificStudyRequest)
        {
            var startFrom = CalculateStartFrom(specificStudyRequest.Page, specificStudyRequest.Size);

            var identifierValue = specificStudyRequest.SearchValue.ToUpper().Trim();

            FiltersListRequest filtersListRequest = null;

            List<QueryContainer> filters = null;
            if (HasProperty(specificStudyRequest, "Filters") && specificStudyRequest.Filters != null)
            {
                filtersListRequest = specificStudyRequest.Filters;
                if (HasProperty(specificStudyRequest.Filters, "StudyFilters"))
                {
                    filters = specificStudyRequest.Filters!.StudyFilters.Select(param => new RawQuery(JsonSerializer.Serialize(param))).Select(dummy => (QueryContainer)dummy).ToList();
                }
            }
            
            var queryClause = new List<QueryContainer>
            {
                new NestedQuery()
                {
                    Name = "",
                    Path = new Field("study_identifiers"),
                    Query = new TermQuery()
                            {
                                Field = Infer.Field<Study>(p => p.StudyIdentifiers.First()
                                    .IdentifierType.Id), Value = specificStudyRequest.SearchType
                            } &&
                            new TermQuery()
                            {
                                Field = Infer.Field<Study>(p => p.StudyIdentifiers.First()
                                    .IdentifierValue), Value = identifierValue
                            }
                }
            };

            if (filters is { Count: > 0 })
            {
                queryClause.Add(new BoolQuery()
                {
                    Should = filters
                });
            }

            var boolQuery = new BoolQuery()
            {
                Must = queryClause
            };
            
            SearchRequest<Study> searchRequest;
            if (startFrom != null)
            {
                searchRequest = new SearchRequest<Study>(Indices.Index("study"))
                {
                    From = startFrom,
                    Size = specificStudyRequest.Size,
                    Query = boolQuery
                };
            }
            else
            {
                searchRequest = new SearchRequest<Study>(Indices.Index("study"))
                {
                    Query = boolQuery
                };
            }
            
            var results = await _elasticSearchService.GetConnection().SearchAsync<Study>(searchRequest);
            FetchedStudies fetchedStudies = new FetchedStudies()
            {
                Total = results.Total,
                Studies = results.Documents.ToList()
            };
            var studies = await _dataMapper.MapStudies(fetchedStudies, filtersListRequest);
            return new BaseResponse()
            {
                Total = results.Total,
                Data = studies
            };
            
        }

        public async Task<BaseResponse> GetByStudyCharacteristics(StudyCharacteristicsRequest studyCharacteristicsRequest)
        {
            var startFrom = CalculateStartFrom(studyCharacteristicsRequest.Page, studyCharacteristicsRequest.Size);
            
            FiltersListRequest filtersListRequest = null;
            
            List<QueryContainer> filters = null;
            if (HasProperty(studyCharacteristicsRequest, "Filters") && studyCharacteristicsRequest.Filters != null)
            {
                filtersListRequest = studyCharacteristicsRequest.Filters;
                if (HasProperty(studyCharacteristicsRequest.Filters, "StudyFilters"))
                {
                    filters = filtersListRequest.StudyFilters.Select(param => new RawQuery(JsonSerializer.Serialize(param))).Select(dummy => (QueryContainer)dummy).ToList();
                }
            }

            var queryClauses = new List<QueryContainer>();

            if (!string.IsNullOrEmpty(studyCharacteristicsRequest.TitleContains))
            {
                queryClauses.Add(new SimpleQueryStringQuery()
                {
                    Fields = Infer.Field<Study>(f => f.DisplayTitle),
                    Query = studyCharacteristicsRequest.TitleContains,
                    DefaultOperator = Operator.And
                });
                queryClauses.Add(new NestedQuery()
                {
                    Path = Infer.Field<Study>(p => p.StudyTitles),
                    Query = new SimpleQueryStringQuery()
                    {
                        Fields = Infer.Field<Study>(f => f.StudyTitles.First().TitleText),
                        Query = studyCharacteristicsRequest.TitleContains,
                        DefaultOperator = Operator.And
                    }
                });
            }

            if (!string.IsNullOrEmpty(studyCharacteristicsRequest.TopicsInclude))
            {
                queryClauses.Add(new NestedQuery()
                {
                    Path = Infer.Field<Study>(p => p.StudyTopics),
                    Query = new SimpleQueryStringQuery()
                    {
                        Fields = Infer.Field<Study>(f => f.StudyTopics.First().MeshValue).And("original_value"),
                        Query = studyCharacteristicsRequest.TopicsInclude,
                        DefaultOperator = Operator.And
                    }
                });
            }

            if (filters is { Count: > 0 })
            {
                queryClauses.Add(new BoolQuery()
                {
                    Should = filters
                });
            }

            var logicalOperator = studyCharacteristicsRequest.LogicalOperator;

            if (string.IsNullOrEmpty(logicalOperator))
            {
                logicalOperator = "and";
            }

            BoolQuery boolQuery;
            if (logicalOperator == "and")
            {
                boolQuery = new BoolQuery()
                {
                    Must = queryClauses
                };
            }
            else
            {
                boolQuery = new BoolQuery()
                {
                    Should = queryClauses
                };
            }

            SearchRequest<Study> searchRequest;
            if (startFrom != null)
            {
                searchRequest = new SearchRequest<Study>(Indices.Index("study"))
                {
                    From = startFrom,
                    Size = studyCharacteristicsRequest.Size,
                    Query = boolQuery
                };
            }
            else
            {
                searchRequest = new SearchRequest<Study>(Indices.Index("study"))
                {
                    Query = boolQuery
                };
            }
            
            {
                var results = await _elasticSearchService.GetConnection().SearchAsync<Study>(searchRequest);
                var fetchedStudies = new FetchedStudies()
                {
                    Total = results.Total,
                    Studies = results.Documents.ToList()
                };
                var studies = await _dataMapper.MapStudies(fetchedStudies, filtersListRequest);
                return new BaseResponse()
                {
                    Total = results.Total,
                    Data = studies
                };
            }
        }

        public async Task<BaseResponse> GetViaPublishedPaper(ViaPublishedPaperRequest viaPublishedPaperRequest)
        {
            var startFrom = CalculateStartFrom(viaPublishedPaperRequest.Page, viaPublishedPaperRequest.Size);

            List<QueryContainer> filters = null;
            if (HasProperty(viaPublishedPaperRequest, "Filters") && viaPublishedPaperRequest.Filters != null)
            {
                var filtersListRequest = viaPublishedPaperRequest.Filters;
                if (HasProperty(viaPublishedPaperRequest.Filters, "ObjectFilters"))
                {
                    filters = filtersListRequest.ObjectFilters.Select(param => new RawQuery(JsonSerializer.Serialize(param))).Select(dummy => (QueryContainer)dummy).ToList();
                }
            }
            
            var mustQuery = new List<QueryContainer>();
            
            if (viaPublishedPaperRequest.SearchType == "doi")
            {
                mustQuery.Add(new TermQuery()
                {
                    Field = Infer.Field<Object>(p => p.Doi),
                    Value = viaPublishedPaperRequest.SearchValue
                });
            }
            else
            {
                var shouldClauses = new List<QueryContainer>
                {
                    new SimpleQueryStringQuery()
                    {
                        Query = viaPublishedPaperRequest.SearchValue,
                        Fields = Infer.Field<Object>(p => p.DisplayTitle),
                        DefaultOperator = Operator.And
                    },
                    new NestedQuery()
                    {
                        Path = Infer.Field<Object>(p => p.ObjectTitles),
                        Query = new SimpleQueryStringQuery()
                        {
                            Query = viaPublishedPaperRequest.SearchValue,
                            Fields = Infer.Field<Object>(p => p.ObjectTitles.First().TitleText),
                            DefaultOperator = Operator.And
                        }
                    }
                };
                mustQuery.Add(new BoolQuery()
                {
                    Should = shouldClauses
                });
            }
            
            if (filters is { Count: > 0 })
            {
                mustQuery.Add(new BoolQuery()
                {
                    Should = filters
                });
            }

            var boolQuery = new BoolQuery()
            {
                Must = mustQuery
            };
            
            SearchRequest<Object> searchRequest;
            if (startFrom != null)
            {
                searchRequest = new SearchRequest<Object>(Indices.Index("data-object"))
                {
                    From = startFrom,
                    Size = viaPublishedPaperRequest.Size,
                    Query = boolQuery
                };
            }
            else
            {
                searchRequest = new SearchRequest<Object>(Indices.Index("data-object"))
                {
                    Query = boolQuery
                };
            }
            
            {
                var results = await _elasticSearchService.GetConnection().SearchAsync<Object>(searchRequest);

                var studies = await _dataMapper.MapViaPublishedPaper(results.Documents.ToList());

                return new BaseResponse()
                {
                    Total = results.Total,
                    Data = studies
                };
            }
        }

        public async Task<IEnumerable<StudyListResponse>> GetByStudyId(StudyIdRequest studyIdRequest)
        {
            var results = await _elasticSearchService.GetConnection().SearchAsync<Study>(s => s
                .Index("study")
                .From(0)
                .Size(1)
                .Query(q => q
                    .Term(t => t
                        .Field(p => p.Id)
                        .Value(studyIdRequest.StudyId.ToString())
                    )
                )
            );
            return await _dataMapper.MapStudy(results.Documents.ToList());
        }
    }
}