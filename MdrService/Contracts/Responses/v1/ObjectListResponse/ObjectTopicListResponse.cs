#nullable enable
namespace MdrService.Contracts.Responses.v1.ObjectListResponse
{
    public class ObjectTopicListResponse
    {
        public int? Id { get; set; }
        
        public string? TopicType { get; set; }
        
        public bool? MeshCoded { get; set; }
        
        public string? MeshCode { get; set; }
        
        public string? MeshValue { get; set; }

        public string? OriginalValue { get; set; }
    }
}