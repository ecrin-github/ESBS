using System;
using LinqToDB.Mapping;

#nullable enable
namespace rms_services.Models
{
    [Table("access_prereqs", Schema = "rms")]
    public class AccessPrereq
    {
        [PrimaryKey, Identity]
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