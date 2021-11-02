namespace MdrService.Contracts.Requests.v1
{
    public class ViaPublishedPaperRequest : BaseQueryRequest
    {
        public string SearchType { get; set; }
        public string SearchValue { get; set; }
    }
}