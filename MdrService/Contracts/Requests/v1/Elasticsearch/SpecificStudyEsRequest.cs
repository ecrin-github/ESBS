namespace MdrService.Contracts.Requests.v1.Elasticsearch
{
    public class SpecificStudyEsRequest : BaseQueryEsRequest
    {
        public int SearchType { get; set; }
        public string SearchValue { get; set; }
    }
}