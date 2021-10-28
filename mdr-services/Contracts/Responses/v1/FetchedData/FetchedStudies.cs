using System.Collections.Generic;
using mdr_services.Models.Elasticsearch.Study;

namespace mdr_services.Contracts.Responses.v1.FetchedData
{
    public class FetchedStudies
    {
        public long Total { get; set; }
        public ICollection<Study> Studies { get; set; }
    }
}