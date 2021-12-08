namespace MdrService.Contracts.Requests.v1.Elasticsearch
{
    public class BaseQueryRequest
    {
        #nullable enable
        public int? Page { get; set; }
        public int? Size { get; set; }
        
        public FiltersListRequest? Filters { get; set; }
    }
}