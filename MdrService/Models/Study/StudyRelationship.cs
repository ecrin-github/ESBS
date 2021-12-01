using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdrService.Models.Study
{
    [Table("study_relationships", Schema = "core")]
    public class StudyRelationship
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("study_id")]
        public int StudyId { get; set; }
        
        [Column("relationship_type_id")]
        public int? RelationshipTypeId { get; set; }
        
        [Column("target_study_id")]
        public string? TargetStudyId { get; set; }
    }
}