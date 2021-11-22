using MdrService.Contracts.Responses.v1.Common;

namespace MdrService.Contracts.Responses.v1.StudyListResponse
{
    #nullable enable
    public class StudyIdentifierListResponse
    {
        public int? Id { get; set; }
        
        public string? IdentifierValue { get; set; }
        
        public string? IdentifierType { get; set; }
        
        public string? IdentifierDate { get; set; }
        
        public string? IdentifierLink { get; set; }
        
        public IdentifierOrg? IdentifierOrg { get; set; }
    }
}