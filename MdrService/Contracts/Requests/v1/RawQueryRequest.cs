using System.Collections.Generic;

namespace MdrService.Contracts.Requests.v1
{
    public class RawQueryRequest : BaseQueryRequest
    {
        public IDictionary<string, object> Query { get; set; }
    }
}