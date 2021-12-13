using System.Collections.Generic;

#nullable enable
namespace MdrService.Contracts.Requests.v1.Elasticsearch
{
    public class BaseQueryEsRequest
    {
        public int? Page { get; set; }
        public int? Size { get; set; }
        public ICollection<object>? Filters { get; set; }
    }
}