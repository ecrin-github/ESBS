#nullable enable
namespace mdr_services.Contracts.Responses.v1.StudyListResponse
{
    public class StudyRelationListResponse
    {
        public int? Id { get; set; }
        
        public string? RelationshipType { get; set; }
        
        public int? TargetStudyId { get; set; }
    }
}