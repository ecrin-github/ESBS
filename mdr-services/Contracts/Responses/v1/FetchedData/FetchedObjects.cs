using System.Collections.Generic;
using mdr_services.Models.Elasticsearch.Object;

namespace mdr_services.Contracts.Responses.v1.FetchedData
{
    public class FetchedObjects
    {
        public long Total { get; set; }
        public ICollection<Object> Objects { get; set; }
    }
}