namespace MdrService.Contracts.Requests.v1.DbSearch
{
    public class ViaPublishedPaperDbRequest : BaseQueryDbRequest
    {
        public string SearchType { get; set; }
        public string SearchValue { get; set; }
    }
}