using System.Collections.Generic;

namespace mdr_services.Contracts.Requests.v1
{
    public class RawQueryRequest : BaseQueryRequest
    {
        public IDictionary<string, object> Query { get; set; }
    }
}