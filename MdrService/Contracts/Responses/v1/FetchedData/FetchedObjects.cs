using System.Collections.Generic;
using MdrService.Models.Elasticsearch.Object;

namespace MdrService.Contracts.Responses.v1.FetchedData
{
    public class FetchedObjects
    {
        public long Total { get; set; }
        public ICollection<Object> Objects { get; set; }
    }
}