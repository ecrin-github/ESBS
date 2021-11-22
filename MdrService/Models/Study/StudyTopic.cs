using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdrService.Models.Study
{
    [Table("study_topics", Schema = "core")]
    public class StudyTopic
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("study_id")]
        public int StudyId { get; set; }
        
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