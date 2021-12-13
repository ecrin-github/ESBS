#nullable enable
namespace MdrService.Contracts.Requests.v1.DbSearch
{
    public class StudyCharacteristicsDbRequest : BaseQueryDbRequest
    {
        public string? TitleContains { get; set; }

        public string? LogicalOperator { get; set; }

        public string? TopicsInclude { get; set; }
    }
}