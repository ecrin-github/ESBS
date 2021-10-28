using System;
using LinqToDB.Mapping;

#nullable enable
namespace mdm_services.Models.Study
{
    [Table("study_relationships", Schema = "mdr")]
    public class StudyRelationship
    {
        [PrimaryKey, Identity]
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
    }
}