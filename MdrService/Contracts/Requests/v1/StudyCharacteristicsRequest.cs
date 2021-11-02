#nullable enable
namespace MdrService.Contracts.Requests.v1
{
    public class StudyCharacteristicsRequest : BaseQueryRequest
    {
        public string? TitleContains { get; set; }

        public string? LogicalOperator { get; set; }

        public string? TopicsInclude { get; set; }
    }
}