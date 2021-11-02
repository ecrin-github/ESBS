using System.Collections.Generic;
using MdrService.Models.Elasticsearch.Study;

namespace MdrService.Contracts.Responses.v1.FetchedData
{
    public class FetchedStudies
    {
        public long Total { get; set; }
        public ICollection<Study> Studies { get; set; }
    }
}