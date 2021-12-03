using System.Collections.Generic;

namespace MdrService.Contracts.Responses.v1.SearchServiceResponse
{
    public class RawSqlSearchServiceResponse
    {
        public long Total { get; set; }
        public ICollection<int> StudyIds { get; set; }
    }
}