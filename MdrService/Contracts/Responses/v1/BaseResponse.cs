using System.Collections.Generic;

namespace MdrService.Contracts.Responses.v1
{
    public class BaseResponse<T>
    {
        public int Total { get; set; }
        public int? Size { get; set; }
        public int? Page { get; set; }
        public int StatusCode { get; set; }
        public IList<string> Messages { get; set; }
        public ICollection<T> Data { get; set; }
    }
}