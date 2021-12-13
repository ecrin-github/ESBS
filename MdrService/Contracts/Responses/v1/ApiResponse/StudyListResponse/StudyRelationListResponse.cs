namespace MdrService.Contracts.Responses.v1.ApiResponse.StudyListResponse
{
    #nullable enable
    public class StudyRelationListResponse
    {
        public int? Id { get; set; }
        
        public string? RelationshipType { get; set; }
        
        public string? TargetStudyId { get; set; }
    }
}