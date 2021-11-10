using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MdrService.Contracts.Requests.v1;
using MdrService.Contracts.Responses.v1;
using MdrService.Contracts.Responses.v1.StudyListResponse;
using MdrService.Interfaces;
using MdrService.Models.Elasticsearch.Study;
using Nest;

namespace MdrService.Repositories
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
            
            List<QueryContainer> filters = null;
            if (specificStudyRequest.Filters != null && HasProperty(specificStudyRequest, "Filters") && specificStudyRequest.Filters.Count > 0)
            {
                filters = specificStudyRequest.Filters!.Select(param => new RawQuery(JsonSerializer.Serialize(param))).Select(dummy => (QueryContainer)dummy).ToList();
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
                searchRequest = new SearchRequest<Study>(Indices.Index("mdr-record"))
                {
                    From = startFrom,
                    Size = specificStudyRequest.Size,
                    Query = boolQuery
                };
            }
            else
            {
                searchRequest = new SearchRequest<Study>(Indices.Index("mdr-record"))
                {
                    Query = boolQuery
                };
            }
            
            var results = await _elasticSearchService.GetConnection().SearchAsync<Study>(searchRequest);
            var studies = _dataMapper.MapStudies(results.Documents.ToList());
            return new BaseResponse()
            {
                Total = results.Total,
                Data = studies
            };
        }

        public async Task<BaseResponse> GetByStudyCharacteristics(StudyCharacteristicsRequest studyCharacteristicsRequest)
        {
            var startFrom = CalculateStartFrom(studyCharacteristicsRequest.Page, studyCharacteristicsRequest.Size);
            
            List<QueryContainer> filters = null;
            if (studyCharacteristicsRequest.Filters != null && HasProperty(studyCharacteristicsRequest, "Filters") && studyCharacteristicsRequest.Filters.Count > 0)
            {
                filters = studyCharacteristicsRequest.Filters!.Select(param => new RawQuery(JsonSerializer.Serialize(param))).Select(dummy => (QueryContainer)dummy).ToList();
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
                searchRequest = new SearchRequest<Study>(Indices.Index("mdr-record"))
                {
                    From = startFrom,
                    Size = studyCharacteristicsRequest.Size,
                    Query = boolQuery
                };
            }
            else
            {
                searchRequest = new SearchRequest<Study>(Indices.Index("mdr-record"))
                {
                    Query = boolQuery
                };
            }
            
            {
                var results = await _elasticSearchService.GetConnection().SearchAsync<Study>(searchRequest);
                var studies = _dataMapper.MapStudies(results.Documents.ToList());
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
            if (viaPublishedPaperRequest.Filters != null && HasProperty(viaPublishedPaperRequest, "Filters") && viaPublishedPaperRequest.Filters.Count > 0)
            {
                filters = viaPublishedPaperRequest.Filters!.Select(param => new RawQuery(JsonSerializer.Serialize(param))).Select(dummy => (QueryContainer)dummy).ToList();
            }
            
            var mustQuery = new List<QueryContainer>();
            
            if (viaPublishedPaperRequest.SearchType == "doi")
            {
                mustQuery.Add(new TermQuery()
                {
                    Field = Infer.Field<Study>(p => p.LinkedDataObjects.First().Doi),
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
                        Fields = Infer.Field<Study>(p => p.LinkedDataObjects.First().DisplayTitle),
                        DefaultOperator = Operator.And
                    },
                    new NestedQuery()
                    {
                        Path = Infer.Field<Study>(p => p.LinkedDataObjects.First().ObjectTitles),
                        Query = new SimpleQueryStringQuery()
                        {
                            Query = viaPublishedPaperRequest.SearchValue,
                            Fields = Infer.Field<Study>(p => p.LinkedDataObjects.First().ObjectTitles.First().TitleText),
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
            
            SearchRequest<Study> searchRequest;
            if (startFrom != null)
            {
                searchRequest = new SearchRequest<Study>(Indices.Index("mdr-record"))
                {
                    From = startFrom,
                    Size = viaPublishedPaperRequest.Size,
                    Query = boolQuery
                };
            }
            else
            {
                searchRequest = new SearchRequest<Study>(Indices.Index("mdr-record"))
                {
                    Query = boolQuery
                };
            }
            
            {
                var results = await _elasticSearchService.GetConnection().SearchAsync<Study>(searchRequest);
                var studies = _dataMapper.MapStudies(results.Documents.ToList());
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
                .Index("mdr-record")
                .From(0)
                .Size(1)
                .Query(q => q
                    .Term(t => t
                        .Field(p => p.Id)
                        .Value(studyIdRequest.StudyId.ToString())
                    )
                )
            );
            return _dataMapper.MapStudies(results.Documents.ToList());
        }
    }
}