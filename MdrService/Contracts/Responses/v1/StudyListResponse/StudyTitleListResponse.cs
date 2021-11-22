namespace MdrService.Contracts.Responses.v1.StudyListResponse
{
    #nullable enable
    public class StudyTitleListResponse
    {
        public int? Id { get; set; }
        
        public string? TitleType { get; set; }
        
        public string? TitleText { get; set; }
        
        public string? LangCode { get; set; }
        
        public string? Comments { get; set; }
    }
}