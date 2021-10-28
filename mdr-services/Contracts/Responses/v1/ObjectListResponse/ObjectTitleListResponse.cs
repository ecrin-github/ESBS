#nullable enable
namespace mdr_services.Contracts.Responses.v1.ObjectListResponse
{
    public class ObjectTitleListResponse
    {
        public int? Id { get; set; }
        
        public string? TitleType { get; set; }
        
        public string? TitleText { get; set; }
        
        public string? LangCode { get; set; }
        
        public string? Comments { get; set; }
    }
}