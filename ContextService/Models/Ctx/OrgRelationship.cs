using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace ContextService.Models.Ctx
{
    [Table("org_relationships", Schema = "ctx")]
    public class OrgRelationship
    {
        [Key]
        public int Id { get; set; }
        
        [Column("org_id")]
        public int OrgId { get; set; }
        
        [Column("default_name")]
        public string? DefaultName { get; set; }
        
        [Column("relationship_type_id")]
        public int RelationshipTypeId { get; set; }
        
        [Column("target_org_id")]
        public int TargetOrgId { get; set; }
        
        [Column("target_default_name")]
        public string? TargetDefaultName { get; set; }
        
        [Column("is_current")]
        public bool IsCurrent { get; set; }
        
        [Column("year_established")]
        public int YearEstablished { get; set; }
        
        [Column("year_ceased")]
        public int YearCeased { get; set; }
        
        [Column("notes")]
        public string? Notes { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}