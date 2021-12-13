namespace MdrService.Contracts.Requests.v1.DbSearch
{
    public class BaseQueryDbRequest
    {
        #nullable enable
        public int Page { get; set; }
        public int Size { get; set; }
        public FiltersDbRequest? Filters { get; set; }
    }
}