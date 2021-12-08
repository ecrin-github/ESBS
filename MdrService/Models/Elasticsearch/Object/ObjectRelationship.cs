using MdrService.Models.Elasticsearch.Common;
using Nest;

#nullable enable
namespace MdrService.Models.Elasticsearch.Object
{
    public class ObjectRelationship
    {
        [Number(Name = "id")]
        public int? Id { get; set; }
        
        [Object]
        [PropertyName("relationship_type")]
        public RelationType? RelationshipType { get; set; }
        
        [Number(Name = "target_object_id")]
        public int? TargetObjectId { get; set; }
    }
}