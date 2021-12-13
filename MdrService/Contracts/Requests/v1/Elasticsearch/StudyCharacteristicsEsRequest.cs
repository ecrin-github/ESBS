#nullable enable
namespace MdrService.Contracts.Requests.v1.Elasticsearch
{
    public class StudyCharacteristicsEsRequest : BaseQueryEsRequest
    {
        public string? TitleContains { get; set; }
        public string? LogicalOperator { get; set; }
        public string? TopicsInclude { get; set; }
    }
}