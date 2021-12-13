namespace MdrService.Contracts.Responses.v1.ApiResponse.ObjectListResponse
{
    #nullable enable
    public class ObjectTitleListResponse
    {
        public int? Id { get; set; }
        
        public string? TitleType { get; set; }
        
        public string? TitleText { get; set; }
        
        public string? LangCode { get; set; }
        
        public string? Comments { get; set; }
    }
}