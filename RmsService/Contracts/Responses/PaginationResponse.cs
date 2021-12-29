using System.Collections.Generic;

namespace RmsService.Contracts.Responses
{
    public class PaginationResponse<T>
    {
        public int Total { get; set; }
        public ICollection<T> Data { get; set; }
    }
}