using mdr_services.Models.Elasticsearch.Common;
using Nest;

namespace mdr_services.Models.Elasticsearch.Study
{
    public class StudyRelation
    {
        [Number(Name = "id")]
        #nullable enable
        public int? Id { get; set; }
        
        [Object]
        [PropertyName("relationship_type")]
        #nullable enable
        public RelationType? RelationshipType { get; set; }
        
        [Number(Name = "target_study_id")]
        #nullable enable
        public int? TargetStudyId { get; set; }
    }
}