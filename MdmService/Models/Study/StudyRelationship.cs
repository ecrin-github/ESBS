using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdmService.Models.Study
{
    [Table("study_relationships", Schema = "mdr")]
    public class StudyRelationship
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("sd_sid")]
        public string? SdSid { get; set; }
        
        [Column("relationship_type_id")]
        public int? RelationshipTypeId { get; set; }
        
        [Column("target_sd_sid")]
        public string? TargetSdSid { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }

        [Column("last_edited_by")]
        public string? LastEditedBy {get; set;}
    }
}