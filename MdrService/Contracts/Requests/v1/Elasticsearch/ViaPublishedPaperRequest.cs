namespace MdrService.Contracts.Requests.v1.Elasticsearch
{
    public class ViaPublishedPaperRequest : BaseQueryRequest
    {
        public string SearchType { get; set; }
        public string SearchValue { get; set; }
    }
}