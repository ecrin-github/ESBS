using System.Collections.Generic;
using MdrService.Contracts.Responses.v1.ApiResponse.StudyListResponse;

namespace MdrService.Contracts.Responses.v1.SearchResponse
{
    public class ElasticsearchServiceResponse
    {
        public int Total { get; set; }
        public ICollection<StudyListResponse> Studies { get; set; }
    }
}