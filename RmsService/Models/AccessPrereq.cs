using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable
namespace RmsService.Models
{
    [Table("access_prereqs", Schema = "rms")]
    public class AccessPrereq
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("object_id")]
        public int? ObjectId { get; set; }
        
        [Column("pre_requisite_id")]
        public int? PreRequisiteId { get; set; }
        
        [Column("pre_requisite_notes")]
        public string? PreRequisiteNotes { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}