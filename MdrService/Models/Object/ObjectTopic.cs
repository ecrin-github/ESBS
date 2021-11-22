using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdrService.Models.Object
{
    [Table("object_topics", Schema = "core")]
    public class ObjectTopic
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("object_id")]
        public int ObjectId { get; set; }
        
        [Column("topic_type_id")]
        public int? TopicTypeId { get; set; }
        
        [Column("mesh_coded")]
        public bool? MeshCoded { get; set; }
        
        [Column("mesh_code")]
        public string? MeshCode { get; set; }
        
        [Column("mesh_value")]
        public string? MeshValue { get; set; }

        [Column("original_ct_id")]
        public int? OriginalCtId { get; set; }
        
        [Column("original_ct_code")]
        public string? OriginalCtCode { get; set; }
        
        [Column("original_value")]
        public string? OriginalValue { get; set; }
    }
}