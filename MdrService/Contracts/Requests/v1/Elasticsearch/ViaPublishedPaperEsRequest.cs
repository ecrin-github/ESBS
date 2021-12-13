namespace MdrService.Contracts.Requests.v1.Elasticsearch
{
    public class ViaPublishedPaperEsRequest : BaseQueryEsRequest
    {
        public string SearchType { get; set; }
        public string SearchValue { get; set; }
    }
}