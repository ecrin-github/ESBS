namespace MdrService.Contracts.Responses.v1.ObjectListResponse
{
    #nullable enable
    public class ObjectRelationshipListResponse
    {
        public int? Id { get; set; }
        
        public string? RelationshipType { get; set; }
        
        public int? TargetObjectId { get; set; }
    }
}