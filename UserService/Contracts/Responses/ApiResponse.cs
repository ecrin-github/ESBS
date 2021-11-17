using System.Collections.Generic;

namespace UserService.Contracts.Responses
{
    public class ApiResponse<T>
    {
        public int Total { get; set; }
        public int? Size { get; set; }
        public int? Page { get; set; }
        public int StatusCode { get; set; }
        public IList<string> Messages { get; set; }
        public ICollection<T> Data { get; set; }
    }
}