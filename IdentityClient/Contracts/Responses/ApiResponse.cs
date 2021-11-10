using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityClient.Contracts.Responses
{
    public class ApiResponse<T>
    {
        public int Total { get; set; }
        public int? Size { get; set; }
        public int? Page { get; set; }
        public int StatusCode { get; set; }
        public IList<string> Messages { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}