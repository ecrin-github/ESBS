using System.Collections.Generic;

namespace MdrService.Contracts.Responses.v1.SearchServiceResponse
{
    public class SearchServiceResponse
    {
        public int Total { get; set; }
        public ICollection<int> StudyIds { get; set; }
    }
}