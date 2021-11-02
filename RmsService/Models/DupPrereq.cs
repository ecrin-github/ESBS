using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace RmsService.Models
{
    [Table("dup_prereqs", Schema = "rms")]
    public class DupPrereq
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("dup_id")]
        public int DupId { get; set; }
        
        [Column("object_id")]
        public string? ObjectId { get; set; }
        
        [Column("pre_requisite_id")]
        public int? PreRequisiteId { get; set; }
        
        [Column("prerequisite_met", TypeName = "Date")]
        public DateTime? PrerequisiteMet { get; set; }
        
        [Column("met_notes")]
        public string? MetNotes { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}