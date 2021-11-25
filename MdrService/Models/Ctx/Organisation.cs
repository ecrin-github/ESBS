using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace MdrService.Models.Ctx
{
    [Table("organisations", Schema = "ctx")]
    public class Organisation
    {
        [Key]
        public int Id { get; set; }
        
        [Column("default_name")]
        public string? DefaultName { get; set; }
        
        [Column("ror_id")]
        public string? RorId { get; set; }
        
        [Column("display_suffix")]
        public string? DisplaySuffix { get; set; }
        
        [Column("scope_id")]
        public int? ScopeId { get; set; }
        
        [Column("scope_notes")]
        public string? ScopeNotes { get; set; }
        
        [Column("is_current")]
        public bool? IsCurrent { get; set; }
        
        [Column("year_established")]
        public int? YearEstablished { get; set; }
        
        [Column("year_ceased")]
        public int? YearCeased { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}