namespace MdrService.Contracts.Responses.v1.StudyListResponse
{
    #nullable enable
    public class StudyRelationListResponse
    {
        public int? Id { get; set; }
        
        public string? RelationshipType { get; set; }
        
        public int? TargetStudyId { get; set; }
    }
}