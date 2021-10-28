namespace mdr_services.Contracts.Requests.v1
{
    public class BaseQueryRequest
    {
        #nullable enable
        public int? Page { get; set; }
        public int? Size { get; set; }
        
        public FiltersListRequest? Filters { get; set; }
    }
}