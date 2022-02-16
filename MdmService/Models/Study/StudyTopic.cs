using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdmService.Models.Study
{
    [Table("study_topics", Schema = "mdr")]
    public class StudyTopic
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("sd_sid")]
        public string? SdSid { get; set; }
        
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

        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }

        [Column("last_edited_by")]
        public string? LastEditedBy {get; set;}
    }
}