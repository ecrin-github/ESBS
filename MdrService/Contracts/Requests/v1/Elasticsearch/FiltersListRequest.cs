using System.Collections.Generic;

namespace MdrService.Contracts.Requests.v1.Elasticsearch
{
    public class FiltersListRequest
    {
        public ICollection<object> StudyFilters { get; set; }
        
        public ICollection<object> ObjectFilters { get; set; }
    }
}