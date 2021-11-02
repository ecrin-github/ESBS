using MdrService.Models.Elasticsearch.Common;
using Nest;

namespace MdrService.Models.Elasticsearch.Object
{
    public class ObjectRelationship
    {
        [Number(Name = "id")]
        #nullable enable
        public int? Id { get; set; }
        
        [Object]
        [PropertyName("relationship_type")]
        #nullable enable
        public RelationType? RelationshipType { get; set; }
        
        [Number(Name = "target_object_id")]
        #nullable enable
        public int? TargetObjectId { get; set; }
    }
}