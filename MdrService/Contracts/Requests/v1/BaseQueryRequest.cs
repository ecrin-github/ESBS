using System.Collections.Generic;

namespace MdrService.Contracts.Requests.v1
{
    public class BaseQueryRequest
    {
        #nullable enable
        public int? Page { get; set; }
        public int? Size { get; set; }
        
        public ICollection<object>? Filters { get; set; }
    }
}