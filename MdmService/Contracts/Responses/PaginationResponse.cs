using System.Collections.Generic;

namespace MdmService.Contracts.Responses
{
    public class PaginationResponse<T>
    {
        public int Total { get; set; }
        public ICollection<T> Data { get; set; }
    }
}