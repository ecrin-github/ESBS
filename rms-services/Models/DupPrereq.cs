using System;
using LinqToDB;
using LinqToDB.Mapping;

#nullable enable
namespace rms_services.Models
{
    [Table("dup_prereqs", Schema = "rms")]
    public class DupPrereq
    {
        [PrimaryKey, Identity]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("dup_id")]
        public int DupId { get; set; }
        
        [Column("object_id")]
        public string? ObjectId { get; set; }
        
        [Column("pre_requisite_id")]
        public int? PreRequisiteId { get; set; }
        
        [Column("prerequisite_met", DataType = DataType.Date)]
        public DateTime? PrerequisiteMet { get; set; }
        
        [Column("met_notes")]
        public string? MetNotes { get; set; }
        
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}