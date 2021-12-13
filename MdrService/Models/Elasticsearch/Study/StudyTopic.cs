using MdrService.Models.Elasticsearch.Common;
using Nest;

#nullable enable
namespace MdrService.Models.Elasticsearch.Study
{
    public class StudyTopic
    {
        [Number(Name = "id")]
        public int? Id { get; set; }
        
        [Object]
        [PropertyName("topic_type")]
        public TopicType? TopicType { get; set; }
        
        [Boolean(Name = "mesh_coded")]
        public bool? MeshCoded { get; set; }
        
        [Text(Name = "mesh_code")]
        public string? MeshCode { get; set; }

        [Text(Name = "mesh_value")]
        public string? MeshValue { get; set; }
        
        [Number(Name = "original_ct_id")]
        public int? OriginalCtId { get; set; }
        
        [Text(Name = "original_ct_code")]
        public string? OriginalCtCode { get; set; }

        [Text(Name = "original_value")]
        public string? OriginalValue { get; set; }
    }
}